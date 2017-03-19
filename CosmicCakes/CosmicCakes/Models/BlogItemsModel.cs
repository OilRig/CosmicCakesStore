using CosmicCakes.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CosmicCakes.Models
{
    public class BlogItemsModel
    {
        public List<BlogPost> BlogPosts { get; set; }
       
        public BlogItemsModel()
        {
            BlogPosts = new List<BlogPost>();

        }
    }
}