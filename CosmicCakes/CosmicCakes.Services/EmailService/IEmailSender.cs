namespace CosmicCakes.Services.EmailService
{
    public interface IEmailSender
    {
        void SendEmailOrder(string message);
    }
}
