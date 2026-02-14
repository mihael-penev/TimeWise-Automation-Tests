using NUnit.Framework;
using TimeWiseTests.Base;
using TimeWiseTests.Pages;
using TimeWiseTests.Utils;

namespace TimeWiseTests.Tests
{
    [TestFixture]
    public class TaskTests : BaseTest
    {
        private static string lastTaskName;
        private static string lastTaskDescription;

        private LoginPage loginPage;
        private CreateTaskPage createTaskPage;
        private ToDoPage toDoPage;

        [SetUp]
        public void TestSetup()
        {
            loginPage = new LoginPage(driver);
            createTaskPage = new CreateTaskPage(driver);
            toDoPage = new ToDoPage(driver);

            loginPage.NavigateToLogin();
            loginPage.Login("misho123@123.bg", "misho123");
        }

        //1? Negative create test
        [Test, Order(1)]
        public void AddTaskWithoutNameTest()
        {
            createTaskPage.Navigate();
            createTaskPage.CreateTask("", "");

            Assert.That(driver.Url.EndsWith("/Task/Create"), Is.True);
        }

        //2? Positive create test
        [Test, Order(2)]
        public void AddTaskWithRandomNameTest()
        {
            lastTaskName = "Task_" + RandomDataGenerator.RandomString(6);
            lastTaskDescription = "Task description: " + RandomDataGenerator.RandomString(20);

            createTaskPage.Navigate();
            createTaskPage.CreateTask(lastTaskName, lastTaskDescription);

            Assert.That(driver.Url.EndsWith("/Task/ToDo"), Is.True);
            Assert.That(toDoPage.GetLastTaskTitle(), Is.EqualTo(lastTaskName));
        }

        //3? Edit test
        [Test, Order(3)]
        public void EditLastAddedTaskTest()
        {
            driver.Navigate().GoToUrl(baseUrl + "/Task/ToDo");

            string editedName = "Edited: " + lastTaskName;
            toDoPage.EditLastTask(editedName);

            Assert.That(toDoPage.GetLastTaskTitle(), Is.EqualTo(editedName));

            lastTaskName = editedName;
        }

        //4? Move test
        [Test, Order(4)]
        public void MoveLastAddedTaskTest()
        {
            driver.Navigate().GoToUrl(baseUrl + "/Task/ToDo");

            string taskName = toDoPage.GetLastTaskTitle();

            toDoPage.MoveLastTask();

            Assert.That(driver.PageSource.Contains(taskName), Is.False);
        }

        //5? Delete test
        [Test, Order(5)]
        public void DeleteLastAddedTaskTest()
        {
            driver.Navigate().GoToUrl(baseUrl + "/Task/InProgress");

            string taskName = toDoPage.GetLastTaskTitle();

            toDoPage.DeleteLastTask();

            Assert.That(driver.PageSource.Contains(taskName), Is.False);

            driver.Navigate().GoToUrl(baseUrl + "/Task/ToDo");
            Assert.That(driver.PageSource.Contains(taskName), Is.False);
        }
    }
}
