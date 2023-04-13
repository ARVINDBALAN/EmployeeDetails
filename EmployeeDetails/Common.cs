using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EmployeeDetails
{
    class Common : IDisposable
    {
        public string GetFilePath(string sFilePath)
        {
            string folderPath = "";
            try
            {
                XmlDocument oXML = new XmlDocument();
                XmlNode oNode;
                oXML.Load("..\\..\\Setting.xml");
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


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public string RegexEmailCheck()
        {
            string pattern = @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";

            return pattern;
        }
    }
}
