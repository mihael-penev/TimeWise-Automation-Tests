using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium;

namespace TimeWiseTests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToLogin()
        {
            driver.FindElement(By.XPath("//a[@href='/User/LoginRegister']")).Click();
            driver.FindElement(By.XPath("//a[@id='tab-login']")).Click();
        }

        public void Login(string username, string password)
        {
            driver.FindElement(By.XPath("//input[@id='loginName']")).SendKeys(username);
            driver.FindElement(By.XPath("//input[@id='loginPassword']")).SendKeys(password);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }
    }
}
