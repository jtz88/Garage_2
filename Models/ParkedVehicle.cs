using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//Add-M<tab> 

namespace Garage_2.Models
{
    public enum VehicleType
    {
        Airplane,
        Boat,
        Bus,
        Car,
        Motorcycle,
    }

    public class ParkedVehicle
    {
        public int Id { get; set; }

        [Required]
        public string RegNr { get; set; }

        [Required]
        public VehicleType vehicleType;

        public int NoWheels { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Time of arrival")]
        public DateTime TimeOfArrival { get; set; }

    }
}
