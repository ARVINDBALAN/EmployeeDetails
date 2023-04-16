using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer
{
    public class BasicDetailsService
    {
        #region Object call
        Common objcom = new Common();
        #endregion

        #region Variable Declaration
        string baseAddress = string.Empty;
        string accessToken = string.Empty;
        string endPoint = string.Empty;
        #endregion

        #region Access Token
        public string IAccessToken()
        {
            try
            {
                accessToken = objcom.GetFilePath("accesstoken").ToString();
            }

            catch (Exception ex)
            {
                throw (ex);

            }
            return accessToken;
        }
        #endregion

        #region Base address
        public string IBaseAddress()
        {
            try
            {
                baseAddress = objcom.GetFilePath("BaseAddress").ToString();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            return baseAddress;
        }
        #endregion

        #region End Point
        public string IEndPoints()
        {
            try
            {
                endPoint = objcom.GetFilePath("endpoints").ToString();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            return endPoint;
        }
        #endregion
    }

}
