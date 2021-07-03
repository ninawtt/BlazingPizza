using System.ComponentModel.DataAnnotations;

namespace BlazingPizza
{
    public class Address
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name."), MaxLength(100, ErrorMessage = "The maximum length is 100.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Line1."), MaxLength(100, ErrorMessage = "The maximum length is 100.")]
        public string Line1 { get; set; }

        [MaxLength(100, ErrorMessage = "The maximum length is 100.")]
        public string Line2 { get; set; }

        [Required(ErrorMessage = "Please enter City."), MaxLength(50, ErrorMessage = "The maximum length is 50.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter Region."), MaxLength(20, ErrorMessage = "The maximum length is 20.")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Please enter Postal Code."), MaxLength(20, ErrorMessage = "The maximum length is 20.")]
        public string PostalCode { get; set; }
    }
}
