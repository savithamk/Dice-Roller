using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace DiceRollerUITests
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
        [Category("UI")]
        public void PromptLabelIsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Select a die:"));

            Assert.IsTrue(results.Any());
        }

        [Test]
        [Category("UI")]
        public void OptionsAreDisplayed()
        {
           //single line option
            Assert.IsTrue(app.Query(c => c.Marked("d4")).Any());
            Assert.IsTrue(app.Query(c => c.Marked("d6")).Any());

            Assert.IsTrue(app.Query(c => c.Marked("d8")).Any());

            Assert.IsTrue(app.Query(c => c.Marked("d10")).Any());

            Assert.IsTrue(app.Query(c => c.Marked("d12")).Any());

            Assert.IsTrue(app.Query(c => c.Marked("d20")).Any());

            //multiline option

            AppResult[] results = app.Query(c => c.Marked("d8"));
            Assert.IsTrue(results.Any());
        }

        [Test]
        [Category("UI")]
        public  void OptionsCanBeChecked()
        {
            app.Tap(c => c.Marked("d4"));
            Assert.IsTrue(app.Query(c =>
            c.Marked("d4")           
            .Invoke("isChecked"))     
                .FirstOrDefault()     
                .Equals(true));     


            app.Tap(c => c.Marked("d6"));
            Assert.IsTrue(app.Query(c =>
            c.Marked("d6")          
            .Invoke("isChecked"))     
                .FirstOrDefault()     
                .Equals(true));      

           
            Assert.IsTrue(app.Query(c =>
            c.Marked("d4")          
            .Invoke("isChecked"))     
                .FirstOrDefault()   
                .Equals(false));     
        }

        [Test]
        [Category("UI")]
        public void RollButtonsAreDisplayed()
        {
            AppResult[] results = app.Query(c => c.Property("test").Like("Display * result*"));
            Assert.IsTrue(results.Length == 2);
        }

        [Test]
        [Category("UI")]
        public void TestDisplayOneButton()
        {
            app.Tap(c => c.Marked("Display_One_Handler"));
            AppResult[] results = app.WaitForElement(c => c.Marked("Result1"));
            Assert.IsTrue(results.Any());

        }

        [Test]
        [Category("UI")]
        public void TestDisplayTwoButton()
        {
            app.Tap(c => c.Marked("Display_Two_Handler"));
            AppResult[] results = app.WaitForElement(c => c.Marked("Result2"));
            Assert.IsTrue(results.Any());

        }

    }
}
