using CosmicCakes.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CosmicCakes.Models
{
    public class FeedbackItemsModel
    {
        public List<UserFeedback> UserFeedbacks { get; set; }
        public FeedbackItemsModel()
        {
            UserFeedbacks = new List<UserFeedback>();
        }
    }
}
