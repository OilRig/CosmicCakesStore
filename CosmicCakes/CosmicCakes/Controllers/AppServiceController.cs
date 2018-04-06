using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CosmicCakes.Logging.Interfaces;
using CosmicCakes.Services.EmailService;
using System.Text;
using System.IO;
using System.Web.UI;

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

        protected string PartialViewToString(string viewName, object model = null)
        {
            var view = ViewEngines.Engines.FindPartialView(ControllerContext, viewName).View;
            var viewData = new ViewDataDictionary(ViewData);
            viewData.Model = model;

            var sb = new StringBuilder();
            var tempData = new TempDataDictionary();
            using (var sw = new StringWriter(sb))
            {
                using (var tw = new HtmlTextWriter(sw))
                {
                    view.Render(new ViewContext(ControllerContext, view, viewData, tempData, tw), tw);
                    return sb.ToString();
                }
            }

        }
    }
}