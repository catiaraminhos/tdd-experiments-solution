using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using TDDWebAPI.Controllers;

namespace TDDWebAPITests
{
    [TestFixture]
    public class LoginControllerTests
    {
        [Test]
        public void WrongPasswordShouldRedirectToErrorPage()
        {
            LoginController loginController = new LoginController();
            var redirectResult = loginController.Login("nonsuchuser", "wrongpassword") as RedirectResult;
            Assert.That(redirectResult.Url, Is.EqualTo("/invalidlogin"));
        }
    }
}
