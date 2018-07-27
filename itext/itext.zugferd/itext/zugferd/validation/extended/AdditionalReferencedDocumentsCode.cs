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

namespace iText.Zugferd.Validation.Extended {
    /// <summary>Series of codes that can be used for additional referenced documents.</summary>
    /// <remarks>
    /// Series of codes that can be used for additional referenced documents.
    /// These codes are used only in the context of the Extended profile.
    /// </remarks>
    public class AdditionalReferencedDocumentsCode : CodeValidation {
        /// <summary>The Constant ORDER_ACKNOWLEDGEMENT.</summary>
        public const String ORDER_ACKNOWLEDGEMENT = "AAA";

        /// <summary>The Constant PROFORMA_INVOICE.</summary>
        public const String PROFORMA_INVOICE = "AAB";

        /// <summary>The Constant OFFER.</summary>
        public const String OFFER = "AAG";

        /// <summary>The Constant DELIVERY_ORDER.</summary>
        public const String DELIVERY_ORDER = "AAJ";

        /// <summary>The Constant DRAWING.</summary>
        public const String DRAWING = "AAL";

        /// <summary>The Constant WAYBILL.</summary>
        public const String WAYBILL = "AAM";

        /// <summary>The Constant TRANSPORT_CONTRACT.</summary>
        public const String TRANSPORT_CONTRACT = "AAS";

        /// <summary>The Constant GOODS_DECLARATION.</summary>
        public const String GOODS_DECLARATION = "ABT";

        /// <summary>The Constant PROJECT_SPECIFICATION.</summary>
        public const String PROJECT_SPECIFICATION = "AER";

        /// <summary>The Constant DISPUTE.</summary>
        public const String DISPUTE = "AGG";

        /// <summary>The Constant AGREEMENT.</summary>
        public const String AGREEMENT = "AJS";

        /// <summary>The Constant RETURNS_NOTICE.</summary>
        public const String RETURNS_NOTICE = "ALQ";

        /// <summary>The Constant RECEIVING_ADVICE.</summary>
        public const String RECEIVING_ADVICE = "ALO";

        /// <summary>The Constant INVENTORY_REPORT.</summary>
        public const String INVENTORY_REPORT = "API";

        /// <summary>The Constant PROOF_OF_DELIVERY.</summary>
        public const String PROOF_OF_DELIVERY = "ASI";

        /// <summary>The Constant COLLECTION_REF.</summary>
        public const String COLLECTION_REF = "AUD";

        /// <summary>The Constant DOCUMENT_REF.</summary>
        public const String DOCUMENT_REF = "AWR";

        /// <summary>The Constant BLANKET_ORDER.</summary>
        public const String BLANKET_ORDER = "BO";

        /// <summary>The Constant BUYERS_CONTRACT.</summary>
        public const String BUYERS_CONTRACT = "BC";

        /// <summary>The Constant CREDIT_NOTE.</summary>
        public const String CREDIT_NOTE = "CD";

        /// <summary>The Constant DEBIT_NOTE.</summary>
        public const String DEBIT_NOTE = "DL";

        /// <summary>The Constant METER_UNIT.</summary>
        public const String METER_UNIT = "MG";

        /// <summary>The Constant PREVIOUS_INVOICE.</summary>
        public const String PREVIOUS_INVOICE = "OI";

        /// <summary>The Constant PRICE_LIST.</summary>
        public const String PRICE_LIST = "PL";

        /// <summary>The Constant PACKING_LIST.</summary>
        public const String PACKING_LIST = "PK";

        /// <summary>The Constant PURCHASE_ORDER_RESPONSE.</summary>
        public const String PURCHASE_ORDER_RESPONSE = "POR";

        /// <summary>The Constant PURCHASE_ORDER_CHANGE.</summary>
        public const String PURCHASE_ORDER_CHANGE = "PP";

        /// <summary>The Constant TRANSPORT_INSTRUCTION.</summary>
        public const String TRANSPORT_INSTRUCTION = "TIN";

        /// <summary>The Constant VENDOR_ORDER.</summary>
        public const String VENDOR_ORDER = "VN";

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.validation.CodeValidation#isValid(java.lang.String)
        */
        public override bool IsValid(String code) {
            return code.Equals(ORDER_ACKNOWLEDGEMENT) || code.Equals(PROFORMA_INVOICE) || code.Equals(OFFER) || code.Equals
                (DELIVERY_ORDER) || code.Equals(DRAWING) || code.Equals(WAYBILL) || code.Equals(TRANSPORT_CONTRACT) ||
                 code.Equals(GOODS_DECLARATION) || code.Equals(PROJECT_SPECIFICATION) || code.Equals(DISPUTE) || code.
                Equals(AGREEMENT) || code.Equals(RETURNS_NOTICE) || code.Equals(RECEIVING_ADVICE) || code.Equals(INVENTORY_REPORT
                ) || code.Equals(PROOF_OF_DELIVERY) || code.Equals(COLLECTION_REF) || code.Equals(DOCUMENT_REF) || code
                .Equals(BLANKET_ORDER) || code.Equals(BUYERS_CONTRACT) || code.Equals(CREDIT_NOTE) || code.Equals(DEBIT_NOTE
                ) || code.Equals(METER_UNIT) || code.Equals(PREVIOUS_INVOICE) || code.Equals(PRICE_LIST) || code.Equals
                (PACKING_LIST) || code.Equals(PURCHASE_ORDER_RESPONSE) || code.Equals(PURCHASE_ORDER_CHANGE) || code.Equals
                (TRANSPORT_INSTRUCTION) || code.Equals(VENDOR_ORDER);
        }
    }
}
