using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer
{
  public class ComboBoxvalues
    {
        public List<string> Gender { get; set; }
        public List<string> EmployeeStatus { get; set; }

        public ComboBoxvalues()
        {
            Gender = new List<string>()
            {
                "male",
                "female"
            };

            EmployeeStatus = new List<string>()
            {
                "active",
                "inactive"
            };

        }

    }
}
