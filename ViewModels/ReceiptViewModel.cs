using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2.ViewModels
{
    public class ReceiptViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Reg.nr")]
        public string RegNr { get; set; }

        [Display(Name = "Arrived")]
        public DateTime TimeOfArrival { get; set; }

        [Display(Name = "Departure")]
        public DateTime TimeOfDeparture { get; set; }

        [Display(Name = "Debt")]
        [Range(0, int.MaxValue)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public int PriceTotal
        {
            get
            {
                var priceTotal = DateTime.Now.Subtract(TimeOfArrival);
                return priceTotal.Hours * 25;
            }
        }

        [Display(Name = "Parking time")]
        public string TotalParkingTime
        {
            get
            {
                var totalParkingTime = DateTime.Now.Subtract(TimeOfArrival);
                return String.Format($"{totalParkingTime.Hours}:{ totalParkingTime.Minutes}:{totalParkingTime.Seconds}");
            }
        }
    }
}
