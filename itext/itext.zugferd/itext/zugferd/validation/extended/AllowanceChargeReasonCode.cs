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

namespace iText.Zugferd.Validation.Extended {
    /// <summary>Series of codes that can be used for allowance charge reasons.</summary>
    /// <remarks>
    /// Series of codes that can be used for allowance charge reasons.
    /// These codes are used only in the context of the Extended profile.
    /// </remarks>
    public class AllowanceChargeReasonCode : CodeValidation {
        public const String ADVERTISING = "AA";

        public const String OTHER_SERVICES = "ADR";

        public const String COLLECTION_AND_RECYCLING = "AEO";

        public const String DISCOUNT = "DI";

        public const String EARLY_PAYMENT_ALLOWANCE = "EAB";

        public const String FREIGHT_SERVICE = "FC";

        public const String INSURANCE = "IN";

        public const String MINIMUM_BILLING_CHARGE = "MAC";

        public const String NON_RETURNABLE_CONTAINERS = "NAA";

        public const String PACKING = "PC";

        public const String REBATE = "RAA";

        public const String SPECIAL_HANDLING = "SH";

        public override bool IsValid(String code) {
            return code.Equals(ADVERTISING) || code.Equals(OTHER_SERVICES) || code.Equals(COLLECTION_AND_RECYCLING) ||
                 code.Equals(DISCOUNT) || code.Equals(EARLY_PAYMENT_ALLOWANCE) || code.Equals(FREIGHT_SERVICE) || code
                .Equals(INSURANCE) || code.Equals(MINIMUM_BILLING_CHARGE) || code.Equals(NON_RETURNABLE_CONTAINERS) ||
                 code.Equals(PACKING) || code.Equals(REBATE) || code.Equals(SPECIAL_HANDLING);
        }
    }
}
