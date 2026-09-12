using System.ComponentModel.DataAnnotations;

namespace ItemToExcel.Data.Dto
{
    public record CategoryCreateDTO(string catName);

    public record CattegoryUpdateDTO(int Id, string catName);
}
