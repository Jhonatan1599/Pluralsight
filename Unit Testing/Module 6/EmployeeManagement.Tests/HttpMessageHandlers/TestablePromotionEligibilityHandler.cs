using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EmployeeManagement.Business;

namespace EmployeeManagement.Tests.HttpMessageHandlers
{
    //Inherit from HttpMessageHandler
    public class TestablePromotionEligibilityHandler : HttpMessageHandler
    {   
        private readonly bool _isEligibleForPromotion;

        public TestablePromotionEligibilityHandler(bool isEligileForPromotion)
        {
            _isEligibleForPromotion = isEligileForPromotion;
        }


        // What we wan to do here is generate a response and return it so that we don't do an actual call into the API.
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {   
            // This is what a response body is deserialized to.
            var promotionEligibility = new PromotionEligibility()
            {
                EligibleForPromotion = _isEligibleForPromotion
            };

            // The response
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(
                    JsonSerializer.Serialize(promotionEligibility,
                        new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        }),
                    Encoding.ASCII,
                    "application/json")
            };

            return Task.FromResult(response);
        }
    }
}
