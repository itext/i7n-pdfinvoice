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

namespace iText.Zugferd.Profiles {
    /// <summary>
    /// If you implement this interface correctly, you provide all the data that
    /// is necessary for iText to create an XML that can be used in a ZUGFeRD
    /// invoice that conforms with the Comfort profile.
    /// </summary>
    public interface IComfortProfile : IBasicProfile {
        /// <summary>Gets the notes codes.</summary>
        /// <returns>the notes codes</returns>
        String[] GetNotesCodes();

        /// <summary>Gets the buyer reference.</summary>
        /// <returns>the buyer reference</returns>
        String GetBuyerReference();

        /// <summary>Gets the seller ID.</summary>
        /// <returns>the seller ID</returns>
        String GetSellerID();

        /// <summary>Gets the seller global ID.</summary>
        /// <returns>the seller global ID</returns>
        String[] GetSellerGlobalID();

        /// <summary>Gets the seller global scheme ID.</summary>
        /// <returns>the seller global scheme ID</returns>
        String[] GetSellerGlobalSchemeID();

        /// <summary>Gets the buyer ID.</summary>
        /// <returns>the buyer ID</returns>
        String GetBuyerID();

        /// <summary>Gets the buyer global ID.</summary>
        /// <returns>the buyer global ID</returns>
        String[] GetBuyerGlobalID();

        /// <summary>Gets the buyer global scheme ID.</summary>
        /// <returns>the buyer global scheme ID</returns>
        String[] GetBuyerGlobalSchemeID();

        /// <summary>Gets the buyer order referenced document issue date time.</summary>
        /// <returns>the buyer order referenced document issue date time</returns>
        DateTime GetBuyerOrderReferencedDocumentIssueDateTime();

        /// <summary>Gets the buyer order referenced document issue date time format.</summary>
        /// <returns>the buyer order referenced document issue date time format</returns>
        String GetBuyerOrderReferencedDocumentIssueDateTimeFormat();

        /// <summary>Gets the buyer order referenced document ID.</summary>
        /// <returns>the buyer order referenced document ID</returns>
        String GetBuyerOrderReferencedDocumentID();

        /// <summary>Gets the contract referenced document issue date time.</summary>
        /// <returns>the contract referenced document issue date time</returns>
        DateTime GetContractReferencedDocumentIssueDateTime();

        /// <summary>Gets the contract referenced document issue date time format.</summary>
        /// <returns>the contract referenced document issue date time format</returns>
        String GetContractReferencedDocumentIssueDateTimeFormat();

        /// <summary>Gets the contract referenced document ID.</summary>
        /// <returns>the contract referenced document ID</returns>
        String GetContractReferencedDocumentID();

        /// <summary>Gets the customer order referenced document issue date time.</summary>
        /// <returns>the customer order referenced document issue date time</returns>
        DateTime GetCustomerOrderReferencedDocumentIssueDateTime();

        /// <summary>Gets the customer order referenced document issue date time format.</summary>
        /// <returns>the customer order referenced document issue date time format</returns>
        String GetCustomerOrderReferencedDocumentIssueDateTimeFormat();

        /// <summary>Gets the customer order referenced document ID.</summary>
        /// <returns>the customer order referenced document ID</returns>
        String GetCustomerOrderReferencedDocumentID();

        /// <summary>Gets the delivery note referenced document issue date time.</summary>
        /// <returns>the delivery note referenced document issue date time</returns>
        DateTime GetDeliveryNoteReferencedDocumentIssueDateTime();

        /// <summary>Gets the delivery note referenced document issue date time format.</summary>
        /// <returns>the delivery note referenced document issue date time format</returns>
        String GetDeliveryNoteReferencedDocumentIssueDateTimeFormat();

        /// <summary>Gets the delivery note referenced document ID.</summary>
        /// <returns>the delivery note referenced document ID</returns>
        String GetDeliveryNoteReferencedDocumentID();

        /// <summary>Gets the invoicee ID.</summary>
        /// <returns>the invoicee ID</returns>
        String GetInvoiceeID();

        /// <summary>Gets the invoicee global ID.</summary>
        /// <returns>the invoicee global ID</returns>
        String[] GetInvoiceeGlobalID();

        /// <summary>Gets the invoicee global scheme ID.</summary>
        /// <returns>the invoicee global scheme ID</returns>
        String[] GetInvoiceeGlobalSchemeID();

        /// <summary>Gets the invoicee name.</summary>
        /// <returns>the invoicee name</returns>
        String GetInvoiceeName();

        /// <summary>Gets the invoicee postcode.</summary>
        /// <returns>the invoicee postcode</returns>
        String GetInvoiceePostcode();

        /// <summary>Gets the invoicee line one.</summary>
        /// <returns>the invoicee line one</returns>
        String GetInvoiceeLineOne();

        /// <summary>Gets the invoicee line two.</summary>
        /// <returns>the invoicee line two</returns>
        String GetInvoiceeLineTwo();

        /// <summary>Gets the invoicee city name.</summary>
        /// <returns>the invoicee city name</returns>
        String GetInvoiceeCityName();

        /// <summary>Gets the invoicee country ID.</summary>
        /// <returns>the invoicee country ID</returns>
        String GetInvoiceeCountryID();

        /// <summary>Gets the invoicee tax registration ID.</summary>
        /// <returns>the invoicee tax registration ID</returns>
        String[] GetInvoiceeTaxRegistrationID();

        /// <summary>Gets the invoicee tax registration scheme ID.</summary>
        /// <returns>the invoicee tax registration scheme ID</returns>
        String[] GetInvoiceeTaxRegistrationSchemeID();

        /// <summary>Gets the payment means type code.</summary>
        /// <returns>the payment means type code</returns>
        String[] GetPaymentMeansTypeCode();

        /// <summary>Gets the payment means information.</summary>
        /// <returns>the payment means information</returns>
        String[][] GetPaymentMeansInformation();

        /// <summary>Gets the payment means payer account IBAN.</summary>
        /// <returns>the payment means payer account IBAN</returns>
        String[] GetPaymentMeansPayerAccountIBAN();

        /// <summary>Gets the payment means payer account proprietary ID.</summary>
        /// <returns>the payment means payer account proprietary ID</returns>
        String[] GetPaymentMeansPayerAccountProprietaryID();

        /// <summary>Gets the payment means payer financial institution BIC.</summary>
        /// <returns>the payment means payer financial institution BIC</returns>
        String[] GetPaymentMeansPayerFinancialInstitutionBIC();

        /// <summary>Gets the payment means payer financial institution german bankleitzahl ID.</summary>
        /// <returns>the payment means payer financial institution german bankleitzahl ID</returns>
        String[] GetPaymentMeansPayerFinancialInstitutionGermanBankleitzahlID();

        /// <summary>Gets the payment means payer financial institution name.</summary>
        /// <returns>the payment means payer financial institution name</returns>
        String[] GetPaymentMeansPayerFinancialInstitutionName();

        /// <summary>Gets the tax exemption reason.</summary>
        /// <returns>the tax exemption reason</returns>
        String[] GetTaxExemptionReason();

        /// <summary>Gets the tax category code.</summary>
        /// <returns>the tax category code</returns>
        String[] GetTaxCategoryCode();

        /// <summary>Gets the billing start date time.</summary>
        /// <returns>the billing start date time</returns>
        DateTime GetBillingStartDateTime();

        /// <summary>Gets the billing start date time format.</summary>
        /// <returns>the billing start date time format</returns>
        String GetBillingStartDateTimeFormat();

        /// <summary>Gets the billing end date time.</summary>
        /// <returns>the billing end date time</returns>
        DateTime GetBillingEndDateTime();

        /// <summary>Gets the billing end date time format.</summary>
        /// <returns>the billing end date time format</returns>
        String GetBillingEndDateTimeFormat();

        /// <summary>Gets the specified trade allowance charge indicator.</summary>
        /// <returns>the specified trade allowance charge indicator</returns>
        bool[] GetSpecifiedTradeAllowanceChargeIndicator();

        /// <summary>Gets the specified trade allowance charge actual amount.</summary>
        /// <returns>the specified trade allowance charge actual amount</returns>
        String[] GetSpecifiedTradeAllowanceChargeActualAmount();

        /// <summary>Gets the specified trade allowance charge actual amount currency.</summary>
        /// <returns>the specified trade allowance charge actual amount currency</returns>
        String[] GetSpecifiedTradeAllowanceChargeActualAmountCurrency();

        /// <summary>Gets the specified trade allowance charge reason.</summary>
        /// <returns>the specified trade allowance charge reason</returns>
        String[] GetSpecifiedTradeAllowanceChargeReason();

        /// <summary>Gets the specified trade allowance charge tax type code.</summary>
        /// <returns>the specified trade allowance charge tax type code</returns>
        String[][] GetSpecifiedTradeAllowanceChargeTaxTypeCode();

        /// <summary>Gets the specified trade allowance charge tax category code.</summary>
        /// <returns>the specified trade allowance charge tax category code</returns>
        String[][] GetSpecifiedTradeAllowanceChargeTaxCategoryCode();

        /// <summary>Gets the specified trade allowance charge tax applicable percent.</summary>
        /// <returns>the specified trade allowance charge tax applicable percent</returns>
        String[][] GetSpecifiedTradeAllowanceChargeTaxApplicablePercent();

        /// <summary>Gets the specified logistics service charge description.</summary>
        /// <returns>the specified logistics service charge description</returns>
        String[][] GetSpecifiedLogisticsServiceChargeDescription();

        /// <summary>Gets the specified logistics service charge amount.</summary>
        /// <returns>the specified logistics service charge amount</returns>
        String[] GetSpecifiedLogisticsServiceChargeAmount();

        /// <summary>Gets the specified logistics service charge amount currency.</summary>
        /// <returns>the specified logistics service charge amount currency</returns>
        String[] GetSpecifiedLogisticsServiceChargeAmountCurrency();

        /// <summary>Gets the specified logistics service charge tax type code.</summary>
        /// <returns>the specified logistics service charge tax type code</returns>
        String[][] GetSpecifiedLogisticsServiceChargeTaxTypeCode();

        /// <summary>Gets the specified logistics service charge tax category code.</summary>
        /// <returns>the specified logistics service charge tax category code</returns>
        String[][] GetSpecifiedLogisticsServiceChargeTaxCategoryCode();

        /// <summary>Gets the specified logistics service charge tax applicable percent.</summary>
        /// <returns>the specified logistics service charge tax applicable percent</returns>
        String[][] GetSpecifiedLogisticsServiceChargeTaxApplicablePercent();

        /// <summary>Gets the specified trade payment terms description.</summary>
        /// <returns>the specified trade payment terms description</returns>
        String[][] GetSpecifiedTradePaymentTermsDescription();

        /// <summary>Gets the specified trade payment terms due date time.</summary>
        /// <returns>the specified trade payment terms due date time</returns>
        DateTime[] GetSpecifiedTradePaymentTermsDueDateTime();

        /// <summary>Gets the specified trade payment terms due date time format.</summary>
        /// <returns>the specified trade payment terms due date time format</returns>
        String[] GetSpecifiedTradePaymentTermsDueDateTimeFormat();

        /// <summary>Gets the total prepaid amount.</summary>
        /// <returns>the total prepaid amount</returns>
        String GetTotalPrepaidAmount();

        /// <summary>Gets the total prepaid amount currency ID.</summary>
        /// <returns>the total prepaid amount currency ID</returns>
        String GetTotalPrepaidAmountCurrencyID();

        /// <summary>Gets the due payable amount.</summary>
        /// <returns>the due payable amount</returns>
        String GetDuePayableAmount();

        /// <summary>Gets the due payable amount currency ID.</summary>
        /// <returns>the due payable amount currency ID</returns>
        String GetDuePayableAmountCurrencyID();

        /// <summary>Gets the line item line ID.</summary>
        /// <returns>the line item line ID</returns>
        String[] GetLineItemLineID();

        /// <summary>Gets the line item included note.</summary>
        /// <returns>the line item included note</returns>
        String[][][] GetLineItemIncludedNote();

        /// <summary>Gets the line item gross price charge amount.</summary>
        /// <returns>the line item gross price charge amount</returns>
        String[] GetLineItemGrossPriceChargeAmount();

        /// <summary>Gets the line item gross price charge amount currency ID.</summary>
        /// <returns>the line item gross price charge amount currency ID</returns>
        String[] GetLineItemGrossPriceChargeAmountCurrencyID();

        /// <summary>Gets the line item gross price basis quantity.</summary>
        /// <returns>the line item gross price basis quantity</returns>
        String[] GetLineItemGrossPriceBasisQuantity();

        /// <summary>Gets the line item gross price basis quantity code.</summary>
        /// <returns>the line item gross price basis quantity code</returns>
        String[] GetLineItemGrossPriceBasisQuantityCode();

        /// <summary>Gets the line item gross price trade allowance charge indicator.</summary>
        /// <returns>the line item gross price trade allowance charge indicator</returns>
        bool[][] GetLineItemGrossPriceTradeAllowanceChargeIndicator();

        /// <summary>Gets the line item gross price trade allowance charge actual amount.</summary>
        /// <returns>the line item gross price trade allowance charge actual amount</returns>
        String[][] GetLineItemGrossPriceTradeAllowanceChargeActualAmount();

        /// <summary>Gets the line item gross price trade allowance charge actual amount currency ID.</summary>
        /// <returns>the line item gross price trade allowance charge actual amount currency ID</returns>
        String[][] GetLineItemGrossPriceTradeAllowanceChargeActualAmountCurrencyID();

        /// <summary>Gets the line item gross price trade allowance charge reason.</summary>
        /// <returns>the line item gross price trade allowance charge reason</returns>
        String[][] GetLineItemGrossPriceTradeAllowanceChargeReason();

        /// <summary>Gets the line item net price charge amount.</summary>
        /// <returns>the line item net price charge amount</returns>
        String[] GetLineItemNetPriceChargeAmount();

        /// <summary>Gets the line item net price charge amount currency ID.</summary>
        /// <returns>the line item net price charge amount currency ID</returns>
        String[] GetLineItemNetPriceChargeAmountCurrencyID();

        /// <summary>Gets the line item net price basis quantity.</summary>
        /// <returns>the line item net price basis quantity</returns>
        String[] GetLineItemNetPriceBasisQuantity();

        /// <summary>Gets the line item net price basis quantity code.</summary>
        /// <returns>the line item net price basis quantity code</returns>
        String[] GetLineItemNetPriceBasisQuantityCode();

        /// <summary>Gets the line item settlement tax type code.</summary>
        /// <returns>the line item settlement tax type code</returns>
        String[][] GetLineItemSettlementTaxTypeCode();

        /// <summary>Gets the line item settlement tax exemption reason.</summary>
        /// <returns>the line item settlement tax exemption reason</returns>
        String[][] GetLineItemSettlementTaxExemptionReason();

        /// <summary>Gets the line item settlement tax category code.</summary>
        /// <returns>the line item settlement tax category code</returns>
        String[][] GetLineItemSettlementTaxCategoryCode();

        /// <summary>Gets the line item settlement tax applicable percent.</summary>
        /// <returns>the line item settlement tax applicable percent</returns>
        String[][] GetLineItemSettlementTaxApplicablePercent();

        /// <summary>Gets the line item line total amount.</summary>
        /// <returns>the line item line total amount</returns>
        String[] GetLineItemLineTotalAmount();

        /// <summary>Gets the line item line total amount currency ID.</summary>
        /// <returns>the line item line total amount currency ID</returns>
        String[] GetLineItemLineTotalAmountCurrencyID();

        /// <summary>Gets the line item specified trade product global ID.</summary>
        /// <returns>the line item specified trade product global ID</returns>
        String[] GetLineItemSpecifiedTradeProductGlobalID();

        /// <summary>Gets the line item specified trade product scheme ID.</summary>
        /// <returns>the line item specified trade product scheme ID</returns>
        String[] GetLineItemSpecifiedTradeProductSchemeID();

        /// <summary>Gets the line item specified trade product seller assigned ID.</summary>
        /// <returns>the line item specified trade product seller assigned ID</returns>
        String[] GetLineItemSpecifiedTradeProductSellerAssignedID();

        /// <summary>Gets the line item specified trade product buyer assigned ID.</summary>
        /// <returns>the line item specified trade product buyer assigned ID</returns>
        String[] GetLineItemSpecifiedTradeProductBuyerAssignedID();

        /// <summary>Gets the line item specified trade product description.</summary>
        /// <returns>the line item specified trade product description</returns>
        String[] GetLineItemSpecifiedTradeProductDescription();
    }
}
