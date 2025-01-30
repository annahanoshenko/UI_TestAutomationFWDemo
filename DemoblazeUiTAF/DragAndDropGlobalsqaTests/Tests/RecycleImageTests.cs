using DemoblazeUiTAF.DragAndDropGlobalsqaTests.Base;
using DemoblazeUiTAF.DragAndDropGlobalsqaTests.Pages;
using NUnit.Framework;

namespace DemoblazeUiTAF.DragAndDropGlobalsqaTests.Tests
{
    [TestFixture]
    internal class RecycleImageTests : BaseTest
    {
        [TestCase("High Tatras")]
        [TestCase("High Tatras 2")]
        [TestCase("High Tatras 3")]
        [TestCase("High Tatras 4")]
        public void ShouldRecycleImage_WhenDraggingToThePhotoMAnager(string photoName)
        {
            MainPage mainPage = new MainPage(Driver);
            mainPage.AcceptCookieConsent();
            mainPage.SwitchToPhotoManagerFrame();
            mainPage.ClickTrashIcon();
            mainPage.DragAndDropElement(photoName);

            bool isElementInPhotoMAnager = mainPage.IsElementInPhotoMAnager(photoName);
            Assert.That(isElementInPhotoMAnager, Is.True);
        }

        [TestCase("High Tatras")]
        [TestCase("High Tatras 2")]
        [TestCase("High Tatras 3")]
        [TestCase("High Tatras 4")]
        public void ShouldRecycleImage_WhenClickOnTheRecycleIcon(string photoName)
        {
            MainPage mainPage = new MainPage(Driver);
            mainPage.AcceptCookieConsent();
            mainPage.SwitchToPhotoManagerFrame();
            mainPage.ClickTrashIcon();
            mainPage.ClickRecycleIcon();

            bool isElementInPhotoMAnager = mainPage.IsElementInPhotoMAnager(photoName);
            Assert.That(isElementInPhotoMAnager, Is.True);
        }
    }
}
