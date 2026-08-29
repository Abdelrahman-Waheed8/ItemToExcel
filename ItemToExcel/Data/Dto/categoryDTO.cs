using System.ComponentModel.DataAnnotations;

namespace ItemToExcel.Data.Dto
{
    public class CategoryCreateDTO
    {
        [Required(ErrorMessage ="Category name required")]
        public string name { get; set; }
    }

    public class CategoryResponseDTO
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
