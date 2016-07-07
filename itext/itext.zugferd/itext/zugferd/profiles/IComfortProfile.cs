/*
* $Id$
*
* This file is part of the iText (R) project.
    Copyright (c) 1998-2017 iText Group NV* Authors: Bruno Lowagie, et al.
*
* This program is free software; you can redistribute it and/or modify
* it under the terms of the GNU Affero General Public License version 3
* as published by the Free Software Foundation with the addition of the
* following permission added to Section 15 as permitted in Section 7(a):
* FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY
* ITEXT GROUP. ITEXT GROUP DISCLAIMS THE WARRANTY OF NON INFRINGEMENT
* OF THIRD PARTY RIGHTS
*
* This program is distributed in the hope that it will be useful, but
* WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
* or FITNESS FOR A PARTICULAR PURPOSE.
* See the GNU Affero General Public License for more details.
* You should have received a copy of the GNU Affero General Public License
* along with this program; if not, see http://www.gnu.org/licenses or write to
* the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
* Boston, MA, 02110-1301 USA, or download the license from the following URL:
* http://itextpdf.com/terms-of-use/
*
* The interactive user interfaces in modified source and object code versions
* of this program must display Appropriate Legal Notices, as required under
* Section 5 of the GNU Affero General Public License.
*
* In accordance with Section 7(b) of the GNU Affero General Public License,
* a covered work must retain the producer line in every PDF that is created
* or manipulated using iText.
*
* You can be released from the requirements of the license by purchasing
* a commercial license. Buying such a license is mandatory as soon as you
* develop commercial activities involving the iText software without
* disclosing the source code of your own applications.
* These activities include: offering paid services to customers as an ASP,
* serving PDFs on the fly in a web application, shipping iText with a closed
* source product.
*
* For more information, please contact iText Software Corp. at this
* address: sales@itextpdf.com
*/
using System;

namespace iText.Zugferd.Profiles {
    /// <summary>
    /// If you implement this interface correctly, you provide all the data that
    /// is necessary for iText to create an XML that can be used in a ZUGFeRD
    /// invoice that conforms with the Comfort profile.
    /// </summary>
    public interface IComfortProfile : IBasicProfile {
        String[] GetNotesCodes();

        String GetBuyerReference();

        String GetSellerID();

        String[] GetSellerGlobalID();

        String[] GetSellerGlobalSchemeID();

        String GetBuyerID();

        String[] GetBuyerGlobalID();

        String[] GetBuyerGlobalSchemeID();

        DateTime GetBuyerOrderReferencedDocumentIssueDateTime();

        String GetBuyerOrderReferencedDocumentIssueDateTimeFormat();

        String GetBuyerOrderReferencedDocumentID();

        DateTime GetContractReferencedDocumentIssueDateTime();

        String GetContractReferencedDocumentIssueDateTimeFormat();

        String GetContractReferencedDocumentID();

        DateTime GetCustomerOrderReferencedDocumentIssueDateTime();

        String GetCustomerOrderReferencedDocumentIssueDateTimeFormat();

        String GetCustomerOrderReferencedDocumentID();

        DateTime GetDeliveryNoteReferencedDocumentIssueDateTime();

        String GetDeliveryNoteReferencedDocumentIssueDateTimeFormat();

        String GetDeliveryNoteReferencedDocumentID();

        String GetInvoiceeID();

        String[] GetInvoiceeGlobalID();

        String[] GetInvoiceeGlobalSchemeID();

        String GetInvoiceeName();

        String GetInvoiceePostcode();

        String GetInvoiceeLineOne();

        String GetInvoiceeLineTwo();

        String GetInvoiceeCityName();

        String GetInvoiceeCountryID();

        String[] GetInvoiceeTaxRegistrationID();

        String[] GetInvoiceeTaxRegistrationSchemeID();

        String[] GetPaymentMeansTypeCode();

        String[][] GetPaymentMeansInformation();

        String[] GetPaymentMeansPayerAccountIBAN();

        String[] GetPaymentMeansPayerAccountProprietaryID();

        String[] GetPaymentMeansPayerFinancialInstitutionBIC();

        String[] GetPaymentMeansPayerFinancialInstitutionGermanBankleitzahlID();

        String[] GetPaymentMeansPayerFinancialInstitutionName();

        String[] GetTaxExemptionReason();

        String[] GetTaxCategoryCode();

        DateTime GetBillingStartDateTime();

        String GetBillingStartDateTimeFormat();

        DateTime GetBillingEndDateTime();

        String GetBillingEndDateTimeFormat();

        bool[] GetSpecifiedTradeAllowanceChargeIndicator();

        String[] GetSpecifiedTradeAllowanceChargeActualAmount();

        String[] GetSpecifiedTradeAllowanceChargeActualAmountCurrency();

        String[] GetSpecifiedTradeAllowanceChargeReason();

        String[][] GetSpecifiedTradeAllowanceChargeTaxTypeCode();

        String[][] GetSpecifiedTradeAllowanceChargeTaxCategoryCode();

        String[][] GetSpecifiedTradeAllowanceChargeTaxApplicablePercent();

        String[][] GetSpecifiedLogisticsServiceChargeDescription();

        String[] GetSpecifiedLogisticsServiceChargeAmount();

        String[] GetSpecifiedLogisticsServiceChargeAmountCurrency();

        String[][] GetSpecifiedLogisticsServiceChargeTaxTypeCode();

        String[][] GetSpecifiedLogisticsServiceChargeTaxCategoryCode();

        String[][] GetSpecifiedLogisticsServiceChargeTaxApplicablePercent();

        String[][] GetSpecifiedTradePaymentTermsDescription();

        DateTime[] GetSpecifiedTradePaymentTermsDueDateTime();

        String[] GetSpecifiedTradePaymentTermsDueDateTimeFormat();

        String GetTotalPrepaidAmount();

        String GetTotalPrepaidAmountCurrencyID();

        String GetDuePayableAmount();

        String GetDuePayableAmountCurrencyID();

        String[] GetLineItemLineID();

        String[][][] GetLineItemIncludedNote();

        String[] GetLineItemGrossPriceChargeAmount();

        String[] GetLineItemGrossPriceChargeAmountCurrencyID();

        String[] GetLineItemGrossPriceBasisQuantity();

        String[] GetLineItemGrossPriceBasisQuantityCode();

        bool[][] GetLineItemGrossPriceTradeAllowanceChargeIndicator();

        String[][] GetLineItemGrossPriceTradeAllowanceChargeActualAmount();

        String[][] GetLineItemGrossPriceTradeAllowanceChargeActualAmountCurrencyID();

        String[][] GetLineItemGrossPriceTradeAllowanceChargeReason();

        String[] GetLineItemNetPriceChargeAmount();

        String[] GetLineItemNetPriceChargeAmountCurrencyID();

        String[] GetLineItemNetPriceBasisQuantity();

        String[] GetLineItemNetPriceBasisQuantityCode();

        String[][] GetLineItemSettlementTaxTypeCode();

        String[][] GetLineItemSettlementTaxExemptionReason();

        String[][] GetLineItemSettlementTaxCategoryCode();

        String[][] GetLineItemSettlementTaxApplicablePercent();

        String[] GetLineItemLineTotalAmount();

        String[] GetLineItemLineTotalAmountCurrencyID();

        String[] GetLineItemSpecifiedTradeProductGlobalID();

        String[] GetLineItemSpecifiedTradeProductSchemeID();

        String[] GetLineItemSpecifiedTradeProductSellerAssignedID();

        String[] GetLineItemSpecifiedTradeProductBuyerAssignedID();

        String[] GetLineItemSpecifiedTradeProductDescription();
    }
}
