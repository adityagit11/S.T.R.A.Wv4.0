using System;
using System.Speech.Synthesis;
using OpenQA.Selenium;
using SpeechToTextEngine;

namespace STRAWv4._0Test.BankBazaar
{
    class HomePageClass
    {
        public static void run(RecognitionEngine recogEngine, SpeechSynthesizer synthEngine, IWebDriver driver)
        {
            recogEngine.SetGrammarFile("HomePage.txt");

            driver.Url = "https://www.bankbazaar.com/";
            
            /*
            synthEngine.SpeakAsync("choose from credit score, home loan, car loan" +
                "used car loan, personal loan, short term loan, credit card, debit card" +
                "mutual fund, life insurance, car insurance, two wheeler insurance" +
                "health insurance, savings account, fixed deposit");
            */

            reiterateIfStaticCommand:

            string command = recogEngine.GetRecognizedText(synthEngine);

            bool WhetherStaticCommand = StaticCommands.WhetherExecuted(driver, command);

            if (!WhetherStaticCommand)
            {
                switch (command)
                {
                    case "credit score":
                        driver.FindElement(By.ClassName("bbicons-cs")).Click();
                        CreditScore.CreditScore.run(recogEngine, synthEngine, driver);
                        break;
                    case "home loan":
                        driver.FindElement(By.ClassName("bbicons-hl")).Click();
                        HomeLoan.HomeLoan.run(recogEngine, synthEngine, driver);
                        break;
                    case "car loan":
                        driver.FindElement(By.ClassName("bbicons-cl")).Click();
                        CarLoan.CarLoan.run(recogEngine, synthEngine, driver);
                        break;
                    case "used car loan":
                        driver.FindElement(By.ClassName("bbicons-ucl")).Click();
                        UsedCarLoan.UsedCarLoan.run(recogEngine, synthEngine, driver);
                        break;
                    case "personal loan":
                        driver.FindElement(By.ClassName("bbicons-pl")).Click();
                        PersonalLoan.PersonalLoan.run(recogEngine, synthEngine, driver);
                        break;
                    case "short term loan":
                        driver.FindElement(By.ClassName("bbicons-stpl")).Click();
                        ShortTermLoan.ShortTermLoan.run(recogEngine, synthEngine, driver);
                        break;
                    case "credit card":
                        driver.FindElement(By.ClassName("bbicons-cc")).Click();
                        CreditCard.CreditCard.run(recogEngine, synthEngine, driver);
                        break;
                    case "debit card":
                        driver.FindElement(By.ClassName("bbicons-dc")).Click();
                        DebitCard.DebitCard.run(recogEngine, synthEngine, driver);
                        break;
                    case "mutual fund":
                        driver.FindElement(By.ClassName("bbicons-mf")).Click();
                        MutualFund.MutualFund.run(recogEngine, synthEngine, driver);
                        break;
                    case "life insurance":
                        driver.FindElement(By.ClassName("bbicons-lfi")).Click();
                        LifeInsurance.LifeInsurance.run(recogEngine, synthEngine, driver);
                        break;
                    case "car insurance":
                        driver.FindElement(By.ClassName("bbicons-ci")).Click();
                        CarInsurance.CarInsurance.run(recogEngine, synthEngine, driver);
                        break;
                    case "two wheeler insurance":
                        driver.FindElement(By.ClassName("bbicons-twi")).Click();
                        TwoWheelerInsurance.TwoWheelerInsurance.run(recogEngine, synthEngine, driver);
                        break;
                    case "health insurance":
                        driver.FindElement(By.ClassName("bbicons-hi")).Click();
                        HealthInsurance.HealthInsurance.run(recogEngine, synthEngine, driver);
                        break;
                    case "savings account":
                        driver.FindElement(By.ClassName("bbicons-acc")).Click();
                        SavingsAccount.SavingsAccount.run(recogEngine, synthEngine, driver);
                        break;
                    case "fixed deposit":
                        driver.FindElement(By.ClassName("bbicons-fd")).Click();
                        FixedDeposit.FixedDeposit.run(recogEngine, synthEngine, driver);
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
