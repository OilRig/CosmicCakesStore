using CosmicCakes.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicCakes.DAL.Interfaces
{
    public interface IFeedbackRepository :IRepository<UserFeedback>
    {
        IEnumerable<UserFeedback> GetAllFeedbacks();
        UserFeedback GetFeedbackById(int id);
    }
}
