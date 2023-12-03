using konyv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPilot;

namespace konyvTests
{
    public class ContentTests
    {
        [Test]
        public void ListItemChangesWhenLanguageChanged()
        {
            using var appDriver = AppDriver.Launch(@"..\..\..\..\konyv\bin\Debug\net6.0-windows\konyv.exe");
            appDriver.GetElement(x => x["Name"] == "cbox_select").SetProperty("SelectedIndex", 1);
            string? firstTitle = appDriver.GetElement(x => x["Content"] == "Cím:")["Content"];
            appDriver.GetElement(x => x["Name"] == "cbox_select").SetProperty("SelectedIndex", 2);
            string? secondTitle = appDriver.GetElement(x => x["Content"] == "Cím:")["Content"];
            Assert.AreNotSame(firstTitle, secondTitle);
        }

        [Test]
        public void ImageChangesWhenSelectedBookChanged()
        {
            using var appDriver = AppDriver.Launch(@"..\..\..\..\konyv\bin\Debug\net6.0-windows\konyv.exe");
            appDriver.GetElement(x => x["Name"] == "cbox_select").SetProperty("SelectedIndex", 1);
            appDriver.GetElements(x => x["Content"] == "Cím:")[0].Click();
            var image1 = appDriver.GetElement(x => x["Name"] == "book_image");
            appDriver.GetElements(x => x["Content"] == "Cím:")[1].Click();
            var image2 = appDriver.GetElement(x => x["Name"] == "book_image");
            Assert.AreNotSame(image1, image2);
        }

        [Test]
        public void TitleChangesWhenSelectedBookChanges()
        {
            using var appDriver = AppDriver.Launch(@"..\..\..\..\konyv\bin\Debug\net6.0-windows\konyv.exe");
            appDriver.GetElement(x => x["Name"] == "cbox_select").SetProperty("SelectedIndex", 1);
            appDriver.GetElements(x => x["Content"] == "Cím:")[0].Click();
            string? title1 = appDriver.GetElements(x => x["Name"] == "info_title")[0]["Content"];
            appDriver.GetElements(x => x["Content"] == "Cím:")[1].Click();
            string? title2 = appDriver.GetElements(x => x["Name"] == "info_title")[0]["Content"];
            Assert.AreNotSame(title1, title2);
        }

        [Test]
        public void BookLanguageChangesWhenLanguageAndBookChanged()
        {
            using var appDriver = AppDriver.Launch(@"..\..\..\..\konyv\bin\Debug\net6.0-windows\konyv.exe");
            appDriver.GetElement(x => x["Name"] == "cbox_select").SetProperty("SelectedIndex", 1);
            appDriver.GetElements(x => x["Content"] == "Cím:")[0].Click();
            string? language1 = appDriver.GetElement(x => x["Name"] == "info_language")["Content"];
            appDriver.GetElement(x => x["Name"] == "cbox_select").SetProperty("SelectedIndex", 2);
            appDriver.GetElements(x => x["Content"] == "Cím:")[0].Click();
            string? language2 = appDriver.GetElement(x => x["Name"] == "info_language")["Content"];
            Assert.AreNotSame(language1, language2);
        }
        [Test]
        public void WikipediaLinkChangesWhenBookChanged()
        {
            using var appDriver = AppDriver.Launch(@"..\..\..\..\konyv\bin\Debug\net6.0-windows\konyv.exe");
            appDriver.GetElement(x => x["Name"] == "cbox_select").SetProperty("SelectedIndex", 1);
            appDriver.GetElements(x => x["Content"] == "Cím:")[0].Click();
            string? link1 = appDriver.GetElement(x => x["Name"] == "HL_wiki")["NavigateUri"];
            appDriver.GetElements(x => x["Content"] == "Cím:")[1].Click();
            string? link2 = appDriver.GetElement(x => x["Name"] == "HL_wiki")["NavigateUri"];
            Assert.AreNotSame(link1, link2);
        }
    }
}
