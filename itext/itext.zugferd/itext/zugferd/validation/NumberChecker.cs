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

namespace iText.Zugferd.Validation {
    /// <summary>
    /// Provide a means to check if a String consist of characters from 0 to 9
    /// and a decimal point in case a decimal is expected.
    /// </summary>
    public class NumberChecker : CodeValidation {
        public const int INTEGER = 0;

        public const int ANY_DECIMALS = 1;

        public const int TWO_DECIMALS = 2;

        public const int FOUR_DECIMALS = 4;

        /// <summary>The type of checker: INTEGER, ANY_DECIMALS, TWO_DECIMALS, FOUR_DECIMALS.</summary>
        protected internal int type;

        /// <summary>Creates a specific number checker.</summary>
        /// <param name="type">
        /// the type of checker that needs to be created:
        /// INTEGER, ANY_DECIMALS, TWO_DECIMALS, or FOUR_DECIMALS
        /// </param>
        public NumberChecker(int type) {
            this.type = type;
        }

        public override bool IsValid(String code) {
            if (type == INTEGER) {
                return IsNumeric(code, code.Length);
            }
            if (code.EndsWith(".")) {
                return false;
            }
            int pos = code.IndexOf(".");
            if (pos < 1) {
                return false;
            }
            String part1 = code.JSubstring(0, pos);
            if (!IsNumeric(part1, part1.Length)) {
                return false;
            }
            String part2 = code.Substring(pos + 1);
            switch (type) {
                case TWO_DECIMALS: {
                    return IsNumeric(part2, 2);
                }

                case FOUR_DECIMALS: {
                    return IsNumeric(part2, 4);
                }

                default: {
                    return IsNumeric(part2, part2.Length);
                }
            }
        }
    }
}
