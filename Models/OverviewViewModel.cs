using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2.Models
{
    public class OverviewViewModel
    {
        public string RegNr { get; }
        public VehicleType VehicleType { get; }
        public DateTime TimeOfArrival { get; }
        
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
