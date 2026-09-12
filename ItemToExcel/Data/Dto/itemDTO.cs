using System.ComponentModel.DataAnnotations;

namespace ItemToExcel.Data.Dto
{
    public record ItemCreateDTO(string Name, decimal beforeDiscount, decimal afterDiscount, int catID);

    public record ItemResponseDTO(int Id,string Name, decimal beforeDiscount, decimal afterDiscount, int catID, string categoryName);
}
