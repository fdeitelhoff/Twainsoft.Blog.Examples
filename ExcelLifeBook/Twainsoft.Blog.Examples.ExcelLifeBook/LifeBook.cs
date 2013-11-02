using System;
using System.Drawing;
using Microsoft.Office.Interop.Excel;

namespace Twainsoft.Blog.Examples.ExcelLifeBook
{
    public partial class LifeBook
    {
        private DateTime Birthday { get; set; }

        public void CreateLifeBook()
        {
            Birthday = new DateTime(1983, 2, 16);

            const int rows = 170;
            const int columns = 170;

            // Create the table format.
            ApplyFormatting(rows, columns);

            // Calculate and mark the birthdays with green cells.
            CalculateBirthdays(rows, columns);

            // Mark the time of kindergarden.
            MarkKinderkarden(3, 6);

            // Mark the time of elementary school.
            MarkElementarySchool(6, 10);

            // Mark the time of middle school.
            MarkMiddleSchool(10, 16);
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

                    //cell.Value2 = "-";

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
            Range[Cells[1, 1], Cells[rows, columns]].Interior.Color = Color.LightGray;

            for (var i = 1; i <= 170; i++)
            {
                var column = Columns[i, System.Type.Missing] as Range;
                if (column != null) column.EntireColumn.ColumnWidth = 2.14;
            }
        }

        private void InternalStartup() { }
    }
}
