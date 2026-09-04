using System.ComponentModel.DataAnnotations;

namespace ItemToExcel.Data.Dto
{
    public class ItemCreateDTO
    {
        // Use Records instead of class to ensure immutability and value based comparison
        [Required(ErrorMessage = "Item name is required.")]
        public string Name { get; set; }
        public decimal BeforeDiscount { get; set; }
        public decimal AfterDiscount { get; set; }
        public int CategoryId { get; set; }
    }

    public class ItemResponseDTO
    {
        // Use Records instead of class to ensure immutability and value based comparison
        public int id { get; set; }
        public string Name { get; set; }
        public decimal BeforeDiscount { get; set; }
        public decimal AfterDiscount { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
