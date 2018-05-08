using OpenQA.Selenium;

namespace OrgaNinja_Net.Pages
{
    public class UsuarioPage
    {
        private IWebDriver navegador;
        private IWebElement TxtNome => navegador.FindElement(By.Name("registerName"));
        private IWebElement TxtEmail => navegador.FindElement(By.Name("registerEmail"));
        private IWebElement TxtSenha => navegador.FindElement(By.Name("registerPassword"));
        private IWebElement BtnComeceUsar => navegador.FindElement(By.XPath("//button[text()='Começar a usar :)']"));

        public UsuarioPage(IWebDriver navegador)
        {
            this.navegador = navegador;
        }

        private void PreencherNome(string nome)
        {
            TxtNome.SendKeys(nome);
        }

        private void PreencherEmail(string email)
        {
            TxtEmail.SendKeys(email);
        }

        private void PreencherSenha(string senha)
        {
            TxtSenha.SendKeys(senha);
        }

        private void CliqueComeceUsar()
        {
            BtnComeceUsar.Click();
        }

        public PaginaInicialPage ComeceUsar()
        {
            CliqueComeceUsar();
            return new PaginaInicialPage(navegador);
        }

        public PaginaInicialAutenticadoPage CadastrarUsuario(string nome, string email, string senha)
        {
            PreencherNome(nome);
            PreencherEmail(email);
            PreencherSenha(senha);
            CliqueComeceUsar();
            return new PaginaInicialAutenticadoPage(navegador);
        }
    }
}
