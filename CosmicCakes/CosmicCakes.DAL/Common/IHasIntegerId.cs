using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmicCakes.DAL.Entities;

namespace CosmicCakes.DAL.Common
{
    public interface IHasIntegerId
    {
        [Key]
        int Id { get; set; }
    }

    public interface IHasCakeForeignKey
    {
        [ForeignKey("SimpleReadyCake")]
        int CakeId { get; set; }

        SimpleReadyCake SimpleReadyCake { get; set; }
    }

    public interface IHasActiveMark
    {
        bool IsActive { get; set; }
    }
}
