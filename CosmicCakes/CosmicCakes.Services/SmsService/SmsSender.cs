using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Newtonsoft.Json;

namespace CosmicCakes.Services.SmsService
{
    public class SmsSender : ISmsSender
    {
        public void SendSmsOrder(string message)
        {
            const string accountSid = "ACb060bfe322862f4ca58e9c2597859355";
            const string authToken = "78799b727da12748949fa5c87b480d6f";

            TwilioClient.Init(accountSid, authToken);
            MessageResource.Create(
                    from: new PhoneNumber("(415)360-3856"),
                    to: new PhoneNumber("+79062558810"),
                    body: message);

        }
    }
}
