using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer
{
   public interface ICommonAction
    {
        //interface method to get the file path
        string IBaseAddress();
        string IAccessToken();
        string IEndPoints();
    }

    public interface ICommonMethods
    {
        string Getpath();
    }

}
