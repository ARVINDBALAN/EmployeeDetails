﻿using System;
using Entities.EmployeeEntities;
using DataAccessLayer.DataAccessService;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class ButtonEvents
    {
        #region Object Call
        CallMethods objConsume = new CallMethods();
        #endregion


        #region Get All Employees Call Method
        public async Task<List<Employee>> GetAllDetails()
        {
            List<Employee> lstAllEmp = new List<Employee>();

            try
            {
                lstAllEmp = await objConsume.GetEmployeeDetails();
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
                lstEmp = await objConsume.GetEmployeeById(Id);
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
                objConsume.UpdateEmployee(emp);
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region Delete method to call service

        #endregion

    }
}