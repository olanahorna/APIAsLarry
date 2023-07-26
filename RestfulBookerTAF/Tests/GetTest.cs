using NUnit.Framework;
using RestfulBookerTAF.Models;
using RestSharp;
using System.Net;
using System.Text.Json;
using TechTalk.SpecFlow;

namespace RestfulBookerTAF.Tests
{
    [Binding]
    public class GetTest
    {
        private RestClient restClient = new RestClient("https://some-api.com");
        private RestResponse restResponse;
        GetModel getModel = new GetModel();

        [Given(@"I send a new request with the valid details:")]
        public void GivenISendValidGetRequest(Table table)
        {
            var detailes = table.Rows[0];
            getModel.user_name = detailes["UserName"];
            getModel.fail_count = Convert.ToInt32(detailes["FailCount"]);
            getModel.fetch_limit = Convert.ToInt32(detailes["FetchLimit"]);

            RestRequest request = new RestRequest("loginfailtotal", Method.Get);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(detailes);
            restResponse = restClient.Execute<GetModel>(request);
        }

        [Given(@"I send a new request with the invalid details - '([^']*)', '([^']*)', '([^']*)'")]
        public void GivenISendInvalidGetRequest(Table table)
        {
            var detailes = table.Rows[0];
            getModel.user_name = detailes["UserName"];
            getModel.fail_count = Convert.ToInt32(detailes["FailCount"]);
            getModel.fetch_limit = Convert.ToInt32(detailes["FetchLimit"]);

            RestRequest request = new RestRequest("loginfailtotal", Method.Get);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(detailes);
            restResponse = restClient.Execute<GetModel>(request);
        }

        [Then(@"OK response is returned")]
        public void VerifyThat200WasFoundTest()
        {
            Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Then(@"400 response is returned")]
        public void VerifyThat400WasFoundTest()
        {
            Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
    }
}
