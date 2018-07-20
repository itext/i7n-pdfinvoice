/*
This file is part of the iText (R) project.
Copyright (c) 1998-2018 iText Group NV
Authors: Bruno Lowagie, et al.

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
address: sales@itextpdf.com
*/
using System;
using iText.Zugferd.Validation;

namespace iText.Zugferd.Validation.Basic {
    /// <summary>Class that can be used to check if a measurement unit code is valid.</summary>
    public class MeasurementUnitCode : CodeValidation {
        /// <summary>The Constant ITEM.</summary>
        public const String ITEM = "C62";

        /// <summary>The Constant DAY.</summary>
        public const String DAY = "DAY";

        /// <summary>The Constant HA.</summary>
        public const String HA = "HAR";

        /// <summary>The Constant HR.</summary>
        public const String HR = "HUR";

        /// <summary>The Constant KG.</summary>
        public const String KG = "KGM";

        /// <summary>The Constant KM.</summary>
        public const String KM = "KTM";

        /// <summary>The Constant KWH.</summary>
        public const String KWH = "KWH";

        /// <summary>The Constant SUM.</summary>
        public const String SUM = "LS";

        /// <summary>The Constant L.</summary>
        public const String L = "LTR";

        /// <summary>The Constant MIN.</summary>
        public const String MIN = "MIN";

        /// <summary>The Constant MM2.</summary>
        public const String MM2 = "MMK";

        /// <summary>The Constant MM.</summary>
        public const String MM = "MMT";

        /// <summary>The Constant M2.</summary>
        public const String M2 = "MTK";

        /// <summary>The Constant M3.</summary>
        public const String M3 = "MTQ";

        /// <summary>The Constant M.</summary>
        public const String M = "MTR";

        /// <summary>The Constant NO.</summary>
        public const String NO = "NAR";

        /// <summary>The Constant PR.</summary>
        public const String PR = "NPR";

        /// <summary>The Constant PCT.</summary>
        public const String PCT = "P1";

        /// <summary>The Constant SET.</summary>
        public const String SET = "SET";

        /// <summary>The Constant T.</summary>
        public const String T = "TNE";

        /// <summary>The Constant WK.</summary>
        public const String WK = "WEE";

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.validation.CodeValidation#isValid(java.lang.String)
        */
        public override bool IsValid(String code) {
            return code.Equals(ITEM) || code.Equals(DAY) || code.Equals(HA) || code.Equals(HR) || code.Equals(KG) || code
                .Equals(KM) || code.Equals(KWH) || code.Equals(SUM) || code.Equals(L) || code.Equals(MIN) || code.Equals
                (MM2) || code.Equals(MM) || code.Equals(M2) || code.Equals(M3) || code.Equals(M) || code.Equals(NO) ||
                 code.Equals(PR) || code.Equals(PCT) || code.Equals(SET) || code.Equals(T) || code.Equals(WK);
        }
    }
}
