using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Entities.Sweets;

namespace CosmicCakes.DAL.Common
{
    public interface IHasIntegerId
    {
        int Id { get; set; }
    }

    public interface IHasCakeForeignKey
    {
        int CakeId { get; set; }

        SimpleReadyCake SimpleReadyCake { get; set; }
    }

    public interface IHasSweetForeignKey
    {
        int SweetId { get; set; }
        AdditionalSweet AdditionalSweet { get; set; }
    }

    public interface IHasActiveMark
    {
        bool IsActive { get; set; }
    }
}
