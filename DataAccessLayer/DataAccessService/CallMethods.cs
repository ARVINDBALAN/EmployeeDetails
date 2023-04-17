using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CommonLayer;
using Entities.EmployeeEntities;
using Newtonsoft.Json;

namespace DataAccessLayer.DataAccessService
{
    public class CallMethods : ICallMethods
    {
        #region Decalre Objects
        HttpClient postclient = new HttpClient();
        BasicDetailsService ObjBServiceDetails = new BasicDetailsService();
        public ICommonAction commonAction;
        #endregion

        #region Decalre variables
        string accessToken = string.Empty;
        string baseAddress = string.Empty;
        string endPoints = string.Empty;
        #endregion

        #region Constructor
        public CallMethods()
        {
            InitiateValue();
            postclient.BaseAddress = new Uri(baseAddress);
            postclient.DefaultRequestHeaders.Accept.Clear();
            postclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            postclient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
        }
        #endregion



        #region Initiate values for endpoint
        public void InitiateValue()
        {
            try
            {
                baseAddress = ObjBServiceDetails.IBaseAddress();
                accessToken = ObjBServiceDetails.IAccessToken();
                endPoints = ObjBServiceDetails.IEndPoints();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region Get all the Employees
        public async Task<List<Employee>> GetAllDetails()
        {
            List<Employee> lstEmp = new List<Employee>();

            try
            {
                var response = await postclient.GetStringAsync(endPoints);
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
        public async Task<List<Employee>> GetOneRecordByID(int Id)
        {
            List<Employee> lstEmp = new List<Employee>();
            Employee emp = new Employee();
            try
            {
                var response = await postclient.GetAsync(endPoints + "" + Id);
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
        public async void InsertNewDetail(Employee emp)
        {

            try
            {
                var json = JsonConvert.SerializeObject(emp);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await postclient.PostAsJsonAsync(endPoints, content);

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
        public async void UpdateExistingRecord(Employee emp)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(emp), Encoding.UTF8, "application/json");
                await postclient.PutAsJsonAsync(endPoints + "" + emp.Id, content);
                //var responsecontent = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region HttpDelete Delete the Existing records
        public async void DeleteExistingRecord(int empId)
        {
            try
            {
                await postclient.DeleteAsync(endPoints + empId);

            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }
        #endregion

    }
}
