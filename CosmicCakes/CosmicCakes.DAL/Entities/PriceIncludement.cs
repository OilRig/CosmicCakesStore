﻿using System.ComponentModel.DataAnnotations.Schema;

namespace CosmicCakes.DAL.Entities
{
    public class PriceIncludement
    {
        public int Id { get; set; }
        public string IncludementInfo { get; set; }

        [ForeignKey("SimpleReadyCake")]
        public int CakeId { get; set; }
        public virtual SimpleReadyCake SimpleReadyCake { get; set; }
    }
}
