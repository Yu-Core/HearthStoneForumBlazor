namespace HearthStoneForum.Client.Extend
{
    public static class StringExtend
    {
        public static string StringCutOutByLength(this string str, int length)
        {
            if (string.IsNullOrWhiteSpace(str)) return string.Empty;
            if (str.Length <= length) return str;
            return str.Substring(0, length) + "...";
        }

        public static string GetStringInitial(this string str, int length)
        {
            if(string.IsNullOrWhiteSpace(str)) return string.Empty;
            if (str.Length <= length) return str;
            return str.Substring(0, length).ToUpper();
        }
    }
}
