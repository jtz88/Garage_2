using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2.Models
{
    public class ParkedVehicle
    {
        public int Id { get; set; }

        [Required]
        [StringLength(32)]
        [Display(Name = "Reg.nr")]
        public string RegNr { get; set; }

        [Required]      // [Required(ErrorMessage = "Your elegant error message goes here")]
        [Display(Name = "Type of vehicle")]
        public VehicleType vehicleType { get; set; }

        [Range(1, 16)]
        [Display(Name = "Number of wheels")]
        public int NrOfWheels { get; set; }
 
        [StringLength(32)]
        public string Color { get; set; }

        [StringLength(32)]
        public string Brand { get; set; }

        [StringLength(64)]
        public string Model { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Time of arrival")]
        public DateTime TimeOfArrival { get; }


        private string timeInGarage;
        public string TimeInGarage
        {
            get
            {
                var timeInGarage = DateTime.Now.Subtract(TimeOfArrival);
                return String.Format($"{timeInGarage.Hours}:{timeInGarage.Minutes}:{timeInGarage.Seconds}");
            }
        }
    }
}
