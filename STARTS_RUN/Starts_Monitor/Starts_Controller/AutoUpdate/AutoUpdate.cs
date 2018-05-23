using System;
using System.Xml;
using System.Collections;
using System.IO;
using MemoryData;

namespace Starts_Controller.AutoUpdate
{
    public class VersionInfo
    {
        private string _AppName;
        private string _Version;
        private string _Description;

        public VersionInfo()
        {
            _Version = "0.0.0.0";
            _Description = "";
            _AppName = "";
        }

        public string AppName
        {
            get { return _AppName; }
            set { _AppName = value; }
        }

        public string Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
    }

    /// <summary>
    /// Thong tin ve cac file 
    /// </summary>
    public class UpdateFileInfo
    {
        string _filename;
        string _filepath;
        string _fileversion;
        string _filelastmodified;

        public string filename
        {
            get { return _filename; }
            set { _filename = value; }
        }

        public string filepath
        {
            get { return _filepath; }
            set { _filepath = value; }
        }

        public string fileversion
        {
            get { return _fileversion; }
            set { _fileversion = value; }
        }

        public string filelastmodified
        {
            get { return _filelastmodified; }
            set { _filelastmodified = value; }
        }
    }

    public class Controller
    {
        private string DatetimeFormat = "dd/MM/yyyy HH:mm:ss";
        private System.Globalization.CultureInfo CULTURE_PROVIDER = new System.Globalization.CultureInfo("en-US");
        //Lấy thông tin phiên bản mới nhất trên máy chủ
        public VersionInfo GetNewnestVersion()
        {
            try
            {
                //doc tu wcf

                byte[] byteRecive = CommonData.c_serviceWCF.GetVersionInfo();
                if (byteRecive != null && byteRecive.Length>0)
                {
                    var stream = new MemoryStream(byteRecive);
                    XmlDocument _xdoc = new XmlDocument();
                    _xdoc.Load(stream);
                    //
                    VersionInfo _VersionInfo = new VersionInfo();

                    XmlNode _appNameNode = _xdoc.SelectSingleNode("versions/appname");
                    if (_appNameNode != null) _VersionInfo.AppName = _appNameNode.InnerText;
                    XmlNode _versionNode = _xdoc.SelectSingleNode("versions/version");
                    if (_versionNode != null) _VersionInfo.Version = _versionNode.InnerText;
                    XmlNode _desNode = _xdoc.SelectSingleNode("versions/description");
                    if (_desNode != null) _VersionInfo.Description = _desNode.InnerText;

                    return _VersionInfo;
                }
                else
                    return new VersionInfo();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new VersionInfo();
            }
        }

        //Lấy thông tin về phiên bản cua chương trình trên máy local
        public VersionInfo GetLocalVersion()
        {
            try
            {
                VersionInfo _VersionInfo = new VersionInfo();
                string _vesionfile = System.IO.Path.Combine(Environment.CurrentDirectory, "version.xml");
                if (System.IO.File.Exists(_vesionfile))
                {
                    XmlDocument _xdoc = new XmlDocument();
                    _xdoc.Load(_vesionfile);

                    XmlNode _appNameNode = _xdoc.SelectSingleNode("versions/appname");
                    if (_appNameNode != null) _VersionInfo.AppName = _appNameNode.InnerText;
                    XmlNode _versionNode = _xdoc.SelectSingleNode("versions/version");
                    if (_versionNode != null) _VersionInfo.Version = _versionNode.InnerText;
                    XmlNode _desNode = _xdoc.SelectSingleNode("versions/description");
                    if (_desNode != null) _VersionInfo.Description = _desNode.InnerText;
                }
                return _VersionInfo;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new VersionInfo();
            }
        }

        //Down load các file cần update về thư mục tạm trên máy local
        public bool DownloadUpdateFile()
        {
            try
            {
                //Lấy thông tin về các file trên máy chủ
                ArrayList _ServerList = GetServerList();
                //So sánh vời file tren máy local để lấy file cần update
                ArrayList _UpdateList = GetNeedFile(_ServerList);


                //xoa het file trong thu muc temp truoc khi lay du lieu moi
                string _tempPath = System.IO.Path.Combine(Environment.CurrentDirectory, "$$temp");
                DirectoryInfo _DirectoryInfo = new DirectoryInfo(_tempPath);
                if (System.IO.Directory.Exists(_tempPath) == true)
                {
                    System.IO.Directory.Delete(_tempPath, true);
                }


                string _dPath = _tempPath;
                string _sFileName = "";
                foreach (UpdateFileInfo _UpdateFileInfo in _UpdateList)
                {
                    if (_UpdateFileInfo.filepath.Length > 0)
                    {
                        // _sFileName = _UpdateFileInfo.filepath + "\\" + _UpdateFileInfo.filename;
                        _sFileName = System.IO.Path.Combine(_UpdateFileInfo.filepath, _UpdateFileInfo.filename);
                    }
                    else
                    {
                        _sFileName = _UpdateFileInfo.filename;
                    }

                    if (SaveFilefromWCF(_tempPath, _sFileName) == false) return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        //Lấy thông tin về các file trên thư mục máy chủ
        private ArrayList GetServerList()
        {
            try
            {
                ArrayList _arr = new ArrayList();
                string returnStr;
                returnStr = CommonData.c_serviceWCF.GetUpdateList();

                if (returnStr.Length > 0)
                {
                    XmlDocument _xdoc = new XmlDocument();
                    _xdoc.LoadXml(returnStr);

                    XmlNodeList _nodeList = _xdoc.SelectNodes("update/name");
                    foreach (XmlNode _node in _nodeList)
                    {
                        UpdateFileInfo _UpdateFileInfo = new UpdateFileInfo();

                        _UpdateFileInfo.filename = _node.ChildNodes[0].InnerText;
                        _UpdateFileInfo.filepath = _node.ChildNodes[1].InnerText;
                        _UpdateFileInfo.fileversion = _node.ChildNodes[2].InnerText;
                        _UpdateFileInfo.filelastmodified = _node.ChildNodes[3].InnerText;

                        _arr.Add(_UpdateFileInfo);
                    }
                }
                return _arr;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new ArrayList();
            }
        }

        //Lay danh sanh các file cần phải download sau khi so sánh danh sách server với các file hiện tại trên local
        private ArrayList GetNeedFile(ArrayList p_ServerFile)
        {
            try
            {
                ArrayList _arr = new ArrayList();
                FileInfo _localfile;
                string _localfilepath = "";
                foreach (UpdateFileInfo _serverfile in p_ServerFile)
                {
                    if (_serverfile.filename == "version.xml")
                    {
                        _arr.Add(_serverfile);
                    }
                    else
                    {
                        _localfilepath = System.IO.Path.Combine(Environment.CurrentDirectory, _serverfile.filepath, _serverfile.filename);
                        _localfile = new FileInfo(_localfilepath);
                        if (_localfile.Exists)
                        {
                            DateTime _servertime = DateTime.ParseExact(_serverfile.filelastmodified, DatetimeFormat, CULTURE_PROVIDER);
                            DateTime _localtime = _localfile.LastWriteTimeUtc;
                            if (_servertime >= _localtime)
                            {
                                _arr.Add(_serverfile);
                            }
                            else
                            {
                                System.Diagnostics.FileVersionInfo fv = System.Diagnostics.FileVersionInfo.GetVersionInfo(_localfilepath);
                                if (fv.FileVersion != null && _serverfile.fileversion != "" && _serverfile.fileversion != fv.FileVersion) _arr.Add(_serverfile);
                            }
                        }
                        else
                        {
                            _arr.Add(_serverfile);
                        }
                    }
                }
                return _arr;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new ArrayList();
            }
        }

        private string ParseVersion(string p_Version)
        {
            string[] s = p_Version.Split('.');

            return String.Format("{0:00000}{1:00000}{2:00000}{3:00000}", int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]), int.Parse(s[3]));
        }

        private bool SaveFilefromWCF(string p_dPath, string p_sFileName)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.GetFile(p_sFileName);
                if (byteRecive == null || byteRecive.Length <= 0) return false; ///khong co du lieu


                FileInfo _FileInfo = new FileInfo(System.IO.Path.Combine(p_dPath, p_sFileName));
                //thu muc dich chua co thi tao moi
                if (_FileInfo.Directory.Exists == false) _FileInfo.Directory.Create();
                //File da co thi xoa di
                if (_FileInfo.Exists == true) _FileInfo.Delete();

                // Create a new stream to write to the file

                BinaryWriter Writer = new BinaryWriter(File.Create(System.IO.Path.Combine(p_dPath, p_sFileName)));

                // Writer raw data                
                Writer.Write(byteRecive);
                Writer.Flush();
                Writer.Close();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }

            return true;
        }
    }
}
