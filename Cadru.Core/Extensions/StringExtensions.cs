//------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" 
//  company="Scott Dorman" 
//  library="Cadru">
//    Copyright (C) 2001-2013 Scott Dorman.
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

namespace Cadru
{
    using System;
    using System.Globalization;
    using System.Text;
    using Cadru.Properties;
    using Cadru.Text;

    /// <summary>
    /// Provides basic routines for common string manipulation.
    /// </summary>
    public static class StringExtensions
    {
        #region LastCharacter
        /// <summary>
        /// Returns the last character in <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <returns>The last character in the string of the null character ('\0') if the
        /// string has a zero length.</returns>
        public static char LastCharacter(this string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            char lastCharacter = '\0';
            if (source.Length > 0)
            {
                lastCharacter = source[source.Length - 1];
            }

            return lastCharacter;
        }
        #endregion

        #region LeftSubstring

        #region LeftSubstring(string source, char value)
        /// <summary>
        /// Retrieves a substring from <paramref name="source"/>. The substring ends at the
        /// specified character position.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="value">The ending character of a substring.</param>
        /// <returns>A <see cref="String"/> object equivalent to the substring that 
        /// ends at the position of <paramref name="value"/> in <paramref name="source"/>, or
        /// the entire string if <paramref name="value"/> is not found in the string.
        /// </returns>
        public static string LeftSubstring(this string source, char value)
        {
            return LeftSubstring(source, value, 1);
        }
        #endregion

        #region LeftSubstring(string source, char value, int occurrence)
        /// <summary>
        /// Retrieves a substring from <paramref name="source"/>. The substring ends at the
        /// specified string position.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="value">The ending string of a substring.</param>
        /// <param name="occurrence">The occurrence of <paramref name="value"/>.</param>
        /// <returns>A <see cref="String"/> object equivalent to the substring that 
        /// ends at the position of <paramref name="value"/> in <paramref name="source"/>, or
        /// the entire string if <paramref name="value"/> is not found in the string.
        /// </returns>
        public static string LeftSubstring(this string source, char value, int occurrence)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            string substring = source;
            int index = source.IndexOf(value);

            while (index != -1 && occurrence > 1)
            {
                index = source.IndexOf(value, index + 1);
                --occurrence;
            }

            if (index != -1)
            {
                substring = source.Substring(0, index + 1);
            }

            return substring;
        }
        #endregion

        #region LeftSubstring(string source, int endingIndex)
        /// <summary>
        /// Retrieves a substring from <paramref name="source"/>. The substring ends at the
        /// specified character position.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="endingIndex">The index of the end of the substring.</param>
        /// <returns>A <see cref="String"/> object equivalent to the substring that 
        /// ends at <paramref name="endingIndex"/> in <paramref name="source"/>, or
        /// the entire string if <paramref name="endingIndex"/> is not found in the string.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">endingIndex is less than zero. </exception>
        public static string LeftSubstring(this string source, int endingIndex)
        {
            return LeftSubstring(source, endingIndex, true);
        }
        #endregion

        #region LeftSubstring(string source, int endingIndex, bool inclusive)
        /// <summary>
        /// Retrieves a substring from <paramref name="source"/>. The substring ends at the
        /// specified character position.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="endingIndex">The index of the end of the substring.</param>
        /// <param name="inclusive">Indicates if the substring should include the ending character position.</param>
        /// <returns>A <see cref="String"/> object equivalent to the substring that 
        /// ends at <paramref name="endingIndex"/> in <paramref name="source"/>, or
        /// the entire string if <paramref name="endingIndex"/> is not found in the string.
        /// </returns>
        public static string LeftSubstring(this string source, int endingIndex, bool inclusive)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (endingIndex <= 0)
            {
                throw new ArgumentOutOfRangeException("endingIndex", Resources.ArgumentOutOfRange_IndexLessThanZero);
            }

            if (endingIndex > source.Length)
            {
                throw new ArgumentOutOfRangeException("endingIndex", Resources.ArgumentOutOfRange_IndexLessThanLength);
            }

            if (inclusive)
            {
                endingIndex++;
            }

            return source.Substring(0, endingIndex);
        }
        #endregion

        #region LeftSubstring(string source, string value)
        /// <summary>
        /// Retrieves a substring from <paramref name="source"/>. The substring ends at the
        /// specified string position.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="value">The ending string of a substring.</param>
        /// <returns>A <see cref="String"/> object equivalent to the substring that 
        /// ends at the position of <paramref name="value"/> in <paramref name="source"/>, or
        /// the entire string if <paramref name="value"/> is not found in the string.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1307:SpecifyStringComparison", MessageId = "Cadru.StringExtensions.LeftSubstring(System.String,System.String,System.Int32)", Justification = "Reviewed.")]
        public static string LeftSubstring(this string source, string value)
        {
            return LeftSubstring(source, value, 1);
        }
        #endregion

        #region LeftSubstring(string source, string value, int occurrence)
        /// <summary>
        /// Retrieves a substring from <paramref name="source"/>. The substring ends at the
        /// specified string position.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="value">The ending string of a substring.</param>
        /// <param name="occurrence">The occurrence of <paramref name="value"/>.</param>
        /// <returns>A <see cref="String"/> object equivalent to the substring that 
        /// ends at the position of <paramref name="value"/> in <paramref name="source"/>, or
        /// the entire string if <paramref name="value"/> is not found in the string.
        /// </returns>
        public static string LeftSubstring(this string source, string value, int occurrence)
        {
            return LeftSubstring(source, value, occurrence, StringComparison.Ordinal);
        }
        #endregion

        #region LeftSubstring(string source, string value, int occurrence, StringComparison comparisonType)
        /// <summary>
        /// Retrieves a substring from <paramref name="source"/>. The substring ends at the
        /// specified string position.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="value">The ending string of a substring.</param>
        /// <param name="occurrence">The occurrence of <paramref name="value"/>.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param> 
        /// <returns>A <see cref="String"/> object equivalent to the substring that 
        /// ends at the position of <paramref name="value"/> in <paramref name="source"/>, or
        /// the entire string if <paramref name="value"/> is not found in the string.
        /// </returns>
        public static string LeftSubstring(this string source, string value, int occurrence, StringComparison comparisonType)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            string substring = source;
            int index = source.IndexOf(value, comparisonType);

            while (index != -1 && occurrence > 1)
            {
                index = source.IndexOf(value, index + 1, comparisonType);
                --occurrence;
            }

            if (index != -1)
            {
                substring = source.Substring(0, index + 1);
            }

            return substring;
        }
        #endregion

        #endregion

        #region LengthBetween

        #region LengthBetween(String expression, Int32 minimum, Int32 maximum)
        /// <summary>
        /// Returns a <see cref="Boolean"/> expression indicating whether the length of <paramref name="expression"/>
        /// is between the minimum and maximum indicated.
        /// </summary>
        /// <param name="expression">Any string expression.</param>
        /// <param name="minimum">The minimum string length.</param>
        /// <param name="maximum">The maximum string length.</param>
        /// <returns>MinMax returns <see langword="true" /> if <paramref name="expression"/> is greater than
        /// the minimum value but less than the maximum value; otherwise it 
        /// returns <see langword="false" />.</returns>
        public static bool LengthBetween(this String expression, Int32 minimum, Int32 maximum)
        {
            return LengthBetween(expression, minimum, maximum, NumericComparisonOptions.IncludeBoth);
        }
        #endregion

        #region LengthBetween(String expression, Int32 minimum, Int32 maximum, MinMaxCompareOptions options)
        /// <summary>
        /// Returns a <see cref="Boolean"/> expression indicating whether the length of <paramref name="expression"/>
        /// is between the minimum and maximum indicated.
        /// </summary>
        /// <param name="expression">Any string expression.</param>
        /// <param name="minimum">The minimum string length.</param>
        /// <param name="maximum">The maximum string length.</param>
        /// <param name="options">A bitwise combination of enumeration values 
        /// that defines whether the comparison is inclusive.</param>
        /// <returns>MinMax returns <see langword="true" /> if <paramref name="expression"/> is greater than
        /// the minimum value but less than the maximum value; otherwise it 
        /// returns <see langword="false" />.</returns>
        public static bool LengthBetween(this String expression, Int32 minimum, Int32 maximum, NumericComparisonOptions options)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            var success = false;
            var length = expression.Length;

            switch (options)
            {
                case NumericComparisonOptions.IncludeBoth:
                    success = length >= minimum && length <= maximum;
                    break;

                case NumericComparisonOptions.IncludeMinimum:
                    success = length >= minimum && length < maximum;
                    break;

                case NumericComparisonOptions.IncludeMaximum:
                    success = length > minimum && length <= maximum;
                    break;

                default:
                    success = length > minimum && length < maximum;
                    break;
            }

            return success;
        }
        #endregion

        #endregion

        #region LengthGreaterThan
        /// <summary>
        /// Returns a <see cref="Boolean"/> expression indicating whether
        /// the length of <paramref name="expression"/> is greater than the
        /// minimum indicated.
        /// </summary>
        /// <param name="expression">The value to test.</param>
        /// <param name="minimum">The minimum value to compare against.</param>
        /// <returns>
        /// <see langword="true"/> if the length of <paramref name="expression"/>
        /// is greater than the minimum indicated; otherwise <see langword="false"/>.
        /// </returns>
        public static bool LengthGreaterThan(this String expression, Int32 minimum)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return expression.Length > minimum;
        }
        #endregion

        #region LengthGreaterThanOrEqualTo
        /// <summary>
        /// Returns a <see cref="Boolean"/> expression indicating whether
        /// the length of <paramref name="expression"/> is greater than or
        /// equal to the minimum indicated.
        /// </summary>
        /// <param name="expression">The value to test.</param>
        /// <param name="minimum">The minimum value to compare against.</param>
        /// <returns>
        /// <see langword="true"/> if the length of <paramref name="expression"/>
        /// is greater than or equal to the minimum indicated; otherwise <see langword="false"/>.
        /// </returns>
        public static bool LengthGreaterThanOrEqualTo(this String expression, Int32 minimum)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return expression.Length >= minimum;
        }
        #endregion

        #region LengthLessThan
        /// <summary>
        /// Returns a <see cref="Boolean"/> expression indicating whether
        /// the length of <paramref name="expression"/> is less than the
        /// minimum indicated.
        /// </summary>
        /// <param name="expression">The value to test.</param>
        /// <param name="maximum">The maximum value to compare against.</param>
        /// <returns>
        /// <see langword="true"/> if the length of <paramref name="expression"/>
        /// is less than the minimum indicated; otherwise <see langword="false"/>.
        /// </returns>
        public static bool LengthLessThan(this String expression, Int32 maximum)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return expression.Length < maximum;
        }
        #endregion

        #region LengthLessThanOrEqualTo
        /// <summary>
        /// Returns a <see cref="Boolean"/> expression indicating whether
        /// the length of <paramref name="expression"/> is less than or
        /// equal to the minimum indicated.
        /// </summary>
        /// <param name="expression">The value to test.</param>
        /// <param name="maximum">The maximum value to compare against.</param>
        /// <returns>
        /// <see langword="true"/> if the length of <paramref name="expression"/>
        /// is less than or equal to the minimum indicated; otherwise <see langword="false"/>.
        /// </returns>
        public static bool LengthLessThanOrEqualTo(this String expression, Int32 maximum)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return expression.Length <= maximum;
        }
        #endregion

        #region IsNullOrWhiteSpace
        /// <summary>
        /// Indicates whether a specified string is <see langword="null"/>, 
        /// <see cref="String.Empty">empty</see>, or consists only of white-space characters
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns><see langword="true"/> if the <paramref name="value"/>
        /// parameter is <see langword="null"/>null or <see cref="String.Empty">String.Empty</see>,
        /// or if <paramref name="value"/> consists exclusively of white-space characters.</returns>
        /// <remarks>White-space characters are defined by the Unicode standard. The 
        /// <see cref="IsNullOrWhiteSpace"/> method interprets any character that returns a value of 
        /// <see langword="true"/> when it is passed to the <see cref="Char.IsWhiteSpace(char)"/>
        /// method as a white-space character.</remarks>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            if (value != null)
            {
                int num = 0;
                while (num < value.Length)
                {
                    if (char.IsWhiteSpace(value[num]))
                    {
                        num++;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region IsNotNullOrWhiteSpace
        /// <summary>
        /// Indicates whether a specified string is not <see langword="null"/>, 
        /// <see cref="String.Empty">empty</see>, or consists only of white-space characters
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns><see langword="true"/> if the <paramref name="value"/>
        /// parameter is not <see langword="null"/>null or <see cref="String.Empty">String.Empty</see>,
        /// or if <paramref name="value"/> does not consist exclusively of white-space characters.</returns>
        /// <remarks>White-space characters are defined by the Unicode standard. The 
        /// <see cref="IsNotNullOrWhiteSpace"/> method interprets any character that returns a value of 
        /// <see langword="true"/> when it is passed to the <see cref="Char.IsWhiteSpace(char)"/>
        /// method as a white-space character.</remarks>
        public static bool IsNotNullOrWhiteSpace(this string value)
        {
            return !value.IsNullOrWhiteSpace();
        }
        #endregion

        #region Normalize

        #region Normalize(string source)
        /// <summary>
        /// Returns a new string whose textual value is the normalized form of
        /// <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="String"/> to normalize.
        /// </param>
        /// <returns>A new, normalized string.</returns>
        /// <remarks><para>The <see cref="Normalize(string)"/> method removes 
        /// all occurrences of white space and control characters from the 
        /// beginning and end of the given string as well as collapsing all 
        /// internal white space characters to a single white space character.
        /// </para>
        /// </remarks>
        public static string Normalize(this string source)
        {
            return Normalize(source, NormalizationOptions.All);
        }
        #endregion

        #region Normalize(string source, NormalizationOptions options)
        /// <summary>
        /// Returns a new string whose textual value is the normalized form of
        /// <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="String"/> to normalize.
        /// </param>
        /// <param name="options">One of the 
        /// <see cref="NormalizationOptions"/> values.</param>
        /// <returns>A new, normalized string.</returns>
        public static string Normalize(this string source, NormalizationOptions options)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if ((int)options < 0 || ((int)options & (int)~(NormalizationOptions.ControlCharacters | NormalizationOptions.Whitespace)) != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentUICulture, Resources.Argument_EnumIllegalVal, (int)options), "options");
            }

            char[] normalized;

            if ((options & NormalizationOptions.Whitespace) == NormalizationOptions.Whitespace)
            {
                normalized = source.Trim().ToCharArray();
            }
            else
            {
                normalized = source.ToCharArray();
            }

            int index = 0;
            int whitespaceCount = 0;
            int controlCount = 0;
            StringBuilder builder = new StringBuilder(source.Length);
            while (index < normalized.Length)
            {
                if ((options & NormalizationOptions.Whitespace) == NormalizationOptions.Whitespace)
                {
                    int position = index;
                    if (Char.IsWhiteSpace(normalized[position]))
                    {
                        while ((position + 1) < normalized.Length && Char.IsWhiteSpace(normalized[++position]))
                        {
                            // we found a whitespace character, so look ahead until we
                            // find the next non-whitespace character.
                            whitespaceCount++;
                        }

                        if (whitespaceCount >= 0)
                        {
                            builder.Append(" ");
                        }

                        whitespaceCount = 0;
                        index = position;
                    }
                }

                if ((options & NormalizationOptions.ControlCharacters) == NormalizationOptions.ControlCharacters)
                {
                    if (Char.IsControl(normalized[index]))
                    {
                        int position = index;
                        while ((position + 1) < normalized.Length && Char.IsControl(normalized[++position]))
                        {
                            // we found a control character, so look ahead until we
                            // find the next non-control character.
                            controlCount++;
                        }

                        controlCount = 0;
                        index = position;
                    }
                }

                builder.Append(normalized[index]);
                index++;
            }

            return builder.ToString();
        }
        #endregion

        #endregion

        #region OccurrencesOf

        #region OccurrencesOf(string source, char value)
        /// <summary>
        /// Returns the number of times <paramref name="value"/> appears in <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="value">The character to count.</param>
        /// <returns>The number of times <paramref name="value"/> appears in <paramref name="source"/>
        /// or 0 if <paramref name="value"/> is not found in the string.</returns>
        public static int OccurrencesOf(this string source, char value)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            int count = 0;
            foreach (char c in source)
            {
                if (c == value)
                {
                    ++count;
                }
            }

            return count;
        }
        #endregion

        #region OccurrencesOf(string source, string value)
        /// <summary>
        /// Returns the number of times <paramref name="value"/> appears in <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="value">The string to count.</param>
        /// <returns>The number of times <paramref name="value"/> appears in <paramref name="source"/>
        /// or 0 if <paramref name="value"/> is not found in the string.</returns>
        public static int OccurrencesOf(this string source, string value)
        {
            return OccurrencesOf(source, value, StringComparison.Ordinal);
        }
        #endregion

        #region OccurrencesOf(string source, string value, StringComparison comparisonType)
        /// <summary>
        /// Returns the number of times <paramref name="value"/> appears in <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="value">The string to count.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param> 
        /// <returns>The number of times <paramref name="value"/> appears in <paramref name="source"/>
        /// or 0 if <paramref name="value"/> is not found in the string.</returns>
        public static int OccurrencesOf(this string source, string value, StringComparison comparisonType)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            int count = 0;
            int index = source.IndexOf(value, comparisonType);

            if (index != -1)
            {
                count++;

                while (index >= 0)
                {
                    index = source.IndexOf(value, index + 1, comparisonType);
                    if (index != -1)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
        #endregion

        #endregion

        #region Replace

        #region Replace(string source, char oldValue, char newValue, int occurrences)
        /// <summary>
        /// Returns a new string where <paramref name="oldValue"/> has been replaced by <paramref name="newValue"/>.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="oldValue">The character to replace.</param>
        /// <param name="newValue">The replacement character.</param>
        /// <param name="occurrences">The occurrences of <paramref name="oldValue"/> to replace.</param>
        /// <returns>A new string where <paramref name="oldValue"/> 
        /// has been replaced by <paramref name="newValue"/>.</returns>
        public static string Replace(this string source, char oldValue, char newValue, int occurrences)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            int count = 0;
            int index = 0;
            char[] newString = source.ToCharArray();

            while (index < (newString.Length - 1) && count < occurrences)
            {
                if (newString[index] == oldValue)
                {
                    newString[index] = newValue;
                    count++;
                }

                index++;
            }

            return new String(newString);
        }
        #endregion

        #region Replace(string source, string oldValue, string newValue, int occurrences)
        /// <summary>
        /// Returns a new string where <paramref name="oldValue"/> 
        /// has been replaced by <paramref name="newValue"/>.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="oldValue">The character to replace.</param>
        /// <param name="newValue">The replacement character.</param>
        /// <param name="occurrences">The occurrences of <paramref name="oldValue"/> to replace.</param>
        /// <returns>A new string where <paramref name="oldValue"/> 
        /// has been replaced by <paramref name="newValue"/>.</returns>
        public static string Replace(this string source, string oldValue, string newValue, int occurrences)
        {
            return Replace(source, oldValue, newValue, occurrences, StringComparison.Ordinal);
        }
        #endregion

        #region Replace(string source, string oldValue, string newValue, int occurrences, StringComparison comparisonType)
        /// <summary>
        /// Returns a new string where <paramref name="oldValue"/>
        /// has been replaced by <paramref name="newValue"/>.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="oldValue">The character to replace.</param>
        /// <param name="newValue">The replacement character.</param>
        /// <param name="occurrences">The occurrences of <paramref name="oldValue"/> to replace.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param> 
        /// <returns>A new string where <paramref name="oldValue"/> 
        /// has been replaced by <paramref name="newValue"/>.</returns>
        public static string Replace(this string source, string oldValue, string newValue, int occurrences, StringComparison comparisonType)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (oldValue == null)
            {
                throw new ArgumentNullException("oldValue");
            }

            if (newValue == null)
            {
                throw new ArgumentNullException("newValue");
            }

            string newString = source;
            int index = source.IndexOf(oldValue, comparisonType);
            int lastIndex = 0;
            int length = oldValue.Length;
            int count = 0;

            if (index != -1 && occurrences > 0)
            {
                StringBuilder builder = new StringBuilder(source.Length);

                // we found an occurrence, so replace it.
                builder.Append(source.Substring(0, index));
                builder.Append(newValue);

                count++;
                lastIndex = index;
                int startingIndex = lastIndex + length;

                while (index >= 0 && count < occurrences)
                {
                    index = source.IndexOf(oldValue, index + 1, comparisonType);
                    lastIndex = index;
                    if (index != -1)
                    {
                        builder.Append(source.Substring(startingIndex, index - startingIndex));
                        builder.Append(newValue);
                        startingIndex = lastIndex + length;
                        count++;
                    }
                }

                builder.Append(source.Substring(startingIndex));
                newString = builder.ToString();
            }

            return newString;
        }
        #endregion

        #endregion

        #region ReplaceBetween

        #region ReplaceBetween(string source, char start, char end, string newValue)
        /// <summary>
        /// Returns a new string where the text between <paramref name="start"/> and
        /// <parameref name="end"/> has been replaced by <paramref name="newValue"/>.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="start">The starting character of the replacement substring.</param>
        /// <param name="end">The ending character of the replacement substring.</param>
        /// <param name="newValue">The replacement text.</param>
        /// <returns>A new string where the text between <paramref name="start"/> and
        /// <parameref name="end"/> has been replaced by <paramref name="newValue"/>.</returns>
        public static string ReplaceBetween(this string source, char start, char end, string newValue)
        {
            return ReplaceBetween(source, start, end, newValue, false);
        }
        #endregion

        #region ReplaceBetween(string source, char start, char end, string newValue, bool inclusive)
        /// <summary>
        /// Returns a new string where the text between <paramref name="start"/> and
        /// <parameref name="end"/> has been replaced by <paramref name="newValue"/>.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="start">The starting character of the replacement substring.</param>
        /// <param name="end">The ending character of the replacement substring.</param>
        /// <param name="newValue">The replacement text.</param>
        /// <param name="inclusive">Indicates if the substring should include the start and end characters.</param> 
        /// <returns>A new string where the text between <paramref name="start"/> and
        /// <parameref name="end"/> has been replaced by <paramref name="newValue"/>.</returns>
        public static string ReplaceBetween(this string source, char start, char end, string newValue, bool inclusive)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (newValue == null)
            {
                throw new ArgumentNullException("newValue");
            }

            string newString = source;
            int startIndex = source.IndexOf(start);

            if (startIndex != -1)
            {
                int endIndex = source.IndexOf(end, startIndex + 1);

                if (endIndex != -1)
                {
                    if (inclusive)
                    {
                        // We need to offset the endIndex by 1 to include
                        // the bracketing character.
                        endIndex++;
                    }
                    else
                    {
                        // We need to offset the startIndex by 1 to exclude the
                        // bracketing character.
                        startIndex++;
                    }

                    newString = String.Concat(source.Substring(0, startIndex), newValue, source.Substring(endIndex));
                }
            }

            return newString;
        }
        #endregion

        #region ReplaceBetween(string source, int start, int end, string newValue)
        /// <summary>
        /// Returns a new string where the text between <paramref name="start"/> and
        /// <parameref name="end"/> has been replaced by <paramref name="newValue"/>.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="start">The starting index of the replacement substring.</param>
        /// <param name="end">The ending index of the replacement substring.</param>
        /// <param name="newValue">The replacement text.</param>
        /// <returns>A new string where the text between <paramref name="start"/> and
        /// <parameref name="end"/> has been replaced by <paramref name="newValue"/>.</returns>
        public static string ReplaceBetween(this string source, int start, int end, string newValue)
        {
            return ReplaceBetween(source, start, end, newValue, false);
        }
        #endregion

        #region ReplaceBetween(string source, int start, int end, string newValue, bool inclusive)
        /// <summary>
        /// Returns a new string where the text between <paramref name="start"/> and
        /// <parameref name="end"/> has been replaced by <paramref name="newValue"/>.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="start">The starting index of the replacement substring.</param>
        /// <param name="end">The ending index of the replacement substring.</param>
        /// <param name="newValue">The replacement text.</param>
        /// <param name="inclusive">Indicates if the substring should include the start and end indices.</param> 
        /// <returns>A new string where the text between <paramref name="start"/> and
        /// <parameref name="end"/> has been replaced by <paramref name="newValue"/>.</returns>
        public static string ReplaceBetween(this string source, int start, int end, string newValue, bool inclusive)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (newValue == null)
            {
                throw new ArgumentNullException("newValue");
            }

            if (start < 0)
            {
                throw new ArgumentOutOfRangeException("start", Resources.ArgumentOutOfRange_IndexLessThanZero);
            }

            if (start > source.Length)
            {
                throw new ArgumentOutOfRangeException("start", Resources.ArgumentOutOfRange_IndexLessThanLength);
            }

            if (end < 0)
            {
                throw new ArgumentOutOfRangeException("end", Resources.ArgumentOutOfRange_IndexLessThanZero);
            }

            if (end > source.Length)
            {
                throw new ArgumentOutOfRangeException("end", Resources.ArgumentOutOfRange_IndexLessThanLength);
            }

            if (start > end)
            {
                throw new ArgumentException(Resources.Argument_StartIndexGreaterThanEndIndexString, "start");
            }

            if (start == end)
            {
                throw new ArgumentException(Resources.Argument_InvalidIndexValuesString, "start");
            }

            string newString = source;

            if (inclusive)
            {
                // We need to offset the ending index by 1 to include the
                // bracketing character.
                end++;
            }
            else
            {
                // We need to offset the starting index by 1 to exclude the
                // bracketing character.
                start++;
            }

            newString = String.Concat(source.Substring(0, start), newValue, source.Substring(end));
            return newString;
        }
        #endregion

        #region ReplaceBetween(string source, string start, string end, string newValue)
        /// <summary>
        /// Returns a new string where the text between <paramref name="start"/> and
        /// <parameref name="end"/> has been replaced by <paramref name="newValue"/>.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="start">The starting string of the replacement substring.</param>
        /// <param name="end">The ending string of the replacement substring.</param>
        /// <param name="newValue">The replacement text.</param>
        /// <returns>A new string where the text between <paramref name="start"/> and
        /// <parameref name="end"/> has been replaced by <paramref name="newValue"/>.</returns>
        public static string ReplaceBetween(this string source, string start, string end, string newValue)
        {
            return ReplaceBetween(source, start, end, newValue, false, StringComparison.Ordinal);
        }
        #endregion

        #region ReplaceBetween(string source, string start, string end, string newValue, bool inclusive)
        /// <summary>
        /// Returns a new string where the text between <paramref name="start"/> and
        /// <parameref name="end"/> has been replaced by <paramref name="newValue"/>.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="start">The starting string of the replacement substring.</param>
        /// <param name="end">The ending string of the replacement substring.</param>
        /// <param name="newValue">The replacement text.</param>
        /// <param name="inclusive">Indicates if the substring should include the start and end strings.</param> 
        /// <returns>A new string where the text between <paramref name="start"/> and
        /// <parameref name="end"/> has been replaced by <paramref name="newValue"/>.</returns>
        public static string ReplaceBetween(this string source, string start, string end, string newValue, bool inclusive)
        {
            return ReplaceBetween(source, start, end, newValue, inclusive, StringComparison.Ordinal);
        }
        #endregion

        #region ReplaceBetween(string source, string start, string end, string newValue, bool inclusive, StringComparison comparisonType)
        /// <summary>
        /// Returns a new string where the text between <paramref name="start"/> and
        /// <parameref name="end"/> has been replaced by <paramref name="newValue"/>.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="start">The starting string of the replacement substring.</param>
        /// <param name="end">The ending string of the replacement substring.</param>
        /// <param name="newValue">The replacement text.</param>
        /// <param name="inclusive">Indicates if the substring should include the start and end strings.</param> 
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param> 
        /// <returns>A new string where the text between <paramref name="start"/> and
        /// <parameref name="end"/> has been replaced by <paramref name="newValue"/>.</returns>
        public static string ReplaceBetween(this string source, string start, string end, string newValue, bool inclusive, StringComparison comparisonType)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (start == null)
            {
                throw new ArgumentNullException("start");
            }

            if (end == null)
            {
                throw new ArgumentNullException("end");
            }

            if (newValue == null)
            {
                throw new ArgumentNullException("newValue");
            }

            string newString = source;
            int startIndex = source.IndexOf(start, comparisonType);

            if (startIndex != -1)
            {
                int endIndex = source.IndexOf(end, startIndex + 1, comparisonType);

                if (endIndex != -1)
                {
                    if (inclusive)
                    {
                        // We need to offset the endIndex to include
                        // the bracketing word. 
                        endIndex += end.Length;
                    }
                    else
                    {
                        // We need to offset the starting index to exclude the
                        // bracketing word.
                        startIndex += start.Length;
                    }

                    newString = String.Concat(source.Substring(0, startIndex), newValue, source.Substring(endIndex));
                }
            }

            return newString;
        }
        #endregion

        #endregion

        #region ResizeString
        /// <summary>
        /// Returns a new string whose textual value is the resized form of
        /// <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="String"/> to resize.</param>
        /// <param name="length">The desired length of the new 
        /// <see cref="String"/>.</param>
        /// <returns>A new, resized string.</returns>
        /// <remarks><para>If <paramref name="source"/> is less than 
        /// <paramref name="length"/>, the returned string is padded with
        /// spaces; otherwise it is truncated to the desired length.</para>
        /// <para>If <paramref name="source"/> is <see langword="null"/>
        /// or is an empty string, a new string containing 
        /// <paramref name="length"/> number of spaces is returned.</para>
        /// </remarks>
        public static string ResizeString(this string source, int length)
        {
            string sizedString = String.Empty;

            if (String.IsNullOrEmpty(source))
            {
                sizedString = sizedString.PadRight(length, ' ');
            }
            else
            {
                if (source.Length > length)
                {
                    sizedString = source.Substring(0, length);
                }
                else
                {
                    sizedString = source.PadRight(length);
                }
            }

            return sizedString;
        }
        #endregion

        #region RightSubstring

        #region RightSubstring(string source, char value)
        /// <summary>
        /// Retrieves a substring from <paramref name="source"/>. The substring ends at the
        /// specified character position from the end of the string.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="value">The ending character of a substring.</param>
        /// <returns>A <see cref="String"/> object equivalent to the substring that 
        /// ends at the position of <paramref name="value"/> in <paramref name="source"/>, or
        /// the entire string if <paramref name="value"/> is not found in the string.
        /// </returns>
        public static string RightSubstring(this string source, char value)
        {
            return RightSubstring(source, value, 1);
        }
        #endregion

        #region RightSubstring(string source, char value, int occurrence
        /// <summary>
        /// Retrieves a substring from <paramref name="source"/>. The substring ends at the
        /// specified string position from the end of the string.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="value">The ending string of a substring.</param>
        /// <param name="occurrence">The occurrence of <paramref name="value"/>.</param>
        /// <returns>A <see cref="String"/> object equivalent to the substring that 
        /// ends at the position of <paramref name="value"/> in <paramref name="source"/>, or
        /// the entire string if <paramref name="value"/> is not found in the string.
        /// </returns>
        public static string RightSubstring(this string source, char value, int occurrence)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            string substring = source;
            int index = source.IndexOf(value);

            while (index != -1 && occurrence > 1)
            {
                index = source.IndexOf(value, index + 1);
                --occurrence;
            }

            if (index != -1)
            {
                substring = source.Substring(index + 1);
            }

            return substring;
        }
        #endregion

        #region RightSubstring(string source, int endingIndex)
        /// <summary>
        /// Retrieves a substring from <paramref name="source"/>. The substring ends at the
        /// specified character position from the end of the string.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="endingIndex">The index of the end of the substring.</param>
        /// <returns>A <see cref="String"/> object equivalent to the substring that 
        /// ends at <paramref name="endingIndex"/> in <paramref name="source"/>, or
        /// the entire string if <paramref name="endingIndex"/> is not found in the string.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">endingIndex is less than zero. </exception>
        public static string RightSubstring(this string source, int endingIndex)
        {
            return RightSubstring(source, endingIndex, true);
        }
        #endregion

        #region RightSubstring(string source, int endingIndex, bool inclusive)
        /// <summary>
        /// Retrieves a substring from <paramref name="source"/>. The substring ends at the
        /// specified character position from the end of the string.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="endingIndex">The index of the end of the substring.</param>
        /// <param name="inclusive">Indicates if the substring should include the ending character position.</param>
        /// <returns>A <see cref="String"/> object equivalent to the substring that 
        /// ends at <paramref name="endingIndex"/> in <paramref name="source"/>, or
        /// the entire string if <paramref name="endingIndex"/> is not found in the string.
        /// </returns>
        public static string RightSubstring(this string source, int endingIndex, bool inclusive)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (endingIndex <= 0)
            {
                throw new ArgumentOutOfRangeException("endingIndex", Resources.ArgumentOutOfRange_IndexLessThanZero);
            }

            if (endingIndex > source.Length)
            {
                throw new ArgumentOutOfRangeException("endingIndex", Resources.ArgumentOutOfRange_IndexLessThanLength);
            }

            if (inclusive)
            {
                endingIndex--;
            }

            return source.Substring(endingIndex, source.Length - endingIndex);
        }
        #endregion

        #region RightSubstring(string source, string value)
        /// <summary>
        /// Retrieves a substring from <paramref name="source"/>. The substring ends at the
        /// specified string position.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="value">The ending string of a substring.</param>
        /// <returns>A <see cref="String"/> object equivalent to the substring that 
        /// ends at the position of <paramref name="value"/> in <paramref name="source"/>, or
        /// the entire string if <paramref name="value"/> is not found in the string.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1307:SpecifyStringComparison", MessageId = "Cadru.StringExtensions.RightSubstring(System.String,System.String,System.Int32)", Justification = "Reviewed.")]
        public static string RightSubstring(this string source, string value)
        {
            return RightSubstring(source, value, 1);
        }
        #endregion

        #region RightSubstring(string source, string value, int occurrence)
        /// <summary>
        /// Retrieves a substring from <paramref name="source"/>. The substring ends at the
        /// specified string position from the end of the string.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="value">The ending string of a substring.</param>
        /// <param name="occurrence">The occurrence of <paramref name="value"/>.</param>
        /// <returns>A <see cref="String"/> object equivalent to the substring that 
        /// ends at the position of <paramref name="value"/> in <paramref name="source"/>, or
        /// the entire string if <paramref name="value"/> is not found in the string.
        /// </returns>
        public static string RightSubstring(this string source, string value, int occurrence)
        {
            return RightSubstring(source, value, occurrence, StringComparison.Ordinal);
        }
        #endregion

        #region RightSubstring(string source, string value, int occurrence, StringComparison comparisonType)
        /// <summary>
        /// Retrieves a substring from <paramref name="source"/>. The substring ends at the
        /// specified string position from the end of the string.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="value">The ending string of a substring.</param>
        /// <param name="occurrence">The occurrence of <paramref name="value"/>.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param> 
        /// <returns>A <see cref="String"/> object equivalent to the substring that 
        /// ends at the position of <paramref name="value"/> in <paramref name="source"/>, or
        /// the entire string if <paramref name="value"/> is not found in the string.
        /// </returns>
        public static string RightSubstring(this string source, string value, int occurrence, StringComparison comparisonType)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            string substring = source;
            int index = source.IndexOf(value, comparisonType);

            while (index != -1 && occurrence > 1)
            {
                index = source.IndexOf(value, index + 1, comparisonType);
                --occurrence;
            }

            if (index != -1)
            {
                substring = source.Substring(index + 1);
            }

            return substring;
        }
        #endregion

        #endregion

        #region SubstringBetween

        #region SubstringBetween(string source, char start, char end)
        /// <summary>
        /// Retrieves a substring from <paramref name="source"/>. The substring begins at <paramref name="start"/>
        /// and ends at <paramref name="end"/>. 
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="start">The starting character of the substring.</param>
        /// <param name="end">The ending character of the substring.</param>
        /// <returns>A <see cref="String"/> object equivalent to the substring that 
        /// ends at the position of <paramref name="end"/> in <paramref name="source"/>, or
        /// <see cref="String.Empty"/> if <paramref name="start"/> or <paramref name="end"/> 
        /// are not found in the string.
        /// </returns>
        public static string SubstringBetween(this string source, char start, char end)
        {
            return SubstringBetween(source, start, end, false);
        }
        #endregion

        #region SubstringBetween(string source, char start, char end, bool inclusive)
        /// <summary>
        /// Retrieves a substring from <paramref name="source"/>. The substring begins at <paramref name="start"/>
        /// and ends at <paramref name="end"/>.
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="start">The starting character of the substring.</param>
        /// <param name="end">The ending character of the substring.</param>
        /// <param name="inclusive">Indicates if the substring should include the start and end characters.</param> 
        /// <returns>A <see cref="String"/> object equivalent to the substring that 
        /// ends at the position of <paramref name="end"/> in <paramref name="source"/>, or
        /// <see cref="String.Empty"/> if <paramref name="start"/> or <paramref name="end"/> 
        /// are not found in the string.
        /// </returns>
        public static string SubstringBetween(this string source, char start, char end, bool inclusive)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            string substring = String.Empty;
            int startIndex = source.IndexOf(start);

            if (startIndex != -1)
            {
                int endIndex = source.IndexOf(end, startIndex + 1);

                if (endIndex != -1)
                {
                    if (inclusive)
                    {
                        // We need to offset the endIndex by 1 to include
                        // the bracketing character
                        endIndex++;
                    }
                    else
                    {
                        // We need to skip over the first character.
                        startIndex++;
                    }

                    substring = source.Substring(startIndex, endIndex - startIndex);
                }
            }

            return substring;
        }
        #endregion

        #region SubstringBetween(string source, string start, string end)
        /// <summary>
        /// Retrieves a substring from <paramref name="source"/>. The substring begins at <paramref name="start"/>
        /// and ends at <paramref name="end"/>. 
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="start">The starting string of the substring.</param>
        /// <param name="end">The ending string of the substring.</param>
        /// <returns>A <see cref="String"/> object equivalent to the substring that 
        /// ends at the position of <paramref name="end"/> in <paramref name="source"/>, or
        /// <see cref="String.Empty"/> if <paramref name="start"/> or <paramref name="end"/> 
        /// are not found in the string.
        /// </returns>
        public static string SubstringBetween(this string source, string start, string end)
        {
            return SubstringBetween(source, start, end, false, StringComparison.Ordinal);
        }
        #endregion

        #region SubstringBetween(string source, string start, string end, bool inclusive)
        /// <summary>
        /// Retrieves a substring from <paramref name="source"/>. The substring begins at <paramref name="start"/>
        /// and ends at <paramref name="end"/>. 
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="start">The starting string of the substring.</param>
        /// <param name="end">The ending string of the substring.</param>
        /// <param name="inclusive">Indicates if the substring should include the start and end strings.</param> 
        /// <returns>A <see cref="String"/> object equivalent to the substring that 
        /// ends at the position of <paramref name="end"/> in <paramref name="source"/>, or
        /// <see cref="String.Empty"/> if <paramref name="start"/> or <paramref name="end"/> 
        /// are not found in the string.
        /// </returns>
        public static string SubstringBetween(this string source, string start, string end, bool inclusive)
        {
            return SubstringBetween(source, start, end, inclusive, StringComparison.Ordinal);
        }
        #endregion

        #region SubstringBetween(string source, string start, string end, bool inclusive, StringComparison comparisonType)
        /// <summary>
        /// Retrieves a substring from <paramref name="source"/>. The substring begins at <paramref name="start"/>
        /// and ends at <paramref name="end"/>. 
        /// </summary>
        /// <param name="source">The source <see cref="String"/>.</param>
        /// <param name="start">The starting string of the substring.</param>
        /// <param name="end">The ending string of the substring.</param>
        /// <param name="inclusive">Indicates if the substring should include the start and end strings.</param> 
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param> 
        /// <returns>A <see cref="String"/> object equivalent to the substring that 
        /// ends at the position of <paramref name="end"/> in <paramref name="source"/>, or
        /// <see cref="String.Empty"/> if <paramref name="start"/> or <paramref name="end"/> 
        /// are not found in the string.
        /// </returns>
        public static string SubstringBetween(this string source, string start, string end, bool inclusive, StringComparison comparisonType)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (start == null)
            {
                throw new ArgumentNullException("start");
            }

            if (end == null)
            {
                throw new ArgumentNullException("end");
            }

            string substring = String.Empty;
            int startIndex = source.IndexOf(start, comparisonType);

            if (startIndex != -1)
            {
                int endIndex = source.IndexOf(end, startIndex + 1, comparisonType);

                if (endIndex != -1)
                {
                    if (inclusive)
                    {
                        // We need to offset the endIndex to include
                        // the bracketing word. 
                        endIndex += end.Length;
                    }
                    else
                    {
                        // We need to offset the starting index to exclude the
                        // bracketing word. The endIndex already excludes the
                        // bracketing word.
                        startIndex += start.Length;
                    }

                    substring = source.Substring(startIndex, endIndex - startIndex);
                }
            }

            return substring;
        }
        #endregion

        #endregion
    }
}