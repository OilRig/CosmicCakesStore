﻿using System;
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
        [Range(1.5,20,ErrorMessage ="Минимальный вес - 1.5кг")]
        [DataType(DataType.Currency,ErrorMessage ="А тут должна быть циферка")]
        public double CakeWeight { get; set; }
        public string Comments { get; set; }
        [Required(ErrorMessage = "Кажется,Вы не указали дату для тортика")]
        public string ExpireDateString { get; set; }
        public DateTime ExpireDate { get; set; }
        public override string ToString()
        {
            return string.Format($"Заказ от: {CustomerName} \nТелефон: {CustomerPhoneNumber} \nДата: {ExpireDate.ToShortDateString()} \nТорт: {CakeName}\nВес: {CakeWeight} кг \nКомментарий: {Comments}");
        }

    }
}
