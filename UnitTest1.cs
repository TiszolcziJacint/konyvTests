using WpfPilot;

namespace konyvTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StackPanelExists()
        {
            using var appDriver = AppDriver.Launch(@"..\..\..\..\konyv\bin\Debug\net6.0-windows\konyv.exe");
            var stackPanel = appDriver.GetElement(x => x["Name"] == "select_container");
            Assert.IsNotNull(stackPanel);
        }
    }
}