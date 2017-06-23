using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CosmicakesControlWebApp.Models.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public double CakeWeight { get; set; }
        public string FillingType { get; set; }
        public string Comments { get; set; }
        public string Berries { get; set; }
        public string CakeName { get; set; }
        public int SelectedLevels { get; set; }
        public string FirstLevelBisquit { get; set; }
        public string SecondLevelBisquit { get; set; }
        public string ThirdLevelBisquit { get; set; }
        public string SelectedOneLevelBisquit { get; set; }
        public string SelectedMultiLevelBisquit { get; set; }
        public bool DeliveryNeeded { get; set; }
        public string DeliveryAdress { get; set; }
        public bool CustonBisquits { get; set; }
    }

}