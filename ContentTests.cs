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
        public void InfoDisplaysCorrectInfo()
        {
            using var appDriver = AppDriver.Launch(@"..\..\..\..\konyv\bin\Debug\net6.0-windows\konyv.exe");
            appDriver.GetElement(x => x["Name"] == "cbox_select").SetProperty("SelectedIndex", 1);
            string? title = appDriver.GetElement(x => x["Name"] == "title")["Content"];
            
        }
    }
}
