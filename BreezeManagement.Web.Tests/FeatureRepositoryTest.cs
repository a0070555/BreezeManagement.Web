using BreezeManagement.CoreBusiness.Models;
using BreezeManagement.UseCases.PluginInterfaces;
using Moq.Protected;
using Moq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Castle.Core.Configuration;
using BreezeManagement.Plugins.EFCore;

namespace BreezeManagement.Web.Tests
{
    public class FeatureRepositoryTest
    {

        private Mock<HttpMessageHandler> CreateHttpMock(HttpStatusCode expectedCode, string expectedJson)
        {
            var response = new HttpResponseMessage
            {
                StatusCode = expectedCode
            };
            if (expectedJson != null)
            {
                response.Content = new StringContent(expectedJson, Encoding.UTF8, "application/json");
            }
            var mock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response)
                .Verifiable();
            return mock;
        }

        private IFeatureRepository CreateFeaturesRepository(HttpClient client)
        {
            var mockConfiguration = new Mock<IConfiguration>(MockBehavior.Strict);
            mockConfiguration.Setup(c => c["WebServices:Features:BaseURL"])
                             .Returns("http://example.com");
            return new FeatureRepository(client, mockConfiguration.Object);
        }

        private IFeatureRepository GetFeaturesByName_WithValid_ShouldOkEntity()
        {
            var expectedResult = new Feature { FeatureId = 1, FeatureName = "Sun Roof", AddedPrice = 500, Description = "Adds a luxurious sunroof to the vehicle" };
            var expectedJson = JsonConvert.SerializeObject(expectedResult);
            var expectedUri = new Uri("http://example.com/features/1");
            var mock = CreateHttpMock(HttpStatusCode.OK, expectedJson);
            var client = new HttpClient(mock.Object);
            var service = CreateFeaturesRepository(client);


            var result = 
            

        }
    }
}