using System.ComponentModel.DataAnnotations;

namespace ItemToExcel.Data.Dto
{
    public class ItemCreateDTO
    {
        [Required(ErrorMessage = "Item name is required.")]
        public string Name { get; set; }
        public decimal BeforeDiscount { get; set; }
        public decimal AfterDiscount { get; set; }
        public int CategoryId { get; set; }
    }

    public class ItemResponseDTO
    {
        public int id { get; set; }
        public string Name { get; set; }
        public decimal BeforeDiscount { get; set; }
        public decimal AfterDiscount { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
