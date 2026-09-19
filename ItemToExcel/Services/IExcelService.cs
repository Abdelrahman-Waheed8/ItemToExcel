using ItemToExcel.Data.Dto;

namespace ItemToExcel.Services
{
    public interface IExcelService
    {
        public byte[] GenerateItemsFile(IEnumerable<ItemResponseDTO> item);
    }
}
