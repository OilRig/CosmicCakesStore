using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CosmicCakes.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Как же Вас зовут?")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "И даже телефончик не оставите?")]
        public string CustomerPhoneNumber { get; set; }

        public string CakeName { get; set; }

        [Required(ErrorMessage = "Не указан вес тортика")]
        [Range(1.5, 20, ErrorMessage = "Минимальный вес - 1.5кг")]
        [DataType(DataType.Currency, ErrorMessage = "А тут должна быть циферка")]
        public double CakeWeight => GetWeight(CakeStringWeight);

        public string CakeStringWeight { get; set; }

        public string Comments { get; set; }

        [Required(ErrorMessage = "Кажется,Вы не указали дату для тортика")]
        public string ExpireDateString { get; set; }

        public DateTime ExpireDate { get; set; }

        public int[] Levels { get; set; } = new[] { 1, 2, 3 };

        public string[] Bisquits { get; set; }
        public string[] Fillings { get; set; }
        public string[] Berries { get; set; }
        public string[] Cakes { get; set; }

        public string SelectedCakeName { get; set; }

        public string FirstLevelBisquit { get; set; }
        public string SecondLevelBisquit { get; set; }
        public string ThirdLevelBisquit { get; set; }

        public bool CustomLevelBisquits { get; set; }
        public bool DeliveryNeeded { get; set; }
        public bool IsLevelable { get; set; }

        public int SelectedLevels { get; set; }

        public string DeliveryAdress { get; set; }
        public string SelectedFilling { get; set; }
        public string SelectedBerries { get; set; }
        public string SelectedOneLevelBisquit { get; set; }
        public string SelectedMultiLevelBisquit { get; set; }

        private double GetWeight(string value)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            if(value != null)
            {
                if (value.Contains("."))
                    nfi.NumberDecimalSeparator = ".";
                else if (value.Contains(","))
                    nfi.NumberDecimalSeparator = ",";
                return double.Parse(value, nfi);
            }
            return double.MinValue; 
        }

        public override string ToString()
        {
            ExpireDate = DateTime.ParseExact(ExpireDateString, "MM/dd/yyyy", null);
            string deliveryAdress = DeliveryNeeded ? DeliveryAdress : "Нет";
            switch (SelectedLevels)
            {
                case 1:
                    {
                        return string.Format($"Заказ от: {CustomerName} \n Телефон: {CustomerPhoneNumber} \n Дата: {ExpireDate.ToShortDateString()} \n Торт: {CakeName}\n Вес: {CakeWeight} кг \n Ярусы:{SelectedLevels} \n Ягоды:{SelectedBerries} \n"
                        + $"Бисквит: {SelectedOneLevelBisquit} \n Начинка:{SelectedFilling} \n Комментарий: {Comments} \n Доставка: {deliveryAdress}");
                    }
                case 2:
                    {
                        if (CustomLevelBisquits)
                        {
                            return string.Format($"Заказ от: {CustomerName} \n Телефон: {CustomerPhoneNumber} \n Дата: {ExpireDate.ToShortDateString()} \n Торт: {CakeName}\n Вес: {CakeWeight} кг \n Начинка:{SelectedFilling} \n Ярусы: {SelectedLevels} \n Ягоды:{SelectedBerries} \n" +
                                $"-Разные бисквиты в ярусы: Да \n --Бисквит в первый ярус: {FirstLevelBisquit} \n --Бисквит во второй ярус: {SecondLevelBisquit} \n Комментарий: {Comments} \n Доставка: {deliveryAdress}");
                        }
                        else
                        {
                            return string.Format($"Заказ от: {CustomerName} \n Телефон: {CustomerPhoneNumber} \n Дата: {ExpireDate.ToShortDateString()} \n Торт: {CakeName}\n Вес: {CakeWeight} кг \n Начинка:{SelectedFilling} \n Ярусы:{SelectedLevels} \n"
                                + $"-Разные бисквиты в ярусы: Нет \n --Бисквит: {SelectedMultiLevelBisquit} \n Комментарий: {Comments} \n Доставка: {deliveryAdress}");
                        }
                    }
                case 3:
                    {
                        if (CustomLevelBisquits)
                        {
                            return string.Format($"Заказ от: {CustomerName} \n Телефон: {CustomerPhoneNumber} \n Дата: {ExpireDate.ToShortDateString()} \n Торт: {CakeName}\n Вес: {CakeWeight} кг \n Начинка:{SelectedFilling} \n Ярусы: {SelectedLevels} \n Ягоды:{SelectedBerries} \n" +
                                $"-Разные бисквиты в ярусы: Да \n --Бисквит в первый ярус: {FirstLevelBisquit} \n --Бисквит во второй ярус: {SecondLevelBisquit}  \n --Бисквит в третий ярус: {ThirdLevelBisquit}\n Комментарий: {Comments} \n Доставка: {deliveryAdress}");
                        }
                        else
                        {
                            return string.Format($"Заказ от: {CustomerName} \n Телефон: {CustomerPhoneNumber} \n Дата: {ExpireDate.ToShortDateString()} \n Торт: {CakeName}\n Вес: {CakeWeight} кг \n Начинка:{SelectedFilling} \n Ярусы:{SelectedLevels} \n Ягоды:{SelectedBerries} \n"
                                + $"-Разные бисквиты в ярусы: Нет \n --Бисквит: {SelectedMultiLevelBisquit} \n Комментарий: {Comments} \n Доставка: {deliveryAdress}");
                        }
                    }
                default: return null;
            }


        }

    }
}
