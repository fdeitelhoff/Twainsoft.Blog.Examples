using System;
using System.Globalization;

namespace Twainsoft.Blog.Example.Localization
{
    static class Program
    {
        static void Main()
        {
            const string lowerCharacters = "abcdefghijklmnopqrstuvwxyz";
            const string upperCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (var culture in cultures)
            {
                var upper = lowerCharacters.ToUpper(culture);
                var lower = upperCharacters.ToLower(culture);

                if (upperCharacters != upper || lowerCharacters != lower)
                {
                    Console.WriteLine(culture.Name);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Total cultures: {0}", cultures.Length);
            Console.ReadLine();
        }
    }
}
