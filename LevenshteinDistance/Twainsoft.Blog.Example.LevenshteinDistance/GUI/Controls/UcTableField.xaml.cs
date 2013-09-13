// **************************************************
// 
// Written by Fabian Deitelhoff, 2013-09-13
// http://www.fabiandeitelhoff.de
// 
// **************************************************

using System;
using System.Windows.Input;
using System.Windows.Media;
using Twainsoft.Blog.Example.LevenshteinDistance.Core.Model;

namespace Twainsoft.Blog.Example.LevenshteinDistance.GUI.Controls
{
    public partial class UcTableField
    {
        public UcTableField()
        {
            InitializeComponent();
        }

        public FieldData FieldData { get; private set; }

        public void SetData(FieldData fieldData)
        {
            FieldData = fieldData;

            if (fieldData != null)
            {
                if (!String.IsNullOrEmpty(fieldData.Content))
                {
                    Data.Content = fieldData.Content;
                }
                else
                {
                    Data.Content = fieldData.CurrentData;
                }

                if (fieldData.Backtrace)
                {
                    Background = Brushes.Orange;
                }
            }
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            BorderBrush = Brushes.Black;
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            BorderBrush = Brushes.Transparent;
        }
    }
}