/*
This file is part of the iText (R) project.
Copyright (c) 1998-2017 iText Group NV
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
using System.Collections.Generic;

namespace iText.Zugferd.Profiles {
    /// <summary>
    /// This implementation of the BasicProfile contains member-variables that store
    /// all the data needed to create an XML attachment for a ZUGFeRD invoice that
    /// conforms with the Comfort profile.
    /// </summary>
    public class ComfortProfileImp : BasicProfileImp, IComfortProfile {
        /// <summary>The notes codes.</summary>
        protected internal IList<String> notesCodes = new List<String>();

        /// <summary>The buyer reference.</summary>
        protected internal String buyerReference;

        /// <summary>The seller ID.</summary>
        protected internal String sellerID;

        /// <summary>The seller global ID.</summary>
        protected internal IList<String> sellerGlobalID = new List<String>();

        /// <summary>The seller global scheme ID.</summary>
        protected internal IList<String> sellerGlobalSchemeID = new List<String>();

        /// <summary>The buyer ID.</summary>
        protected internal String buyerID;

        /// <summary>The buyer global ID.</summary>
        protected internal IList<String> buyerGlobalID = new List<String>();

        /// <summary>The buyer global scheme ID.</summary>
        protected internal IList<String> buyerGlobalSchemeID = new List<String>();

        /// <summary>The buyer order referenced document issue date time.</summary>
        protected internal DateTime buyerOrderReferencedDocumentIssueDateTime;

        /// <summary>The buyer order referenced document issue date time format.</summary>
        protected internal String buyerOrderReferencedDocumentIssueDateTimeFormat;

        /// <summary>The buyer order referenced document ID.</summary>
        protected internal String buyerOrderReferencedDocumentID;

        /// <summary>The contract referenced document issue date time.</summary>
        protected internal DateTime contractReferencedDocumentIssueDateTime;

        /// <summary>The contract referenced document issue date time format.</summary>
        protected internal String contractReferencedDocumentIssueDateTimeFormat;

        /// <summary>The contract referenced document ID.</summary>
        protected internal String contractReferencedDocumentID;

        /// <summary>The customer order referenced document issue date time.</summary>
        protected internal DateTime customerOrderReferencedDocumentIssueDateTime;

        /// <summary>The customer order referenced document issue date time format.</summary>
        protected internal String customerOrderReferencedDocumentIssueDateTimeFormat;

        /// <summary>The customer order referenced document ID.</summary>
        protected internal String customerOrderReferencedDocumentID;

        /// <summary>The delivery note referenced document issue date time.</summary>
        protected internal DateTime deliveryNoteReferencedDocumentIssueDateTime;

        /// <summary>The delivery note referenced document issue date time format.</summary>
        protected internal String deliveryNoteReferencedDocumentIssueDateTimeFormat;

        /// <summary>The delivery note referenced document ID.</summary>
        protected internal String deliveryNoteReferencedDocumentID;

        /// <summary>The invoicee ID.</summary>
        protected internal String invoiceeID;

        /// <summary>The invoicee global ID.</summary>
        protected internal IList<String> invoiceeGlobalID = new List<String>();

        /// <summary>The invoicee global scheme ID.</summary>
        protected internal IList<String> invoiceeGlobalSchemeID = new List<String>();

        /// <summary>The invoicee name.</summary>
        protected internal String invoiceeName;

        /// <summary>The invoicee postcode.</summary>
        protected internal String invoiceePostcode;

        /// <summary>The invoicee line one.</summary>
        protected internal String invoiceeLineOne;

        /// <summary>The invoicee line two.</summary>
        protected internal String invoiceeLineTwo;

        /// <summary>The invoicee city name.</summary>
        protected internal String invoiceeCityName;

        /// <summary>The invoicee country ID.</summary>
        protected internal String invoiceeCountryID;

        /// <summary>The invoicee tax registration ID.</summary>
        protected internal IList<String> invoiceeTaxRegistrationID = new List<String>();

        /// <summary>The invoicee tax registration scheme ID.</summary>
        protected internal IList<String> invoiceeTaxRegistrationSchemeID = new List<String>();

        /// <summary>The payment means type code.</summary>
        protected internal IList<String> paymentMeansTypeCode = new List<String>();

        /// <summary>The payment means information.</summary>
        protected internal IList<String[]> paymentMeansInformation = new List<String[]>();

        /// <summary>The payment means payer account IBAN.</summary>
        protected internal IList<String> paymentMeansPayerAccountIBAN = new List<String>();

        /// <summary>The payment means payer account proprietary ID.</summary>
        protected internal IList<String> paymentMeansPayerAccountProprietaryID = new List<String>();

        /// <summary>The payment means payer financial institution BIC.</summary>
        protected internal IList<String> paymentMeansPayerFinancialInstitutionBIC = new List<String>();

        /// <summary>The payment means payer financial institution german bankleitzahl ID.</summary>
        protected internal IList<String> paymentMeansPayerFinancialInstitutionGermanBankleitzahlID = new List<String
            >();

        /// <summary>The payment means payer financial institution name.</summary>
        protected internal IList<String> paymentMeansPayerFinancialInstitutionName = new List<String>();

        /// <summary>The tax exemption reason.</summary>
        protected internal IList<String> taxExemptionReason = new List<String>();

        /// <summary>The tax category code.</summary>
        protected internal IList<String> taxCategoryCode = new List<String>();

        /// <summary>The billing start date time.</summary>
        protected internal DateTime billingStartDateTime;

        /// <summary>The billing start date time format.</summary>
        protected internal String billingStartDateTimeFormat;

        /// <summary>The billing end date time.</summary>
        protected internal DateTime billingEndDateTime;

        /// <summary>The billing end date time format.</summary>
        protected internal String billingEndDateTimeFormat;

        /// <summary>The trade allowance charge indicator.</summary>
        protected internal IList<bool> tradeAllowanceChargeIndicator = new List<bool>();

        /// <summary>The trade allowance charge actual amount.</summary>
        protected internal IList<String> tradeAllowanceChargeActualAmount = new List<String>();

        /// <summary>The trade allowance charge actual amount currency.</summary>
        protected internal IList<String> tradeAllowanceChargeActualAmountCurrency = new List<String>();

        /// <summary>The trade allowance charge reason.</summary>
        protected internal IList<String> tradeAllowanceChargeReason = new List<String>();

        /// <summary>The trade allowance charge tax type code.</summary>
        protected internal IList<String[]> tradeAllowanceChargeTaxTypeCode = new List<String[]>();

        /// <summary>The trade allowance charge tax category code.</summary>
        protected internal IList<String[]> tradeAllowanceChargeTaxCategoryCode = new List<String[]>();

        /// <summary>The trade allowance charge tax applicable percent.</summary>
        protected internal IList<String[]> tradeAllowanceChargeTaxApplicablePercent = new List<String[]>();

        /// <summary>The logistics service charge description.</summary>
        protected internal IList<String[]> logisticsServiceChargeDescription = new List<String[]>();

        /// <summary>The logistics service charge amount.</summary>
        protected internal IList<String> logisticsServiceChargeAmount = new List<String>();

        /// <summary>The logistics service charge amount currency.</summary>
        protected internal IList<String> logisticsServiceChargeAmountCurrency = new List<String>();

        /// <summary>The logistics service charge tax type code.</summary>
        protected internal IList<String[]> logisticsServiceChargeTaxTypeCode = new List<String[]>();

        /// <summary>The logistics service charge tax category code.</summary>
        protected internal IList<String[]> logisticsServiceChargeTaxCategoryCode = new List<String[]>();

        /// <summary>The logistics service charge tax applicable percent.</summary>
        protected internal IList<String[]> logisticsServiceChargeTaxApplicablePercent = new List<String[]>();

        /// <summary>The trade payment terms information.</summary>
        protected internal IList<String[]> tradePaymentTermsInformation = new List<String[]>();

        /// <summary>The trade payment terms due date time.</summary>
        protected internal IList<DateTime> tradePaymentTermsDueDateTime = new List<DateTime>();

        /// <summary>The trade payment terms due date time format.</summary>
        protected internal IList<String> tradePaymentTermsDueDateTimeFormat = new List<String>();

        /// <summary>The total prepaid amount.</summary>
        protected internal String totalPrepaidAmount;

        /// <summary>The total prepaid amount currency ID.</summary>
        protected internal String totalPrepaidAmountCurrencyID;

        /// <summary>The due payable amount.</summary>
        protected internal String duePayableAmount;

        /// <summary>The due payable amount currency ID.</summary>
        protected internal String duePayableAmountCurrencyID;

        /// <summary>The line item line ID.</summary>
        protected internal IList<String> lineItemLineID = new List<String>();

        /// <summary>The line item included note.</summary>
        protected internal IList<String[][]> lineItemIncludedNote = new List<String[][]>();

        /// <summary>The line item gross price charge amount.</summary>
        protected internal IList<String> lineItemGrossPriceChargeAmount = new List<String>();

        /// <summary>The line item gross price charge amount currency ID.</summary>
        protected internal IList<String> lineItemGrossPriceChargeAmountCurrencyID = new List<String>();

        /// <summary>The line item gross price basis quantity.</summary>
        protected internal IList<String> lineItemGrossPriceBasisQuantity = new List<String>();

        /// <summary>The line item gross price basis quantity code.</summary>
        protected internal IList<String> lineItemGrossPriceBasisQuantityCode = new List<String>();

        /// <summary>The line item gross price trade allowance charge indicator.</summary>
        protected internal IList<bool[]> lineItemGrossPriceTradeAllowanceChargeIndicator = new List<bool[]>();

        /// <summary>The line item gross price trade allowance charge actual amount.</summary>
        protected internal IList<String[]> lineItemGrossPriceTradeAllowanceChargeActualAmount = new List<String[]>
            ();

        /// <summary>The line item gross price trade allowance charge actual amount currency ID.</summary>
        protected internal IList<String[]> lineItemGrossPriceTradeAllowanceChargeActualAmountCurrencyID = new List
            <String[]>();

        /// <summary>The line item gross price trade allowance charge reason.</summary>
        protected internal IList<String[]> lineItemGrossPriceTradeAllowanceChargeReason = new List<String[]>();

        /// <summary>The line item net price charge amount.</summary>
        protected internal IList<String> lineItemNetPriceChargeAmount = new List<String>();

        /// <summary>The line item net price charge amount currency ID.</summary>
        protected internal IList<String> lineItemNetPriceChargeAmountCurrencyID = new List<String>();

        /// <summary>The line item net price basis quantity.</summary>
        protected internal IList<String> lineItemNetPriceBasisQuantity = new List<String>();

        /// <summary>The line item net price basis quantity code.</summary>
        protected internal IList<String> lineItemNetPriceBasisQuantityCode = new List<String>();

        /// <summary>The line item settlement tax type code.</summary>
        protected internal IList<String[]> lineItemSettlementTaxTypeCode = new List<String[]>();

        /// <summary>The line item settlement tax exemption reason.</summary>
        protected internal IList<String[]> lineItemSettlementTaxExemptionReason = new List<String[]>();

        /// <summary>The line item settlement tax category code.</summary>
        protected internal IList<String[]> lineItemSettlementTaxCategoryCode = new List<String[]>();

        /// <summary>The line item settlement tax applicable percent.</summary>
        protected internal IList<String[]> lineItemSettlementTaxApplicablePercent = new List<String[]>();

        /// <summary>The line item line total amount.</summary>
        protected internal IList<String> lineItemLineTotalAmount = new List<String>();

        /// <summary>The line item line total amount currency ID.</summary>
        protected internal IList<String> lineItemLineTotalAmountCurrencyID = new List<String>();

        /// <summary>The line item specified trade product global ID.</summary>
        protected internal IList<String> lineItemSpecifiedTradeProductGlobalID = new List<String>();

        /// <summary>The line item specified trade product scheme ID.</summary>
        protected internal IList<String> lineItemSpecifiedTradeProductSchemeID = new List<String>();

        /// <summary>The line item specified trade product seller assigned ID.</summary>
        protected internal IList<String> lineItemSpecifiedTradeProductSellerAssignedID = new List<String>();

        /// <summary>The line item specified trade product buyer assigned ID.</summary>
        protected internal IList<String> lineItemSpecifiedTradeProductBuyerAssignedID = new List<String>();

        /// <summary>The line item specified trade product description.</summary>
        protected internal IList<String> lineItemSpecifiedTradeProductDescription = new List<String>();

        /// <summary>
        /// Creates a new
        /// <see cref="ComfortProfileImp"/>
        /// instance.
        /// </summary>
        /// <param name="testIndicator">
        /// the parameter that determines whether a test invoice is going to be created.
        /// The test indicator can be used when implementing a newly developed system. It is to mark the
        /// invoice as a "test" and thus not leading to vat issues.
        /// </param>
        public ComfortProfileImp(bool testIndicator)
            : base(testIndicator) {
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getNotesCodes()
        */
        public virtual String[] GetNotesCodes() {
            return To1DArray(notesCodes);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getBuyerReference()
        */
        public virtual String GetBuyerReference() {
            return buyerReference;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getSellerID()
        */
        public virtual String GetSellerID() {
            return sellerID;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getSellerGlobalID()
        */
        public virtual String[] GetSellerGlobalID() {
            return To1DArray(sellerGlobalID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getSellerGlobalSchemeID()
        */
        public virtual String[] GetSellerGlobalSchemeID() {
            return To1DArray(sellerGlobalSchemeID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getBuyerID()
        */
        public virtual String GetBuyerID() {
            return buyerID;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getBuyerGlobalID()
        */
        public virtual String[] GetBuyerGlobalID() {
            return To1DArray(buyerGlobalID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getBuyerGlobalSchemeID()
        */
        public virtual String[] GetBuyerGlobalSchemeID() {
            return To1DArray(buyerGlobalSchemeID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getBuyerOrderReferencedDocumentIssueDateTime()
        */
        public virtual DateTime GetBuyerOrderReferencedDocumentIssueDateTime() {
            return buyerOrderReferencedDocumentIssueDateTime;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getBuyerOrderReferencedDocumentIssueDateTimeFormat()
        */
        public virtual String GetBuyerOrderReferencedDocumentIssueDateTimeFormat() {
            return buyerOrderReferencedDocumentIssueDateTimeFormat;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getBuyerOrderReferencedDocumentID()
        */
        public virtual String GetBuyerOrderReferencedDocumentID() {
            return buyerOrderReferencedDocumentID;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getContractReferencedDocumentIssueDateTime()
        */
        public virtual DateTime GetContractReferencedDocumentIssueDateTime() {
            return contractReferencedDocumentIssueDateTime;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getContractReferencedDocumentIssueDateTimeFormat()
        */
        public virtual String GetContractReferencedDocumentIssueDateTimeFormat() {
            return contractReferencedDocumentIssueDateTimeFormat;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getContractReferencedDocumentID()
        */
        public virtual String GetContractReferencedDocumentID() {
            return contractReferencedDocumentID;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getCustomerOrderReferencedDocumentIssueDateTime()
        */
        public virtual DateTime GetCustomerOrderReferencedDocumentIssueDateTime() {
            return customerOrderReferencedDocumentIssueDateTime;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getCustomerOrderReferencedDocumentIssueDateTimeFormat()
        */
        public virtual String GetCustomerOrderReferencedDocumentIssueDateTimeFormat() {
            return customerOrderReferencedDocumentIssueDateTimeFormat;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getCustomerOrderReferencedDocumentID()
        */
        public virtual String GetCustomerOrderReferencedDocumentID() {
            return customerOrderReferencedDocumentID;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getDeliveryNoteReferencedDocumentIssueDateTime()
        */
        public virtual DateTime GetDeliveryNoteReferencedDocumentIssueDateTime() {
            return deliveryNoteReferencedDocumentIssueDateTime;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getDeliveryNoteReferencedDocumentIssueDateTimeFormat()
        */
        public virtual String GetDeliveryNoteReferencedDocumentIssueDateTimeFormat() {
            return deliveryNoteReferencedDocumentIssueDateTimeFormat;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getDeliveryNoteReferencedDocumentID()
        */
        public virtual String GetDeliveryNoteReferencedDocumentID() {
            return deliveryNoteReferencedDocumentID;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getInvoiceeID()
        */
        public virtual String GetInvoiceeID() {
            return invoiceeID;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getInvoiceeGlobalID()
        */
        public virtual String[] GetInvoiceeGlobalID() {
            return To1DArray(invoiceeGlobalID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getInvoiceeGlobalSchemeID()
        */
        public virtual String[] GetInvoiceeGlobalSchemeID() {
            return To1DArray(invoiceeGlobalSchemeID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getInvoiceeName()
        */
        public virtual String GetInvoiceeName() {
            return invoiceeName;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getInvoiceePostcode()
        */
        public virtual String GetInvoiceePostcode() {
            return invoiceePostcode;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getInvoiceeLineOne()
        */
        public virtual String GetInvoiceeLineOne() {
            return invoiceeLineOne;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getInvoiceeLineTwo()
        */
        public virtual String GetInvoiceeLineTwo() {
            return invoiceeLineTwo;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getInvoiceeCityName()
        */
        public virtual String GetInvoiceeCityName() {
            return invoiceeCityName;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getInvoiceeCountryID()
        */
        public virtual String GetInvoiceeCountryID() {
            return invoiceeCountryID;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getInvoiceeTaxRegistrationID()
        */
        public virtual String[] GetInvoiceeTaxRegistrationID() {
            return To1DArray(invoiceeTaxRegistrationID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getInvoiceeTaxRegistrationSchemeID()
        */
        public virtual String[] GetInvoiceeTaxRegistrationSchemeID() {
            return To1DArray(invoiceeTaxRegistrationSchemeID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getPaymentMeansTypeCode()
        */
        public virtual String[] GetPaymentMeansTypeCode() {
            return To1DArray(paymentMeansTypeCode);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getPaymentMeansInformation()
        */
        public virtual String[][] GetPaymentMeansInformation() {
            return To2DArray(paymentMeansInformation);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getPaymentMeansPayerAccountIBAN()
        */
        public virtual String[] GetPaymentMeansPayerAccountIBAN() {
            return To1DArray(paymentMeansPayerAccountIBAN);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getPaymentMeansPayerAccountProprietaryID()
        */
        public virtual String[] GetPaymentMeansPayerAccountProprietaryID() {
            return To1DArray(paymentMeansPayerAccountProprietaryID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getPaymentMeansPayerFinancialInstitutionBIC()
        */
        public virtual String[] GetPaymentMeansPayerFinancialInstitutionBIC() {
            return To1DArray(paymentMeansPayerFinancialInstitutionBIC);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getPaymentMeansPayerFinancialInstitutionGermanBankleitzahlID()
        */
        public virtual String[] GetPaymentMeansPayerFinancialInstitutionGermanBankleitzahlID() {
            return To1DArray(paymentMeansPayerFinancialInstitutionGermanBankleitzahlID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getPaymentMeansPayerFinancialInstitutionName()
        */
        public virtual String[] GetPaymentMeansPayerFinancialInstitutionName() {
            return To1DArray(paymentMeansPayerFinancialInstitutionName);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getTaxExemptionReason()
        */
        public virtual String[] GetTaxExemptionReason() {
            return To1DArray(taxExemptionReason);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getTaxCategoryCode()
        */
        public virtual String[] GetTaxCategoryCode() {
            return To1DArray(taxCategoryCode);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getBillingStartDateTime()
        */
        public virtual DateTime GetBillingStartDateTime() {
            return billingStartDateTime;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getBillingStartDateTimeFormat()
        */
        public virtual String GetBillingStartDateTimeFormat() {
            return billingStartDateTimeFormat;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getBillingEndDateTime()
        */
        public virtual DateTime GetBillingEndDateTime() {
            return billingEndDateTime;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getBillingEndDateTimeFormat()
        */
        public virtual String GetBillingEndDateTimeFormat() {
            return billingEndDateTimeFormat;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getSpecifiedTradeAllowanceChargeIndicator()
        */
        public virtual bool[] GetSpecifiedTradeAllowanceChargeIndicator() {
            return To1DArrayB(tradeAllowanceChargeIndicator);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getSpecifiedTradeAllowanceChargeActualAmount()
        */
        public virtual String[] GetSpecifiedTradeAllowanceChargeActualAmount() {
            return To1DArray(tradeAllowanceChargeActualAmount);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getSpecifiedTradeAllowanceChargeActualAmountCurrency()
        */
        public virtual String[] GetSpecifiedTradeAllowanceChargeActualAmountCurrency() {
            return To1DArray(tradeAllowanceChargeActualAmountCurrency);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getSpecifiedTradeAllowanceChargeReason()
        */
        public virtual String[] GetSpecifiedTradeAllowanceChargeReason() {
            return To1DArray(tradeAllowanceChargeReason);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getSpecifiedTradeAllowanceChargeTaxTypeCode()
        */
        public virtual String[][] GetSpecifiedTradeAllowanceChargeTaxTypeCode() {
            return To2DArray(tradeAllowanceChargeTaxTypeCode);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getSpecifiedTradeAllowanceChargeTaxCategoryCode()
        */
        public virtual String[][] GetSpecifiedTradeAllowanceChargeTaxCategoryCode() {
            return To2DArray(tradeAllowanceChargeTaxCategoryCode);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getSpecifiedTradeAllowanceChargeTaxApplicablePercent()
        */
        public virtual String[][] GetSpecifiedTradeAllowanceChargeTaxApplicablePercent() {
            return To2DArray(tradeAllowanceChargeTaxApplicablePercent);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getSpecifiedLogisticsServiceChargeDescription()
        */
        public virtual String[][] GetSpecifiedLogisticsServiceChargeDescription() {
            return To2DArray(logisticsServiceChargeDescription);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getSpecifiedLogisticsServiceChargeAmount()
        */
        public virtual String[] GetSpecifiedLogisticsServiceChargeAmount() {
            return To1DArray(logisticsServiceChargeAmount);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getSpecifiedLogisticsServiceChargeAmountCurrency()
        */
        public virtual String[] GetSpecifiedLogisticsServiceChargeAmountCurrency() {
            return To1DArray(logisticsServiceChargeAmountCurrency);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getSpecifiedLogisticsServiceChargeTaxTypeCode()
        */
        public virtual String[][] GetSpecifiedLogisticsServiceChargeTaxTypeCode() {
            return To2DArray(logisticsServiceChargeTaxTypeCode);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getSpecifiedLogisticsServiceChargeTaxCategoryCode()
        */
        public virtual String[][] GetSpecifiedLogisticsServiceChargeTaxCategoryCode() {
            return To2DArray(logisticsServiceChargeTaxCategoryCode);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getSpecifiedLogisticsServiceChargeTaxApplicablePercent()
        */
        public virtual String[][] GetSpecifiedLogisticsServiceChargeTaxApplicablePercent() {
            return To2DArray(logisticsServiceChargeTaxApplicablePercent);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getSpecifiedTradePaymentTermsDescription()
        */
        public virtual String[][] GetSpecifiedTradePaymentTermsDescription() {
            return To2DArray(tradePaymentTermsInformation);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getSpecifiedTradePaymentTermsDueDateTime()
        */
        public virtual DateTime[] GetSpecifiedTradePaymentTermsDueDateTime() {
            return (DateTime[])tradePaymentTermsDueDateTime.ToArray(new DateTime[tradePaymentTermsDueDateTime.Count]);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getSpecifiedTradePaymentTermsDueDateTimeFormat()
        */
        public virtual String[] GetSpecifiedTradePaymentTermsDueDateTimeFormat() {
            return To1DArray(tradePaymentTermsDueDateTimeFormat);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getTotalPrepaidAmount()
        */
        public virtual String GetTotalPrepaidAmount() {
            return totalPrepaidAmount;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getTotalPrepaidAmountCurrencyID()
        */
        public virtual String GetTotalPrepaidAmountCurrencyID() {
            return totalPrepaidAmountCurrencyID;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getDuePayableAmount()
        */
        public virtual String GetDuePayableAmount() {
            return duePayableAmount;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getDuePayableAmountCurrencyID()
        */
        public virtual String GetDuePayableAmountCurrencyID() {
            return duePayableAmountCurrencyID;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemLineID()
        */
        public virtual String[] GetLineItemLineID() {
            return To1DArray(lineItemLineID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemIncludedNote()
        */
        public virtual String[][][] GetLineItemIncludedNote() {
            return To3DArray(lineItemIncludedNote);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemGrossPriceChargeAmount()
        */
        public virtual String[] GetLineItemGrossPriceChargeAmount() {
            return To1DArray(lineItemGrossPriceChargeAmount);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemGrossPriceChargeAmountCurrencyID()
        */
        public virtual String[] GetLineItemGrossPriceChargeAmountCurrencyID() {
            return To1DArray(lineItemGrossPriceChargeAmountCurrencyID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemGrossPriceBasisQuantity()
        */
        public virtual String[] GetLineItemGrossPriceBasisQuantity() {
            return To1DArray(lineItemGrossPriceBasisQuantity);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemGrossPriceBasisQuantityCode()
        */
        public virtual String[] GetLineItemGrossPriceBasisQuantityCode() {
            return To1DArray(lineItemGrossPriceBasisQuantityCode);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemGrossPriceTradeAllowanceChargeIndicator()
        */
        public virtual bool[][] GetLineItemGrossPriceTradeAllowanceChargeIndicator() {
            return To2DArrayB(lineItemGrossPriceTradeAllowanceChargeIndicator);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemGrossPriceTradeAllowanceChargeActualAmount()
        */
        public virtual String[][] GetLineItemGrossPriceTradeAllowanceChargeActualAmount() {
            return To2DArray(lineItemGrossPriceTradeAllowanceChargeActualAmount);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemGrossPriceTradeAllowanceChargeActualAmountCurrencyID()
        */
        public virtual String[][] GetLineItemGrossPriceTradeAllowanceChargeActualAmountCurrencyID() {
            return To2DArray(lineItemGrossPriceTradeAllowanceChargeActualAmountCurrencyID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemGrossPriceTradeAllowanceChargeReason()
        */
        public virtual String[][] GetLineItemGrossPriceTradeAllowanceChargeReason() {
            return To2DArray(lineItemGrossPriceTradeAllowanceChargeReason);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemNetPriceChargeAmount()
        */
        public virtual String[] GetLineItemNetPriceChargeAmount() {
            return To1DArray(lineItemNetPriceChargeAmount);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemNetPriceChargeAmountCurrencyID()
        */
        public virtual String[] GetLineItemNetPriceChargeAmountCurrencyID() {
            return To1DArray(lineItemNetPriceChargeAmountCurrencyID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemNetPriceBasisQuantity()
        */
        public virtual String[] GetLineItemNetPriceBasisQuantity() {
            return To1DArray(lineItemNetPriceBasisQuantity);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemNetPriceBasisQuantityCode()
        */
        public virtual String[] GetLineItemNetPriceBasisQuantityCode() {
            return To1DArray(lineItemNetPriceBasisQuantityCode);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemSettlementTaxTypeCode()
        */
        public virtual String[][] GetLineItemSettlementTaxTypeCode() {
            return To2DArray(lineItemSettlementTaxTypeCode);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemSettlementTaxExemptionReason()
        */
        public virtual String[][] GetLineItemSettlementTaxExemptionReason() {
            return To2DArray(lineItemSettlementTaxExemptionReason);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemSettlementTaxCategoryCode()
        */
        public virtual String[][] GetLineItemSettlementTaxCategoryCode() {
            return To2DArray(lineItemSettlementTaxCategoryCode);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemSettlementTaxApplicablePercent()
        */
        public virtual String[][] GetLineItemSettlementTaxApplicablePercent() {
            return To2DArray(lineItemSettlementTaxApplicablePercent);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemLineTotalAmount()
        */
        public virtual String[] GetLineItemLineTotalAmount() {
            return To1DArray(lineItemLineTotalAmount);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemLineTotalAmountCurrencyID()
        */
        public virtual String[] GetLineItemLineTotalAmountCurrencyID() {
            return To1DArray(lineItemLineTotalAmountCurrencyID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemSpecifiedTradeProductGlobalID()
        */
        public virtual String[] GetLineItemSpecifiedTradeProductGlobalID() {
            return To1DArray(lineItemSpecifiedTradeProductGlobalID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemSpecifiedTradeProductSchemeID()
        */
        public virtual String[] GetLineItemSpecifiedTradeProductSchemeID() {
            return To1DArray(lineItemSpecifiedTradeProductSchemeID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemSpecifiedTradeProductSellerAssignedID()
        */
        public virtual String[] GetLineItemSpecifiedTradeProductSellerAssignedID() {
            return To1DArray(lineItemSpecifiedTradeProductSellerAssignedID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemSpecifiedTradeProductBuyerAssignedID()
        */
        public virtual String[] GetLineItemSpecifiedTradeProductBuyerAssignedID() {
            return To1DArray(lineItemSpecifiedTradeProductBuyerAssignedID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IComfortProfile#getLineItemSpecifiedTradeProductDescription()
        */
        public virtual String[] GetLineItemSpecifiedTradeProductDescription() {
            return To1DArray(lineItemSpecifiedTradeProductDescription);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.BasicProfileImp#addNote(java.lang.String[])
        */
        public override void AddNote(String[] note) {
            throw new NotSupportedException("This method can only be used for the BASIC level.");
        }

        /// <summary>Adds the note.</summary>
        /// <param name="note">the note</param>
        /// <param name="code">the code</param>
        public virtual void AddNote(String[] note, String code) {
            notes.Add(note);
            notesCodes.Add(code);
        }

        /// <summary>Sets the buyer reference.</summary>
        /// <param name="buyerReference">the new buyer reference</param>
        public virtual void SetBuyerReference(String buyerReference) {
            this.buyerReference = buyerReference;
        }

        /// <summary>Sets the seller ID.</summary>
        /// <param name="sellerID">the new seller ID</param>
        public virtual void SetSellerID(String sellerID) {
            this.sellerID = sellerID;
        }

        /// <summary>Adds the seller global ID.</summary>
        /// <param name="sellerGlobalSchemeID">the seller global scheme ID</param>
        /// <param name="sellerGlobalID">the seller global ID</param>
        public virtual void AddSellerGlobalID(String sellerGlobalSchemeID, String sellerGlobalID) {
            this.sellerGlobalID.Add(sellerGlobalID);
            this.sellerGlobalSchemeID.Add(sellerGlobalSchemeID);
        }

        /// <summary>Sets the buyer ID.</summary>
        /// <param name="buyerID">the new buyer ID</param>
        public virtual void SetBuyerID(String buyerID) {
            this.buyerID = buyerID;
        }

        /// <summary>Adds the buyer global ID.</summary>
        /// <param name="buyerGlobalSchemeID">the buyer global scheme ID</param>
        /// <param name="buyerGlobalID">the buyer global ID</param>
        public virtual void AddBuyerGlobalID(String buyerGlobalSchemeID, String buyerGlobalID) {
            this.buyerGlobalID.Add(buyerGlobalID);
            this.buyerGlobalSchemeID.Add(buyerGlobalSchemeID);
        }

        /// <summary>Sets the buyer order referenced document issue date time.</summary>
        /// <param name="buyerOrderReferencedDocumentIssueDateTime">the buyer order referenced document issue date time
        ///     </param>
        /// <param name="buyerOrderReferencedDocumentIssueDateTimeFormat">the buyer order referenced document issue date time format
        ///     </param>
        public virtual void SetBuyerOrderReferencedDocumentIssueDateTime(DateTime buyerOrderReferencedDocumentIssueDateTime
            , String buyerOrderReferencedDocumentIssueDateTimeFormat) {
            this.buyerOrderReferencedDocumentIssueDateTime = buyerOrderReferencedDocumentIssueDateTime;
            this.buyerOrderReferencedDocumentIssueDateTimeFormat = buyerOrderReferencedDocumentIssueDateTimeFormat;
        }

        /// <summary>Sets the buyer order referenced document ID.</summary>
        /// <param name="buyerOrderReferencedDocumentID">the new buyer order referenced document ID</param>
        public virtual void SetBuyerOrderReferencedDocumentID(String buyerOrderReferencedDocumentID) {
            this.buyerOrderReferencedDocumentID = buyerOrderReferencedDocumentID;
        }

        /// <summary>Sets the contract referenced document issue date time.</summary>
        /// <param name="contractReferencedDocumentIssueDateTime">the contract referenced document issue date time</param>
        /// <param name="contractReferencedDocumentIssueDateTimeFormat">the contract referenced document issue date time format
        ///     </param>
        public virtual void SetContractReferencedDocumentIssueDateTime(DateTime contractReferencedDocumentIssueDateTime
            , String contractReferencedDocumentIssueDateTimeFormat) {
            this.contractReferencedDocumentIssueDateTime = contractReferencedDocumentIssueDateTime;
            this.contractReferencedDocumentIssueDateTimeFormat = contractReferencedDocumentIssueDateTimeFormat;
        }

        /// <summary>Sets the contract referenced document ID.</summary>
        /// <param name="contractReferencedDocumentID">the new contract referenced document ID</param>
        public virtual void SetContractReferencedDocumentID(String contractReferencedDocumentID) {
            this.contractReferencedDocumentID = contractReferencedDocumentID;
        }

        /// <summary>Sets the customer order referenced document issue date time.</summary>
        /// <param name="customerOrderReferencedDocumentIssueDateTime">the customer order referenced document issue date time
        ///     </param>
        /// <param name="customerOrderReferencedDocumentIssueDateTimeFormat">the customer order referenced document issue date time format
        ///     </param>
        public virtual void SetCustomerOrderReferencedDocumentIssueDateTime(DateTime customerOrderReferencedDocumentIssueDateTime
            , String customerOrderReferencedDocumentIssueDateTimeFormat) {
            this.customerOrderReferencedDocumentIssueDateTime = customerOrderReferencedDocumentIssueDateTime;
            this.customerOrderReferencedDocumentIssueDateTimeFormat = customerOrderReferencedDocumentIssueDateTimeFormat;
        }

        /// <summary>Sets the customer order referenced document ID.</summary>
        /// <param name="customerOrderReferencedDocumentID">the new customer order referenced document ID</param>
        public virtual void SetCustomerOrderReferencedDocumentID(String customerOrderReferencedDocumentID) {
            this.customerOrderReferencedDocumentID = customerOrderReferencedDocumentID;
        }

        /// <summary>Sets the delivery note referenced document issue date time.</summary>
        /// <param name="deliveryNoteReferencedDocumentIssueDateTime">the delivery note referenced document issue date time
        ///     </param>
        /// <param name="deliveryNoteReferencedDocumentIssueDateTimeFormat">the delivery note referenced document issue date time format
        ///     </param>
        public virtual void SetDeliveryNoteReferencedDocumentIssueDateTime(DateTime deliveryNoteReferencedDocumentIssueDateTime
            , String deliveryNoteReferencedDocumentIssueDateTimeFormat) {
            this.deliveryNoteReferencedDocumentIssueDateTime = deliveryNoteReferencedDocumentIssueDateTime;
            this.deliveryNoteReferencedDocumentIssueDateTimeFormat = deliveryNoteReferencedDocumentIssueDateTimeFormat;
        }

        /// <summary>Sets the delivery note referenced document ID.</summary>
        /// <param name="deliveryNoteReferencedDocumentID">the new delivery note referenced document ID</param>
        public virtual void SetDeliveryNoteReferencedDocumentID(String deliveryNoteReferencedDocumentID) {
            this.deliveryNoteReferencedDocumentID = deliveryNoteReferencedDocumentID;
        }

        /// <summary>Sets the invoicee ID.</summary>
        /// <param name="invoiceeID">the new invoicee ID</param>
        public virtual void SetInvoiceeID(String invoiceeID) {
            this.invoiceeID = invoiceeID;
        }

        /// <summary>Adds the invoicee global ID.</summary>
        /// <param name="invoiceeGlobalSchemeID">the invoicee global scheme ID</param>
        /// <param name="invoiceeGlobalID">the invoicee global ID</param>
        public virtual void AddInvoiceeGlobalID(String invoiceeGlobalSchemeID, String invoiceeGlobalID) {
            this.invoiceeGlobalSchemeID.Add(invoiceeGlobalSchemeID);
            this.invoiceeGlobalID.Add(invoiceeGlobalID);
        }

        /// <summary>Sets the invoicee name.</summary>
        /// <param name="invoiceeName">the new invoicee name</param>
        public virtual void SetInvoiceeName(String invoiceeName) {
            this.invoiceeName = invoiceeName;
        }

        /// <summary>Sets the invoicee postcode.</summary>
        /// <param name="invoiceePostcode">the new invoicee postcode</param>
        public virtual void SetInvoiceePostcode(String invoiceePostcode) {
            this.invoiceePostcode = invoiceePostcode;
        }

        /// <summary>Sets the invoicee line one.</summary>
        /// <param name="invoiceeLineOne">the new invoicee line one</param>
        public virtual void SetInvoiceeLineOne(String invoiceeLineOne) {
            this.invoiceeLineOne = invoiceeLineOne;
        }

        /// <summary>Sets the invoicee line two.</summary>
        /// <param name="invoiceeLineTwo">the new invoicee line two</param>
        public virtual void SetInvoiceeLineTwo(String invoiceeLineTwo) {
            this.invoiceeLineTwo = invoiceeLineTwo;
        }

        /// <summary>Sets the invoicee city name.</summary>
        /// <param name="invoiceeCityName">the new invoicee city name</param>
        public virtual void SetInvoiceeCityName(String invoiceeCityName) {
            this.invoiceeCityName = invoiceeCityName;
        }

        /// <summary>Sets the invoicee country ID.</summary>
        /// <param name="invoiceeCountryID">the new invoicee country ID</param>
        public virtual void SetInvoiceeCountryID(String invoiceeCountryID) {
            this.invoiceeCountryID = invoiceeCountryID;
        }

        /// <summary>Adds the invoicee tax registration.</summary>
        /// <param name="schemeID">the scheme ID</param>
        /// <param name="taxId">the tax id</param>
        public virtual void AddInvoiceeTaxRegistration(String schemeID, String taxId) {
            invoiceeTaxRegistrationSchemeID.Add(schemeID);
            invoiceeTaxRegistrationID.Add(taxId);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.BasicProfileImp#addPaymentMeans(java.lang.String, java.lang.String, java.lang.String, java.lang.String, java.lang.String, java.lang.String, java.lang.String, java.lang.String)
        */
        public override void AddPaymentMeans(String schemeAgencyID, String id, String iban, String accountname, String
             proprietaryID, String bic, String germanBankleitzahlID, String institutionname) {
            throw new NotSupportedException("This method can only be used for the BASIC level.");
        }

        /// <summary>Adds the payment means.</summary>
        /// <param name="typeCode">the type code</param>
        /// <param name="information">the information</param>
        /// <param name="schemeAgencyID">the scheme agency ID</param>
        /// <param name="id">the id</param>
        /// <param name="ibanDebtor">the iban debtor</param>
        /// <param name="proprietaryIDDebtor">the proprietary ID debtor</param>
        /// <param name="ibanCreditor">the iban creditor</param>
        /// <param name="accountnameCreditor">the accountname creditor</param>
        /// <param name="proprietaryIDCreditor">the proprietary ID creditor</param>
        /// <param name="bicDebtor">the bic debtor</param>
        /// <param name="germanBankleitzahlIDDebtor">the german bankleitzahl ID debtor</param>
        /// <param name="institutionnameDebtor">the institutionname debtor</param>
        /// <param name="bicCreditor">the bic creditor</param>
        /// <param name="germanBankleitzahlIDCreditor">the german bankleitzahl ID creditor</param>
        /// <param name="institutionnameCreditor">the institutionname creditor</param>
        public virtual void AddPaymentMeans(String typeCode, String[] information, String schemeAgencyID, String id
            , String ibanDebtor, String proprietaryIDDebtor, String ibanCreditor, String accountnameCreditor, String
             proprietaryIDCreditor, String bicDebtor, String germanBankleitzahlIDDebtor, String institutionnameDebtor
            , String bicCreditor, String germanBankleitzahlIDCreditor, String institutionnameCreditor) {
            paymentMeansTypeCode.Add(typeCode);
            paymentMeansInformation.Add(information);
            paymentMeansID.Add(id);
            paymentMeansSchemeAgencyID.Add(schemeAgencyID);
            paymentMeansPayerAccountIBAN.Add(ibanDebtor);
            paymentMeansPayerAccountProprietaryID.Add(proprietaryIDDebtor);
            paymentMeansPayeeAccountIBAN.Add(ibanCreditor);
            paymentMeansPayeeAccountName.Add(accountnameCreditor);
            paymentMeansPayeeAccountProprietaryID.Add(proprietaryIDCreditor);
            paymentMeansPayerFinancialInstitutionBIC.Add(bicDebtor);
            paymentMeansPayerFinancialInstitutionGermanBankleitzahlID.Add(germanBankleitzahlIDDebtor);
            paymentMeansPayerFinancialInstitutionName.Add(institutionnameDebtor);
            paymentMeansPayeeFinancialInstitutionBIC.Add(bicCreditor);
            paymentMeansPayeeFinancialInstitutionGermanBankleitzahlID.Add(germanBankleitzahlIDCreditor);
            paymentMeansPayeeFinancialInstitutionName.Add(institutionnameCreditor);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.BasicProfileImp#addApplicableTradeTax(java.lang.String, java.lang.String, java.lang.String, java.lang.String, java.lang.String, java.lang.String)
        */
        public override void AddApplicableTradeTax(String calculatedAmount, String calculatedAmountCurrencyID, String
             typeCode, String basisAmount, String basisAmountCurrencyID, String applicablePercent) {
            throw new NotSupportedException("This method can only be used for the BASIC level.");
        }

        /// <summary>Adds the applicable trade tax.</summary>
        /// <param name="calculatedAmount">the calculated amount</param>
        /// <param name="calculatedAmountCurrencyID">the calculated amount currency ID</param>
        /// <param name="typeCode">the type code</param>
        /// <param name="exemptionReason">the exemption reason</param>
        /// <param name="basisAmount">the basis amount</param>
        /// <param name="basisAmountCurrencyID">the basis amount currency ID</param>
        /// <param name="categoryCode">the category code</param>
        /// <param name="applicablePercent">the applicable percent</param>
        public virtual void AddApplicableTradeTax(String calculatedAmount, String calculatedAmountCurrencyID, String
             typeCode, String exemptionReason, String basisAmount, String basisAmountCurrencyID, String categoryCode
            , String applicablePercent) {
            taxCalculatedAmount.Add(calculatedAmount);
            taxCalculatedAmountCurrencyID.Add(calculatedAmountCurrencyID);
            taxTypeCode.Add(typeCode);
            taxExemptionReason.Add(exemptionReason);
            taxBasisAmount.Add(basisAmount);
            taxBasisAmountCurrencyID.Add(basisAmountCurrencyID);
            taxCategoryCode.Add(categoryCode);
            taxApplicablePercent.Add(applicablePercent);
        }

        /// <summary>Sets the billing start end.</summary>
        /// <param name="billingStartDateTime">the billing start date time</param>
        /// <param name="billingStartDateTimeFormat">the billing start date time format</param>
        /// <param name="billingEndDateTime">the billing end date time</param>
        /// <param name="billingEndDateTimeFormat">the billing end date time format</param>
        public virtual void SetBillingStartEnd(DateTime billingStartDateTime, String billingStartDateTimeFormat, DateTime
             billingEndDateTime, String billingEndDateTimeFormat) {
            this.billingStartDateTime = billingStartDateTime;
            this.billingStartDateTimeFormat = billingStartDateTimeFormat;
            this.billingEndDateTime = billingEndDateTime;
            this.billingEndDateTimeFormat = billingEndDateTimeFormat;
        }

        /// <summary>Adds the specified trade allowance charge.</summary>
        /// <param name="indicator">the indicator</param>
        /// <param name="actualAmount">the actual amount</param>
        /// <param name="actualAmountCurrency">the actual amount currency</param>
        /// <param name="reason">the reason</param>
        /// <param name="typeCodes">the type codes</param>
        /// <param name="categoryCodes">the category codes</param>
        /// <param name="applicablePercent">the applicable percent</param>
        public virtual void AddSpecifiedTradeAllowanceCharge(bool indicator, String actualAmount, String actualAmountCurrency
            , String reason, String[] typeCodes, String[] categoryCodes, String[] applicablePercent) {
            this.tradeAllowanceChargeIndicator.Add(indicator);
            this.tradeAllowanceChargeActualAmount.Add(actualAmount);
            this.tradeAllowanceChargeActualAmountCurrency.Add(actualAmountCurrency);
            this.tradeAllowanceChargeReason.Add(reason);
            this.tradeAllowanceChargeTaxTypeCode.Add(typeCodes);
            this.tradeAllowanceChargeTaxCategoryCode.Add(categoryCodes);
            this.tradeAllowanceChargeTaxApplicablePercent.Add(applicablePercent);
        }

        /// <summary>Adds the specified logistics service charge.</summary>
        /// <param name="description">the description</param>
        /// <param name="actualAmount">the actual amount</param>
        /// <param name="actualAmountCurrency">the actual amount currency</param>
        /// <param name="typeCodes">the type codes</param>
        /// <param name="categoryCodes">the category codes</param>
        /// <param name="applicablePercent">the applicable percent</param>
        public virtual void AddSpecifiedLogisticsServiceCharge(String[] description, String actualAmount, String actualAmountCurrency
            , String[] typeCodes, String[] categoryCodes, String[] applicablePercent) {
            this.logisticsServiceChargeDescription.Add(description);
            this.logisticsServiceChargeAmount.Add(actualAmount);
            this.logisticsServiceChargeAmountCurrency.Add(actualAmountCurrency);
            this.logisticsServiceChargeTaxTypeCode.Add(typeCodes);
            this.logisticsServiceChargeTaxCategoryCode.Add(categoryCodes);
            this.logisticsServiceChargeTaxApplicablePercent.Add(applicablePercent);
        }

        /// <summary>Adds the specified trade payment terms.</summary>
        /// <param name="information">the information</param>
        /// <param name="dateTime">the date time</param>
        /// <param name="dateTimeFormat">the date time format</param>
        public virtual void AddSpecifiedTradePaymentTerms(String[] information, DateTime dateTime, String dateTimeFormat
            ) {
            this.tradePaymentTermsInformation.Add(information);
            this.tradePaymentTermsDueDateTime.Add(dateTime);
            this.tradePaymentTermsDueDateTimeFormat.Add(dateTimeFormat);
        }

        /// <summary>Sets the total prepaid amount.</summary>
        /// <param name="totalPrepaidAmount">the total prepaid amount</param>
        /// <param name="totalPrepaidCurrencyID">the total prepaid currency ID</param>
        public virtual void SetTotalPrepaidAmount(String totalPrepaidAmount, String totalPrepaidCurrencyID) {
            this.totalPrepaidAmount = totalPrepaidAmount;
            this.totalPrepaidAmountCurrencyID = totalPrepaidCurrencyID;
        }

        /// <summary>Sets the due payable amount.</summary>
        /// <param name="duePayableAmount">the due payable amount</param>
        /// <param name="duePayableAmountCurrencyID">the due payable amount currency ID</param>
        public virtual void SetDuePayableAmount(String duePayableAmount, String duePayableAmountCurrencyID) {
            this.duePayableAmount = duePayableAmount;
            this.duePayableAmountCurrencyID = duePayableAmountCurrencyID;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.BasicProfileImp#addIncludedSupplyChainTradeLineItem(java.lang.String, java.lang.String, java.lang.String)
        */
        public override void AddIncludedSupplyChainTradeLineItem(String billedQuantity, String billedQuantityUnitCode
            , String specifiedTradeProductName) {
            throw new NotSupportedException("This method can only be used for the BASIC level.");
        }

        /// <summary>Adds the included supply chain trade line item.</summary>
        /// <param name="id">the id</param>
        /// <param name="notes">the notes</param>
        /// <param name="grossPriceChargeAmount">the gross price charge amount</param>
        /// <param name="grossPriceChargeAmountCurrencyID">the gross price charge amount currency ID</param>
        /// <param name="grossPriceBasisQuantity">the gross price basis quantity</param>
        /// <param name="grossPriceBasisQuantityCode">the gross price basis quantity code</param>
        /// <param name="grossPriceTradeAllowanceChargeIndicator">the gross price trade allowance charge indicator</param>
        /// <param name="grossPriceTradeAllowanceChargeActualAmount">the gross price trade allowance charge actual amount
        ///     </param>
        /// <param name="grossPriceTradeAllowanceChargeActualAmountCurrencyID">the gross price trade allowance charge actual amount currency ID
        ///     </param>
        /// <param name="grossPriceTradeAllowanceChargeReason">the gross price trade allowance charge reason</param>
        /// <param name="netPriceChargeAmount">the net price charge amount</param>
        /// <param name="netPriceChargeAmountCurrencyID">the net price charge amount currency ID</param>
        /// <param name="netPriceBasisQuantity">the net price basis quantity</param>
        /// <param name="netPriceBasisQuantityCode">the net price basis quantity code</param>
        /// <param name="billedQuantity">the billed quantity</param>
        /// <param name="billedQuantityUnitCode">the billed quantity unit code</param>
        /// <param name="lineItemSettlementTaxTypeCode">the line item settlement tax type code</param>
        /// <param name="lineItemSettlementTaxExemptionReason">the line item settlement tax exemption reason</param>
        /// <param name="lineItemSettlementTaxCategoryCode">the line item settlement tax category code</param>
        /// <param name="lineItemSettlementTaxApplicablePercent">the line item settlement tax applicable percent</param>
        /// <param name="lineItemLineTotalAmount">the line item line total amount</param>
        /// <param name="lineItemLineTotalAmountCurrencyID">the line item line total amount currency ID</param>
        /// <param name="lineItemSpecifiedTradeProductGlobalID">the line item specified trade product global ID</param>
        /// <param name="lineItemSpecifiedTradeProductSchemeID">the line item specified trade product scheme ID</param>
        /// <param name="lineItemSpecifiedTradeProductSellerAssignedID">the line item specified trade product seller assigned ID
        ///     </param>
        /// <param name="lineItemSpecifiedTradeProductBuyerAssignedID">the line item specified trade product buyer assigned ID
        ///     </param>
        /// <param name="lineItemSpecifiedTradeProductName">the line item specified trade product name</param>
        /// <param name="lineItemSpecifiedTradeProductDescription">the line item specified trade product description</param>
        public virtual void AddIncludedSupplyChainTradeLineItem(String id, String[][] notes, String grossPriceChargeAmount
            , String grossPriceChargeAmountCurrencyID, String grossPriceBasisQuantity, String grossPriceBasisQuantityCode
            , bool[] grossPriceTradeAllowanceChargeIndicator, String[] grossPriceTradeAllowanceChargeActualAmount, 
            String[] grossPriceTradeAllowanceChargeActualAmountCurrencyID, String[] grossPriceTradeAllowanceChargeReason
            , String netPriceChargeAmount, String netPriceChargeAmountCurrencyID, String netPriceBasisQuantity, String
             netPriceBasisQuantityCode, String billedQuantity, String billedQuantityUnitCode, String[] lineItemSettlementTaxTypeCode
            , String[] lineItemSettlementTaxExemptionReason, String[] lineItemSettlementTaxCategoryCode, String[] 
            lineItemSettlementTaxApplicablePercent, String lineItemLineTotalAmount, String lineItemLineTotalAmountCurrencyID
            , String lineItemSpecifiedTradeProductGlobalID, String lineItemSpecifiedTradeProductSchemeID, String lineItemSpecifiedTradeProductSellerAssignedID
            , String lineItemSpecifiedTradeProductBuyerAssignedID, String lineItemSpecifiedTradeProductName, String
             lineItemSpecifiedTradeProductDescription) {
            this.lineItemLineID.Add(id);
            this.lineItemIncludedNote.Add(notes);
            this.lineItemGrossPriceChargeAmount.Add(grossPriceChargeAmount);
            this.lineItemGrossPriceChargeAmountCurrencyID.Add(grossPriceChargeAmountCurrencyID);
            this.lineItemGrossPriceBasisQuantity.Add(grossPriceBasisQuantity);
            this.lineItemGrossPriceBasisQuantityCode.Add(grossPriceBasisQuantityCode);
            this.lineItemGrossPriceTradeAllowanceChargeIndicator.Add(grossPriceTradeAllowanceChargeIndicator);
            this.lineItemGrossPriceTradeAllowanceChargeActualAmount.Add(grossPriceTradeAllowanceChargeActualAmount);
            this.lineItemGrossPriceTradeAllowanceChargeActualAmountCurrencyID.Add(grossPriceTradeAllowanceChargeActualAmountCurrencyID
                );
            this.lineItemGrossPriceTradeAllowanceChargeReason.Add(grossPriceTradeAllowanceChargeReason);
            this.lineItemNetPriceChargeAmount.Add(netPriceChargeAmount);
            this.lineItemNetPriceChargeAmountCurrencyID.Add(netPriceChargeAmountCurrencyID);
            this.lineItemNetPriceBasisQuantity.Add(netPriceBasisQuantity);
            this.lineItemNetPriceBasisQuantityCode.Add(netPriceBasisQuantityCode);
            this.lineItemBilledQuantity.Add(billedQuantity);
            this.lineItemBilledQuantityUnitCode.Add(billedQuantityUnitCode);
            this.lineItemSettlementTaxTypeCode.Add(lineItemSettlementTaxTypeCode);
            this.lineItemSettlementTaxExemptionReason.Add(lineItemSettlementTaxExemptionReason);
            this.lineItemSettlementTaxCategoryCode.Add(lineItemSettlementTaxCategoryCode);
            this.lineItemSettlementTaxApplicablePercent.Add(lineItemSettlementTaxApplicablePercent);
            this.lineItemLineTotalAmount.Add(lineItemLineTotalAmount);
            this.lineItemLineTotalAmountCurrencyID.Add(lineItemLineTotalAmountCurrencyID);
            this.lineItemSpecifiedTradeProductGlobalID.Add(lineItemSpecifiedTradeProductGlobalID);
            this.lineItemSpecifiedTradeProductSchemeID.Add(lineItemSpecifiedTradeProductSchemeID);
            this.lineItemSpecifiedTradeProductSellerAssignedID.Add(lineItemSpecifiedTradeProductSellerAssignedID);
            this.lineItemSpecifiedTradeProductBuyerAssignedID.Add(lineItemSpecifiedTradeProductBuyerAssignedID);
            this.lineItemSpecifiedTradeProductName.Add(lineItemSpecifiedTradeProductName);
            this.lineItemSpecifiedTradeProductDescription.Add(lineItemSpecifiedTradeProductDescription);
        }
    }
}
