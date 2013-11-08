using System;
using System.Drawing;
using Microsoft.Office.Interop.Excel;

namespace Twainsoft.Blog.Examples.ExcelLifeBook
{
    public partial class LifeBook
    {
        public void CreateLifeBook()
        {
            // We assume 170 * 170 cells.
            const int rows = 170;
            const int columns = 170;

            // Create the table format.
            ApplyFormatting(rows, columns);

            // Calculate and mark all birthdays with green cells.
            CalculateBirthdays(rows, columns);

            // Mark all important time ranges (from -> to year).
            MarkKinderkarden(3, 6);
            MarkElementarySchool(6, 10);
            MarkMiddleSchool(10, 16);
            MarkHighSchool(16, 20);
            MarkApprenticeship(20, 23);
            MarkWork(23, 26);
            MarkBachelor(26, 29);
            MarkMaster(29, 31);
        }

        private void MarkMaster(int fromYear, int toYear)
        {
            MarkRange(fromYear, toYear, Color.Sienna);
        }

        private void MarkBachelor(int fromYear, int toYear)
        {
            MarkRange(fromYear, toYear, Color.Olive);
        }

        private void MarkWork(int fromYear, int toYear)
        {
            MarkRange(fromYear, toYear, Color.DarkGreen);
        }

        private void MarkApprenticeship(int fromYear, int toYear)
        {
            MarkRange(fromYear, toYear, Color.Brown);
        }

        private void MarkHighSchool(int fromYear, int toYear)
        {
            MarkRange(fromYear, toYear, Color.SlateBlue);
        }

        private void MarkMiddleSchool(int fromYear, int toYear)
        {
            MarkRange(fromYear, toYear, Color.DarkOrange);
        }

        private void MarkElementarySchool(int fromYear, int toYear)
        {
            MarkRange(fromYear, toYear, Color.IndianRed);
        }

        private void MarkKinderkarden(int fromYear, int toYear)
        {
            MarkRange(fromYear, toYear, Color.SteelBlue);
        }
        
        private void MarkRange(int fromYear, int toYear, Color color)
        {
            var dayStart = fromYear*365;
            var dayEnd = toYear*365;

            // Calculate the row and column of the starting cell for the range.
            var startRow = Math.Ceiling(dayStart/170.0f);
            var startColumn = dayStart%170;

            for (var day = dayStart; day < dayEnd; day++)
            {
                var cell = Cells[startRow, startColumn++] as Range;
                if (cell != null) cell.Interior.Color = color;

                if (startColumn > 170)
                {
                    startColumn = 1;
                    startRow++;

                    if (startRow > 170)
                    {
                        startRow = 1;
                    }
                }
            }
        }

        private void CalculateBirthdays(int rows, int columns)
        {
            var days = 1;
            var years = 1;

            for (var row = 1; row <= rows; row++)
            {
                for (var column = 1; column <= columns; column++)
                {
                    var cell = Cells[row, column] as Range;

                    if (cell != null && days % 365 == 0)
                    {
                        cell.Interior.Color = Color.Green;
                        Cells[row, column] = years;

                        years++;
                    }

                    days++;
                }
            }
        }

        private void ApplyFormatting(int rows, int columns)
        {
            // Complete surrounding borders of the gray box. 
            Range[Cells[1, 1], Cells[rows, columns]].Interior.Color = Color.LightGray;
            Range[Cells[1, 1], Cells[rows, columns]].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            Range[Cells[1, 1], Cells[rows, columns]].Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            Range[Cells[1, 1], Cells[rows, columns]].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            Range[Cells[1, 1], Cells[rows, columns]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

            // Set all column width to 2.14. That's a nice looking width.
            for (var i = 1; i <= 170; i++)
            {
                var column = Columns[i, System.Type.Missing] as Range;
                if (column != null) column.EntireColumn.ColumnWidth = 2.14;
            }
        }

        private void InternalStartup() { }
    }
}
