using OpenQA.Selenium;


namespace OrgaNinja_Net.Pages
{
    public class PaginaInicialPage
    {
        private IWebDriver navegador;
        private IWebElement BtnLogin => navegador.FindElement(By.LinkText("LOGIN"));

        public PaginaInicialPage(IWebDriver navegador)
        {
            this.navegador = navegador;
        }

        public LoginPage CliqueLogin()
        {
            BtnLogin.Click();
            return new LoginPage(navegador);
        }
    }
}
