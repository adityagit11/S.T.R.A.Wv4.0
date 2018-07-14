using System;
using System.Speech.Synthesis;
using OpenQA.Selenium;
using SpeechToTextEngine;

namespace STRAWv4._0Test.BankBazaar.FixedDeposit
{
    class Salary
    {
        public static void run(RecognitionEngine recogEngine, SpeechSynthesizer synthEngine, IWebDriver driver)
        {
            //synthEngine.Speak("what is you net monthly salary, enter one digit at a time");

            reiterateIfStaticCommand:

            //synthEngine.Speak("If done speak click continue");

            string command = recogEngine.GetRecognizedText(synthEngine);

            bool WhetherStaticCommand = StaticCommands.WhetherExecuted(driver, command);

            if (!WhetherStaticCommand)
            {
                switch (command)
                {
                    case "number one":
                        driver.FindElement(By.CssSelector("input[name='netMonthlyIncome']")).SendKeys("1");
                        goto reiterateIfStaticCommand;
                    case "number two":
                        driver.FindElement(By.CssSelector("input[name='netMonthlyIncome']")).SendKeys("2");
                        goto reiterateIfStaticCommand;
                    case "number three":
                        driver.FindElement(By.CssSelector("input[name='netMonthlyIncome']")).SendKeys("3");
                        goto reiterateIfStaticCommand;
                    case "number four":
                        driver.FindElement(By.CssSelector("input[name='netMonthlyIncome']")).SendKeys("4");
                        goto reiterateIfStaticCommand;
                    case "number five":
                        driver.FindElement(By.CssSelector("input[name='netMonthlyIncome']")).SendKeys("5");
                        goto reiterateIfStaticCommand;
                    case "number six":
                        driver.FindElement(By.CssSelector("input[name='netMonthlyIncome']")).SendKeys("6");
                        goto reiterateIfStaticCommand;
                    case "number seven":
                        driver.FindElement(By.CssSelector("input[name='netMonthlyIncome']")).SendKeys("7");
                        goto reiterateIfStaticCommand;
                    case "number eight":
                        driver.FindElement(By.CssSelector("input[name='netMonthlyIncome']")).SendKeys("8");
                        goto reiterateIfStaticCommand;
                    case "numberoo nine":
                        driver.FindElement(By.CssSelector("input[name='netMonthlyIncome']")).SendKeys("9");
                        goto reiterateIfStaticCommand;
                    case "click continue":
                        driver.FindElement(By.ClassName("btn-large")).Click();
                        Gender.run(recogEngine, synthEngine, driver);
                        break;
                    default:
                        break;
                }
            }
            else
                goto reiterateIfStaticCommand;
        }
    }
}
