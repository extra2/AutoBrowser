using OpenQA.Selenium;

namespace AutoBrowser
{
    public interface IOperation
    {
        bool Click(IWebDriver driver, char FindByType, string FindBy);
        bool SendKeys(IWebDriver driver, char FindByType, string FindBy, string TypeText);
        bool IfVisible(IWebDriver driver, char FindByType, string FindBy);
        bool WaitFor(IWebDriver driver, char FindByType, string FindBy);
        bool Wait(int TimeInMs);
        bool GoToPage(IWebDriver driver, string URL);
    }
}