using System;
using System.ComponentModel.DataAnnotations;

namespace CosmicCakes.DAL.Entities
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        public string Author { get; set; }
        public string Theme { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
