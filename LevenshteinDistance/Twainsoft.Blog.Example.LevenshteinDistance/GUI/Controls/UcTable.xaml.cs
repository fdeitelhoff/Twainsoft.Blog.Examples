// **************************************************
// 
// Written by Fabian Deitelhoff, 2013-09-13
// http://www.fabiandeitelhoff.de
// 
// **************************************************

using System.Windows.Input;
using System.Windows.Media;
using Twainsoft.Blog.Example.LevenshteinDistance.Core.Model;

namespace Twainsoft.Blog.Example.LevenshteinDistance.GUI.Controls
{
    public partial class UcTable
    {
        public UcTable()
        {
            InitializeComponent();
        }

        private FieldData[,] Table { get; set; }
        private UcTableField[,] UcTables { get; set; }

        internal void SetData(FieldData[,] tabelle)
        {
            Table = tabelle;
            UcTables = new UcTableField[tabelle.GetLength(0), tabelle.GetLength(1)];

            ClearElements();

            Grid.Rows = tabelle.GetLength(0);
            Grid.Columns = tabelle.GetLength(1);

            for (var i = 0; i < tabelle.GetLength(0); i++)
            {
                for (var j = 0; j < tabelle.GetLength(1); j++)
                {
                    var ucTableField = new UcTableField();
                    ucTableField.MouseEnter += ucTableField_MouseEnter;
                    ucTableField.MouseLeave += ucTableField_MouseLeave;
                    ucTableField.SetData(tabelle[i, j]);

                    Grid.Children.Add(ucTableField);

                    UcTables[i, j] = ucTableField;
                }
            }
        }

        private void ClearElements()
        {
            for (var i = 0; i < UcTables.GetLength(0); i++)
            {
                for (var j = 0; j < UcTables.GetLength(1); j++)
                {
                    if (UcTables[i, j] != null)
                    {
                        UcTables[i, j].MouseEnter -= ucTableField_MouseLeave;
                        UcTables[i, j].MouseLeave -= ucTableField_MouseEnter;
                    }
                }
            }

            Grid.Children.Clear();
        }

        private void ucTableField_MouseLeave(object sender, MouseEventArgs e)
        {
            var fieldData = ((UcTableField) sender).FieldData;

            if (fieldData == null)
            {
                return;
            }

            if (fieldData.FieldDataSource != FieldDataSources.None)
            {
                if (!UcTables[fieldData.I, fieldData.J - 1].FieldData.Backtrace)
                {
                    UcTables[fieldData.I, fieldData.J - 1].Background = Brushes.Transparent;
                }
                else
                {
                    UcTables[fieldData.I, fieldData.J - 1].Background = Brushes.Orange;
                }

                if (!UcTables[fieldData.I - 1, fieldData.J - 1].FieldData.Backtrace)
                {
                    UcTables[fieldData.I - 1, fieldData.J - 1].Background = Brushes.Transparent;
                }
                else
                {
                    UcTables[fieldData.I - 1, fieldData.J - 1].Background = Brushes.Orange;
                }

                if (!UcTables[fieldData.I - 1, fieldData.J].FieldData.Backtrace)
                {
                    UcTables[fieldData.I - 1, fieldData.J].Background = Brushes.Transparent;
                }
                else
                {
                    UcTables[fieldData.I - 1, fieldData.J].Background = Brushes.Orange;
                }
            }
        }

        private void ucTableField_MouseEnter(object sender, MouseEventArgs e)
        {
            var fieldData = ((UcTableField) sender).FieldData;

            if (fieldData == null)
            {
                return;
            }

            if (fieldData.FieldDataSource != FieldDataSources.None)
            {
                // links
                if (fieldData.FieldDataSource == FieldDataSources.Left)
                    UcTables[fieldData.I, fieldData.J - 1].Background = Brushes.Red;

                // links oben
                if (fieldData.FieldDataSource == FieldDataSources.TopLeft)
                    UcTables[fieldData.I - 1, fieldData.J - 1].Background = Brushes.Red;

                // oben
                if (fieldData.FieldDataSource == FieldDataSources.Top)
                    UcTables[fieldData.I - 1, fieldData.J].Background = Brushes.Red;

                // alles gleich (Maximum)
                if (fieldData.FieldDataSource == FieldDataSources.All)
                {
                    UcTables[fieldData.I, fieldData.J - 1].Background = Brushes.LightGray;
                    UcTables[fieldData.I - 1, fieldData.J - 1].Background = Brushes.LightGray;
                    UcTables[fieldData.I - 1, fieldData.J].Background = Brushes.LightGray;
                }

                // Links oben einer addiert.
                if (fieldData.FieldDataSource == FieldDataSources.TopLeftAddOne)
                    UcTables[fieldData.I - 1, fieldData.J - 1].Background = Brushes.LightGreen;
            }
        }
    }
}