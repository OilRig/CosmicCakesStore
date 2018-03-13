using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmicCakes.DAL.Common;

namespace CosmicCakes.DAL.Entities
{
    public class EmailLinkedResorce : IHasIntegerId
    {
        [Key]
        public int Id { get; set; }

        public int? EmailTemplateId { get; set; }
        [ForeignKey("EmailTemplateId")]
        public EmailTemplate Template { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
        public byte[] Content { get; set; }
        [MaxLength(64)]
        public string ContentType { get; set; }
        public bool IsActive { get; set; }
    }
}
