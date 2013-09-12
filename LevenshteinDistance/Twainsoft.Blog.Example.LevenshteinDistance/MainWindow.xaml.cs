// **************************************************
// 
// Written by Fabian Deitelhoff, 2013-09-12
// http://www.fabiandeitelhoff.de
// 
// **************************************************

using System.Windows;
using Twainsoft.Blog.Example.LevenshteinDistance.Core;

namespace Twainsoft.Blog.Example.LevenshteinDistance
{
    public partial class WinMain
    {
        public WinMain()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            var levenshteinDistance = new Ls();

            var table = levenshteinDistance.Calculate(FirstString.Text,
                SecondString.Text);

            levenshteinDistance.DetectSolution();

            Table.SetData(table);
            Backtrace.Clear();
            Backtrace.AppendText(levenshteinDistance.Backtrace);

            Result.Content = string.Format("Editierdistanz('{0}', '{1}') = {2}", FirstString.Text,
                SecondString.Text, levenshteinDistance.Result);
        }
    }
}