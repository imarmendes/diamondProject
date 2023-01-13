using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace diamond;

public class PdfCreator
{
   public static bool wantToCreateAnPdf()
   {
      Console.WriteLine("\nDeseja criar um PDF como o diamante gerado? SIM / Não");
      var createPdf = Console.ReadLine().ToLower();

      if (createPdf == "sim" || createPdf == "s" || createPdf == "yes" || createPdf == "y" )
      {
         return true;
      }

      return false;
   }
   public static void PdfGenerator(string letter, string diamond)
   {
      var doc = new Document();
      PdfWriter.GetInstance(doc, new FileStream(@"../../../diamonds/DiamondWithLetter" + letter + ".pdf", FileMode.Create));
      
      doc.Open();
      doc.Add(new Paragraph("Diamante criado com a letra " + letter + "\n"));
      doc.Add(new Paragraph(diamond  + Constants.SIGNATURE));
      doc.Close();
      
      Console.WriteLine("\nPDF criado com sucesso!");
   }
}