using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace WeatherUITest
{
    [TestFixture(Platform.Android)]    
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Repl();
        }
         [Test]
        public void ButtonClicked()
        {
            app.Tap(c => c.Marked("MyButton"));
            app.WaitForElement("message");
            AppResult[] results = app.Query("message");

            Assert.AreEqual("The temperature in New York was", results[0].Text.Substring(0,31));

            app.Tap(c => c.Marked("button2"));

        }
    }
}

