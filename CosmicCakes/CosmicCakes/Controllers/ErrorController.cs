using CosmicCakes.Logging.Interfaces;
using System;
using System.Web.Mvc;

namespace CosmicCakes.Controllers
{
    public class ErrorController : AppServiceController
    {
        public IAppLogger Logger { get; set; }

        public ErrorController(IAppLogger logger) : base(logger)
        {
            Logger = logger;
        }

        private void LogError(string message)
        {
            Exception referrerException = Server.GetLastError();
            Logger.Error(referrerException, message);
        }

        [HttpGet]
        public ActionResult PageNotFound()
        {
            LogError(string.Empty);

            return View();
        }
        [HttpGet]
        public ActionResult Error500()
        {
            LogError(string.Empty);

            return View();
        }
        [HttpGet]
        public ActionResult General()
        {
            LogError(string.Empty);

            return View();
        }
    }
}