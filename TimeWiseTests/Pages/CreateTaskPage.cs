using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TimeWiseTests.Pages
{
    public class CreateTaskPage
    {
        private readonly IWebDriver driver;

        public CreateTaskPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Navigate()
        {
            driver.FindElement(By.XPath("//a[@href='/Task/ToDo']")).Click();
            driver.FindElement(By.XPath("//a[@href='/Task/Create']")).Click();
        }

        public void CreateTask(string name, string description)
        {
            driver.FindElement(By.XPath("//input[@name='TaskName']")).SendKeys(name);
            driver.FindElement(By.XPath("//textarea[@name='Description']")).SendKeys(description);

            driver.FindElement(By.XPath("//input[@name='StartDate']"))
                .SendKeys(DateTime.Now.ToString("dd/MM/yyyy HH:mm"));

            driver.FindElement(By.XPath("//input[@name='EndDate']"))
                .SendKeys(DateTime.Now.AddDays(1).ToString("dd/MM/yyyy HH:mm"));

            var status = new SelectElement(driver.FindElement(By.CssSelector("select[name='Status']")));
            status.SelectByValue("10");

            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }
    }
}
