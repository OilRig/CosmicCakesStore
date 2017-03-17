using System;

namespace CosmicCakes.DAL.Entities
{
    public class UserFeedback
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
