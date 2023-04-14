using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace CommonLayer
{
    public class Common : ICommonAction, IDisposable
    {
        #region Get details from XML file
        public string GetFilePath(string sFilePath)
        {
            string folderPath = "";
            try
            {
                XmlDocument oXML = new XmlDocument();
                XmlNode oNode;
                oXML.Load("..\\..\\..\\Settings.xml");
                oNode = oXML.SelectSingleNode("//ApiBasicCredential/" + sFilePath);
                if (oNode != null)
                    folderPath = oNode.InnerXml;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return folderPath;
        }
        #endregion

        #region Dispose the data
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
        public string IGetFilePath(string sFilePath)
        {
            string folderPath = "";
            try
            {
                XmlDocument oXML = new XmlDocument();
                XmlNode oNode;
                oXML.Load("..\\..\\..\\Settings.xml");
                oNode = oXML.SelectSingleNode("//ApiBasicCredential/" + sFilePath);
                if (oNode != null)
                    folderPath = oNode.InnerXml;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return folderPath;
        }
       
    }
}
