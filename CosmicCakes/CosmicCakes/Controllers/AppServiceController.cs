using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CosmicCakes.Logging.Interfaces;
using CosmicCakes.Services.EmailService;

namespace CosmicCakes.Controllers
{
    public class AppServiceController : Controller
    {
        protected readonly IAppLogger Logger;
        protected readonly IEmailSender EmailSender;

        public AppServiceController(IAppLogger logger, IEmailSender emailSender)
        {
            Logger = logger;
            EmailSender = emailSender;
        }
        public AppServiceController(IAppLogger logger)
        {
            Logger = logger;
        }
    }
}