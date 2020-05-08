using Garage_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2.ViewModels
{
    public class OverviewViewModel
    {
        public string RegNr { get; set; }
        public VehicleType VehicleType { get; set; }
        public DateTime TimeOfArrival { get; set; }

        private string timeInGarage;
        public string TimeInGarage
        {
            get
            {
                var timeInGarage = DateTime.Now.Subtract(TimeOfArrival);
                return String.Format($"{timeInGarage.Hours}:{ timeInGarage.Minutes}:{timeInGarage.Seconds}");
            }
        }
    }
}
