namespace HearthStoneForum.Client.Extend
{
    public static class StringExtend
    {
        public static string StringCutOutByLength(this string str, int length)
        {
            if (str.Length < length) return str;
            return str.Substring(0, length) + "...";
        }
    }
}
