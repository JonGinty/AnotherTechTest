using SearchService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchServiceTests;

[TestClass]
public class KvpItemRepositoryTests
{
    private static readonly Dictionary<string, string>[] simpleItems = new Dictionary<string, string>[]
        {
            new ()
            {
                { "foo", "one two" },
                { "bar", "three four" }
            },
            new ()
            {
                {"foo", "five six" },
                {"bar", "seven eight" }
            },
            new ()
            {
                {"foo", "nine ten" },
                {"bar", "eleven twelve" }
            },
            new ()
            {
                {"foo", "thirteen fourteen" },
                {"bar", "fifteen sixteen" }
            }
        };


    [TestMethod]
    public async Task WorksForSingleToken()
    {
        var repo = new KvpItemRepository(simpleItems);

        var result = (await repo.Find(new(new[] { "o" }))).ToList();
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(simpleItems[0], result[0]);
        Assert.AreEqual(simpleItems[3], result[1]);

        result = (await repo.Find(new(new[] { "ee" }))).ToList();
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(simpleItems[0], result[0]);
        Assert.AreEqual(simpleItems[3], result[1]);

        result = (await repo.Find(new(new[] { "ven" }))).ToList();
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(simpleItems[1], result[0]);
        Assert.AreEqual(simpleItems[2], result[1]);
    }

    [TestMethod]
    public async Task WorksForMultipleTokens()
    {
        var repo = new KvpItemRepository(simpleItems);

        var result = (await repo.Find(new(new[] { "o", "teen" }))).ToList();
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(simpleItems[3], result[0]);
    }

    [TestMethod]
    public async Task IgnoresTokenCase()
    {
        var repo = new KvpItemRepository(simpleItems);

        var result = (await repo.Find(new(new[] { "O" }))).ToList();
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(simpleItems[0], result[0]);
        Assert.AreEqual(simpleItems[3], result[1]);
    }

    [TestMethod]
    public async Task IgnoresOrder()
    {
        var repo = new KvpItemRepository(simpleItems);

        var result = (await repo.Find(new(new[] { "teen", "o"}))).ToList();
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(simpleItems[3], result[0]);
    }

}
