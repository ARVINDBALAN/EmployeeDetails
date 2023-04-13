using System;
using System.Collections.Generic;
using System.Text;
using EmployeeDetails.DataAccessAPI;
using EmployeeDetails.Entities;
using System.Threading.Tasks;

namespace EmployeeDetails.BusinessModels
{
    class ButtonActionEvents
    {
        #region Object Call
        RestApiConsume objSeriveCall = new RestApiConsume();

        #endregion

        #region Get All Employees Call Method
        public async Task<List<Employee>> GetAllDetails()
        {
            List<Employee> lstAllEmp = new List<Employee>();

            try
            {
                lstAllEmp = await objSeriveCall.GetEmployeeDetails();
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            return lstAllEmp;

        }
        #endregion

        #region Get Single Employee Method
        public async Task<List<Employee>> GetById(int Id)
        {
            List<Employee> lstEmp = new List<Employee>();

            try
            {
                lstEmp = await objSeriveCall.GetEmployeeById(Id);
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            return lstEmp;

        }
        #endregion

        #region Call Update Service EndPoint
        public void UpdateDetails(Employee emp)
        {
            try
            {
                objSeriveCall.UpdateEmployee(emp);
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
    }
}
