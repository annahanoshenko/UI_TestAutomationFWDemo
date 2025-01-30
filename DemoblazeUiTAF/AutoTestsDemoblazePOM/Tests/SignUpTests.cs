using DemoblazeUiTAF.AutoTestsDemoblazePOM.Base;
using DemoblazeUiTAF.AutoTestsDemoblazePOM.Entities;
using DemoblazeUiTAF.AutoTestsDemoblazePOM.Pages;
using DemoblazeUiTAF.AutoTestsDemoblazePOM.Storages;
using NUnit.Framework;

namespace DemoblazeUiTAF.AutoTestsDemoblazePOM.Tests
{
    [TestFixture]
    public class SignUpTests : BaseTest
    {
        [Test]
        public void ShouldCteateNewUser_WhenDataIsValid()
        {
            UserEntity user = UserStorage.UserWithDynamicName;

            SignUpPage signUpPage = new SignUpPage(Driver);

            signUpPage.RegisterNewUser(user);

            string actualAlertText = signUpPage.GetAlertTextWithWait();
            string expectedAlertText = "Sign up successful.";
            signUpPage.AcceptAlert();

            Assert.That(actualAlertText.Equals(expectedAlertText));
        }

        [Test]
        public void Registration_ShouldFail_WhenUsernameAndPasswordFieldsAreEmpty()
        {
            SignUpPage signUpPage = new SignUpPage(Driver);

            signUpPage.RegisterNewUser(UserStorage.UserWithEmptyFields);

            string actualAlertText = signUpPage.GetAlertTextWithWait();
            string expectedAlertText = "Please fill out Username and Password.";
            signUpPage.AcceptAlert();

            Assert.That(actualAlertText.Equals(expectedAlertText));
        }
    }
}
