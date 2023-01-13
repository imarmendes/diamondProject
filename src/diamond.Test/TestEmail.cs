using Xunit;
using System.IO;
using System;
using FluentAssertions;

namespace diamond.Test;

public class TestEmail
{
    [Theory(DisplayName = "Testa se questiona sobre mandar ou não o e-mail e retorna um bool de acordo")]
    [InlineData("Sim\n", true, "Deseja enviar o diamante por e-mail? SIM / Não")]
    [InlineData("S\n", true, "Deseja enviar o diamante por e-mail? SIM / Não")]
    [InlineData("Yes\n", true, "Deseja enviar o diamante por e-mail? SIM / Não")]
    [InlineData("y\n", true, "Deseja enviar o diamante por e-mail? SIM / Não")]
    [InlineData("Não\n", false, "Deseja enviar o diamante por e-mail? SIM / Não")]
    [InlineData("n\n", false, "Deseja enviar o diamante por e-mail? SIM / Não")]
    [InlineData("a", false, "Deseja enviar o diamante por e-mail? SIM / Não")]
    [InlineData(".", false, "Deseja enviar o diamante por e-mail? SIM / Não")]
    public void TestWantToSendAnEmail(string comandEntry, bool expected, string stringExpected)
    {
        using (var stringWriter = new StringWriter())
        {
            using (var stringReader = new StringReader(comandEntry))
            {
                Console.SetOut(stringWriter); 
                Console.SetIn(stringReader);
                var response = Email.WantToSendAnEmail();
                var consoleResponse = stringWriter.ToString().Trim().Split('\n');
                
                response.Should().Be(expected);
                consoleResponse[0].Should().Be(stringExpected);

            }
        }
    }
    
    [Theory(DisplayName = "Testa se  o e-mail e se valida o formato do e-mail - Success")]
    [InlineData("imarteste@outloock.com", "Digite o e-mail para o qual deseja envia.")]
    public void TestGetEmailToSendSuccess(string emailEntry, string stringExpected)
    {
        using (var stringWriter = new StringWriter())
        {
            using (var stringReader = new StringReader(emailEntry))
            {
                Console.SetOut(stringWriter); 
                Console.SetIn(stringReader);
                var response = Email.GetEmailToSend();
                var consoleResponse = stringWriter.ToString().Trim().Split('\n');
                
                response.Should().Be(emailEntry);
                consoleResponse[0].Should().Be(stringExpected);
            }
        }
    }
    
    [Theory(DisplayName = "Testa se  o e-mail e se valida o formato do e-mail - Fail")]
    [InlineData("@gmail.com\nimarteste@outlook.com", "imarteste@outlook.com", "Digite o e-mail para o qual deseja envia.", "Email inválido tente novamente:")]
    [InlineData("as@.com\nimarteste@outlook.com", "imarteste@outlook.com", "Digite o e-mail para o qual deseja envia.", "Email inválido tente novamente:")]
    [InlineData("as@gmail.\nimarteste@outlook.com", "imarteste@outlook.com", "Digite o e-mail para o qual deseja envia.", "Email inválido tente novamente:")]
    [InlineData("@\nimarteste@outlook.com", "imarteste@outlook.com", "Digite o e-mail para o qual deseja envia.", "Email inválido tente novamente:")]
    public void TestGetEmailToSendFail(string emailEntry, string emailExpected, string stringInitialExpected, string stringFinalExpected)
    {
        using (var stringWriter = new StringWriter())
        {
            using (var stringReader = new StringReader(emailEntry))
            {
                Console.SetOut(stringWriter); 
                Console.SetIn(stringReader);
                var response = Email.GetEmailToSend();
                var consoleResponse = stringWriter.ToString().Trim().Split('\n');
                
                response.Should().Be(emailExpected);
                consoleResponse[0].Should().Be(stringInitialExpected);
                consoleResponse[1].Should().Be(stringFinalExpected);
            }
        }
    }
    
    [Theory(DisplayName = "Testa da função que envia o e-mail")]
    [InlineData(
        "C", 
        "  A  \n B B \nC   C\n B B \n  A  \n", 
        "imarmendes@gmail.com", 
        "Iniciando o envio do e-mail...")]
    public void TestSendEmail(
        string letter,
        string diamond,
        string emailEntry,
        string stringInitialExpected)
    {
        using (var stringWriter = new StringWriter())
        {
            using (var stringReader = new StringReader(emailEntry))
            {
                Console.SetOut(stringWriter); 
                Console.SetIn(stringReader);
                Email.SendEmail(letter, diamond);
                var consoleResponse = stringWriter.ToString().Trim().Split('\n');
                
                consoleResponse[1].Should().Be(stringInitialExpected);
            }
        }
    }
}