﻿//------------------------------------------------------------------------------
// <copyright file="DateTimeOffsetExtensions.cs"
//  company="Scott Dorman"
//  library="Cadru">
//    Copyright (C) 2001-2014 Scott Dorman.
// </copyright>
//
// <license>
//    Licensed under the Microsoft Public License (Ms-PL) (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//    http://opensource.org/licenses/Ms-PL.html
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </license>
//------------------------------------------------------------------------------

namespace Cadru.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Cadru.Properties;
    using Cadru.Text;
    using Cadru.Internal;

    /// <summary>
    /// Provides basic routines for common DateTimeOffset manipulation.
    /// </summary>
    public static class DateTimeOffsetExtensions
    {
        #region fields
        private static readonly TimeSpan UtcOffset = new TimeSpan(0, 0, 0);
        #endregion

        #region constructors
        #endregion

        #region events
        #endregion

        #region properties
        #endregion

        #region methods

        #region AddWeekdays
        /// <summary>
        /// Returns a new <see cref="DateTimeOffset"/> that adds the specified number of
        /// weekdays to the value of this instance.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <param name="value">A number of whole and fractional weekdays.
        /// The <paramref name="value"/> parameter can be negative or positive.</param>
        /// <returns>A <see cref="DateTimeOffset"/> whose value is the sum of the
        /// date and time represented by this instance and the number of weekdays
        /// represented by <paramref name="value"/>.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// The resulting <see cref="DateTimeOffset"/> is less than
        /// <see cref="DateTimeOffset.MinValue"/> or greater than
        /// <see cref="DateTimeOffset.MaxValue"/>.
        /// </exception>
        public static DateTimeOffset AddWeekdays(this DateTimeOffset date, double value)
        {
            int direction = value < 0 ? -1 : 1;

            while (value != 0)
            {
                date = date.AddDays(direction);
                if (!date.IsWeekend())
                {
                    value -= direction;
                }
            }

            return date;
        }
        #endregion

        #region AddQuarters
        /// <summary>
        /// Returns a new <see cref="DateTimeOffset"/> that adds the specified number of
        /// quarters to the value of this instance.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <param name="value">A number of whole and fractional quarters.
        /// The <paramref name="value"/> parameter can be negative or positive.</param>
        /// <returns>A <see cref="DateTimeOffset"/> whose value is the sum of the
        /// date and time represented by this instance and the number of quarters
        /// represented by <paramref name="value"/>.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// The resulting <see cref="DateTimeOffset"/> is less than
        /// <see cref="DateTimeOffset.MinValue"/> or greater than
        /// <see cref="DateTimeOffset.MaxValue"/>.
        /// </exception>
        public static DateTimeOffset AddQuarters(this DateTimeOffset date, double value)
        {
            return date.AddMonths(checked((int)value * 3));
        }
        #endregion

        #region AddWeeks
        /// <summary>
        /// Returns a new <see cref="DateTimeOffset"/> that adds the specified number of
        /// weeks to the value of this instance.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <param name="value">A number of whole and fractional weeks.
        /// The <paramref name="value"/> parameter can be negative or positive.</param>
        /// <returns>A <see cref="DateTimeOffset"/> whose value is the sum of the
        /// date and time represented by this instance and the number of weeks
        /// represented by <paramref name="value"/>.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// The resulting <see cref="DateTimeOffset"/> is less than
        /// <see cref="DateTimeOffset.MinValue"/> or greater than
        /// <see cref="DateTimeOffset.MaxValue"/>.
        /// </exception>
        public static DateTimeOffset AddWeeks(this DateTimeOffset date, double value)
        {
            return date.AddDays(value * 7);
        }
        #endregion

        #region Between

        #region Between(this DateTimeOffset date, DateTimeOffset start, DateTimeOffset end)
        /// <summary>
        /// Returns a <see cref="Boolean"/> expression indicating whether
        /// the current <see cref="DateTimeOffset"/> instance is between the
        /// start and end indicated.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <param name="start">The starting <see cref="DateTimeOffset"/>.</param>
        /// <param name="end">The ending <see cref="DateTimeOffset"/>.</param>
        /// <returns><see langword="true"/> if the current instance is between
        /// <paramref name="start"/> and <paramref name="end"/>; otherwise,
        /// <see langword="false"/>.</returns>
        public static bool Between(this DateTimeOffset date, DateTimeOffset start, DateTimeOffset end)
        {
            return Between(date, start, end, true);
        }
        #endregion

        #region Between(this DateTimeOffset date, DateTimeOffset start, DateTimeOffset end, bool includeTime)
        /// <summary>
        /// Returns a <see cref="Boolean"/> expression indicating whether
        /// the current <see cref="DateTimeOffset"/> instance is between the
        /// start and end indicated.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <param name="start">The starting <see cref="DateTimeOffset"/>.</param>
        /// <param name="end">The ending <see cref="DateTimeOffset"/>.</param>
        /// <param name="includeTime"><see langword="true"/> to compare
        /// the time portion of the date; otherwise, <see langword="false"/>.</param>
        /// <returns><see langword="true"/> if the current instance is between
        /// <paramref name="start"/> and <paramref name="end"/>; otherwise,
        /// <see langword="false"/>.</returns>
        public static bool Between(this DateTimeOffset date, DateTimeOffset start, DateTimeOffset end, bool includeTime)
        {
            return includeTime ?
               date >= start && date <= end :
               date.Date >= start.Date && date.Date <= end.Date;
        }
        #endregion

        #endregion

        #region DaysInMonth
        /// <summary>
        /// Returns the number of days in the month for the date represented by this instance.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <returns>The number of days in the month for the date represented by this instance.</returns>
        public static int DaysInMonth(this DateTimeOffset date)
        {
            return DateTime.DaysInMonth(date.Year, date.Month);
        }
        #endregion

        #region Elapsed
        /// <summary>
        /// Returns the elapsed time between the date represented by this instance
        /// and the current date and time.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <returns>A <see cref="TimeSpan"/> representing the elapsed
        /// time between the date represented by this instance and the
        /// current date and time.</returns>
        public static TimeSpan Elapsed(this DateTimeOffset date)
        {
            return DateTimeOffset.Now - date;
        }
        #endregion

        #region FirstDayOfMonth
        /// <summary>
        /// Returns a <see cref="DateTimeOffset"/> representing the
        /// first day of the month for the date represented by this instance.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <returns>A <see cref="DateTimeOffset"/> representing the
        /// first day of the month for the date represented by this instance.</returns>
        public static DateTimeOffset FirstDayOfMonth(this DateTimeOffset date)
        {
            var firstDate = new DateTimeOffset(date.Year, date.Month, 1, date.Hour, date.Minute, date.Second, date.Offset);
            return firstDate;
        }
        #endregion

        #region FirstDayOfNextQuarter
        /// <summary>
        /// Returns a <see cref="DateTimeOffset"/> which represents the
        /// first day of the next quarter of the date represented by this instance.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <returns>A <see cref="DateTimeOffset"/> which represents the
        /// first day of the next quarter of the date represented by this instance.</returns>
        public static DateTimeOffset FirstDayOfNextQuarter(this DateTimeOffset date)
        {
            return date.FirstDayOfQuarter().AddMonths(3);
        }
        #endregion

        #region FirstDayOfQuarter
        /// <summary>
        /// Returns a <see cref="DateTimeOffset"/> which represents the
        /// first day of the quarter of the date represented by this instance.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <returns>A <see cref="DateTimeOffset"/> which represents the
        /// first day of the quarter of the date represented by this instance.</returns>
        public static DateTimeOffset FirstDayOfQuarter(this DateTimeOffset date)
        {
            return new DateTimeOffset(date.Year, ((date.Quarter() - 1) * 3) + 1, 1, date.Hour, date.Minute, date.Second, date.Offset);
        }
        #endregion

        #region FirstDayOfWeek
        /// <summary>
        /// Returns a <see cref="DateTimeOffset"/> which represents the
        /// first day of the week of the date represented by this instance.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <returns>A <see cref="DateTimeOffset"/> which represents the
        /// first day of the week of the date represented by this instance.</returns>
        public static DateTimeOffset FirstDayOfWeek(this DateTimeOffset date)
        {
            return date.FirstDayOfWeek(DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek);
        }

        /// <summary>
        /// Returns a <see cref="DateTimeOffset"/> which represents the
        /// first day of the week of the date represented by this instance.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <param name="startOfWeek">An enumeration value that represents the first day of the week.</param>
        /// <returns>A <see cref="DateTimeOffset"/> which represents the
        /// first day of the week of the date represented by this instance.</returns>
        public static DateTimeOffset FirstDayOfWeek(this DateTimeOffset date, DayOfWeek startOfWeek)
        {
            int diff = date.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return date.AddDays(-1 * diff);
        }
        #endregion

        #region FirstDayOfYear
        /// <summary>
        /// Returns a <see cref="DateTimeOffset"/> representing the
        /// first day of the year for the date represented by this instance.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <returns>A <see cref="DateTimeOffset"/> representing the
        /// first day of the year for the date represented by this instance.</returns>
        public static DateTimeOffset FirstDayOfYear(this DateTimeOffset date)
        {
            return new DateTimeOffset(date.Year, 1, 1, date.Hour, date.Minute, date.Second, date.Offset);
        }
        #endregion

        #region GetAbbreviatedMonthName
        /// <summary>
        /// Returns the culture-specific abbreviated name of the month represented by this instance.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <returns>The culture-specific abbreviated name of the month represented by this instance.</returns>
        public static string GetAbbreviatedMonthName(this DateTimeOffset date)
        {
            return DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(date.Month);
        }
        #endregion

        #region GetAbbreviatedMonthNames
        /// <summary>
        /// Returns the culture-specific abbreviated names of the months.
        /// </summary>
        /// <returns>A list that contains the culture-specific abbreviated names of the months.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "This is an extension method.")]
        public static IList<string> GetAbbreviatedMonthNames()
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames.Where(m => !string.IsNullOrEmpty(m)).ToList();
        }
        #endregion

        #region GetDayOfWeek
        /// <summary>
        /// Returns a <see cref="DateTimeOffset"/> representing the
        /// day of the week from the date represented by this instance.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <param name="day">An enumeration value that represents the day of
        /// the week for which the date is to be calculated.</param>
        /// <returns>A <see cref="DateTimeOffset"/> representing the
        /// day of the week from the date represented by this instance.</returns>
        public static DateTimeOffset GetDayOfWeek(this DateTimeOffset date, DayOfWeek day)
        {
            return date.GetDayOfWeek(day, DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek);
        }

        /// <summary>
        /// Returns a <see cref="DateTimeOffset"/> representing the
        /// day of the week from the date represented by this instance.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <param name="day">An enumeration value that represents the day of
        /// the week for which the date is to be calculated.</param>
        /// <param name="startOfWeek">An enumeration value that represents the first day of the week.</param>
        /// <returns>A <see cref="DateTimeOffset"/> representing the
        /// day of the week from the date represented by this instance.</returns>
        public static DateTimeOffset GetDayOfWeek(this DateTimeOffset date, DayOfWeek day, DayOfWeek startOfWeek)
        {
            int current = DaysBetween(date.DayOfWeek, startOfWeek);
            int resultday = DaysBetween(day, startOfWeek);
            return date.AddDays(resultday - current);
        }
        #endregion

        #region GetMonthName
        /// <summary>
        /// Returns the culture-specific name of the month represented by this instance.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <returns>The culture-specific name of the month represented by this instance.</returns>
        public static string GetMonthName(this DateTimeOffset date)
        {
            return DateTimeFormatInfo.CurrentInfo.GetMonthName(date.Month);
        }
        #endregion

        #region GetMonthNames
        /// <summary>
        /// Returns the culture-specific names of the months.
        /// </summary>
        /// <returns>A list that contains the culture-specific names of the months.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "This is an extension method.")]
        public static IList<string> GetMonthNames()
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.MonthNames.Where(m => !string.IsNullOrEmpty(m)).ToList();
        }
        #endregion

        #region GetMonthNumber
        /// <summary>
        /// Returns the month number for the given month name.
        /// </summary>
        /// <param name="name">The month name.</param>
        /// <param name="abbreviated"><see langword="true"/> if the name is abbreviated;
        /// otherwise, <see langword="false"/>.</param>
        /// <returns>The month number for the given month name.</returns>
        public static int GetMonthNumber(string name, bool abbreviated)
        {
            var months = abbreviated ? GetAbbreviatedMonthNames() : GetMonthNames();
            return months.IndexOf(name) + 1;
        }
        #endregion

        #region GetWeekOfYear

        #region GetWeekOfYear(this DateTimeOffset time)
        /// <summary>
        /// Returns the week of the year that includes the date in the specified DateTimeOffset value.
        /// </summary>
        /// <param name="time">A date and time value.</param>
        /// <returns>A positive integer that represents the week of the year
        /// that includes the date in the <paramref name="time"/> parameter.</returns>
        public static int GetWeekOfYear(this DateTimeOffset time)
        {
            return GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
        }
        #endregion

        #region GetWeekOfYear(this DateTimeOffset time, CalendarWeekRule rule)
        /// <summary>
        /// Returns the week of the year that includes the date in the specified DateTimeOffset value.
        /// </summary>
        /// <param name="time">A date and time value.</param>
        /// <param name="rule">An enumeration value that defines a calendar week.</param>
        /// <returns>A positive integer that represents the week of the year
        /// that includes the date in the <paramref name="time"/> parameter.</returns>
        public static int GetWeekOfYear(this DateTimeOffset time, CalendarWeekRule rule)
        {
            return GetWeekOfYear(time, rule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
        }
        #endregion

        #region GetWeekOfYear(this DateTimeOffset time, CalendarWeekRule rule, DayOfWeek firstDayOfWeek)
        /// <summary>
        /// Returns the week of the year that includes the date in the specified DateTimeOffset value.
        /// </summary>
        /// <param name="time">A date and time value.</param>
        /// <param name="rule">An enumeration value that defines a calendar week.</param>
        /// <param name="firstDayOfWeek">An enumeration value that represents the first day of the week.</param>
        /// <returns>A positive integer that represents the week of the year
        /// that includes the date in the <paramref name="time"/> parameter.</returns>
        public static int GetWeekOfYear(this DateTimeOffset time, CalendarWeekRule rule, DayOfWeek firstDayOfWeek)
        {
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(time.DateTime, rule, firstDayOfWeek);
        }
        #endregion

        #endregion

        #region IsLeapYear
        /// <summary>
        /// Determines whether the specified date is a leap year.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <returns><see langword="true"/> if the specified date is a leap year;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool IsLeapYear(this DateTimeOffset date)
        {
            return DateTime.IsLeapYear(date.Year);
        }
        #endregion

        #region IsLeapMonth
        /// <summary>
        /// Determines whether the specified date is a leap month.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <returns><see langword="true"/> if the specified date is a leap month;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool IsLeapMonth(this DateTimeOffset date)
        {
            return CultureInfo.CurrentCulture.Calendar.IsLeapMonth(date.Year, date.Month);
        }
        #endregion

        #region IsLeapDay
        /// <summary>
        /// Determines whether the specified date is a leap day.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <returns><see langword="true"/> if the specified date is a leap day;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool IsLeapDay(this DateTimeOffset date)
        {
            return CultureInfo.CurrentCulture.Calendar.IsLeapDay(date.Year, date.Month, date.Day);
        }
        #endregion

        #region IsWeekday
        /// <summary>
        /// Determines whether the specified date is a week day.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <returns><see langword="true"/> if the specified date is a week day;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool IsWeekday(this DateTimeOffset date)
        {
            return !date.IsWeekend();
        }
        #endregion

        #region IsWeekend
        /// <summary>
        /// Determines whether the specified date is a weekend.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <returns><see langword="true"/> if the specified date is a weekend;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool IsWeekend(this DateTimeOffset date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }
        #endregion

        #region IsUtcDateTime
        /// <summary>
        /// Determines whether he specified date is a UTC date.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <returns><see langword="true"/> if the specified date is a UTC date;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool IsUtcDateTime(this DateTimeOffset date)
        {
            return date.UtcDateTime == date.DateTime && date.Offset == UtcOffset && date.Offset == TimeZoneInfo.Utc.GetUtcOffset(date);
        }
        #endregion

        #region Last
        /// <summary>
        /// Return a <see cref="DateTimeOffset"/> representing the previous day of
        /// the week.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <param name="day">The <see cref="DayOfWeek"/> whose <see cref="DateTime"/>
        /// representation should be returned.</param>
        /// <returns>A <see cref="DateTimeOffset"/> representing the
        /// previous day of the week.</returns>
        public static DateTimeOffset Last(this DateTimeOffset date, DayOfWeek day)
        {
            var yesterday = date.Yesterday();
            var diff = (day - yesterday.DayOfWeek - 7) % 7;
            return yesterday.AddDays(diff);
        }
        #endregion

        #region LastDayOfMonth
        /// <summary>
        /// Returns a <see cref="DateTimeOffset"/> representing the
        /// last day of the month for the date represented by this instance.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <returns>A <see cref="DateTimeOffset"/> representing the
        /// last day of the month for the date represented by this instance.</returns>
        public static DateTimeOffset LastDayOfMonth(this DateTimeOffset date)
        {
            return new DateTimeOffset(date.Year, date.Month, date.DaysInMonth(), date.Hour, date.Minute, date.Second, date.Offset);
        }
        #endregion

        #region LastDayOfQuarter
        /// <summary>
        /// Returns a <see cref="DateTimeOffset"/> which represents the
        /// last day of the quarter of the date represented by this instance.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <returns>A <see cref="DateTimeOffset"/> which represents the
        /// last day of the quarter of the date represented by this instance.</returns>
        public static DateTimeOffset LastDayOfQuarter(this DateTimeOffset date)
        {
            return date.FirstDayOfNextQuarter().AddDays(-1);
        }
        #endregion

        #region LastDayOfWeek
        /// <summary>
        /// Returns a <see cref="DateTimeOffset"/> which represents the
        /// last day of the week of the date represented by this instance.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <returns>A <see cref="DateTimeOffset"/> which represents the
        /// last day of the week of the date represented by this instance.</returns>
        public static DateTimeOffset LastDayOfWeek(this DateTimeOffset date)
        {
            return date.LastDayOfWeek(DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek);
        }

        /// <summary>
        /// Returns a <see cref="DateTimeOffset"/> which represents the
        /// last day of the week of the date represented by this instance.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <param name="firstDayOfWeek">An enumeration value that represents the first day of the week.</param>
        /// <returns>A <see cref="DateTimeOffset"/> which represents the
        /// last day of the week of the date represented by this instance.</returns>
        public static DateTimeOffset LastDayOfWeek(this DateTimeOffset date, DayOfWeek firstDayOfWeek)
        {
            return date.FirstDayOfWeek(firstDayOfWeek).AddDays(6);
        }
        #endregion

        #region LastDayOfYear
        /// <summary>
        /// Returns a <see cref="DateTimeOffset"/> representing the
        /// last day of the year for the date represented by this instance.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <returns>A <see cref="DateTimeOffset"/> representing the
        /// last day of the year for the date represented by this instance.</returns>
        public static DateTimeOffset LastDayOfYear(this DateTimeOffset date)
        {
            return new DateTimeOffset(date.Year, 12, 31, date.Hour, date.Minute, date.Second, date.Offset);
        }
        #endregion

        #region Next
        /// <summary>
        /// Return a <see cref="DateTimeOffset"/> representing the next day of
        /// the week.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <param name="day">The <see cref="DayOfWeek"/> whose <see cref="DateTime"/>
        /// representation should be returned.</param>
        /// <returns>A <see cref="DateTimeOffset"/> representing the
        /// next day of the week.</returns>
        public static DateTimeOffset Next(this DateTimeOffset date, DayOfWeek day)
        {
            var tomorrow = date.Tomorrow();
            var diff = (day - tomorrow.DayOfWeek + 7) % 7;
            return tomorrow.AddDays(diff <= 0 ? diff + 7 : diff);
        }
        #endregion

        #region Quarter
        /// <summary>
        /// Returns the quarter component of the date represented by this instance.
        /// </summary>
        /// <param name="date">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <returns>The quarter component of the date represented by this instance.</returns>
        public static int Quarter(this DateTimeOffset date)
        {
            return ((date.Month - 1) / 3) + 1;
        }
        #endregion

        #region Tomorrow
        /// <summary>
        /// Returns a <see cref="DateTimeOffset"/> representing the day after
        /// the date represented by this instance.
        /// </summary>
        /// <param name="value">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <returns>A <see cref="DateTimeOffset"/> representing the day after
        /// the date represented by this instance.</returns>
        public static DateTimeOffset Tomorrow(this DateTimeOffset value)
        {
            return value.AddDays(1);
        }
        #endregion

        #region ToRelativeDateString

        #region ToRelativeDateString(this DateTimeOffset value)
        /// <summary>
        /// Convert a <see cref="DateTimeOffset"/> object to a relative date
        /// (e.g., Today, tomorrow, yesterday) string format.
        /// </summary>
        /// <param name="value">The <see cref="DateTimeOffset"/> object to convert.</param>
        /// <returns>A relative date/time formatted string.</returns>
        public static string ToRelativeDateString(this DateTimeOffset value)
        {
            return ToRelativeDateString(value, RelativeDateFormattingOptions.DayNames);
        }
        #endregion

        #region ToRelativeDateString(this DateTimeOffset value, RelativeDateFormattingOptions options)
        /// <summary>
        /// Convert a <see cref="DateTimeOffset"/> object to a relative date
        /// (e.g., Today, tomorrow, yesterday) string format.
        /// </summary>
        /// <param name="value">The <see cref="DateTimeOffset"/> object to convert.</param>
        /// <param name="options">One of the <see cref="RelativeDateFormattingOptions"/> values.</param>
        /// <returns>A relative date/time formatted string.</returns>
        public static string ToRelativeDateString(this DateTimeOffset value, RelativeDateFormattingOptions options)
        {
            var diff = value.Date - DateTimeOffset.Now.Date;
            var days = diff.Days;
            string format;

            switch (days)
            {
                case 0:
                    format = String.Format(Resources.RelativeDateFormatStringToday, value);
                    break;

                case 1:
                    format = Resources.RelativeDateFormatStringTomorrow;
                    break;

                case -1:
                    format = Resources.RelativeDateFormatStringYesterday;
                    break;

                case 2:
                case 3:
                case 4:
                case 5:
                    format = options == RelativeDateFormattingOptions.DayNames ? value.ToString("dddd") : String.Format(Resources.RelativeDateFormatStringDaysFromNow, days);
                    break;

                case -2:
                case -3:
                case -4:
                case -5:
                    format = options == RelativeDateFormattingOptions.DayNames ? value.ToString("dddd") : String.Format(Resources.RelativeDateFormatStringDaysAgo, Math.Abs(days));
                    break;

                default:
                    format = String.Format(Resources.RelativeDateFormatStringDefault, value);
                    break;
            }

            return format;
        }
        #endregion

        #endregion

        #region ToRelativeTimeString

        #region ToRelativeTimeString(this DateTimeOffset value)
        /// <summary>
        /// Convert a <see cref="DateTimeOffset"/> object to a relative time
        /// (e.g., now, 2 days ago, 3 days from now) string format.
        /// </summary>
        /// <param name="value">The <see cref="DateTimeOffset"/> object to convert.</param>
        /// <returns>A relative date/time formatted string.</returns>
        public static string ToRelativeTimeString(this DateTimeOffset value)
        {
            return ToRelativeTimeString(value, DateTimeOffset.Now);
        }
        #endregion

        #region ToRelativeTimeString(this DateTimeOffset value, DateTimeOffset baseDate)
        /// <summary>
        /// Convert a <see cref="DateTimeOffset"/> object to a relative time
        /// (e.g., now, 2 days ago, 3 days from now) string format.
        /// </summary>
        /// <param name="value">The <see cref="DateTimeOffset"/> object to convert.</param>
        /// <param name="baseDate">The <see cref="DateTimeOffset"/> object to use as the relative date.</param>
        /// <returns>A relative date/time formatted string.</returns>
        public static string ToRelativeTimeString(this DateTimeOffset value, DateTimeOffset baseDate)
        {
            var diff = baseDate - value;
            var delta = Math.Round(diff.TotalSeconds, 0);
            var format = "now";

            if (Math.Sign(delta) != 0)
            {
                var baseFormat = Resources.RelativeTimeFormatStringPast;
                if (delta < -0.1)
                {
                    baseFormat = Resources.RelativeTimeFormatStringFuture;
                    delta = -delta;
                    diff = -diff;
                }

                if (delta < Constants.SecondsPerMinute)
                {
                    format = String.Format(baseFormat, diff.Seconds, diff.Seconds == 1 ? Resources.RelativeTimeFormatStringSecond : Resources.RelativeTimeFormatStringSeconds);
                }
                else if (delta < Constants.SecondsPerMinute * 2)
                {
                    format = String.Format(baseFormat, diff.Minutes, Resources.RelativeTimeFormatStringMinute);
                }
                else if (delta < Constants.SecondsPerHour)
                {
                    format = String.Format(baseFormat, diff.Minutes, Resources.RelativeTimeFormatStringMinutes);
                }
                else if (delta < Constants.SecondsPerHour * 2)
                {
                    format = String.Format(baseFormat, diff.Hours, Resources.RelativeTimeFormatStringHour);
                }
                else if (delta < Constants.SecondsPerDay)
                {
                    format = String.Format(baseFormat, diff.Hours, Resources.RelativeTimeFormatStringHours);
                }
                else if (delta < Constants.SecondsPerDay * 2)
                {
                    format = String.Format(baseFormat, diff.Days, Resources.RelativeTimeFormatStringDay);
                }
                else if (delta < Constants.ApproximateSecondsPerMonth)
                {
                    format = String.Format(baseFormat, diff.Days, Resources.RelativeTimeFormatStringDays);
                }
                else if (delta < Constants.ApproximateSecondsPerYear)
                {
                    var months = Convert.ToInt32(Math.Floor((double)diff.Days / 30));
                    format = String.Format(baseFormat, months, months <= 1 ? Resources.RelativeTimeFormatStringMonth : Resources.RelativeTimeFormatStringMonths);
                }
                else
                {
                    var years = Convert.ToInt32(Math.Floor((double)diff.Days / 365));
                    format = String.Format(baseFormat, years, years <= 1 ? Resources.RelativeTimeFormatStringYear : Resources.RelativeTimeFormatStringYears);
                }
            }

            return format;
        }
        #endregion

        #endregion

        #region Yesterday
        /// <summary>
        /// Returns a <see cref="DateTimeOffset"/> representing the day before
        /// the date represented by this instance.
        /// </summary>
        /// <param name="value">A valid <see cref="DateTimeOffset"/> instance.</param>
        /// <returns>A <see cref="DateTimeOffset"/> representing the day before
        /// the date represented by this instance.</returns>
        public static DateTimeOffset Yesterday(this DateTimeOffset value)
        {
            return value.AddDays(-1);
        }
        #endregion

        #region DaysBetween
        private static int DaysBetween(DayOfWeek current, DayOfWeek firstDayOfWeek)
        {
            int days = current - firstDayOfWeek;
            return days < 0 ? days + 7 : days;
        }
        #endregion

        #endregion
    }
}
