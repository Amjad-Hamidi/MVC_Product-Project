using System.ComponentModel.DataAnnotations;

namespace ProductApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Display(Name="Product Name")]
        public string Name { get; set; }
        [Display(Name = "Product Quantity")]

        public int Qty { get; set; }
        [Display(Name = "Product Price")]

        public decimal Price { get; set; }
        [Display(Name = "Product Available")]

        public bool InStock {  get; set; } //عندي كمية في المخزن
        [Display(Name="Product Publish")]

        public bool InPublish { get; set; } //اني انشر الموجود في المخزن ولا لا

    }
}
