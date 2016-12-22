using System.Collections.Generic;

namespace CosmicCakes.Models
{
    public class CreateCakeModel
    {
        public IList<string> Bisquit { get; set; }
        public IList<string> Berries { get; set; }
        public IList<string> Filling { get; set; }
        public IList<string> Decorations { get; set; }

        public CreateCakeModel()
        {
            Bisquit = new List<string>
            {
                "Шоколадный","Лимонный"
            };
            Berries = new List<string>()
            {
                "Клубника","Малина","Ежевика","Голубика"
            };
            Filling = new List<string>
            {
                "Карамель","Желе","Курд"
            }
            ;
            Decorations = new List<string>
            {
                "Горка красных ягод","Горка черных ягод","Кумкваты","Инжир","Цветы"
            };
        }
    }
}
