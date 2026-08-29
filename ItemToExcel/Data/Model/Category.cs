using System.ComponentModel.DataAnnotations;

namespace ItemToExcel.Data.Model
{
    public class Category
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
