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
        public void MainContainerCheck()
        {
            using var appDriver = AppDriver.Launch(@"..\..\..\..\konyv\bin\Debug\net6.0-windows\konyv.exe");
            var mainContainer = appDriver.GetElement(x => x["Name"] == "main_container");
            Assert.IsNotNull(mainContainer);
        }

        [Test]
        public void SelectContainerCheck()
        {
            using var appDriver = AppDriver.Launch(@"..\..\..\..\konyv\bin\Debug\net6.0-windows\konyv.exe");
            var stackPanel = appDriver.GetElement(x => x["Name"] == "select_container");
            Assert.IsNotNull(stackPanel);
        }

        [Test]
        public void ComboBoxSelectCheck()
        {
            using var appDriver = AppDriver.Launch(@"..\..\..\..\konyv\bin\Debug\net6.0-windows\konyv.exe");
            var combobox = appDriver.GetElement(x => x["Name"] == "cbox_select");
            Assert.IsNotNull(combobox);
        }

        [Test]
        public void InfoLabelsCheck()
        {
            using var appDriver = AppDriver.Launch(@"..\..\..\..\konyv\bin\Debug\net6.0-windows\konyv.exe");
            var author = appDriver.GetElement(x => x["Content"] == "Szerzõ:" && x["FontWeight"] == "Bold");
            var title = appDriver.GetElement(x => x["Content"] == "Könyv címe:");
            var language = appDriver.GetElement(x => x["Content"] == "Nyelve:");
            var country = appDriver.GetElement(x => x["Content"] == "Ország:");
            var year = appDriver.GetElement(x => x["Content"] == "Megjelenés éve:");
            Assert.IsNotNull(author);
            Assert.IsNotNull(title);
            Assert.IsNotNull(language);
            Assert.IsNotNull(country);
            Assert.IsNotNull(year);
        }

        [Test]
        public void ListElementLabelsCheck()
        {
            using var appDriver = AppDriver.Launch(@"..\..\..\..\konyv\bin\Debug\net6.0-windows\konyv.exe");
            appDriver.GetElement(x => x["Name"] == "cbox_select").SetProperty("SelectedIndex", 1);
            var author = appDriver.GetElement(x => x["Content"] == "Szerzõ:" && x["FontWeight"] != "Bold");
            var title = appDriver.GetElement(x => x["Content"] == "Cím:");
            Assert.IsNotNull(author);
            Assert.IsNotNull(title);
        }

        [Test]
        public void ImageCheck()
        {
            using var appDriver = AppDriver.Launch(@"..\..\..\..\konyv\bin\Debug\net6.0-windows\konyv.exe");
            appDriver.GetElement(x => x["Name"] == "cbox_select").SetProperty("SelectedIndex", 1);
            var image = appDriver.GetElement(x => x["Name"] == "book_image");
            Assert.IsNotNull(image);
        }

        [Test]
        public void WikipediaLinkCheck()
        {
            using var appDriver = AppDriver.Launch(@"..\..\..\..\konyv\bin\Debug\net6.0-windows\konyv.exe");
            appDriver.GetElement(x => x["Name"] == "cbox_select").SetProperty("SelectedIndex", 1);
            var link = appDriver.GetElement(x => x["Name"] == "HL_wiki");
        }
    }
}