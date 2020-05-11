using Garage_2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2.ViewModels
{
    public class OverviewViewModel
    {
        [Display(Name = "Reg.nr")]
        public string RegNr { get; set; }

        [Display(Name = "Type of vehicle")]
        public VehicleType VehicleType { get; set; }

        [Display(Name = "Arrived")]
        public DateTime TimeOfArrival { get; set; }

        [Display(Name = "Time parked")]
        public string TimeInGarage { get; set; }

        public string timeInGarage
        {
            get
            {
                var timeInGarage = DateTime.Now.Subtract(TimeOfArrival);
                return String.Format($"{timeInGarage.Hours}:{timeInGarage.Minutes}:{timeInGarage.Seconds}");
            }
        }
    }
}
