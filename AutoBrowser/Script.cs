using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.PhantomJS;

namespace AutoBrowser
{
    public class Script : IScript
    {
        private string[] _instructions;
        public bool IsValid = true;
        private IWebDriver driver = null;
        private Operation operation = new Operation();
        public Script(string[] instructions)
        {
            if (VerifyScript(instructions))
            {
                _instructions = instructions;
            }
            else
            {
                IsValid = false;
            }
        }

        public bool ExecuteScript()
        {
            InitDriver(); // init section
            RunScript(); // program section
            return true;
        }

        public bool RunScript() // prepare program script
        {
            int iterator = 0;
            while (_instructions[iterator].Split(' ')[0] != "program") iterator++;
            iterator++;// program +1
            List<string> instList = new List<string>();
            while (_instructions[iterator].Split(' ')[0] != "endprogram")
            {
                instList.Add(_instructions[iterator]);
                iterator++;
            }
            RunSequence(instList.ToArray(), 1);
            return true;
        }

        public bool RunSequence(string[] sequence, int times) // run sequence n times (as for loop OR as if() -> run one time)
        {
            for (int i = 0; i < times; i++)
            {
                for(int iterator = 0; iterator < sequence.Length;)
                {
                    switch (sequence[iterator].Split(' ')[0])
                    {
                        case "goto":
                            driver.Url = sequence[iterator].Split(' ')[1];
                            break;
                        case "sendtext":
                            operation.SendKeys(driver, sequence[iterator].Split(' ')[1][0],
                                sequence[iterator].Split(' ')[2],
                                sequence[iterator].Substring(sequence[iterator].IndexOf(sequence[iterator].Split(' ')[2]) + sequence[iterator].Split(' ')[2].Length)); // for now only one word
                            break;
                        case "clickon":
                            operation.Click(driver, sequence[iterator].Split(' ')[1][0],
                                sequence[iterator].Split(' ')[2]);
                            break;
                        case "wait":
                            operation.Wait(Int32.Parse(sequence[iterator].Split(' ')[1]));
                            break;
                        case "waitfor":
                            operation.WaitFor(driver, sequence[iterator].Split(' ')[1][0],
                                sequence[iterator].Split(' ')[2]);
                            break;
                        case "exit":
                            driver.Dispose();
                            return true;
                        case "loop": // for loop; it can be used as loop inside loop; works as recursion
                            int loopTimes = Int32.Parse(sequence[iterator].Split(' ')[1]);
                            List<string> loopSequence = new List<string>();
                            iterator++;
                            int moreLoops = 0;
                            while (sequence[iterator].Split(' ')[0] != "endloop" || moreLoops != -1)
                            {
                                loopSequence.Add(sequence[iterator]);
                                iterator++;
                                if (sequence[iterator].Split(' ')[0] == "loop") moreLoops++;
                                else if (sequence[iterator].Split(' ')[0] == "endloop")
                                {
                                    moreLoops--;
                                    loopSequence.Add(sequence[iterator]);
                                }
                            }
                            RunSequence(loopSequence.ToArray(), loopTimes);
                            break;
                        case "ifvisible": // if element is visible; runs as recursion
                            if (operation.IfVisible(driver, sequence[iterator].Split(' ')[1][0], sequence[iterator].Split(' ')[2]))
                            {
                                List<string> loopSequenceIf = new List<string>();
                                iterator++;
                                while (sequence[iterator].Split(' ')[0] != "endif")
                                {
                                    loopSequenceIf.Add(sequence[iterator]);
                                    iterator++;
                                }
                                RunSequence(loopSequenceIf.ToArray(), 1);
                            }
                            break;
                        case "break": // ends current sequence, does not dispose driver
                            return true;
                        default:
                            break;

                    }
                    iterator++;
                }
            }
            return true;
        }
        public bool InitDriver() // init section
        {
            int timeout = 60;
            int iterator = 0;
            char browser = 'c';
            bool hideDebugConsole = false;
            if (!_instructions[0].Contains("init")) return false;
            while (_instructions[iterator].Split(' ')[0] != "program")
            {
                switch (_instructions[iterator].Split(' ')[0])
                {
                    case "debugconsole":
                        if (_instructions[iterator].Split(' ')[1] == "off") hideDebugConsole = true;//service.HideCommandPromptWindow = true;
                        break;
                    case "timeout":
                         timeout = Int32.Parse(_instructions[iterator].Split(' ')[1]);
                        break;
                    case "browser":
                        if (_instructions[iterator].Split(' ')[1] == "chrome") browser = 'c';
                        else if (_instructions[iterator].Split(' ')[1] == "firefox") browser = 'f';
                        else if (_instructions[iterator].Split(' ')[1] == "phantomjs") browser = 'p';
                        break;
                    default:
                        break;
                }
                iterator++;
            }
            switch (browser)
            {
                case 'c':
                    ChromeDriverService c_service = ChromeDriverService.CreateDefaultService();
                    c_service.HideCommandPromptWindow = hideDebugConsole;
                    driver = new ChromeDriver(c_service);
                    break;
                case 'f':
                    FirefoxDriverService f_service = FirefoxDriverService.CreateDefaultService();
                    f_service.HideCommandPromptWindow = hideDebugConsole;
                    driver = new FirefoxDriver(f_service);
                    break;
                case 'p':
                    PhantomJSDriverService p_service = PhantomJSDriverService.CreateDefaultService();
                    p_service.HideCommandPromptWindow = hideDebugConsole;
                    driver = new PhantomJSDriver(p_service);
                    break;
            }
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeout);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
            return true;
        }

        public bool VerifyScript(string[] instructions)
        {
            // todo - check sctipt for errors etc
            return true;
        }
    }
}