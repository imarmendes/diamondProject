using Xunit;
using System.IO;
using System;
using FluentAssertions;

namespace diamond.Test;

public class TestPdfCreator
{
    [Theory(DisplayName = "Testa se questiona sobre criar ou não o PDF e retorna um bool de acordo")]
    [InlineData("Sim\n", true, "Deseja criar um PDF como o diamante gerado? SIM / Não")]
    [InlineData("S\n", true, "Deseja criar um PDF como o diamante gerado? SIM / Não")]
    [InlineData("Yes\n", true, "Deseja criar um PDF como o diamante gerado? SIM / Não")]
    [InlineData("y\n", true, "Deseja criar um PDF como o diamante gerado? SIM / Não")]
    [InlineData("Não\n", false, "Deseja criar um PDF como o diamante gerado? SIM / Não")]
    [InlineData("n\n", false, "Deseja criar um PDF como o diamante gerado? SIM / Não")]
    [InlineData("a", false, "Deseja criar um PDF como o diamante gerado? SIM / Não")]
    [InlineData(".", false, "Deseja criar um PDF como o diamante gerado? SIM / Não")]
    public void TestWantToSendAnEmail(string comandEntry, bool expected, string stringExpected)
    {
        using (var stringWriter = new StringWriter())
        {
            using (var stringReader = new StringReader(comandEntry))
            {
                Console.SetOut(stringWriter); 
                Console.SetIn(stringReader);
                var response = PdfCreator.wantToCreateAnPdf();
                var consoleResponse = stringWriter.ToString().Trim().Split('\n');
                
                response.Should().Be(expected);
                consoleResponse[0].Should().Be(stringExpected);

            }
        }
    }
    
    [Theory(DisplayName = "Testa se o PDF foi criado com sucesso.")]
    [InlineData("C", 
        "  A  \n B B \nC   C\n B B \n  A  \n", 
        "PDF criado com sucesso!")]
    public void TestPdfGenerator(
        string letter,
        string diamond,
        string stringExpected)
    {
        using (var stringWriter = new StringWriter())
        {
            Console.SetOut(stringWriter); 
            PdfCreator.PdfGenerator(letter, diamond);
            var consoleResponse = stringWriter.ToString().Trim().Split('\n');
            
            consoleResponse[0].Should().Be(stringExpected);
        }
    }
}