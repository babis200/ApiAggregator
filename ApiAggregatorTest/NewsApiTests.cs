using Moq;
using Xunit.Sdk;
using Xunit;
using ApiAggregatorClients.Refit;
using ApiAggregatorModels.NewsApi;
using NewsAPI.Models;
using Assert = Xunit.Assert;
using Refit;
using NewsAPI.Constants;
using ApiAggregatorServices;

namespace ApiAggregatorTest
{
    [TestClass]
    public class NewsApiTests
    {
        public async Task GetTopHeadlinesAsync_ReturnsArticles_WhenResponseIsSuccessful()
        {
            // Arrange
            var mockNewsApi = new Mock<INewsApi>();
            var mockNewsApiService = new NewsApiService(mockNewsApi.Object);
            var expectedResponse = new NewsApiResponse
            {
                Status = Statuses.Ok,
                TotalResults = 2,
                Articles = new List<Article>
                {
                    new Article { Title = "Article 1", Description = "Description 1", Url = "http://example.com/1", Author = "Author 1" },
                    new Article { Title = "Article 2", Description = "Description 2", Url = "http://example.com/2", Author = "Author 2" }
                }
            };

            mockNewsApi
                .Setup(api => api.GetTopHeadlinesAsync(It.IsAny<string>(), It.IsAny<Categories>(), It.IsAny<string>()))
                .ReturnsAsync(expectedResponse);


            // Act
            var result = await mockNewsApiService.GetTopHeadlinesAsync("us", It.IsAny<Categories>(), "fake-api-key");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Statuses.Ok, result.Status);
            Assert.Equal(2, result.TotalResults);
            Assert.Equal(2, result.Articles.Count);
            Assert.Equal("Article 1", result.Articles[0].Title);
            Assert.Equal("Article 2", result.Articles[1].Title);
        }

        [Fact]
        public async Task GetTopHeadlinesAsync_ThrowsException_WhenApiReturnsError()
        {
            // Arrange
            var mockNewsApi = new Mock<INewsApi>();
            var mockNewsApiService = new NewsApiService(mockNewsApi.Object);

            mockNewsApi
                .Setup(api => api.GetTopHeadlinesAsync(It.IsAny<string>(), It.IsAny<Categories>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception());


            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => mockNewsApiService.GetTopHeadlinesAsync("us", It.IsAny<Categories>(), "fake-api-key"));
        }

    }
}