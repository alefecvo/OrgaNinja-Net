using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace OrgaNinja_Net.Suporte
{
    public class Instance
    {
        public IWebDriver navegador;
        public Instance(IWebDriver navegador)
        {
            this.navegador = navegador;
        }

        public static IWebDriver CreateChrome()
        {
            IWebDriver navegador = new ChromeDriver();
            navegador.Navigate().GoToUrl("http://organinja.herokuapp.com/");
            navegador.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return navegador;
        }

        public static void FinalizarChrome(IWebDriver navegador)
        {
            //navegador.Quit();
        }
    }
}
