using System.ComponentModel.DataAnnotations;

namespace ItemToExcel.Data.Model
{
    public class Item
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal BeforeDiscount { get; set; }
        public decimal AfterDiscount { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
