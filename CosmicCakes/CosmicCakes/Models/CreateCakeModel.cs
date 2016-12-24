using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CosmicCakes.Models
{
    public class CreateCakeModel
    {
        [Required]
        public double Weight { get; set; }
        public IList<string> Bisquit { get; set; }
        public IList<string> Berries { get; set; }
        public IList<string> Filling { get; set; }
        public IList<string> Decorations { get; set; }
        public IList<string> Cream { get; set; }

        public CreateCakeModel()
        {
            Bisquit = new List<string>
            {
                "Шоколадный", "Ванильный", "Лимонный", "Мандариновый", "Миндальный",
                "Лавандовый", "Морковный", "Красный бархат", "Чизкейк", "Лайм", "Черничный"
            };
            Berries = new List<string>()
            {
                "Клубника","Малина","Ежевика","Голубика"
            };
            Filling = new List<string>
            {
                 "Фруктовое желе на со свежими ягодами",
                "Цитрусовый курд (лимон, апельсин, мандарин)",
                "Домашний шоколадный мусс",
                "Орехи: миндаль, фундук, фисташка, грецкий, кешью",
                "Домашняя карамель с пряными нотками корицы, кардамона, имбиря и гвоздики",
                "Сезонные ягоды и фрукты",
                "Джем, варенье"
            }
            ;
            Decorations = new List<string>
            {
                "Горка красных ягод","Горка черных ягод","Цветы","Другое(укажите в дополнении)"
            };
            Cream = new List<string>
            {
                "Сливочно-творожный"," Шоколадный", "Крем на белом швейцарском шоколаде"
            };
        }
    }
}
