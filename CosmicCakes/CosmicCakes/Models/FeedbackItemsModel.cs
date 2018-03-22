using CosmicCakes.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CosmicCakes.Models
{
    public class FeedbackItemsModel
    {
        public UserFeedback[] UserFeedbacks { get; set; }
        public UserFeedbackModel LeftedFeedback { get; set; } = new UserFeedbackModel();
    }
}
