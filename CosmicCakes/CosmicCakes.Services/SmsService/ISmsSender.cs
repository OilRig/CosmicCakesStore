﻿namespace CosmicCakes.Services.SmsService
{
    public interface ISmsSender
    {
        void SendSmsOrder(string message);
    }
}
