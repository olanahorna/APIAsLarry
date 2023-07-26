using NUnit.Framework;
using RestfulBookerTAF.Models;
using RestSharp;
using System.Net;
using System.Text.Json;
using TechTalk.SpecFlow;

namespace RestfulBookerTAF.Tests
{
    [Binding]
    public class PutTest
    {
        PutModel putModel = new PutModel();
        private RestClient restClient = new RestClient("https://some-api.com");
        private RestResponse restResponse;
        
        [Given(@"I want to update request with the following details - '([^']*)'")]
        public void IWantToUpdateBookingRequestTest(Table table)
        {
            var bookingDetailes = table.Rows[0];
            putModel.username = bookingDetailes["username"];

            RestRequest restRequest = new RestRequest($"resetloginfailtotal", Method.Put);
            
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddJsonBody(putModel);

            restResponse = restClient.Execute<PutModel>(restRequest);
        }

        [Then(@"the request details should be updated")]
        public void VerifyThatBookingWasUpdatedTest()
        {
            Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Given(@"I want to update request with the following invalid details - '([^']*)'")]
        public void UpdateBookingWithIvalidRequestTest(Table table)
        {
            var bookingDetailes = table.Rows[0];
            putModel.username = bookingDetailes["username"];

            RestRequest restRequest = new RestRequest($"resetloginfailtotal", Method.Put);

            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddJsonBody(putModel);

            restResponse = restClient.Execute<PutModel>(restRequest);
        }

        [Then(@"the booking should not be updated")]
        public void VerifyThatBookingWasNotUpdatedTest()
        {
            Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
    }
}
