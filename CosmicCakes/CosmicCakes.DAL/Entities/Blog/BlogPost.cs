using System;
using System.ComponentModel.DataAnnotations;
using CosmicCakes.DAL.Common;

namespace CosmicCakes.DAL.Entities
{
    public class BlogPost : IHasIntegerId
    {
        [Key]
        public int Id { get; set; }
        public string Author { get; set; }
        public string Theme { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
