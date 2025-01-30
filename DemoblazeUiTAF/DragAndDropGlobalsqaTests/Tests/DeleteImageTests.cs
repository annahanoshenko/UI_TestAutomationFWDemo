using DemoblazeUiTAF.DragAndDropGlobalsqaTests.Base;
using DemoblazeUiTAF.DragAndDropGlobalsqaTests.Pages;
using NUnit.Framework;

namespace DemoblazeUiTAF.DragAndDropGlobalsqaTests.Tests
{
    [TestFixture]
    internal class DeleteImageTests : BaseTest
    {
        [TestCase("High Tatras")]
        [TestCase("High Tatras 2")]
        [TestCase("High Tatras 3")]
        [TestCase("High Tatras 4")]
        public void ShouldDeleteImage_WhenDraggingToTheTrash(string photoName)
        {
            MainPage mainPage = new MainPage(Driver);
            mainPage.AcceptCookieConsent();
            mainPage.SwitchToPhotoManagerFrame();
            mainPage.DragAndDropElement(photoName);

            bool isElementInTrash = mainPage.IsElementInTrash(photoName);
            Assert.That(isElementInTrash, Is.True);
        }

        [TestCase("High Tatras")]
        [TestCase("High Tatras 2")]
        [TestCase("High Tatras 3")]
        [TestCase("High Tatras 4")]
        public void ShouldDeleteImage_WhenClickOnTheTrashIcon(string photoName)
        {
            MainPage mainPage = new MainPage(Driver);
            mainPage.AcceptCookieConsent();
            mainPage.SwitchToPhotoManagerFrame();
            mainPage.ClickTrashIcon();

            bool isElementInTrash = mainPage.IsElementInTrash(photoName);
            Assert.That(isElementInTrash, Is.True);
        }
    }
}
