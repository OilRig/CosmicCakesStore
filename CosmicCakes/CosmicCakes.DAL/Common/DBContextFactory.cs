using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicCakes.DAL.Common
{
    public class DBContextFactory
    {
        public CakeContext CreateContext(string connectionString = null)
        {
            return new CakeContext();
        }
    }
}
