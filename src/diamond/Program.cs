namespace diamond
{
    public class Program
    {
        public static void Main()
        {
          var makeDiamond = new MakeDiamond();
          var letter = makeDiamond.GetLetter();
          var diamond = makeDiamond.PrintDiamond();

          if (Email.WantToSendAnEmail())
          {
              Email.SendEmail(letter, diamond);
          }
          
          if (PdfCreator.wantToCreateAnPdf())
          {
              PdfCreator.PdfGenerator(letter, diamond);
          }
        }
    }
}