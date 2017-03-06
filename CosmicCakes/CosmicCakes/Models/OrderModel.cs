using System;
using System.ComponentModel.DataAnnotations;

namespace CosmicCakesWebApp.Models
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
        public double CakeWeight { get; set; }
        public string Comments { get; set; }
        [Required(ErrorMessage = "Кажется,Вы не указали дату для тортика")]
        public DateTime ExpireDate { get; set; }
        public override string ToString()
        {
            return string.Format($"Заказ от: {CustomerName} \nТелефон: {CustomerPhoneNumber} \nДата: {ExpireDate.ToShortDateString()} \nТорт: {CakeName}\nВес: {CakeWeight} кг \nКомментарий: {Comments}");
        }
    }
}
