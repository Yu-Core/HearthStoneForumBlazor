namespace HearthStoneForum.Client.Utility
{
    public static class TimeDifference
    {
        public static string TimeDifferenceToNow(DateTime dt)
        {
            TimeSpan ts = DateTime.Now - dt;
            string timedifference = "";
            if (ts.TotalMinutes < 1)
            {
                timedifference = "刚刚";
            }
            else if (ts.TotalMinutes < 60)
            {
                timedifference = ts.Minutes + "分钟前";
            }
            else if (ts.TotalHours < 24)
            {
                timedifference = ts.Hours + "小时前";
            }
            else if (ts.TotalDays < 30)
            {
                timedifference = ts.Days + "天前";
            }
            else if (DateTime.Now.ToString("yyyy").Equals(dt.ToString("yyyy")))
            {
                dt.ToString("MM-dd");
            }
            else
            {
                timedifference = dt.ToString("yyyy-MM-dd");
            }
            return timedifference;
        }
    }
}
