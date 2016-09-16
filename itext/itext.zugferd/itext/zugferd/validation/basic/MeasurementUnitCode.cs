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
using iText.Zugferd.Validation;

namespace iText.Zugferd.Validation.Basic {
    /// <summary>Class that can be used to check if a measurement unit code is valid.</summary>
    public class MeasurementUnitCode : CodeValidation {
        public const String ITEM = "C62";

        public const String DAY = "DAY";

        public const String HA = "HAR";

        public const String HR = "HUR";

        public const String KG = "KGM";

        public const String KM = "KTM";

        public const String KWH = "KWH";

        public const String SUM = "LS";

        public const String L = "LTR";

        public const String MIN = "MIN";

        public const String MM2 = "MMK";

        public const String MM = "MMT";

        public const String M2 = "MTK";

        public const String M3 = "MTQ";

        public const String M = "MTR";

        public const String NO = "NAR";

        public const String PR = "NPR";

        public const String PCT = "P1";

        public const String SET = "SET";

        public const String T = "TNE";

        public const String WK = "WEE";

        public override bool IsValid(String code) {
            return code.Equals(ITEM) || code.Equals(DAY) || code.Equals(HA) || code.Equals(HR) || code.Equals(KG) || code
                .Equals(KM) || code.Equals(KWH) || code.Equals(SUM) || code.Equals(L) || code.Equals(MIN) || code.Equals
                (MM2) || code.Equals(MM) || code.Equals(M2) || code.Equals(M3) || code.Equals(M) || code.Equals(NO) ||
                 code.Equals(PR) || code.Equals(PCT) || code.Equals(SET) || code.Equals(T) || code.Equals(WK);
        }
    }
}
