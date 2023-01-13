using System.Net;
using System.Text.RegularExpressions;
using EASendMail;
namespace diamond
{
  public static class Email
  {
    public static bool WantToSendAnEmail()
    {
      Console.WriteLine("\nDeseja enviar o diamante por e-mail? SIM / Não");
      var sendEmail = Console.ReadLine().ToLower();

      if (sendEmail == "sim" || sendEmail == "s" || sendEmail == "yes" || sendEmail == "y" )
      {
        return true;
      }
      
      return false;
    }
    public static string GetEmailToSend()
    {
      Console.WriteLine("Digite o e-mail para o qual deseja envia.");
      while (true)
      {
        var emailTo = Console.ReadLine().ToLower();
        try
        {
          if( Regex.IsMatch(emailTo,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
          {
            return emailTo;
          }
          else Console.WriteLine("Email inválido tente novamente:");
        }
        catch (System.Exception)
        {
          Console.WriteLine("Email inválido tente novamente:");
        }
      }
    }

    public static void SendEmail(string letter, string diamond)
    {
      SmtpMail oMail = new SmtpMail("TryIt");

      oMail.From = "imarteste@outlook.com";
      oMail.To = GetEmailToSend();
      oMail.Subject = "Diamante usando a letra: " + letter + "\n";
      oMail.TextBody = diamond + Constants.SIGNATURE;
      
      SmtpServer oServer = new SmtpServer("smtp.office365.com");

      oServer.User = "imarteste@outlook.com";
      oServer.Password = "teste!@#";
      oServer.Port = 587;

      oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

      try
      {
          Console.WriteLine("Iniciando o envio do e-mail...");

          SmtpClient oSmtp = new SmtpClient();
          oSmtp.SendMail(oServer, oMail);

          Console.WriteLine("e-mail enviado com sucesso!");
      }
      catch (Exception ex)
      {
          Console.WriteLine("Exception caught in SendEmail(): {0}",
              ex.ToString());
      }
    }
  }
}