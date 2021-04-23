using APIAutomationBDD.Deserializer.GetEmployeeById;
using APIAutomationBDD.Helper.Request;
using APIAutomationBDD.Helper.ResponseData;
using APIAutomationBDD.Modal.JsonModal;
using APIAutomationBDD.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace APIAutomationBDD.Steps
{
    [Binding]
    public class GetEmpolyeeByIdSteps
    {
        private string requestUrl;
        private RestResponse restResponse;
        private GetEmployeeByIdRoot getEmployeeById;

        [Given(@"User have the baseUri with id as ""(.*)""")]
        public void GivenUserHaveTheBaseUriWithIdAs(string requestUri)
        {
            requestUrl = requestUri;
        }
        
        [When(@"User send the get request")]
        public void WhenUserSendTheGetRequest()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Accpet", "application/json");
            restResponse = HttpClientHelper.PerformGetRequest(requestUrl, dict);
        }
        
        [Then(@"User get the Employee details with status code as (.*)")]
        public void ThenUserGetTheEmployeeDetailsWithStatusCodeAs(int statusCode, Table table)
        {
            Assert.AreEqual(restResponse.StatusCode, statusCode);
            getEmployeeById = ResponseDataHelper.DeserializeJsonResponse<GetEmployeeByIdRoot>(restResponse.ResponseData);
            var employeeList = table.CreateSet<Employee>();
            var employeeData = employeeList.ToList();
            Assert.AreEqual(getEmployeeById.data.id, employeeData[0].id);
            Assert.AreEqual(getEmployeeById.data.employee_name, employeeData[0].employee_name);
            Assert.IsTrue(getEmployeeById.data.employee_age.Equals(employeeData[0].employee_age));
            Assert.AreEqual(getEmployeeById.data.employee_salary, employeeData[0].employee_salary);
            Assert.AreEqual(getEmployeeById.data.profile_image, employeeData[0].profile_image);
        }
    }
}
