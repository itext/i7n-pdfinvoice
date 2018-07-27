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
    /// <summary>
    /// Class that can be used to check if a document type code is valid for
    /// use in the context of a specific format.
    /// </summary>
    public class DocumentTypeCode : CodeValidation {
        /// <summary>The Constant COMMERCIAL_INVOICE.</summary>
        public const String COMMERCIAL_INVOICE = "380";

        /// <summary>The Constant DEBIT_NOTE_FINANCIAL_ADJUSTMENT.</summary>
        public const String DEBIT_NOTE_FINANCIAL_ADJUSTMENT = "38";

        /// <summary>The Constant SELF_BILLED_INVOICE.</summary>
        public const String SELF_BILLED_INVOICE = "389";

        /// <summary>The Constant BASIC.</summary>
        public const int BASIC = 0;

        /// <summary>The Constant COMFORT.</summary>
        public const int COMFORT = 1;

        /// <summary>The Constant EXTENDED.</summary>
        public const int EXTENDED = 2;

        /// <summary>The profile.</summary>
        protected internal int profile;

        /// <summary>
        /// Creates a new
        /// <see cref="DocumentTypeCode"/>
        /// .
        /// </summary>
        /// <param name="profile">the profile</param>
        public DocumentTypeCode(int profile) {
            this.profile = profile;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.validation.CodeValidation#isValid(java.lang.String)
        */
        public override bool IsValid(String code) {
            switch (profile) {
                case BASIC: {
                    return IsValidBasic(code);
                }

                case COMFORT: {
                    return IsValidComfort(code);
                }

                default: {
                    return IsValidExtended(code);
                }
            }
        }

        /// <summary>Checks if a code is valid for the Basic profile.</summary>
        /// <param name="code">the code</param>
        /// <returns>true, if a valid Basic profile code</returns>
        public static bool IsValidBasic(String code) {
            return COMMERCIAL_INVOICE.Equals(code);
        }

        /// <summary>Checks if a code is valid for the Comfort profile.</summary>
        /// <param name="code">the code</param>
        /// <returns>true, if a valid Comfort profile code</returns>
        public static bool IsValidComfort(String code) {
            return COMMERCIAL_INVOICE.Equals(code) || DEBIT_NOTE_FINANCIAL_ADJUSTMENT.Equals(code);
        }

        /// <summary>Checks if a code is valid for the Extended profile.</summary>
        /// <param name="code">the code</param>
        /// <returns>true, if a valid Extended profile code</returns>
        public static bool IsValidExtended(String code) {
            return COMMERCIAL_INVOICE.Equals(code) || DEBIT_NOTE_FINANCIAL_ADJUSTMENT.Equals(code) || SELF_BILLED_INVOICE
                .Equals(code);
        }
    }
}
