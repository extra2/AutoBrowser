using System;
using System.Threading;
using OpenQA.Selenium;

namespace AutoBrowser
{
    public class Operation : IOperation
    {
        public bool Click(IWebDriver driver, char FindByType, string FindBy)
        {
            By by = CreateBy(FindByType, FindBy);
            try
            {
                driver.FindElement(by).Click();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool SendKeys(IWebDriver driver, char FindByType, string FindBy, string TypeText)
        {
            By by = CreateBy(FindByType, FindBy);
            try
            {
                driver.FindElement(by).SendKeys(TypeText);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool IfVisible(IWebDriver driver, char FindByType, string FindBy)
        {
            By by = CreateBy(FindByType, FindBy);
            try
            {
                driver.FindElement(by);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool WaitFor(IWebDriver driver, char FindByType, string FindBy)
        {
            By by = CreateBy(FindByType, FindBy);
            while (true) // TODO: add timeout
            {
                try
                {
                    driver.FindElement(by);
                    return true;
                }
                catch (Exception)
                {
                    Thread.Sleep(100);
                }
            }
            return true; // for compiler
        }

        public bool Wait(int TimeInMs)
        {
            Thread.Sleep(TimeInMs);
            return true;
        }

        public bool GoToPage(IWebDriver driver, string URL)
        {
            try
            {
                driver.Navigate().GoToUrl(URL);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private By CreateBy(char findByType, string findBy)
        {
            By by = null;
            switch (findByType)
            {
                case 'i':
                    by = By.Id(findBy);
                    break;
                case 'c':
                    by = By.ClassName(findBy);
                    break;
                case 'x':
                    by = By.XPath(findBy);
                    break;
                case 'n':
                    by = By.Name(findBy);
                    break;
                case 'l':
                    by = By.LinkText(findBy);
                    break;
                case 't':
                    by = By.TagName(findBy);
                    break;
            }
            return by;
        }
    }
}