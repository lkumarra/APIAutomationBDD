using APIAutomationBDD.Deserializer.CreateEmployee;
using APIAutomationBDD.Helper.Request;
using APIAutomationBDD.Helper.ResponseData;
using APIAutomationBDD.Modal.JsonModal;
using APIAutomationBDD.Serializer.CreateEmployee;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TechTalk.SpecFlow;

namespace APIAutomationBDD.Steps
{
    [Binding]
    public class CreateEmployeeSteps
    {
        private string requestUrl;
        private RestResponse restResponse;
        private CreateEmployeeRoot createEmployeeRoot;

        [Given(@"User have a valid uri as ""(.*)""")]
        public void GivenUserHaveAValidUriAs(string requestUri)
        {
            requestUrl = requestUri;
        }
        
        [When(@"User send the post request with ""(.*)"", ""(.*)"" and ""(.*)""\.")]
        public void WhenUserSendThePostRequestWithAnd_(string name, string salary, string age)
        {
            CreateEmployee createEmployee = new CreateEmployee(name, salary, age);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Accpet", "application/json");
            restResponse = HttpClientHelper.PerformPostRequest(requestUrl, new StringContent(createEmployee.GetCreateEmployeePayload(), Encoding.UTF8, "application/json"), dict);
        }
        
        [Then(@"User get the status code as (.*)")]
        public void ThenUserGetTheStatusCodeAs(int statusCode)
        {
            Assert.AreEqual(restResponse.StatusCode, statusCode);
        }
        
        [Then(@"User get the name as ""(.*)""")]
        public void ThenUserGetTheNameAs(string name)
        {
            createEmployeeRoot = ResponseDataHelper.DeserializeJsonResponse<CreateEmployeeRoot>(restResponse.ResponseData);
            Assert.AreEqual(createEmployeeRoot.data.name, name);
        }
        
        [Then(@"User get the salary as ""(.*)""")]
        public void ThenUserGetTheSalaryAs(string salary)
        {
            Assert.AreEqual(createEmployeeRoot.data.salary, salary);
        }
        
        [Then(@"User get the age as ""(.*)""")]
        public void ThenUserGetTheAgeAs(string age)
        {
            Assert.AreEqual(createEmployeeRoot.data.age, age);
        }
    }
}
