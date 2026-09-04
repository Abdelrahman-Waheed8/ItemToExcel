using System.ComponentModel.DataAnnotations;

namespace ItemToExcel.Data.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal BeforeDiscount { get; set; }
        public decimal AfterDiscount { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
