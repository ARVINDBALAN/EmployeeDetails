using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CommonLayer;
using Entities.EmployeeEntities;

namespace BusinessLayer
{
    public class ButtonEvents
    {
        //Dependency Object call using Interface

        public ICallMethods callMethods;

        #region Constructor Dependency call
        public ButtonEvents(ICallMethods callmethod)
        {
            this.callMethods = callmethod;
        }
        #endregion

        #region Get All Employees Call Method
        public async Task<List<Employee>> SelectAllDetails()
        {
            List<Employee> lstAllEmp = new List<Employee>();

            try
            {
                lstAllEmp = await this.callMethods.GetAllDetails();
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
                lstEmp = await this.callMethods.GetOneRecordByID(Id);
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            return lstEmp;

        }
        #endregion

        #region Create save new record
        public void SaveDetails(Employee emp)
        {
            try
            {
                callMethods.InsertNewDetail(emp);
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region Call Update Service EndPoint
        public void UpdateDetails(Employee emp)
        {
            try
            {
                callMethods.UpdateExistingRecord(emp);
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region Delete method to call service
        public void DeleteDetails(int id)
        {
            try
            {
                callMethods.DeleteExistingRecord(id);
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
    }
}
