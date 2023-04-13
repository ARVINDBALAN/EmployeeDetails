using System;
using System.Collections.Generic;
using System.Text;
using EmployeeDetails.DataAccessAPI;
using EmployeeDetails.Entities;
using System.Threading.Tasks;
using System.Windows;

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
                MessageBox.Show("An unhandled exception just occurred: " + ex.InnerException.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("An unhandled exception just occurred: " + ex.InnerException.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("An unhandled exception just occurred: " + ex.InnerException.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
