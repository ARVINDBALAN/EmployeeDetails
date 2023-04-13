using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace EmployeeDetails.DataAccessAPI
{
    class GetApiConfigDetails : IConfigAPICredential
    {
        #region Object call
        Common objcom = new Common();
        #endregion

        #region Variable Declaration
        string strAddress = string.Empty;
        string strToken = string.Empty;
        string strEndpoint = string.Empty;
        #endregion

        #region Access Token
        public string IAccessToken()
        {
            try
            {
                strAddress = objcom.GetFilePath("accesstoken").ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show("An unhandled exception just occurred: " + ex.InnerException.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            return strAddress;

        }
        #endregion

        #region Base address
        public string IBaseAddress()
        {
            try
            {
                strAddress = objcom.GetFilePath("BaseAddress").ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show("An unhandled exception just occurred: " + ex.InnerException.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return strAddress;
        }
        #endregion

        #region End Point
        public string IEndPoints()
        {
            try
            {
                strAddress = objcom.GetFilePath("endpoints").ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show("An unhandled exception just occurred: " + ex.InnerException.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return strAddress;
        }
        #endregion
    }
}
