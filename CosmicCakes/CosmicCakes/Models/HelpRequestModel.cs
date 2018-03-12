using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CosmicCakes.Models
{
    public class HelpRequestModel
    {
        [RegularExpression(@"^[-\w.]+@([A-z0-9][-A-z0-9]+\.)+[A-z]{2,4}$", ErrorMessage = "Ваша почта не похожа на email@domain.ru")]
        [EmailAddress]
        [Required(ErrorMessage = "Куда же мы Вам ответим ?")]
        public string Email { get; set; }

        [Required(ErrorMessage = "А как Вас зовут?")]
        public string Name { get; set; }

        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Какой у Вас вопрос?")]
        public string RequestText { get; set; }
    }
}