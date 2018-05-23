using System;
using System.ServiceModel;
using System.Data;
using System.IO;
using System.Xml;
using System.Collections;
using MemoryData;

namespace Starts_Service
{
    public partial interface IAppService
    {
        [OperationContract()]
        byte[] GetVersionInfo();

        [OperationContract()]
        string GetUpdateList();

        [OperationContract()]
        byte[] GetFile(string filename);

    }


    public partial class AppService : IAppService
    {
        string AppPath()
        {
            return ConfigInfo.UpdatePath;
        }

        const string DatetimeFormat = "dd/MM/yyyy HH:mm:ss";

        public byte[] GetVersionInfo()
        {
            try
            {
                return GetFile("version.xml");
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public string GetUpdateList()
        {
            try
            {
                XmlElement _oElmntRoot;
                _oElmntRoot = c_xmlDoc.CreateElement("update");

                c_xmlDoc.RemoveAll(); //Clears the xmlDoc for multiple process, because xmlDoc is a class level object
                c_xmlDoc.AppendChild(c_xmlDoc.CreateProcessingInstruction("xml", "version='1.0' encoding='UTF-8'"));//First Chid: Header

                //Second Child: update
                c_xmlDoc.AppendChild(_oElmntRoot);
                //Add the element to the xml document

                string v_SubFolder = "";

                loopNodes(_oElmntRoot, AppPath(), v_SubFolder);
                //
                return c_xmlDoc.InnerXml;
                //

            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return "";
            }
        }

        public byte[] GetFile(string filename)
        {
            try
            {
                // nếu ko có thì tạo mới ổ đó
                if (!Directory.Exists(AppPath()))
                {
                    Directory.CreateDirectory(AppPath());
                }

                string filepath = System.IO.Path.Combine(AppPath(), filename);
                FileInfo _FileInfo = new FileInfo(filepath);

                if (_FileInfo.Exists == false)
                {
                    return new byte[0];
                }

                BinaryReader binReader = new BinaryReader(File.Open(filepath, FileMode.Open, FileAccess.Read));
                binReader.BaseStream.Position = 0;
                byte[] binFile = binReader.ReadBytes(Convert.ToInt32(binReader.BaseStream.Length));
                binReader.Close();
                return binFile;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        #region private
        XmlDocument c_xmlDoc = new XmlDocument();

        private void loopNodes(XmlElement oElmntParent, string strRootPath, string strSubFolder)
        {
            try
            {
                DirectoryInfo ofs = new DirectoryInfo(System.IO.Path.Combine(strRootPath, strSubFolder));
                foreach (FileInfo oFile in ofs.GetFiles())
                {
                    string v_strFileName = oFile.Name;


                    XmlElement oElmntLeaf1 = default(XmlElement);
                    //Manipulates the files nodes
                    XmlElement oElmntFileName = default(XmlElement);
                    XmlElement oElmntFilPath = default(XmlElement);
                    XmlElement oElmntFileVersion = default(XmlElement);
                    XmlElement oElmntFileModified = default(XmlElement);

                    oElmntLeaf1 = c_xmlDoc.CreateElement("name");
                    oElmntParent.AppendChild(oElmntLeaf1);

                    oElmntFileName = c_xmlDoc.CreateElement("filename");
                    oElmntFileName.InnerText = v_strFileName;
                    oElmntLeaf1.AppendChild(oElmntFileName);

                    oElmntFilPath = c_xmlDoc.CreateElement("filepath");
                    oElmntFilPath.InnerText = strSubFolder;
                    oElmntLeaf1.AppendChild(oElmntFilPath);

                    System.Diagnostics.FileVersionInfo fv = System.Diagnostics.FileVersionInfo.GetVersionInfo(oFile.FullName);
                    oElmntFileVersion = c_xmlDoc.CreateElement("fileversion");
                    oElmntFileVersion.InnerText = fv.FileVersion;
                    oElmntLeaf1.AppendChild(oElmntFileVersion);

                    oElmntFileModified = c_xmlDoc.CreateElement("filelastmodified");
                    oElmntFileModified.InnerText = oFile.LastWriteTimeUtc.ToString(DatetimeFormat);
                    oElmntLeaf1.AppendChild(oElmntFileModified);
                }

                foreach (DirectoryInfo oDic in ofs.GetDirectories())
                {
                    loopNodes(oElmntParent, strRootPath, System.IO.Path.Combine(strSubFolder, oDic.Name));
                }
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        #endregion
    }
}
