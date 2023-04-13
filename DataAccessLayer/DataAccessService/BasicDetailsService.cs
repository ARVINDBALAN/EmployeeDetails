using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer;

namespace DataAccessLayer.DataAccessService
{
   public class BasicDetailsService : IConfigDetails
    {
        #region Object call
        Common objcom = new Common();
        #endregion

        #region Variable Declaration
        string BaseAddress = string.Empty;
        string AccessToken = string.Empty;
        string EndPoint = string.Empty;
        #endregion

        #region Access Token
       public string IAccessToken()
        {
            try
            {
                AccessToken = objcom.GetFilePath("accesstoken").ToString();
            }

            catch (Exception ex)
            {
                throw (ex);

            }
            return AccessToken;
        }
        #endregion

        #region Base address
        public string IBaseAddress()
        {
            try
            {
                BaseAddress = objcom.GetFilePath("BaseAddress").ToString();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            return BaseAddress;
        }
        #endregion

        #region End Point
        public string IEndPoints()
        {
            try
            {
                EndPoint = objcom.GetFilePath("endpoints").ToString();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            return EndPoint;
        }
        #endregion
    }
}
