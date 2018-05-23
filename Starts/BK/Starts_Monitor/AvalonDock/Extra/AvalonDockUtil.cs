// Project: HNXIndex-Monitor
// Author : Nguyen Nhat Linh – Navisoft.
// Summary: Các hàm chuyển đổi để hỗ trợ thêm
// Modification Logs:
// DATE             AUTHOR      DESCRIPTION
// --------------------------------------------------------
// Dec 22, 2011  	LinhNN     Created


using System;
using System.Collections;
using System.Xml;

namespace AvalonDock
{
    public class AvalonDockUtil
    {
        /// <summary>
        /// Lấy document của DockingManager theo tên từ layout tổng thể
        /// </summary>
        /// <param name="p_xmlString"></param>
        /// <param name="p_DockManagerName"></param>
        /// <returns></returns>
        public static XmlDocument GetDocManagerbyName(string p_xmlString, string p_DockManagerName)
        {
            try
            {
                XmlDocument _xdoc = new XmlDocument();
                XmlDocument _xdocResult = new XmlDocument();
                _xdoc.LoadXml(p_xmlString);

                foreach (XmlNode _node in _xdoc.DocumentElement.ChildNodes)
                {
                    if (_node.Attributes["name"] != null && _node.Name == "DockingManager" && _node.Attributes["name"].Value == p_DockManagerName)
                        _xdocResult.AppendChild(_xdocResult.ImportNode(_node, true));
                }

                return _xdocResult;
            }
            catch
            {
                return new XmlDocument();
            }
        }

        /// <summary>
        /// Tạo XMLDocument cho layout tổng thể 
        /// </summary>
        /// <returns></returns>
        public static XmlDocument CreateMainDoc()
        {
            try
            {
                string xmlContent = "<layout></layout>";
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlContent);

                return doc;
            }
            catch
            {
                return new XmlDocument();
            }
        }

        /// <summary>
        /// Import layout của 1 DockingManager vào layout tổng thể
        /// </summary>
        /// <param name="_mainDock"></param>
        /// <param name="p_SubDockXML"></param>
        public static void ImportToMainDoc(ref XmlDocument _mainDock, string p_SubDockXML)
        {
            try
            {
                XmlDocument _subdoc = new XmlDocument();
                _subdoc.LoadXml(p_SubDockXML);
                //
                _mainDock.DocumentElement.AppendChild(_mainDock.ImportNode(_subdoc.DocumentElement, true));
            }
            catch
            {
            }
        }

        /// <summary>
        /// Lấy tất cả các content (DockableContent, DocumentContent)có trong 1 node (không lấy trong hiden)
        /// </summary>
        /// <param name="p_allContent"></param>
        /// <param name="p_xNode"></param>
        public static void GetAllContent(ref ArrayList p_allContent, XmlNode p_xNode)
        {
            try
            {
                foreach (XmlNode _xnode in p_xNode)
                {
                    if (_xnode.Name == "DockableContent" || _xnode.Name == "DocumentContent")
                    {
                        if (_xnode.Attributes["Name"] != null)
                        {
                            string ContentName = _xnode.Attributes["Name"].Value;
                            p_allContent.Add(ContentName);
                        }
                    }
                    else if (_xnode.Name != "Hidden")
                    {
                        GetAllContent(ref p_allContent, _xnode);
                    }
                }
            }
            catch
            {

            }
        }

    }
}
