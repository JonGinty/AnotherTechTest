using Microsoft.Extensions.Logging;
using Moq;
using SearchPlatform;
using SearchPlatform.Controllers;
using SearchPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchService;

namespace SearchPlatformTests;

[TestClass]
public class ScenariosFromSpecTests
{
    private static SearchController BuildSearchController()
    {
        var repo = new PlaceholderDataLoader().LoadUserItemRepository();
        var logger = new Mock<ILogger<SearchController>>();
        var service = new SearchService<UserItem>(repo);
        return new SearchController(logger.Object, service);
    }

    [TestMethod]
    public async Task ScenarioJames()
    {
        var controller = BuildSearchController();
        var result = (await controller.Get("James")).ToList();
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("Kubu", result[0].LastName);

        // NOTE: there is a typo in the spec, the scenario expects Pfieffer but the test data contains Pfeffer
        Assert.AreEqual("Pfeffer", result[1].LastName);
    }

    [TestMethod]
    public async Task ScenarioJam()
    {
        var controller = BuildSearchController();
        var result = (await controller.Get("jam")).ToList();
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual("Kubu", result[0].LastName);
        Assert.AreEqual("Pfeffer", result[1].LastName);
        Assert.AreEqual("Longfut", result[2].LastName);
    }

    [TestMethod]
    public async Task ScenarioKateySoltan()
    {
        var controller = BuildSearchController();
        var result = (await controller.Get("Katey Soltan")).ToList();
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Katey", result[0].FirstName);
        Assert.AreEqual("Soltan", result[0].LastName);
    }

    [TestMethod]
    public async Task ScenarioJasmineDuncan()
    {
        var controller = BuildSearchController();
        var result = (await controller.Get("Jasmine Duncan")).ToList();
        Assert.AreEqual(0, result.Count);
    }

    /**
     * I have opted not to do the empty-string validation here.
     * I will validate for the empty string in the front-end.
     */ 
}
