using ClosedXML.Excel;
using ItemToExcel.Data.Dto;

namespace ItemToExcel.Services
{
    public class ExcelService : IExcelService
    {
        public byte[] GenerateItemsFile(IEnumerable<ItemResponseDTO> items)
        {
            using var workbook = new XLWorkbook();

            var itemsByCat = items.GroupBy(i => i.categoryName).OrderBy(g => g.Key);

            foreach (var group in itemsByCat)
            {
                var ws = workbook.AddWorksheet(group.Key); // create a sheet for each category
                ws.Cell(1, 3).Value = "Name";
                ws.Cell(1, 2).Value = "After Discount";
                ws.Cell(1, 1).Value = "Before Discount";
                var header = ws.Range(1, 1, 1, 3);
                header.Style.Font.Bold = true; // bold
                header.Style.Fill.BackgroundColor = XLColor.LightBlue; // background color
                header.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick); // outside border for range of cells
                header.Style.Border.SetInsideBorder(XLBorderStyleValues.Thick); // inside border for range of cells

                var row = 2;
                foreach(var item in group)
                {
                    var range = ws.Range(row, row, row, 3);
                    ws.Cell(row, 1).Value = item.beforeDiscount;
                    ws.Cell(row, 2).Value = item.afterDiscount;
                    ws.Cell(row, 3).Value = item.Name;
                    range.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
                    range.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
                    row++;
                }
                ws.Columns().AdjustToContents();
            }
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
    }
}
