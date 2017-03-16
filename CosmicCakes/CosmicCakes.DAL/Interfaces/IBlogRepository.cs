using CosmicCakes.DAL.Entities;
using System.Collections.Generic;

namespace CosmicCakes.DAL.Interfaces
{
    public interface IBlogRepository : IRepository<BlogPost>
    {
        IEnumerable<BlogPost> GetAllPosts();
    }
}
