using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeDetails;
using DataAccessLayer;
using CommonLayer;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Net;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestMethods
    {
        #region Api details test Common class
        [TestMethod]
        public void ApiServiceTest()
        {
           CommonLayer.Common obj = new CommonLayer.Common();

            string accesskey = obj.GetFilePath("endpoints");

            Assert.AreEqual(accesskey, "/public/v2/users/");
        }
        #endregion

        #region Service call Check
        [TestMethod]
        public void TestApiServiceClass()
        {
            BasicDetailsService objApiCall = new BasicDetailsService();

            string baseaddress = objApiCall.IBaseAddress();

            Assert.AreEqual(baseaddress, "https://gorest.co.in/");
        }
        #endregion

        #region Api Response Check
        [TestMethod]
        public void TestApiResponse()
        {
            var client = new HttpClient(); // no HttpServer

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("https://gorest.co.in/public/v2/users/"),
                Method = HttpMethod.Get
            };

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (var response = client.SendAsync(request).Result)
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }
        #endregion

        //[TestMethod]
        //public void TestGetEmployeeById()
        //{
        //    Employee emp = new Employee();
        //    ServiceApiCall objScall = new ServiceApiCall();

        //   var results =   objScall.GetEmployeeById(812669);

        //    var excepted = new Employee
        //    {
        //        Id = 812669,
        //        Name = "Ujjawal Dwivedi",
        //        Email = "dwivedi_ujjawal@schroeder-franecki.com",
        //        Gender = "female",
        //        Status = "active"
        //    };

        //    Assert.AreEqual(results, excepted);

        //}

    }
}
