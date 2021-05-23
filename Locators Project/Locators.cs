using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Locators_Project
{
    [TestFixture]
    public class LocatorsTests
    {
        IWebDriver driver;

        [SetUp]
        public void BeforeTest()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
        }

        #region ID

        [Test]
        public void BasicLocatorTestId()
        {
            string url = "https://www.saucedemo.com/";
            driver.Navigate().GoToUrl(url);

            IWebElement loginButton = driver.FindElement(By.Id("login-button"));
            loginButton.Click();
        }
        #endregion

        #region Classname

        [Test]
        public void BasicLocatorTestClassname()
        {
            string url = "https://www.saucedemo.com/";
            driver.Navigate().GoToUrl(url);

            IWebElement loginButton = driver.FindElement(By.ClassName("submit-button btn_action"));
            loginButton.Click();
        }
        #endregion

        #region Name

        [Test]
        public void BasicLocatorTestName()
        {
            string url = "https://www.saucedemo.com/";
            driver.Navigate().GoToUrl(url);

            IWebElement loginButton = driver.FindElement(By.Name("login-button"));
            loginButton.Click();
        }
        #endregion

        #region Tagname

        [Test]
        public void BasicLocatorTestTagName()
        {
            string url = "https://www.saucedemo.com/";
            driver.Navigate().GoToUrl(url);

            IWebElement loginBox = driver.FindElement(By.TagName("form"));
        }
        #endregion

        #region XPath

        [Test]
        public void BasicLocatorTestXpathAsTagName()
        {
            string url = "https://www.saucedemo.com/";
            driver.Navigate().GoToUrl(url);

            IWebElement loginBox = driver.FindElement(By.XPath("//form"));

        }

        [Test]
        public void BasicLocatorTestXpathLoginButton()
        {
            string url = "https://www.saucedemo.com/";
            driver.Navigate().GoToUrl(url);

            IWebElement loginButton = driver.FindElement(By.XPath("//input[@id='login-button']"));
            loginButton = driver.FindElement(By.XPath("//input[@id='login-button']"));
            loginButton = driver.FindElement(By.XPath("//input[@name='login-button']"));
            loginButton = driver.FindElement(By.XPath("//input[@value='Login']"));
            loginButton = driver.FindElement(By.XPath("//form//input[@id='login-button']"));

            loginButton = driver.FindElement(By.XPath("//form//*[@id='login-button']"));
        }

        [Test]
        public void BasicLocatorTestXpathLoginSearchByText()
        {
            string url = "https://www.saucedemo.com/";
            driver.Navigate().GoToUrl(url);

            IWebElement usernameField = driver.FindElement(By.XPath("//input[@id='user-name']"));
            usernameField.Click();
            usernameField.Clear();
            usernameField.SendKeys("standard_user");

            IWebElement passwordField = driver.FindElement(By.XPath("//input[@id='password']"));
            passwordField.Click();
            passwordField.Clear();
            passwordField.SendKeys("secret_sauce");

            IWebElement loginButton = driver.FindElement(By.XPath("//input[@id='login-button']"));
            loginButton.Click();

            IWebElement productLabel = driver.FindElement(By.ClassName("title"));
            productLabel = driver.FindElement(By.XPath("//span[@class='title']"));

            productLabel = driver.FindElement(By.XPath("//span[text()='Products']"));

            productLabel = driver.FindElement(By.XPath("//span[contains(text(),'Produc')]"));

            productLabel = driver.FindElement(By.XPath("//span[starts-with(text(),'Prod')]"));

            productLabel = driver.FindElement(By.XPath("//span[starts-with(@class,'titl')]"));

            productLabel = driver.FindElement(By.XPath("//span[text()='Products' and @class='title']"));

            productLabel = driver.FindElement(By.XPath("//span[text()='Products' or @class='title']"));
        }
        #endregion

        #region CSS Selectors

        [Test]
        public void BasicLocatorTestCSSSelectorLoginButton()
        {
            string url = "https://www.saucedemo.com/";
            driver.Navigate().GoToUrl(url);

            IWebElement loginButton = driver.FindElement(By.XPath("//input[@id='login-button']"));
            
            //ID
            loginButton = driver.FindElement(By.CssSelector("#login-button"));

            //ClassName (submit-button btn_action)
            loginButton = driver.FindElement(By.CssSelector(".submit-button.btn_action"));

            //Attribute
            loginButton = driver.FindElement(By.CssSelector("input[id='login-button']"));

            //Sub-string
            loginButton = driver.FindElement(By.CssSelector("input[id^='login']"));//prefix
            loginButton = driver.FindElement(By.CssSelector("input[id$='login']"));//suffix
            loginButton = driver.FindElement(By.CssSelector("input[id*='login']"));//contains

            //Combined
            loginButton = driver.FindElement(By.CssSelector("input[id = 'login-button'][type = 'submit']"));
        }
        #endregion

        [Test]
        public void FinalTest()
        {
            string url = "https://www.saucedemo.com/";
            driver.Navigate().GoToUrl(url);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='user-name']")));

            IWebElement usernameField = driver.FindElement(By.XPath("//input[@id='user-name']"));
            usernameField.Click();
            usernameField.Clear();
            usernameField.SendKeys("standard_user");

            IWebElement passwordField = driver.FindElement(By.XPath("//input[@id='password']"));
            passwordField.Click();
            passwordField.Clear();
            passwordField.SendKeys("secret_sauce");

            IWebElement loginButton = driver.FindElement(By.XPath("//input[@id='login-button']"));
            loginButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".peek")));

            Assert.True(driver.FindElement(By.CssSelector(".title")).Displayed, "Title was not displayed!");
            Assert.AreEqual("PRODUCTS", driver.FindElement(By.CssSelector(".title")).Text, "Title text differs from expected!");
        }

    }
}
