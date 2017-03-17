using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CosmicCakes.Services.SmsService
{
    public class SmsSender : ISmsSender
    {
        public void SendSmsOrder(string message,bool error = false)
        {
            const string accountSid = "ACb060bfe322862f4ca58e9c2597859355";
            const string authToken = "78799b727da12748949fa5c87b480d6f";
            TwilioClient.Init(accountSid, authToken);

            if (!error)
            {
                try
                {
                    MessageResource.Create(
                       from: new PhoneNumber("(415)360-3856"),
                       to: new PhoneNumber("+79062558810"),
                       body: "\n" + message);

                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                try
                {
                    MessageResource.Create(
                       from: new PhoneNumber("(415)360-3856"),
                       to: new PhoneNumber("+79697137351"),
                       body: "\n" + message);

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        
    }
}
