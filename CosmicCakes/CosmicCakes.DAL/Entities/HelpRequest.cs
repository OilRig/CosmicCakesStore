﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicCakes.DAL.Entities
{
    public class HelpRequest
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Patronymic { get; set; }

        public string RequestText { get; set; }
    }
}