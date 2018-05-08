using System;
using OpenQA.Selenium;

namespace OrgaNinja_Net.Pages
{
    public class LoginPage
    {
        private IWebDriver navegador;
        private IWebElement TxtEmail => navegador.FindElement(By.Name("loginEmail"));
        private IWebElement TxtSenha => navegador.FindElement(By.Name("loginPassword"));
        private IWebElement BtnEntrar => navegador.FindElement(By.XPath("//button[text()='Entrar']"));
        private IWebElement BtnComeceUsar => navegador.FindElement(By.XPath("//a[text()='Começe agora mesmo']"));

        public LoginPage(IWebDriver navegador)
        {
            this.navegador = navegador;
        }

        private void PreencherEmail(String login)
        {
            TxtEmail.SendKeys(login);
        }

        private void PreencherSenha(String senha)
        {
            TxtSenha.SendKeys(senha);
        }

        private void CliqueEntrar()
        {
            BtnEntrar.Click();
        }

        private void CliqueComeceUsar()
        {
            BtnComeceUsar.Click();
        }

        public PaginaInicialAutenticadoPage RealizarLogin(String login, String senha)
        {
            PreencherEmail(login);
            PreencherSenha(senha);
            CliqueEntrar();
            return new PaginaInicialAutenticadoPage(navegador);
        }

        public UsuarioPage ComeceUsar()
        {
            CliqueComeceUsar();
            return new UsuarioPage(navegador);
        }

    }
}
