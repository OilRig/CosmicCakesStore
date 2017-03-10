using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CosmicCakes.Logging.Interfaces;
using CosmicCakes.Services.EmailService;
using CosmicCakes.Services.SmsService;

namespace CosmicCakes.Controllers
{
    public class AppServiceController : Controller
    {
        protected readonly IAppLogger Logger;
        protected readonly IEmailSender EmailSender;
        protected readonly ISmsSender SmsSender;

        public AppServiceController(IAppLogger logger, IEmailSender emailSender, ISmsSender smsSender)
        {
            Logger = logger;
            EmailSender = emailSender;
            SmsSender = smsSender;
        }
        public AppServiceController(IAppLogger logger)
        {
            Logger = logger;
        }
    }
}