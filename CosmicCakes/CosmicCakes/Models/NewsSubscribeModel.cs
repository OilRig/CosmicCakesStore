using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CosmicCakes.Models
{
    public class NewsSubscribeModel
    {
        [RegularExpression(@"^[-\w.]+@([A-z0-9][-A-z0-9]+\.)+[A-z]{2,4}$", ErrorMessage = "Ваша почта не похожа на email@domain.ru")]
        [EmailAddress]
        [Required(ErrorMessage ="Мы ведь не знаем куда писать письма :(")]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
    }
}