using System.Drawing;
using Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace Twainsoft.DNP.Articles.ExcelLifeBook
{
    public partial class LifeBook
    {
        private void Tabelle1_Startup(object sender, System.EventArgs e)
        {
        }

        private void Tabelle1_Shutdown(object sender, System.EventArgs e)
        {
        }

        public void CreateLifeBook()
        {
            const int rows = 170;
            const int columns = 170;

            // Mark 
            ApplyFormatting(rows, columns);

            CalculateBirthdays(rows, columns);
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

                    if (days%365 == 0)
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
                column.EntireColumn.ColumnWidth = 2.14;
            }
        }

        #region VSTO Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(Tabelle1_Startup);
            this.Shutdown += new System.EventHandler(Tabelle1_Shutdown);
        }

        #endregion

    }
}
