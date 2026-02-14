using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TimeWiseTests.Pages
{
    public class ToDoPage
    {
        private readonly IWebDriver driver;

        public ToDoPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetLastTaskTitle()
        {
            return driver.FindElement(
                By.XPath("(//h5[@class='card-title'])[last()]")
            ).Text;
        }

        public void EditLastTask(string newName)
        {
            driver.FindElement(
                By.XPath("//div[contains(@class,'card')][last()]//a[text()='Edit']")
            ).Click();

            var nameField = driver.FindElement(By.XPath("//input[@name='TaskName']"));
            nameField.Clear();
            nameField.SendKeys(newName);

            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        public void MoveLastTask()
        {
            driver.FindElement(By.XPath("//a[@class='btn btn-primary']")).Click();
        }

        public void DeleteLastTask()
        {
            driver.FindElement(By.XPath("//a[@class='btn btn-danger']")).Click();
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }
    }
}

