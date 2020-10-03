using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingExercise.API.Models
{
    public class AddVehicleInStockModel
    {
        public int ModelId { get; set; }

        public DateTime DateBought { get; set; }

        public decimal PriceBought { get; set; }
    }
}