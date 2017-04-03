using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Car
    {
        public int CarID { get; set; }

        [DisplayName("Car name")]
        [Required(ErrorMessage = "You have to enter car name.")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Car name must have between 2-25 characters.")]
        public string Name { get; set; }

        [DisplayName("Horse Power (HP)")]
        [Range(1, 1000, ErrorMessage = "Choose value between 1 and 1000.")]
        public int HorsePower { get; set; }

        [DisplayName("Model Year")]
        [Range(1900, 2017, ErrorMessage = "Choose value between 1900 and 2017.")]
        public int Year { get; set; }

        public Car()
        {
            Year = DateTime.Now.Year;
        }

        public int horsepowerToKilowatts()
        {
            return (int)(HorsePower * 0.745699872);
        }
    }
}