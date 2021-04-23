using APIAutomationBDD.Deserializer.GetEmployee;
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
    public class GetEmployeeSteps
    {
        private string requestUrl;
        private RestResponse restResponse;
        private GetEmployeeRoot getEmployeeRoot;
        
        [Given(@"User have the baseuri as ""(.*)""")]
        public void GivenUserHaveTheBaseuriAs(string requestUrl)
        {
            this.requestUrl = requestUrl;
        }
        
        [When(@"User send a get request")]
        public void WhenUserSendAGetRequest()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Accpet", "application/json");
            restResponse = HttpClientHelper.PerformGetRequest(requestUrl, dict);
            //Console.WriteLine(restResponse.ResponseData);
        }
        
        [Then(@"Empolyee list should be returned with status code (.*)")]
        public void ThenEmpolyeeListShouldBeReturnedWithStatusCode(int statusCode, Table table)
        {
            Assert.AreEqual(restResponse.StatusCode, statusCode);
            var employee = table.CreateSet<Employee>();
            var emloyeedata = employee.ToList();
            getEmployeeRoot = ResponseDataHelper.DeserializeJsonResponse<GetEmployeeRoot>(restResponse.ResponseData);
            for (int i=0; i<24; i++)
            {
               Assert.AreEqual(getEmployeeRoot.data[i].id, emloyeedata[i].id);
               Assert.AreEqual(getEmployeeRoot.data[i].employee_name, emloyeedata[i].employee_name);
               Assert.IsTrue(getEmployeeRoot.data[i].employee_age.Equals(emloyeedata[i].employee_age));
               Assert.AreEqual(getEmployeeRoot.data[i].employee_salary, emloyeedata[i].employee_salary);
               Assert.AreEqual(getEmployeeRoot.data[i].profile_image, emloyeedata[i].profile_image);
            }
        }
    }
}
