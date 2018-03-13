using CosmicCakes.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicCakes.DAL.Interfaces
{
    public interface ICakeInventoryRepository : IRepository<Berry>
    {
        IEnumerable<Berry> GetAll();
    }
}
