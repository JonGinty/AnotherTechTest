using SearchPlatform;
using SearchPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchPlatformTests;

[TestClass]
public class ShimUserDataTests
{
    [TestMethod]
    public void LoadsCorrectData()
    {
        var loader = new PlaceholderDataLoader();
        var data = loader.LoadItems();
        Assert.AreEqual(20, data.Length);

        // I'm not going to check all 20 values so we'll just check the first and last
        Assert.AreEqual(new UserItem(1, "Antony", "Fitt", "afitt0@a8.net", "Male"), data.First());
        Assert.AreEqual(new UserItem(20, "Kameko", "Vanes", "kvanesj@discuz.net", "Female"), data.Last());
    }
}
