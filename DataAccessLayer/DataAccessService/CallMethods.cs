using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Entities;
using System.Threading.Tasks;
using Entities.EmployeeEntities;
using Newtonsoft.Json;

namespace DataAccessLayer.DataAccessService
{
    public class CallMethods
    {
        #region Decalre Objects
        HttpClient postclient = new HttpClient();
        Entities.EmployeeEntities.Employee emp = new Entities.EmployeeEntities.Employee();
        BasicDetailsService ObjBServiceDetails = new BasicDetailsService();
        #endregion

        #region Decalre variables
        string Accesstoken = string.Empty;
        string Baseaddress = string.Empty;
        string Endpoints = string.Empty;
        #endregion

        #region Constructor
        public CallMethods()
        {
            InitiateValue();
            postclient.BaseAddress = new Uri(Baseaddress);
            postclient.DefaultRequestHeaders.Accept.Clear();
            postclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            postclient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Accesstoken);
        }
        #endregion

        #region Initiate values for endpoint
        public void InitiateValue()
        {
            try
            {
                Baseaddress = ObjBServiceDetails.IBaseAddress();
                Accesstoken = ObjBServiceDetails.IAccessToken();
                Endpoints = ObjBServiceDetails.IEndPoints();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region Get all the Employees
        public async Task<List<Employee>> GetEmployeeDetails()
        {
            List<Employee> lstEmp = new List<Employee>();

            try
            {
                var response = await postclient.GetStringAsync(Endpoints);
                var employee = JsonConvert.DeserializeObject<List<Employee>>(response);

                lstEmp = employee;

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return lstEmp;
        }
        #endregion

        #region Get one record by Id
        public async Task<List<Employee>> GetEmployeeById(int Id)
        {
            List<Employee> lstEmp = new List<Employee>();
            Employee emp = new Employee();
            try
            {
                var response = await postclient.GetAsync(Endpoints + "" + Id);
                var result = await response.Content.ReadAsStringAsync();

                var results = JsonConvert.DeserializeObject<Employee>(result);

                emp.Id = results.Id;
                emp.Name = results.Name;
                emp.Email = results.Email;
                emp.Gender = results.Gender;
                emp.Status = results.Status;
                lstEmp.Add(emp);
            }

            catch (Exception ex)
            {
                throw (ex);    
            }

            return lstEmp;

        }
        #endregion

        #region HttpPost post new records in End Point
        public async void SaveEmployee(Employee emp)
        {

            try
            {
                var json = JsonConvert.SerializeObject(emp);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await postclient.PostAsJsonAsync(Endpoints, content);

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }

        #endregion

        #region HttpPut Update the existing Details
        public async void UpdateEmployee(Employee emp)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(emp), Encoding.UTF8, "application/json");
                await postclient.PutAsJsonAsync(Endpoints + "" + emp.Id, content);
                //var responsecontent = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region HttpDelete Delete the Existing records
        public async void DeleteEmployee(int EmpID)
        {
            try
            {
                await postclient.DeleteAsync(Endpoints + EmpID);

            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }
        #endregion

    }
}
