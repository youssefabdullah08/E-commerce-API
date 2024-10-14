using System.ComponentModel.DataAnnotations;

namespace Store.Serveses.OrderService.DTOs
{
    public class ShepingAdressDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Country { get; set; }
    }
}