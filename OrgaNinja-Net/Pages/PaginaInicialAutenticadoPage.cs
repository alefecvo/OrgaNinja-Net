using OpenQA.Selenium;
using System;

namespace OrgaNinja_Net.Pages
{
    public class PaginaInicialAutenticadoPage
    {
        private IWebDriver navegador;
        private IWebElement ToastMessageGeral => navegador.FindElement(By.XPath("//*[@id=\"toast-container\"]/div/div[3]"));
        private IWebElement ToastUsuarioLogado => navegador.FindElement(By.XPath("//h5[text()='Meu Plano']"));

        public PaginaInicialAutenticadoPage(IWebDriver navegador)
        {
            this.navegador = navegador;
        }

        public String CaptureToastMensagem()
        {
            return ToastMessageGeral.Text.ToString();
        }

        public String CaptureUsuarioLogado()
        {
            return ToastUsuarioLogado.Text.ToString();
        }
    }
}
