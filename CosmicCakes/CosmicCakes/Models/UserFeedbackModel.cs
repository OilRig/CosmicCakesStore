using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CosmicCakes.Models
{
    public class UserFeedbackModel
    {
        [Required(ErrorMessage ="А как Вас зовут?")]
        public string Author { get; set; }

        [RegularExpression(@"^[-\w.]+@([A-z0-9][-A-z0-9]+\.)+[A-z]{2,4}$", ErrorMessage = "Ваша почта не похожа на example@domain.ru")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Мы грустим,когда Вы ничего не пишете:(")]
        public string Content { get; set; }

        public DateTime CreateDate => DateTime.UtcNow;

        public HttpPostedFileBase AttachedImage { get; set; }
    }
}