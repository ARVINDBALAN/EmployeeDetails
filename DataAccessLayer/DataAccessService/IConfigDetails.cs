using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DataAccessService
{
    interface IConfigDetails
    {
        string IBaseAddress();
        string IAccessToken();
        string IEndPoints();
    }
}
