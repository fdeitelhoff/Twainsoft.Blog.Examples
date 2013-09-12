// **************************************************
// 
// Written by Fabian Deitelhoff, 2013-09-12
// http://www.fabiandeitelhoff.de
// 
// **************************************************

namespace Twainsoft.Blog.Example.LevenshteinDistance.Core.Model
{
    public class FieldData
    {
        private FieldData()
        {
            I = 0;
            J = 0;

            FieldDataSource = FieldDataSources.None;
        }

        public FieldData(int currentData)
            : this()
        {
            CurrentData = currentData;
        }

        public FieldData(string content)
            : this()
        {
            Content = content;
        }

        public FieldData(int currentData, int i, int j, FieldDataSources fieldDataSource)
            : this(currentData)
        {
            I = i;
            J = j;
            FieldDataSource = fieldDataSource;
        }

        public int CurrentData { get; set; }
        public int I { get; set; }
        public int J { get; set; }
        public FieldDataSources FieldDataSource { get; set; }
        public string Content { get; set; }
        public bool Backtrace { get; set; }
    }
}