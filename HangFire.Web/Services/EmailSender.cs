
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HangFire.Web.Services
{
	public class EmailSender : IEmailSender
	{
		private readonly IConfiguration _configuration;

		public EmailSender(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task Sender(string userId, string message)
		{
			var apiKey = _configuration.GetSection("APIs")["SendGridApi"];
			/* var options = new SendGridClientOptions
            {
                ApiKey = apiKey
            };
            options.SetDataResidency("eu"); 
            var client = new SendGridClient(options); */
			// uncomment the above 6 lines if you are sending mail using a regional EU subuser
			// and remove the client declaration just below
			var client = new SendGridClient(apiKey);
			var from = new EmailAddress("ulasaktas882@gmail.com", "Example User");
			var subject = "www.mysite.com bilgilendirme";
			var to = new EmailAddress("traversal5353@gmail.com", "Example User");
			//var plainTextContent = "and easy to do anywhere, even with C#";
			var htmlContent = $"<strong>{message}</strong>";
			var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
			 await client.SendEmailAsync(msg);
		}
	}
}
