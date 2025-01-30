using DemoblazeUiTAF.DragAndDropGlobalsqaTests.Base;
using DemoblazeUiTAF.DragAndDropGlobalsqaTests.Pages;
using NUnit.Framework;

namespace DemoblazeUiTAF.DragAndDropGlobalsqaTests.Tests
{
    [TestFixture]
    internal class ZoomImageTests : BaseTest
    {
        [Test]
        public void ShoulZoomImage_WhenClickOnTheZoomIcon()
        {
            MainPage mainPage = new MainPage(Driver);
            mainPage.AcceptCookieConsent();
            mainPage.SwitchToPhotoManagerFrame();

            Dictionary<string, string> imgMap = new Dictionary<string, string>
            {
                { "High Tatras", "images/high_tatras.jpg" },
                { "High Tatras 2", "images/high_tatras2.jpg" },
                { "High Tatras 3", "images/high_tatras3.jpg" },
                { "High Tatras 4", "images/high_tatras4.jpg" }
            };


            ImageWidget[] imageWidgets = mainPage.GetAllPhotoElements();
            foreach (var imageWidget in imageWidgets)
            {
                imageWidget.ZoomIcon.Click();
                string imageSearchKey = imgMap[imageWidget.Title.Text];
                mainPage.WaitUntilImageIsZoomed(imageSearchKey);
            }
        }

        [TestCase("High Tatras")]
        [TestCase("High Tatras 2")]
        [TestCase("High Tatras 3")]
        [TestCase("High Tatras 4")]
        public void ShouldCloseImage_WhenClickOnTheCloseIcon(string photoName)
        {
            MainPage mainPage = new MainPage(Driver);
            mainPage.AcceptCookieConsent();
            mainPage.SwitchToPhotoManagerFrame();
            mainPage.ClickZoomIcon();
            mainPage.ClickExitIcon();

            bool isElementInPhotoManager = mainPage.IsElementInPhotoMAnager(photoName);
            Assert.That(isElementInPhotoManager, Is.True);
        }
    }
}
