// **************************************************
// 
// Written by Fabian Deitelhoff, 2013-09-13
// http://www.fabiandeitelhoff.de
// 
// **************************************************

using System;
using System.Globalization;
using Twainsoft.Blog.Example.LevenshteinDistance.Core.Model;

namespace Twainsoft.Blog.Example.LevenshteinDistance.Core
{
    public class Ls
    {
        private FieldData[,] Table { get; set; }
        private string FirstString { get; set; }
        private string SecondString { get; set; }
        public int Result { get; private set; }
        public string Backtrace { get; private set; }

        public FieldData[,] Calculate(string firstString, string secondString)
        {
            FirstString = firstString;
            SecondString = secondString;

            Table = new FieldData[FirstString.Length + 2, SecondString.Length + 2];

            Table[0, 0] = new FieldData(" ");
            Table[1, 0] = new FieldData(" ");
            Table[0, 1] = new FieldData(" ");

            for (var i = 2; i <= FirstString.Length + 1; i++)
            {
                Table[i, 0] = new FieldData(FirstString[i - 2].ToString(CultureInfo.InvariantCulture));
            }

            for (var j = 2; j <= SecondString.Length + 1; j++)
            {
                Table[0, j] = new FieldData(SecondString[j - 2].ToString(CultureInfo.InvariantCulture));
            }


            for (var i = 1; i <= FirstString.Length + 1; i++)
            {
                Table[i, 1] = new FieldData(i - 1);
            }

            for (var j = 1; j <= SecondString.Length + 1; j++)
            {
                Table[1, j] = new FieldData(j - 1);
            }

            for (var indexi = 2; indexi <= FirstString.Length + 1; indexi++)
            {
                for (var indexj = 2; indexj <= SecondString.Length + 1; indexj++)
                {
                    Table[indexi, indexj] = CalculateValue(indexi, indexj);
                }
            }

            Result = Table[FirstString.Length, SecondString.Length].CurrentData;

            return Table;
        }

        private FieldData CalculateValue(int i, int j)
        {
            var left = Table[i, j - 1].CurrentData;
            var top = Table[i - 1, j].CurrentData;
            var topLeft = Table[i - 1, j - 1].CurrentData;

            var source = FieldDataSources.TopLeftAddOne;

            if (FirstString[i - 2] != SecondString[j - 2])
            {
                topLeft += 1;
                source = GetFieldDataSourceMin(left, top, topLeft);
            }

            return new FieldData(Min(left + 1, top + 1, topLeft), i, j, source);
        }

        private int Min(int links, int oben, int linksOben)
        {
            return Math.Min(links, Math.Min(oben, linksOben));
        }

        private FieldDataSources GetFieldDataSourceMin(int links, int oben, int linksOben)
        {
            if (links < oben && links < linksOben)
                return FieldDataSources.Left;
            if (oben < links && oben < linksOben)
                return FieldDataSources.Top;
            if (linksOben < links && linksOben < oben)
                return FieldDataSources.TopLeft;
            return FieldDataSources.All;
        }

        public void DetectSolution()
        {
            DetectNextStep(FirstString.Length + 1, SecondString.Length + 1);
        }

        private void DetectNextStep(int i, int j)
        {
            if (i == 0 || j == 0)
            {
                return;
            }

            // Mark every backtraced entry in the table.
            Table[i, j].Backtrace = true;

            // Some character was deleted.
            if (i != 0 && Table[i - 1, j].CurrentData + 1 == Table[i, j].CurrentData)
            {
                Backtrace += string.Format("Deleted: {0}\n", i - 2 >= 0 ? FirstString[i - 2] : SecondString[j - 2]);

                DetectNextStep(i - 1, j);
            }
                // Some character was inserted.
            else if (j != 0 && Table[i, j - 1].CurrentData + 1 == Table[i, j].CurrentData)
            {
                Backtrace += string.Format("Inserted: {0}\n", SecondString[j - 2]);

                DetectNextStep(i, j - 1);
            }
            else
            {
                if (i - 2 >= 0 && j - 2 >= 0)
                {
                    var first = FirstString[i - 2];
                    var second = SecondString[j - 2];

                    // Two matching characters.
                    if (first == second)
                    {
                        Backtrace += string.Format("Matched: {0}\n", first);
                    }
                        // Changed one character.
                    else
                    {
                        Backtrace += string.Format("Substituted {0} with {1}.\n", first, second);
                    }

                    DetectNextStep(i - 1, j - 1);
                }
            }
        }
    }
}