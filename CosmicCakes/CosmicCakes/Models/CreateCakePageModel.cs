using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CosmicCakes.Models
{
    public class CreateCakePageModel
    {
        [Required(ErrorMessage = "Не указан вес тортика")]
        [Range(1.5, 30, ErrorMessage = "Минимальный вес - 1,5кг, а максимальный 30кг")]
        public double CakeWeight { get; set; }
        public IList<string> Bisquit { get; set; }
        public IList<string> Berries { get; set; }
        public IList<string> Filling { get; set; }
        //public IList<string> Decorations { get; set; }
        public IList<string> Cream { get; set; }
        public string BisquitType { get; set; }
        public string FillingType { get; set; }
        public string Comments { get; set; }
        public ICollection<string> SelectedBerries { get; set; }
        public CreateCakePageModel()
        {
            Bisquit = new List<string>();

            Berries = new List<string>();

            SelectedBerries = new List<string>();

            Filling = new List<string>();

            //Decorations = new List<string>
            //{
            //    "Горка красных ягод","Горка черных ягод","Цветы","Другое(укажите в дополнении)"
            //};
            Cream = new List<string>();

            CakeWeight = 1.5;
        }
    }
}
