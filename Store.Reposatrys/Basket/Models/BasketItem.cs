using System.ComponentModel.DataAnnotations;

namespace Store.Reposatrys.Basket.Models
{
    public class BasketItem
    {
        [Required]
        public int productId { get; set; }
        [Required]
        public string productName { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int count { get; set; }
        [Required]
        public string BrandName { get; set; }
        [Required]
        public string TypeName { get; set; }
    }
}