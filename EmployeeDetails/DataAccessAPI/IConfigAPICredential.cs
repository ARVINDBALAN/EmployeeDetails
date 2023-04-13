using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetails.DataAccessAPI
{
    interface IConfigAPICredential
    {
        string IBaseAddress();
        string IAccessToken();
        string IEndPoints();
    }
}
