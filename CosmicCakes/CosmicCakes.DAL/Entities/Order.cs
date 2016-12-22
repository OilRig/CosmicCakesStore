using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CosmicCakes.DAL.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("Bisquit")]
        public int BusquitId { get; set; }
        public virtual Bisquit Bisquit { get; set; }

        public virtual ICollection<Berry> Berries { get; set; }
        public virtual ICollection<Filling> Fillings { get; set; }
        public virtual ICollection<Decoration> Decorations { get; set; }


        public double CakeWeight { get; set; }
        public int GuestsAmount { get; set; }
        public string CreamColorDescription { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerName { get; set; }
        public string AdditionalInofrmation { get; set; }

    }
}
