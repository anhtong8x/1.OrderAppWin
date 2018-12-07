using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TN.UI.Extensions
{
    public  class ExportExcelExtention
    {
        public static double GetTrueColumnWidth(double width)
        {
            //DEDUCE WHAT THE COLUMN WIDTH WOULD REALLY GET SET TO
            double z = 1d;
            if (width >= (1 + 2 / 3))
            {
                z = Math.Round((Math.Round(7 * (width - 1 / 256), 0) - 5) / 7, 2);
            }
            else
            {
                z = Math.Round((Math.Round(12 * (width - 1 / 256), 0) - Math.Round(5 * width, 0)) / 12, 2);
            }

            //HOW FAR OFF? (WILL BE LESS THAN 1)
            double errorAmt = width - z;

            //CALCULATE WHAT AMOUNT TO TACK ONTO THE ORIGINAL AMOUNT TO RESULT IN THE CLOSEST POSSIBLE SETTING 
            double adj = 0d;
            if (width >= (1 + 2 / 3))
            {
                adj = (Math.Round(7 * errorAmt - 7 / 256, 0)) / 7;
            }
            else
            {
                adj = ((Math.Round(12 * errorAmt - 12 / 256, 0)) / 12) + (2 / 12);
            }

            //RETURN A SCALED-VALUE THAT SHOULD RESULT IN THE NEAREST POSSIBLE VALUE TO THE TRUE DESIRED SETTING
            if (z > 0)
            {
                return width + adj;
            }

            return 0d;
        }
        public static ExcelWorksheet SetBorder(ExcelWorksheet ws, int row, int col)
        {
            ws.Cells[row, col].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            ws.Cells[row, col].Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
            ws.Cells[row, col].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            ws.Cells[row, col].Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
            ws.Cells[row, col].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            ws.Cells[row, col].Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
            ws.Cells[row, col].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            ws.Cells[row, col].Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
            return ws;
        }

        public static ExcelWorksheet SetBorder(ExcelWorksheet ws, int startRow, int StartCol, int endRow, int endCol)
        {
            ws.Cells[startRow, StartCol, endRow, endCol].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            ws.Cells[startRow, StartCol, endRow, endCol].Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
            ws.Cells[startRow, StartCol, endRow, endCol].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            ws.Cells[startRow, StartCol, endRow, endCol].Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
            ws.Cells[startRow, StartCol, endRow, endCol].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            ws.Cells[startRow, StartCol, endRow, endCol].Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
            ws.Cells[startRow, StartCol, endRow, endCol].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            ws.Cells[startRow, StartCol, endRow, endCol].Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
            return ws;
        }
    }
}
