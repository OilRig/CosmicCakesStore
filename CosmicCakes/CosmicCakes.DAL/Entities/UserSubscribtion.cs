using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicCakes.DAL.Entities
{
    public class UserSubscribtion
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
