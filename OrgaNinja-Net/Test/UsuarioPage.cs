using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OrgaNinja_Net.Suporte;
using OrgaNinja_Net.Pages;

namespace OrgaNinja_Net
{
    [TestClass]
    public class UsuarioPage
    {
        public IWebDriver navegador;
        public static String mensagemUsuarioExistente = "Já existe um usuário cadastrado com o email informado.";
        public static String mensagemNomeNaoPreenchido = "Você precisa informar seu nome completo.";
        public static String mensagemEmailNaoPreenchido = "Você precisa informar seu email.";
        public static String mensagemSenhaNaoPreenchido = "Você precisa informar uma senha.";

        [TestInitialize]
        public void IniciarExecucao()
        {
            navegador = Instance.CreateChrome();
        }

        [TestMethod]
        public void TestValidarRealizarCadastroNovoUsuario()
        {
            String resposta = new PaginaInicialPage(navegador)
                    .CliqueLogin()
                    .ComeceUsar()
                    .CadastrarUsuario("Álefe ES", "alefecardozo@hotmail.com.es", "123456")
                    .CaptureUsuarioLogado();

            Assert.AreEqual("Meu Plano", resposta);
        }

        [TestMethod]
        public void TestValidarRealizarCadastroUsuarioExistente()
        {
            String resposta = new PaginaInicialPage(navegador)
                    .CliqueLogin()
                    .ComeceUsar()
                    .CadastrarUsuario("Álefe", "alefecardozo@hotmail.com", "123456")
                    .CaptureToastMensagem();

            Assert.AreEqual(mensagemUsuarioExistente, resposta);
        }

        [TestMethod]
        public void TestValidarCamposObrigatoriosNomeNaoPreenchidos()
        {
            String respostaNomeNaoPreenchido = new PaginaInicialPage(navegador)
                    .CliqueLogin()
                    .ComeceUsar()
                    .CadastrarUsuario("", "alefecardozo@hotmai.com", "123456")
                    .CaptureToastMensagem();

            Assert.AreEqual(mensagemNomeNaoPreenchido, respostaNomeNaoPreenchido);
        }

        [TestMethod]
        public void TestValidarRealizarCamposObrigatoriosEmailNaoPreenchidos()
        {
            String respostaEmailNaoPreenchido = new PaginaInicialPage(navegador)
                    .CliqueLogin()
                    .ComeceUsar()
                    .CadastrarUsuario("Álefe", "", "123456")
                    .CaptureToastMensagem();

            Assert.AreEqual(mensagemEmailNaoPreenchido, respostaEmailNaoPreenchido);
        }

        [TestMethod]
        public void TestValidarRealizarCamposObrigatoriosSenhaNaoPreenchidos()
        {
            String respostaSenhaNaoPreenchida = new PaginaInicialPage(navegador)
                    .CliqueLogin()
                    .ComeceUsar()
                    .CadastrarUsuario("Álefe", "alefecardozo@hotmai.com", "")
                    .CaptureToastMensagem();

            Assert.AreEqual(mensagemSenhaNaoPreenchido, respostaSenhaNaoPreenchida);
        }

        [TestCleanup]
        public void FinalizarExecucao()
        {
            Instance.FinalizarChrome(navegador);
        }
    }
}
