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

namespace iText.Zugferd.Validation.Comfort {
    /// <summary>Class that can be used to check if a free text subject code is valid.</summary>
    public class FreeTextSubjectCode : CodeValidation {
        public const String REGULATORY_INFORMATION = "REG";

        public const String PRICE_CONDITIONS = "AAK";

        public const String ADDITIONAL_SALES_CONDITIONS = "AAJ";

        public const String PAYMENT_INFORMATION = "PMT";

        public const String PRICE_CALCULATION_FORMULA = "PRF";

        public const String PRODUCT_INFORMATION = "PRD";

        public const String CERTIFICATION_STATEMENTS = "AAY";

        public const int HEADER = 1;

        public const int LINE = 2;

        protected internal int level;

        public FreeTextSubjectCode(int level) {
            // header 
            // line
            this.level = level;
        }

        public static bool IsHeaderLevel(String code) {
            return code.Equals(REGULATORY_INFORMATION) || code.Equals(PRICE_CONDITIONS) || code.Equals(ADDITIONAL_SALES_CONDITIONS
                ) || code.Equals(PAYMENT_INFORMATION);
        }

        public static bool IsLineLevel(String code) {
            return code.Equals(PRICE_CALCULATION_FORMULA) || code.Equals(PRODUCT_INFORMATION) || code.Equals(CERTIFICATION_STATEMENTS
                );
        }

        public override bool IsValid(String code) {
            switch (level) {
                case HEADER: {
                    return IsHeaderLevel(code);
                }

                case LINE: {
                    return IsLineLevel(code);
                }
            }
            return true;
        }
    }
}
