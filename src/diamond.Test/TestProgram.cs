using Xunit;
using System.IO;
using System;
using FluentAssertions;

namespace diamond.Test;

public class TestProgram
{
    [Theory(DisplayName = "Teste se passando a letra D, gera a quantidade de linhas esperada.")]
    [InlineData("d\nNão\nNão\n", 13)]
    [InlineData("d\nSim\nimarmende@gmail.com\nNão\n", 21)]
    [InlineData("d\nNão\nSim\n", 15)]
    public void TestConsoleIntefaceCountLines(string comandEntry, int linesCountExpected )
    {
        using (var stringWriter = new StringWriter())
        {
            using (var stringReader = new StringReader(comandEntry))
            {
                Console.SetOut(stringWriter); 
                Console.SetIn(stringReader); 
                Program.Main();
                var consoleResponse = stringWriter.ToString().Trim().Split('\n').Length;  
                consoleResponse.Should().Be(linesCountExpected);     
            }
        }
    }
}