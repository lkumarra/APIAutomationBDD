using APIAutomationBDD.Deserializer.DeleteEmployee;
using APIAutomationBDD.Helper.Request;
using APIAutomationBDD.Helper.ResponseData;
using APIAutomationBDD.Modal.JsonModal;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace APIAutomationBDD.Steps
{
    [Binding]
    public class DeleteEmployeeSteps
    {
        private string requestUrl;
        private RestResponse restResponse;
        private DeleteEmployeeRoot deleteEmpolyee;

        [Given(@"User have as valid endpoint as ""(.*)""")]
        public void GivenUserHaveAsValidEndpointAs(string requestUri)
        {
            requestUrl = requestUri;
        }
        
        [When(@"User send the delete request")]
        public void WhenUserSendTheDeleteRequest()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Accpet", "application/json");
            restResponse = HttpClientHelper.PerformDeleteRequest(requestUrl, dict);
        }

        [Then(@"User get (.*) as status code")]
        public void ThenUserGetAsStatusCode(int statusCode)
        {
            Assert.AreEqual(restResponse.StatusCode, statusCode);
        }

        [Then(@"User get status as ""(.*)""")]
        public void ThenUserGetStatusAs(string status)
        {
            deleteEmpolyee = ResponseDataHelper.DeserializeJsonResponse<DeleteEmployeeRoot>(restResponse.ResponseData);
            Assert.AreEqual(deleteEmpolyee.status, status);
        }
        
        [Then(@"User get message as ""(.*)""")]
        public void ThenUserGetMessageAs(string message)
        {
            Assert.AreEqual(deleteEmpolyee.message, message);
        }

       

    }
}
