using DemoblazeUiTAF.AutoTestsDemoblazePOM.Base;
using DemoblazeUiTAF.AutoTestsDemoblazePOM.Entities;
using DemoblazeUiTAF.AutoTestsDemoblazePOM.Pages;
using DemoblazeUiTAF.AutoTestsDemoblazePOM.Storages;
using NUnit.Framework;

namespace DemoblazeUiTAF.AutoTestsDemoblazePOM.Tests
{
    [TestFixture]
    public class Tests : BaseTest
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
        [Test]
        public void ShouldAddProductToCart_Succeds()
        {
            ProductPage productPage = new ProductPage(Driver);
            CartPage cartPage = new CartPage(Driver);

            productPage.ClickProductNameTitle();
            productPage.ClickAddToCartButton();

            string actualAlertText = productPage.GetAlertTextWithWait();
            string expectedAlertText = "Product added";
            productPage.AcceptAlert();

            Assert.That(actualAlertText.Equals(expectedAlertText));

            cartPage.ClickCartButton();
        }

        [Test]
        public void ShouldDeleteProductFromCart_Succeds()
        {
            ProductPage productPage = new ProductPage(Driver);
            CartPage cartPage = new CartPage(Driver);

            productPage.ClickProductNameTitle();
            productPage.ClickAddToCartButton();

            string actualAlertText = productPage.GetAlertTextWithWait();
            string expectedAlertText = "Product added";
            productPage.AcceptAlert();

            Assert.That(actualAlertText.Equals(expectedAlertText));

            cartPage.ClickCartButton();
            cartPage.ClickDeleteProductBtn();
            cartPage.WaitUntilCartIsEmpty();
        }

        [Test]
        public void CanMakeOrderSuccessfully_WhenDataIsValid()
        {
            OrderEntity order = new OrderEntity("Anna", "USA", "New York", "123456789", "12", "122029");
            LoginPage loginPage = new LoginPage(Driver);
            ProductPage productPage = new ProductPage(Driver);
            CartPage cartPage = new CartPage(Driver);
            OrderPage orderPage = new OrderPage(Driver);

            loginPage.LoginUser(UserStorage.ValidTestUser);

            // Add product to cart
            productPage.WaitForTheProductToBeNotStale();
            productPage.ClickProductNameTitle();
            productPage.ClickAddToCartButton();
    
            // Place order
            cartPage.ClickCartButton();
            cartPage.ClickPlaceOrderButton();
            
            orderPage.FillingOrderFields(order);

            // Verify confirmation
            string confirmationMessage = orderPage.GetConfirmationMessage();
            Assert.That(confirmationMessage, Is.EqualTo("Thank you for your purchase!"));
            orderPage.ClickOkButton();
        }
        [Test]
        public void MakeOrderShouldFail_WhenOrderNameAndCardFieldsAreEmpty()
        {
            OrderEntity order = new OrderEntity("", "USA", "New York", "", "12", "122029");

            LoginPage loginPage = new LoginPage(Driver);
            ProductPage productPage = new ProductPage(Driver);
            CartPage cartPage = new CartPage(Driver);
            OrderPage orderPage = new OrderPage(Driver);

            loginPage.LoginUser(UserStorage.ValidTestUser);

            productPage.WaitForTheProductToBeNotStale();
            productPage.ClickProductNameTitle();
            productPage.ClickAddToCartButton();

            cartPage.ClickCartButton();
            cartPage.ClickPlaceOrderButton();

            orderPage.FillingOrderFields(order);

            string actualAlertText = orderPage.GetAlertTextWithWait();
            string expectedAlertText = "Please fill out Name and Creditcard.";
            productPage.AcceptAlert();

            Assert.That(actualAlertText.Equals(expectedAlertText));
        }

        [Test]
        public void MakeOrderWithEmptyCart_Succeds()
        {
            OrderEntity order = new OrderEntity("Anna", "USA", "New York", "123456789", "12", "122029");
         
            LoginPage loginPage = new LoginPage(Driver);
            ProductPage productPage = new ProductPage(Driver);
            CartPage cartPage = new CartPage(Driver);
            OrderPage orderPage = new OrderPage(Driver);

            loginPage.LoginUser(UserStorage.ValidTestUser);

            productPage.WaitForTheProductToBeNotStale();
            productPage.ClickProductNameTitle();
            productPage.ClickAddToCartButton();

            cartPage.ClickCartButton();
            cartPage.ClickPlaceOrderButton();

            orderPage.FillingOrderFields(order);

            string confirmationMessage = orderPage.GetConfirmationMessage();
            Assert.That(confirmationMessage, Is.EqualTo("Thank you for your purchase!"));
            orderPage.ClickOkButton();
        }

    }
}
