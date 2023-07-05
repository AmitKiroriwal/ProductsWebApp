using System.ComponentModel.DataAnnotations;

namespace ProductsWebApp.Models
{
    public class ProductViewModel
    {
        [Display(Order = 1)]
        public int Id { get; set; }
        [Required]
        [Display(Order = 2)]
        public string Category { get; set; }
        [Required]
        [Display(Order = 3)]
        public string SubCategory { get; set; }

        [Required, Display(Order = 4)]
        public string ProductName { get; set; }

        [Required, Display(Order = 5)]
        public string ShortDescription { get; set; }

        [Required, Display(Order = 6)]
        public string FullDescription { get; set; }

        [Required, Display(Order = 7)]
        public string Status { get; set; }

        [Required]

        public IFormFile PhotoPath { get; set; }

        public string Features { get; set; }
        [Required]
        public IFormFile PdfPath { get; set; }
    }
}
