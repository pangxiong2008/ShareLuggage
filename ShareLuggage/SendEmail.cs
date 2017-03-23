using System;
using System.Configuration;
using System.Text;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;

namespace ShareLuggage.Email
{
    abstract class Email
    {
        abstract public void Create_draft();
        abstract public void Send_Email();
      
    }
    class Email_raw
    {
         // clientSecret = "dfDfdOJeobb1x0VNrTDHsEGO";
        public string senderName { get; set; }
        public string senderAddress { get; set; }
        public string receiverName { get; set; }
        public string receiverAddress { get; set; }
        public string subject { set; get; }
        public string body { set; get; }
    }

      

   
    class EmailConfig
    {
        public string clientId { get; set; }
        //public string clientId = "739330450434-e4cq0bonlglucdnmodofbjg09qj26u36.apps.googleusercontent.com";
        public string clientSecret { get; set; }
        public string ApplicationName { get; set; }
        public UserCredential credential { get; set; }
        public GmailService service { get; set; }
    }


    class Send_Gmail
    {
        private void send(Email_raw _Email_raw)
        {
            EmailConfig _EmailConfig = new EmailConfig();
           // Email_raw _Email_raw = new Email_raw();

            _EmailConfig.clientId = "739330450434-e4cq0bonlglucdnmodofbjg09qj26u36.apps.googleusercontent.com";
            //  var clientSecret = ConfigurationManager.AppSettings["ClientSecret"];
            _EmailConfig.clientSecret = "dfDfdOJeobb1x0VNrTDHsEGO";
            //var senderName = ConfigurationManager.AppSettings["EmailSenderName"];
            //var senderAddress = ConfigurationManager.AppSettings["EmailSenderAddress"];
            //var receiverName = ConfigurationManager.AppSettings["EmailReceiverName"];
            //var receiverAddress = ConfigurationManager.AppSettings["EmailReceiverAddress"];

            try
            {
                _EmailConfig.credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets
                    {
                        ClientId = _EmailConfig.clientId,
                        ClientSecret = _EmailConfig.clientSecret,
                    },
                    new[] { GmailService.Scope.GmailCompose },
                    "user",
                    CancellationToken.None).Result;

                _EmailConfig.service = new GmailService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = _EmailConfig.credential,
                    ApplicationName = "Gmail API",
                });

                // only the raw parameter of the message resource needs set, see: http://stackoverflow.com/questions/24460422/how-to-send-a-message-successfully-using-the-new-gmail-rest-api
                // from that there is a working example in the RFC 2822nspecification: "From: John Doe <jdoe@machine.example>\nTo: Mary Smith <mary@example.net>\nSubject: Saying Hello\nDate: Fri, 21 Nov 1997 09:55:06 -0600\nMessage-ID: <1234@local.machine.example>\n\nThis is a message just to say hello.\nSo, \"Hello\".";
                // use that as a working base
                // the values Date and Message-ID have no bearing on the final email (or didn't to me) so have keep them as placeholders and haven't tried to replace them

               // const string subject = "Email Subject";

                // there are some issues around the body encoding/decoding
                // this message decoded will have a '5' at the end
                // a full stop at the end will make an invalid raw parameter
                // but this was good enough for my purposes...
                //const string body = "Hello this is an email wriien by a very simple console application";
                //senderName = "51ShareLuggage";
                //senderAddress = "51ShareLuggage@gmail.com";
                //receiverName = "pangxiong";
                //receiverAddress = "wuxiaonong@gmail.com";
                // format the message
                var text = string.Format("From: {0} <{1}>\nTo: {2} <{3}>\nSubject: {4}\nDate: Fri, 21 Nov 1997 09:55:06 -0600\nMessage-ID: <1234@local.machine.example>\n\n{5}",
                    senderName,
                    senderAddress,
                    receiverName,
                    receiverAddress,
                    subject,
                    body);

                Console.WriteLine("Send email:\n{0}", text);

                // must be base64 encoded but also web safe and also initially UTF8
                // http://stackoverflow.com/questions/24460422/how-to-send-a-message-successfully-using-the-new-gmail-rest-api
                // http://stackoverflow.com/questions/13017703/java-and-net-base64-conversion-confusion
                var encodedText = System.Web.HttpServerUtility.UrlTokenEncode(Encoding.UTF8.GetBytes(text));

                Console.WriteLine("Raw email:\n{0}", encodedText);

                var message = new Message { Raw = encodedText };

                var request = service.Users.Messages.Send(message, "me").Execute();

                Console.WriteLine(
                    string.IsNullOrEmpty(request.Id) ? "Issue sending, returned id: {0}" : "Email looks good, id populated: {0}",
                    request.Id);



            }
       
            }
          
    }
