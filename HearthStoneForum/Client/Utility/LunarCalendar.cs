using System.Globalization;
using System.Text;

namespace HearthStoneForum.Client.Utility
{
    public static class LunarCalendar
    {
        public static string ChineseTimeNow = "";
        public static string ForignTimeNow = "";
        private static readonly ChineseLunisolarCalendar calendar = new ChineseLunisolarCalendar();
        private static readonly string ChineseNumber = "〇一二三四五六七八九";
        public const string CelestialStem = "甲乙丙丁戊己庚辛壬癸";
        public const string TerrestrialBranch = "子丑寅卯辰巳午未申酉戌亥";
        public static readonly string[] ChineseDayName = new string[] {
            "初一","初二","初三","初四","初五","初六","初七","初八","初九","初十",
            "十一","十二","十三","十四","十五","十六","十七","十八","十九","二十",
            "廿一","廿二","廿三","廿四","廿五","廿六","廿七","廿八","廿九","三十"};
        public static readonly string[] ChineseMonthName = new string[] { "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "十二" };

        /// <summary>
        /// 获取一个公历日期对应的完整的农历日期
        /// </summary>
        /// <param name="time">一个公历日期</param>
        /// <returns>农历日期</returns>
        public static string GetChineseDate(DateTime time)
        {

            string strM = GetMonth(time);
            string strD = GetDay(time);
            string strSB = GetStemBranch(time);
            string strDate = strSB + "年 " + strM + "月 " + strD;
            return strDate;
        }
        /// <summary>
        /// 获取一个公历日期的农历干支纪年
        /// </summary>
        /// <param name="time">一个公历日期</param>
        /// <returns>农历干支纪年</returns>
        public static string GetStemBranch(DateTime time)
        {
            int sexagenaryYear = calendar.GetSexagenaryYear(time);
            int celestialStemIndex = sexagenaryYear % 10 - 1;
            if (celestialStemIndex < 0)
            {
                celestialStemIndex = 0;
            }
            int terrestrialBranchIndex = sexagenaryYear % 12 - 1;
            if (terrestrialBranchIndex < 0)
            {
                terrestrialBranchIndex = 0;
            }
            string stemBranch = CelestialStem.Substring(celestialStemIndex, 1) + TerrestrialBranch.Substring(terrestrialBranchIndex, 1);
            return stemBranch;
        }

        /// <summary>
        /// 获取一个公历日期的农历年份
        /// </summary>
        /// <param name="time">一个公历日期</param>
        /// <returns>农历年份</returns>
        public static string GetYear(DateTime time)
        {
            StringBuilder sb = new StringBuilder();
            int year = calendar.GetYear(time);
            int d;
            do
            {
                d = year % 10;
                sb.Insert(0, ChineseNumber[d]);
                year /= 10;
            } while (year > 0);
            return sb.ToString();
        }

        /// <summary>
        /// 获取一个公历日期的农历月份
        /// </summary>
        /// <param name="time">一个公历日期</param>
        /// <returns>农历月份</returns>
        public static string GetMonth(DateTime time)
        {
            int month = calendar.GetMonth(time);
            int year = calendar.GetYear(time);
            int leap = 0;

            //正月不可能闰月
            for (int i = 3; i <= month; i++)
            {
                if (calendar.IsLeapMonth(year, i))
                {
                    leap = i;
                    break; //一年中最多有一个闰月
                }

            }
            if (leap > 0) month--;
            return (leap == month + 1 ? "闰" : "") + ChineseMonthName[month - 1];
        }

        /// <summary>
        /// 获取一个公历日期的农历日
        /// </summary>
        /// <param name="time">一个公历日期</param>
        /// <returns>农历日</returns>
        public static string GetDay(DateTime time)
        {
            return ChineseDayName[calendar.GetDayOfMonth(time) - 1];
        }
    }
}
