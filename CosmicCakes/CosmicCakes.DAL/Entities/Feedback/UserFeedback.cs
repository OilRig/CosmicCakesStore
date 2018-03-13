using System;
using CosmicCakes.DAL.Common;

namespace CosmicCakes.DAL.Entities
{
    public class UserFeedback : IHasIntegerId
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public string AttachedImagePath { get; set; }
    }
}
