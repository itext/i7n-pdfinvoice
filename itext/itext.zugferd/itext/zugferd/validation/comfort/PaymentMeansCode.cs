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

namespace iText.Zugferd.Validation.Comfort {
    /// <summary>Class that can be used to check if a payment means code is valid.</summary>
    public class PaymentMeansCode : CodeValidation {
        /// <summary>The Constant NOT_DEFINED.</summary>
        public const String NOT_DEFINED = "1";

        /// <summary>The Constant AUTOMATED_CLEARING_HOUSE.</summary>
        public const String AUTOMATED_CLEARING_HOUSE = "3";

        /// <summary>The Constant CASH.</summary>
        public const String CASH = "10";

        /// <summary>The Constant CHEQUE.</summary>
        public const String CHEQUE = "20";

        /// <summary>The Constant DEBIT_TRANSFER.</summary>
        public const String DEBIT_TRANSFER = "31";

        /// <summary>The Constant PAYMENT_TO_BANK_ACCOUNT.</summary>
        public const String PAYMENT_TO_BANK_ACCOUNT = "42";

        /// <summary>The Constant BANK_CARD.</summary>
        public const String BANK_CARD = "48";

        /// <summary>The Constant DIRECT_DEBIT.</summary>
        public const String DIRECT_DEBIT = "49";

        /// <summary>The Constant CLEARING.</summary>
        public const String CLEARING = "97";

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.validation.CodeValidation#isValid(java.lang.String)
        */
        public override bool IsValid(String code) {
            return code.Equals(NOT_DEFINED) || code.Equals(AUTOMATED_CLEARING_HOUSE) || code.Equals(CASH) || code.Equals
                (CHEQUE) || code.Equals(DEBIT_TRANSFER) || code.Equals(PAYMENT_TO_BANK_ACCOUNT) || code.Equals(BANK_CARD
                ) || code.Equals(DIRECT_DEBIT) || code.Equals(CLEARING);
        }
    }
}
