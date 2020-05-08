using System;
using System.ComponentModel.DataAnnotations;

namespace Garage_2.ViewModels
{
    public class ParkedVehiclesDetails
    {
        [Required]
        [StringLength(32)]
        [Display(Name = "Reg.nr")]
        public string RegNr { get; set; }

        [Required]
        [Display(Name = "Type of vehicle")]
        public VehicleType VehicleType { get; set; }

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
        public DateTime TimeOfArrival { get; set; }

        public string TimeInGarage { get; set; }

    }
}
