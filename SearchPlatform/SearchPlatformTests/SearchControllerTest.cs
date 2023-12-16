using Moq;
using SearchPlatform;
using SearchPlatform.Controllers;
using SearchService;
using Microsoft.Extensions.Logging;

namespace SearchPlatformTests;

[TestClass]
public class SearchControllerTest
{
    private static readonly UserItem _defaultItem = new UserItem(1, "han", "solo", "han@mf.space", "Male");

    [TestMethod]
    public async Task CallsCorrectSearchMethod()
    {
        var mock = new Mock<ISearchService<UserItem>>();
        var logMock = new Mock<ILogger<SearchController>>();
        IEnumerable<UserItem> expectedResult = new[] { _defaultItem }; 
        mock.Setup(s => s.Search(It.IsAny<string>())).Returns(Task.FromResult(expectedResult));

        var controller = new SearchController(logMock.Object, mock.Object);
        var testQuery = "test query";
        var result = await controller.Get(testQuery);
        Assert.AreEqual(expectedResult, result);
        mock.Verify(s => s.Search(testQuery), Times.Once);
    }
}