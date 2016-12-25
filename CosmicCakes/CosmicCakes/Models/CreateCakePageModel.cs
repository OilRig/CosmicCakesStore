using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CosmicCakes.Models
{
    public class CreateCakePageModel
    {
        [Required(ErrorMessage = "Кажется,вы забыли указать вес")]
        [Range(1.5, 100, ErrorMessage = "Минимальный вес - 1,5кг")]
        public double Weight { get; set; }
        public IList<string> Bisquit { get; set; }
        public IList<string> Berries { get; set; }
        public IList<string> Filling { get; set; }
        public IList<string> Decorations { get; set; }
        public IList<string> Cream { get; set; }

        public CreateCakePageModel()
        {
            Bisquit = new List<string>();

            Berries = new List<string>();

            Filling = new List<string>();

            Decorations = new List<string>
            {
                "Горка красных ягод","Горка черных ягод","Цветы","Другое(укажите в дополнении)"
            };
            Cream = new List<string>();

            Weight = 1.5;
        }
    }
}
