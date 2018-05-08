using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OrgaNinja_Net.Suporte;
using OrgaNinja_Net.Pages;

namespace OrgaNinja_Net
{
    [TestClass]
    public class LoginTest
    {
        public IWebDriver navegador;
        public static String mensagemInformarEmail = "Você precisa informar seu email.";
        public static String mensagemUsuarioNaoCadastrado = "Usuário não cadastrado.";
        public static String mensagemSenhaInvalida = "Senha inválida.";

        [TestInitialize]
        public void IniciarExecucao()
        {
            navegador = Instance.CreateChrome();
        }

        [TestMethod]
        public void TestValidarRealizarLoginCamposNaoPreenchidos()
        {
            String resposta = new PaginaInicialPage(navegador)
                    .CliqueLogin()
                    .RealizarLogin("", "")
                    .CaptureToastMensagem();

            Assert.AreEqual(mensagemInformarEmail, resposta);
        }

        [TestMethod]
        public void TestValidarRealizarLoginUsuarioSenhaCorreta()
        {
            String resposta = new PaginaInicialPage(navegador)
                    .CliqueLogin()
                    .RealizarLogin("alefecardozo@hotmail.com", "123456")
                    .CaptureUsuarioLogado();

            Assert.AreEqual("Meu Plano", resposta);
        }

        [TestMethod]
        public void TestValidarRealizarLoginUsuarioIncorreto()
        {
            String resposta = new PaginaInicialPage(navegador)
                    .CliqueLogin()
                    .RealizarLogin("alefecardozo@hotmail.com.br", "123456")
                    .CaptureToastMensagem();

            Assert.AreEqual(mensagemUsuarioNaoCadastrado, resposta);
        }

        [TestMethod]
        public void TestValidarRealizarLoginSenhaIncorreta()
        {
            String resposta = new PaginaInicialPage(navegador)
                    .CliqueLogin()
                    .RealizarLogin("alefecardozo@hotmail.com", "1234567")
                    .CaptureToastMensagem();

            Assert.AreEqual(mensagemSenhaInvalida, resposta);
        }

        [TestMethod]
        public void TestValidarRealizarLoginUsuarioESenhaIncorreta()
        {
            String resposta = new PaginaInicialPage(navegador)
                    .CliqueLogin()
                    .RealizarLogin("alefecardozo@hotmail.com.br", "1234567")
                    .CaptureToastMensagem();
            Assert.AreEqual(mensagemUsuarioNaoCadastrado, resposta);
        }

        [TestMethod]
        public void TestValidarRealizarLoginUsuarioOuSenhaIncorreta()
        {
            String resposta = new PaginaInicialPage(navegador)
                    .CliqueLogin()
                    .RealizarLogin("alefecardozo@hotmail.com.br", "123456")
                    .CaptureToastMensagem();
            Assert.AreEqual(mensagemUsuarioNaoCadastrado, resposta);
        }

        [TestCleanup]
        public void FinalizarExecucao()
        {
            Instance.FinalizarChrome(navegador);
        }

    }
}
