namespace GintamaArcsScrapper.Utils
{
    public static class StringExtensions
    {
        public static string[] Separate(this string s, params char[] separators)
        {
            return s.Split(separators);
        }
    }
}