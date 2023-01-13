using Xunit;
using System.IO;
using System;
using FluentAssertions;

namespace diamond.Test;

public class TestMakeDiamond
{
    [Theory(DisplayName = "Teste se passand a letra 'd' para o método GetLetter(), as saidas adequadas.")]
    [InlineData("d\n", "Digite uma letra maior ou igual a C", "D", 1)]
    [InlineData("D\n", "Digite uma letra maior ou igual a C", "D", 1)]
    [InlineData(".\na\nd\n", "Digite uma letra maior ou igual a C", "D", 3)]
    public void TestGetLetter(string comandEntry, string stringExpected, string letterExpected, int linesCountExpected )
    {
        using (var stringWriter = new StringWriter())
        {
            using (var stringReader = new StringReader(comandEntry))
            {
                Console.SetOut(stringWriter); 
                Console.SetIn(stringReader);
                var makeDiamond = new MakeDiamond();
                var response = makeDiamond.GetLetter();
                var consoleResponse = stringWriter.ToString().Trim().Split('\n');  
                var countLinesResponse = stringWriter.ToString().Trim().Split('\n').Length;  

                response.Should().Be(letterExpected);
                consoleResponse[0].Should().Be(stringExpected);
                countLinesResponse.Should().Be(linesCountExpected);     
            }
        }
    }
    
    [Theory(DisplayName = "Teste se gera o diamante corretamente.")]
    [InlineData('C', "  A  \n B B \nC   C\n B B \n  A  \n", 5)]
    [InlineData('D', "   A   \n  B B  \n C   C \nD     D\n C   C \n  B B  \n   A   \n", 7)]
    [InlineData('E', "    A    \n   B B   \n  C   C  \n D     D \nE       E\n D     D \n  C   C  \n   B B   \n    A    \n", 9)]
    public void TestPrintDiamond(char letter, string diamond, int linesCountExpected )
    {
        using (var stringWriter = new StringWriter())
        {
            Console.SetOut(stringWriter); 
            var makeDiamond = new MakeDiamond();
            makeDiamond.Letter = letter;
            var response = makeDiamond.PrintDiamond();
            var countLinesResponse = stringWriter.ToString().Trim().Split('\n').Length;  

            response.Should().Be(diamond);
            countLinesResponse.Should().Be(linesCountExpected);     
        }
    }
}