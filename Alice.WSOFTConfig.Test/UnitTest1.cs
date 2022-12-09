using WSOFT.Config;

namespace Alice.WSOFTConfig.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            Assert.AreNotEqual( ConfigFile.FromFile("K:\\LocalFiles\\Docments\\WSOFT\\Losetta\\alice\\bin\\Debug\\net6.0\\app.wsconf"),null);
        }
    }
}