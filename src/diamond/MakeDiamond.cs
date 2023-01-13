using System.Text;

namespace diamond
{
    public class MakeDiamond
    {
      public char Letter { get; set; }

      public string GetLetter()
      {
        while (true)
        {
          Console.WriteLine("Digite uma letra maior ou igual a C");
          var letterReceive = Console.ReadLine();
          
          if (letterReceive is null || letterReceive.Length != 1) continue;

          Letter = Char.Parse(letterReceive.ToUpper());

          if (!Char.IsLetter(Letter) || (int)Letter  < Constants.LETTER_C_IN_ASCII ) continue;

          return Letter.ToString();
        }
      }

      public string PrintDiamond()
      {
        int START_LETTERS_IN_ASCII = Constants.LETTER_A_IN_ASCII;
        int POSITION_LETTER = (int)Letter - START_LETTERS_IN_ASCII + 1;
        int middle = 1;
        var result = new String[POSITION_LETTER * 2 - 1];

        for (int i = 0; i < POSITION_LETTER; i++)
        {
          var word = new String[5];

          word[0] = "".PadLeft(POSITION_LETTER - 1 - i, ' ');
          word[1] = Convert.ToChar(START_LETTERS_IN_ASCII + i).ToString();
          if (i != 0) 
          {
            word[2] = "".PadLeft(middle, ' ');
            middle += 2;
            word[3] = Convert.ToChar(START_LETTERS_IN_ASCII + i).ToString();
          } 
          word[4] = "".PadLeft(POSITION_LETTER - 1 - i, ' ');


          result[i] = String.Join("", word) + "\n";
          result[POSITION_LETTER * 2 - 2 -i] = String.Join("", word) + "\n";
        }

        var diamond = String.Join("", result);
        Console.WriteLine(diamond);

        return diamond;
      }
    }
}