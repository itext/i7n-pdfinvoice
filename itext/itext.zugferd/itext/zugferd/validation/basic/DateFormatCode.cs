/*
    This file is part of the iText (R) project.
    Copyright (c) 1998-2017 iText Group NV
    Authors: iText Software.

    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License version 3
    as published by the Free Software Foundation with the addition of the
    following permission added to Section 15 as permitted in Section 7(a):
    FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY
    ITEXT GROUP. ITEXT GROUP DISCLAIMS THE WARRANTY OF NON INFRINGEMENT
    OF THIRD PARTY RIGHTS

    This program is distributed in the hope that it will be useful, but
    WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
    or FITNESS FOR A PARTICULAR PURPOSE.
    See the GNU Affero General Public License for more details.
    You should have received a copy of the GNU Affero General Public License
    along with this program; if not, see http://www.gnu.org/licenses or write to
    the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
    Boston, MA, 02110-1301 USA, or download the license from the following URL:
    http://itextpdf.com/terms-of-use/

    The interactive user interfaces in modified source and object code versions
    of this program must display Appropriate Legal Notices, as required under
    Section 5 of the GNU Affero General Public License.

    In accordance with Section 7(b) of the GNU Affero General Public License,
    a covered work must retain the producer line in every PDF that is created
    or manipulated using iText.

    You can be released from the requirements of the license by purchasing
    a commercial license. Buying such a license is mandatory as soon as you
    develop commercial activities involving the iText software without
    disclosing the source code of your own applications.
    These activities include: offering paid services to customers as an ASP,
    serving PDFs on the fly in a web application, shipping iText with a closed
    source product.

    For more information, please contact iText Software Corp. at this
    address: sales@itextpdf.com */
using System;
using System.Globalization;
using System.Threading;
using iText.Zugferd.Exceptions;

namespace iText.Zugferd.Validation.Basic {
    /// <summary>Class that can be used to check a code for a date format.</summary>
    /// <remarks>
    /// Class that can be used to check a code for a date format.
    /// Additionally, this class also contains some methods that allow you
    /// to convert dates to strings and vice-versa based on a given format.
    /// </remarks>
    public class DateFormatCode : CodeValidation {
        public const String YYYYMMDD = "102";

        public const String YYYYMM = "610";

        public const String YYYYWW = "616";

        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        public static String GetDateFormat(String format) {
            if (YYYYMMDD.Equals(format)) {
                return "yyyyMMdd";
            }
            else {
                if (YYYYMM.Equals(format)) {
                    return "yyyyMM";
                }
                else {
                    if (YYYYWW.Equals(format)) {
                        return "yyyyww";
                    }
                }
            }
            throw new InvalidCodeException(format, "date format");
        }

        public override bool IsValid(String format) {
            return format.Equals(YYYYMMDD) || format.Equals(YYYYMM) || format.Equals(YYYYWW);
        }

        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        public virtual String ConvertToString(DateTime d, String format) {
            String pattern = GetDateFormat(format);
            if (pattern.Contains("ww")) {
                int weekNumber = WeekOfYearISO8601(d);
                pattern = pattern.Replace("ww", weekNumber.ToString(CultureInfo.InvariantCulture));
            }
            return d.ToString(pattern);
        }

        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        /// <exception cref="Java.Text.ParseException"/>
        public virtual DateTime ConvertToDate(String d, String format) {
            String pattern = GetDateFormat(format);
            int week = -1;
            if (pattern.IndexOf("ww") != -1) {
                int ind = pattern.IndexOf("ww");
                string weekStr = d.Substring(ind, 2);
                pattern = pattern.Replace("ww", "");
                d = d.Substring(0, ind) + d.Substring(ind + 2, d.Length - ind - 2);
                if (!int.TryParse(weekStr, out week)) {
                    week = -1;
                }
            }
            DateTime result = DateTime.ParseExact(d, pattern, Thread.CurrentThread.CurrentCulture, DateTimeStyles.None);
            if (week != -1 && !pattern.Contains("d")) {
                // CurrentCulture is here on purpose. In Java, ww format also seems to be locale-dependent
                result = result.Add(TimeSpan.FromDays(7*week));
                CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
                DayOfWeek fdow = ci.DateTimeFormat.FirstDayOfWeek;
                result = result.AddDays(-(result.DayOfWeek - fdow)).Date;
            }
            return result;
        }

        private static int WeekOfYearISO8601(DateTime date) {
            // CurrentCulture is here on purpose. In Java, ww format also seems to be locale-dependent
            var day = (int) CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(date);
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date.AddDays(4 - (day == 0 ? 7 : day)),
                CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}
