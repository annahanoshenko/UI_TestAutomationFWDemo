using DemoblazeUiTAF.AutoTestsDemoblazePOM.Base;
using DemoblazeUiTAF.AutoTestsDemoblazePOM.Pages;
using DemoblazeUiTAF.AutoTestsDemoblazePOM.Storages;
using NUnit.Framework;

namespace DemoblazeUiTAF.AutoTestsDemoblazePOM.Tests
{
    [TestFixture]
    internal class LoginTests : BaseTest
    {
        [Test]
        public void ShouldDisplayWelcomeLable_AfterLogin()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.LoginUser(UserStorage.ValidTestUser);

            string actualWelcomeLable = loginPage.GetWelcomeMessageText(UserStorage.ValidTestUser.UserName);
            string expectedWelcomeLablel = ($"Welcome {UserStorage.ValidTestUser.UserName}");

            Assert.That(actualWelcomeLable.Equals(expectedWelcomeLablel));
        }

        [Test]
        public void LoginShouldFail_WhenUsernameAndPasswordFieldsAreEmpty()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.LoginUser(UserStorage.UserWithEmptyFields);

            string actualAlertText = loginPage.GetAlertTextWithWait();
            string expectedAlertText = "Please fill out Username and Password.";
            loginPage.AcceptAlert();

            Assert.That(actualAlertText.Equals(expectedAlertText));
        }
    }
}
