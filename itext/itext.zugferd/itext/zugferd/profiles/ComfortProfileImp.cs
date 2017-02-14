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
using System.Collections.Generic;

namespace iText.Zugferd.Profiles {
    /// <summary>
    /// This implementation of the BasicProfile contains member-variables that store
    /// all the data needed to create an XML attachment for a ZUGFeRD invoice that
    /// conforms with the Comfort profile.
    /// </summary>
    public class ComfortProfileImp : BasicProfileImp, IComfortProfile {
        protected internal IList<String> notesCodes = new List<String>();

        protected internal String buyerReference;

        protected internal String sellerID;

        protected internal IList<String> sellerGlobalID = new List<String>();

        protected internal IList<String> sellerGlobalSchemeID = new List<String>();

        protected internal String buyerID;

        protected internal IList<String> buyerGlobalID = new List<String>();

        protected internal IList<String> buyerGlobalSchemeID = new List<String>();

        protected internal DateTime buyerOrderReferencedDocumentIssueDateTime;

        protected internal String buyerOrderReferencedDocumentIssueDateTimeFormat;

        protected internal String buyerOrderReferencedDocumentID;

        protected internal DateTime contractReferencedDocumentIssueDateTime;

        protected internal String contractReferencedDocumentIssueDateTimeFormat;

        protected internal String contractReferencedDocumentID;

        protected internal DateTime customerOrderReferencedDocumentIssueDateTime;

        protected internal String customerOrderReferencedDocumentIssueDateTimeFormat;

        protected internal String customerOrderReferencedDocumentID;

        protected internal DateTime deliveryNoteReferencedDocumentIssueDateTime;

        protected internal String deliveryNoteReferencedDocumentIssueDateTimeFormat;

        protected internal String deliveryNoteReferencedDocumentID;

        protected internal String invoiceeID;

        protected internal IList<String> invoiceeGlobalID = new List<String>();

        protected internal IList<String> invoiceeGlobalSchemeID = new List<String>();

        protected internal String invoiceeName;

        protected internal String invoiceePostcode;

        protected internal String invoiceeLineOne;

        protected internal String invoiceeLineTwo;

        protected internal String invoiceeCityName;

        protected internal String invoiceeCountryID;

        protected internal IList<String> invoiceeTaxRegistrationID = new List<String>();

        protected internal IList<String> invoiceeTaxRegistrationSchemeID = new List<String>();

        protected internal IList<String> paymentMeansTypeCode = new List<String>();

        protected internal IList<String[]> paymentMeansInformation = new List<String[]>();

        protected internal IList<String> paymentMeansPayerAccountIBAN = new List<String>();

        protected internal IList<String> paymentMeansPayerAccountProprietaryID = new List<String>();

        protected internal IList<String> paymentMeansPayerFinancialInstitutionBIC = new List<String>();

        protected internal IList<String> paymentMeansPayerFinancialInstitutionGermanBankleitzahlID = new List<String
            >();

        protected internal IList<String> paymentMeansPayerFinancialInstitutionName = new List<String>();

        protected internal IList<String> taxExemptionReason = new List<String>();

        protected internal IList<String> taxCategoryCode = new List<String>();

        protected internal DateTime billingStartDateTime;

        protected internal String billingStartDateTimeFormat;

        protected internal DateTime billingEndDateTime;

        protected internal String billingEndDateTimeFormat;

        protected internal IList<bool> tradeAllowanceChargeIndicator = new List<bool>();

        protected internal IList<String> tradeAllowanceChargeActualAmount = new List<String>();

        protected internal IList<String> tradeAllowanceChargeActualAmountCurrency = new List<String>();

        protected internal IList<String> tradeAllowanceChargeReason = new List<String>();

        protected internal IList<String[]> tradeAllowanceChargeTaxTypeCode = new List<String[]>();

        protected internal IList<String[]> tradeAllowanceChargeTaxCategoryCode = new List<String[]>();

        protected internal IList<String[]> tradeAllowanceChargeTaxApplicablePercent = new List<String[]>();

        protected internal IList<String[]> logisticsServiceChargeDescription = new List<String[]>();

        protected internal IList<String> logisticsServiceChargeAmount = new List<String>();

        protected internal IList<String> logisticsServiceChargeAmountCurrency = new List<String>();

        protected internal IList<String[]> logisticsServiceChargeTaxTypeCode = new List<String[]>();

        protected internal IList<String[]> logisticsServiceChargeTaxCategoryCode = new List<String[]>();

        protected internal IList<String[]> logisticsServiceChargeTaxApplicablePercent = new List<String[]>();

        protected internal IList<String[]> tradePaymentTermsInformation = new List<String[]>();

        protected internal IList<DateTime> tradePaymentTermsDueDateTime = new List<DateTime>();

        protected internal IList<String> tradePaymentTermsDueDateTimeFormat = new List<String>();

        protected internal String totalPrepaidAmount;

        protected internal String totalPrepaidAmountCurrencyID;

        protected internal String duePayableAmount;

        protected internal String duePayableAmountCurrencyID;

        protected internal IList<String> lineItemLineID = new List<String>();

        protected internal IList<String[][]> lineItemIncludedNote = new List<String[][]>();

        protected internal IList<String> lineItemGrossPriceChargeAmount = new List<String>();

        protected internal IList<String> lineItemGrossPriceChargeAmountCurrencyID = new List<String>();

        protected internal IList<String> lineItemGrossPriceBasisQuantity = new List<String>();

        protected internal IList<String> lineItemGrossPriceBasisQuantityCode = new List<String>();

        protected internal IList<bool[]> lineItemGrossPriceTradeAllowanceChargeIndicator = new List<bool[]>();

        protected internal IList<String[]> lineItemGrossPriceTradeAllowanceChargeActualAmount = new List<String[]>
            ();

        protected internal IList<String[]> lineItemGrossPriceTradeAllowanceChargeActualAmountCurrencyID = new List
            <String[]>();

        protected internal IList<String[]> lineItemGrossPriceTradeAllowanceChargeReason = new List<String[]>();

        protected internal IList<String> lineItemNetPriceChargeAmount = new List<String>();

        protected internal IList<String> lineItemNetPriceChargeAmountCurrencyID = new List<String>();

        protected internal IList<String> lineItemNetPriceBasisQuantity = new List<String>();

        protected internal IList<String> lineItemNetPriceBasisQuantityCode = new List<String>();

        protected internal IList<String[]> lineItemSettlementTaxTypeCode = new List<String[]>();

        protected internal IList<String[]> lineItemSettlementTaxExemptionReason = new List<String[]>();

        protected internal IList<String[]> lineItemSettlementTaxCategoryCode = new List<String[]>();

        protected internal IList<String[]> lineItemSettlementTaxApplicablePercent = new List<String[]>();

        protected internal IList<String> lineItemLineTotalAmount = new List<String>();

        protected internal IList<String> lineItemLineTotalAmountCurrencyID = new List<String>();

        protected internal IList<String> lineItemSpecifiedTradeProductGlobalID = new List<String>();

        protected internal IList<String> lineItemSpecifiedTradeProductSchemeID = new List<String>();

        protected internal IList<String> lineItemSpecifiedTradeProductSellerAssignedID = new List<String>();

        protected internal IList<String> lineItemSpecifiedTradeProductBuyerAssignedID = new List<String>();

        protected internal IList<String> lineItemSpecifiedTradeProductDescription = new List<String>();

        /// <summary>
        /// Creates a new
        /// <see cref="ComfortProfileImp"/>
        /// instance
        /// </summary>
        /// <param name="testIndicator">
        /// the parameter that determines whether a test invoice is going to be created.
        /// The test indicator can be used when implementing a newly developed system. It is to mark the
        /// invoice as a "test" and thus not leading to vat issues.
        /// </param>
        public ComfortProfileImp(bool testIndicator)
            : base(testIndicator) {
        }

        public virtual String[] GetNotesCodes() {
            return To1DArray(notesCodes);
        }

        public virtual String GetBuyerReference() {
            return buyerReference;
        }

        public virtual String GetSellerID() {
            return sellerID;
        }

        public virtual String[] GetSellerGlobalID() {
            return To1DArray(sellerGlobalID);
        }

        public virtual String[] GetSellerGlobalSchemeID() {
            return To1DArray(sellerGlobalSchemeID);
        }

        public virtual String GetBuyerID() {
            return buyerID;
        }

        public virtual String[] GetBuyerGlobalID() {
            return To1DArray(buyerGlobalID);
        }

        public virtual String[] GetBuyerGlobalSchemeID() {
            return To1DArray(buyerGlobalSchemeID);
        }

        public virtual DateTime GetBuyerOrderReferencedDocumentIssueDateTime() {
            return buyerOrderReferencedDocumentIssueDateTime;
        }

        public virtual String GetBuyerOrderReferencedDocumentIssueDateTimeFormat() {
            return buyerOrderReferencedDocumentIssueDateTimeFormat;
        }

        public virtual String GetBuyerOrderReferencedDocumentID() {
            return buyerOrderReferencedDocumentID;
        }

        public virtual DateTime GetContractReferencedDocumentIssueDateTime() {
            return contractReferencedDocumentIssueDateTime;
        }

        public virtual String GetContractReferencedDocumentIssueDateTimeFormat() {
            return contractReferencedDocumentIssueDateTimeFormat;
        }

        public virtual String GetContractReferencedDocumentID() {
            return contractReferencedDocumentID;
        }

        public virtual DateTime GetCustomerOrderReferencedDocumentIssueDateTime() {
            return customerOrderReferencedDocumentIssueDateTime;
        }

        public virtual String GetCustomerOrderReferencedDocumentIssueDateTimeFormat() {
            return customerOrderReferencedDocumentIssueDateTimeFormat;
        }

        public virtual String GetCustomerOrderReferencedDocumentID() {
            return customerOrderReferencedDocumentID;
        }

        public virtual DateTime GetDeliveryNoteReferencedDocumentIssueDateTime() {
            return deliveryNoteReferencedDocumentIssueDateTime;
        }

        public virtual String GetDeliveryNoteReferencedDocumentIssueDateTimeFormat() {
            return deliveryNoteReferencedDocumentIssueDateTimeFormat;
        }

        public virtual String GetDeliveryNoteReferencedDocumentID() {
            return deliveryNoteReferencedDocumentID;
        }

        public virtual String GetInvoiceeID() {
            return invoiceeID;
        }

        public virtual String[] GetInvoiceeGlobalID() {
            return To1DArray(invoiceeGlobalID);
        }

        public virtual String[] GetInvoiceeGlobalSchemeID() {
            return To1DArray(invoiceeGlobalSchemeID);
        }

        public virtual String GetInvoiceeName() {
            return invoiceeName;
        }

        public virtual String GetInvoiceePostcode() {
            return invoiceePostcode;
        }

        public virtual String GetInvoiceeLineOne() {
            return invoiceeLineOne;
        }

        public virtual String GetInvoiceeLineTwo() {
            return invoiceeLineTwo;
        }

        public virtual String GetInvoiceeCityName() {
            return invoiceeCityName;
        }

        public virtual String GetInvoiceeCountryID() {
            return invoiceeCountryID;
        }

        public virtual String[] GetInvoiceeTaxRegistrationID() {
            return To1DArray(invoiceeTaxRegistrationID);
        }

        public virtual String[] GetInvoiceeTaxRegistrationSchemeID() {
            return To1DArray(invoiceeTaxRegistrationSchemeID);
        }

        public virtual String[] GetPaymentMeansTypeCode() {
            return To1DArray(paymentMeansTypeCode);
        }

        public virtual String[][] GetPaymentMeansInformation() {
            return To2DArray(paymentMeansInformation);
        }

        public virtual String[] GetPaymentMeansPayerAccountIBAN() {
            return To1DArray(paymentMeansPayerAccountIBAN);
        }

        public virtual String[] GetPaymentMeansPayerAccountProprietaryID() {
            return To1DArray(paymentMeansPayerAccountProprietaryID);
        }

        public virtual String[] GetPaymentMeansPayerFinancialInstitutionBIC() {
            return To1DArray(paymentMeansPayerFinancialInstitutionBIC);
        }

        public virtual String[] GetPaymentMeansPayerFinancialInstitutionGermanBankleitzahlID() {
            return To1DArray(paymentMeansPayerFinancialInstitutionGermanBankleitzahlID);
        }

        public virtual String[] GetPaymentMeansPayerFinancialInstitutionName() {
            return To1DArray(paymentMeansPayerFinancialInstitutionName);
        }

        public virtual String[] GetTaxExemptionReason() {
            return To1DArray(taxExemptionReason);
        }

        public virtual String[] GetTaxCategoryCode() {
            return To1DArray(taxCategoryCode);
        }

        public virtual DateTime GetBillingStartDateTime() {
            return billingStartDateTime;
        }

        public virtual String GetBillingStartDateTimeFormat() {
            return billingStartDateTimeFormat;
        }

        public virtual DateTime GetBillingEndDateTime() {
            return billingEndDateTime;
        }

        public virtual String GetBillingEndDateTimeFormat() {
            return billingEndDateTimeFormat;
        }

        public virtual bool[] GetSpecifiedTradeAllowanceChargeIndicator() {
            return To1DArrayB(tradeAllowanceChargeIndicator);
        }

        public virtual String[] GetSpecifiedTradeAllowanceChargeActualAmount() {
            return To1DArray(tradeAllowanceChargeActualAmount);
        }

        public virtual String[] GetSpecifiedTradeAllowanceChargeActualAmountCurrency() {
            return To1DArray(tradeAllowanceChargeActualAmountCurrency);
        }

        public virtual String[] GetSpecifiedTradeAllowanceChargeReason() {
            return To1DArray(tradeAllowanceChargeReason);
        }

        public virtual String[][] GetSpecifiedTradeAllowanceChargeTaxTypeCode() {
            return To2DArray(tradeAllowanceChargeTaxTypeCode);
        }

        public virtual String[][] GetSpecifiedTradeAllowanceChargeTaxCategoryCode() {
            return To2DArray(tradeAllowanceChargeTaxCategoryCode);
        }

        public virtual String[][] GetSpecifiedTradeAllowanceChargeTaxApplicablePercent() {
            return To2DArray(tradeAllowanceChargeTaxApplicablePercent);
        }

        public virtual String[][] GetSpecifiedLogisticsServiceChargeDescription() {
            return To2DArray(logisticsServiceChargeDescription);
        }

        public virtual String[] GetSpecifiedLogisticsServiceChargeAmount() {
            return To1DArray(logisticsServiceChargeAmount);
        }

        public virtual String[] GetSpecifiedLogisticsServiceChargeAmountCurrency() {
            return To1DArray(logisticsServiceChargeAmountCurrency);
        }

        public virtual String[][] GetSpecifiedLogisticsServiceChargeTaxTypeCode() {
            return To2DArray(logisticsServiceChargeTaxTypeCode);
        }

        public virtual String[][] GetSpecifiedLogisticsServiceChargeTaxCategoryCode() {
            return To2DArray(logisticsServiceChargeTaxCategoryCode);
        }

        public virtual String[][] GetSpecifiedLogisticsServiceChargeTaxApplicablePercent() {
            return To2DArray(logisticsServiceChargeTaxApplicablePercent);
        }

        public virtual String[][] GetSpecifiedTradePaymentTermsDescription() {
            return To2DArray(tradePaymentTermsInformation);
        }

        public virtual DateTime[] GetSpecifiedTradePaymentTermsDueDateTime() {
            return (DateTime[])tradePaymentTermsDueDateTime.ToArray(new DateTime[tradePaymentTermsDueDateTime.Count]);
        }

        public virtual String[] GetSpecifiedTradePaymentTermsDueDateTimeFormat() {
            return To1DArray(tradePaymentTermsDueDateTimeFormat);
        }

        public virtual String GetTotalPrepaidAmount() {
            return totalPrepaidAmount;
        }

        public virtual String GetTotalPrepaidAmountCurrencyID() {
            return totalPrepaidAmountCurrencyID;
        }

        public virtual String GetDuePayableAmount() {
            return duePayableAmount;
        }

        public virtual String GetDuePayableAmountCurrencyID() {
            return duePayableAmountCurrencyID;
        }

        public virtual String[] GetLineItemLineID() {
            return To1DArray(lineItemLineID);
        }

        public virtual String[][][] GetLineItemIncludedNote() {
            return To3DArray(lineItemIncludedNote);
        }

        public virtual String[] GetLineItemGrossPriceChargeAmount() {
            return To1DArray(lineItemGrossPriceChargeAmount);
        }

        public virtual String[] GetLineItemGrossPriceChargeAmountCurrencyID() {
            return To1DArray(lineItemGrossPriceChargeAmountCurrencyID);
        }

        public virtual String[] GetLineItemGrossPriceBasisQuantity() {
            return To1DArray(lineItemGrossPriceBasisQuantity);
        }

        public virtual String[] GetLineItemGrossPriceBasisQuantityCode() {
            return To1DArray(lineItemGrossPriceBasisQuantityCode);
        }

        public virtual bool[][] GetLineItemGrossPriceTradeAllowanceChargeIndicator() {
            return To2DArrayB(lineItemGrossPriceTradeAllowanceChargeIndicator);
        }

        public virtual String[][] GetLineItemGrossPriceTradeAllowanceChargeActualAmount() {
            return To2DArray(lineItemGrossPriceTradeAllowanceChargeActualAmount);
        }

        public virtual String[][] GetLineItemGrossPriceTradeAllowanceChargeActualAmountCurrencyID() {
            return To2DArray(lineItemGrossPriceTradeAllowanceChargeActualAmountCurrencyID);
        }

        public virtual String[][] GetLineItemGrossPriceTradeAllowanceChargeReason() {
            return To2DArray(lineItemGrossPriceTradeAllowanceChargeReason);
        }

        public virtual String[] GetLineItemNetPriceChargeAmount() {
            return To1DArray(lineItemNetPriceChargeAmount);
        }

        public virtual String[] GetLineItemNetPriceChargeAmountCurrencyID() {
            return To1DArray(lineItemNetPriceChargeAmountCurrencyID);
        }

        public virtual String[] GetLineItemNetPriceBasisQuantity() {
            return To1DArray(lineItemNetPriceBasisQuantity);
        }

        public virtual String[] GetLineItemNetPriceBasisQuantityCode() {
            return To1DArray(lineItemNetPriceBasisQuantityCode);
        }

        public virtual String[][] GetLineItemSettlementTaxTypeCode() {
            return To2DArray(lineItemSettlementTaxTypeCode);
        }

        public virtual String[][] GetLineItemSettlementTaxExemptionReason() {
            return To2DArray(lineItemSettlementTaxExemptionReason);
        }

        public virtual String[][] GetLineItemSettlementTaxCategoryCode() {
            return To2DArray(lineItemSettlementTaxCategoryCode);
        }

        public virtual String[][] GetLineItemSettlementTaxApplicablePercent() {
            return To2DArray(lineItemSettlementTaxApplicablePercent);
        }

        public virtual String[] GetLineItemLineTotalAmount() {
            return To1DArray(lineItemLineTotalAmount);
        }

        public virtual String[] GetLineItemLineTotalAmountCurrencyID() {
            return To1DArray(lineItemLineTotalAmountCurrencyID);
        }

        public virtual String[] GetLineItemSpecifiedTradeProductGlobalID() {
            return To1DArray(lineItemSpecifiedTradeProductGlobalID);
        }

        public virtual String[] GetLineItemSpecifiedTradeProductSchemeID() {
            return To1DArray(lineItemSpecifiedTradeProductSchemeID);
        }

        public virtual String[] GetLineItemSpecifiedTradeProductSellerAssignedID() {
            return To1DArray(lineItemSpecifiedTradeProductSellerAssignedID);
        }

        public virtual String[] GetLineItemSpecifiedTradeProductBuyerAssignedID() {
            return To1DArray(lineItemSpecifiedTradeProductBuyerAssignedID);
        }

        public virtual String[] GetLineItemSpecifiedTradeProductDescription() {
            return To1DArray(lineItemSpecifiedTradeProductDescription);
        }

        public override void AddNote(String[] note) {
            throw new NotSupportedException("This method can only be used for the BASIC level.");
        }

        public virtual void AddNote(String[] note, String code) {
            notes.Add(note);
            notesCodes.Add(code);
        }

        public virtual void SetBuyerReference(String buyerReference) {
            this.buyerReference = buyerReference;
        }

        public virtual void SetSellerID(String sellerID) {
            this.sellerID = sellerID;
        }

        public virtual void AddSellerGlobalID(String sellerGlobalSchemeID, String sellerGlobalID) {
            this.sellerGlobalID.Add(sellerGlobalID);
            this.sellerGlobalSchemeID.Add(sellerGlobalSchemeID);
        }

        public virtual void SetBuyerID(String buyerID) {
            this.buyerID = buyerID;
        }

        public virtual void AddBuyerGlobalID(String buyerGlobalSchemeID, String buyerGlobalID) {
            this.buyerGlobalID.Add(buyerGlobalID);
            this.buyerGlobalSchemeID.Add(buyerGlobalSchemeID);
        }

        public virtual void SetBuyerOrderReferencedDocumentIssueDateTime(DateTime buyerOrderReferencedDocumentIssueDateTime
            , String buyerOrderReferencedDocumentIssueDateTimeFormat) {
            this.buyerOrderReferencedDocumentIssueDateTime = buyerOrderReferencedDocumentIssueDateTime;
            this.buyerOrderReferencedDocumentIssueDateTimeFormat = buyerOrderReferencedDocumentIssueDateTimeFormat;
        }

        public virtual void SetBuyerOrderReferencedDocumentID(String buyerOrderReferencedDocumentID) {
            this.buyerOrderReferencedDocumentID = buyerOrderReferencedDocumentID;
        }

        public virtual void SetContractReferencedDocumentIssueDateTime(DateTime contractReferencedDocumentIssueDateTime
            , String contractReferencedDocumentIssueDateTimeFormat) {
            this.contractReferencedDocumentIssueDateTime = contractReferencedDocumentIssueDateTime;
            this.contractReferencedDocumentIssueDateTimeFormat = contractReferencedDocumentIssueDateTimeFormat;
        }

        public virtual void SetContractReferencedDocumentID(String contractReferencedDocumentID) {
            this.contractReferencedDocumentID = contractReferencedDocumentID;
        }

        public virtual void SetCustomerOrderReferencedDocumentIssueDateTime(DateTime customerOrderReferencedDocumentIssueDateTime
            , String customerOrderReferencedDocumentIssueDateTimeFormat) {
            this.customerOrderReferencedDocumentIssueDateTime = customerOrderReferencedDocumentIssueDateTime;
            this.customerOrderReferencedDocumentIssueDateTimeFormat = customerOrderReferencedDocumentIssueDateTimeFormat;
        }

        public virtual void SetCustomerOrderReferencedDocumentID(String customerOrderReferencedDocumentID) {
            this.customerOrderReferencedDocumentID = customerOrderReferencedDocumentID;
        }

        public virtual void SetDeliveryNoteReferencedDocumentIssueDateTime(DateTime deliveryNoteReferencedDocumentIssueDateTime
            , String deliveryNoteReferencedDocumentIssueDateTimeFormat) {
            this.deliveryNoteReferencedDocumentIssueDateTime = deliveryNoteReferencedDocumentIssueDateTime;
            this.deliveryNoteReferencedDocumentIssueDateTimeFormat = deliveryNoteReferencedDocumentIssueDateTimeFormat;
        }

        public virtual void SetDeliveryNoteReferencedDocumentID(String deliveryNoteReferencedDocumentID) {
            this.deliveryNoteReferencedDocumentID = deliveryNoteReferencedDocumentID;
        }

        public virtual void SetInvoiceeID(String invoiceeID) {
            this.invoiceeID = invoiceeID;
        }

        public virtual void AddInvoiceeGlobalID(String invoiceeGlobalSchemeID, String invoiceeGlobalID) {
            this.invoiceeGlobalSchemeID.Add(invoiceeGlobalSchemeID);
            this.invoiceeGlobalID.Add(invoiceeGlobalID);
        }

        public virtual void SetInvoiceeName(String invoiceeName) {
            this.invoiceeName = invoiceeName;
        }

        public virtual void SetInvoiceePostcode(String invoiceePostcode) {
            this.invoiceePostcode = invoiceePostcode;
        }

        public virtual void SetInvoiceeLineOne(String invoiceeLineOne) {
            this.invoiceeLineOne = invoiceeLineOne;
        }

        public virtual void SetInvoiceeLineTwo(String invoiceeLineTwo) {
            this.invoiceeLineTwo = invoiceeLineTwo;
        }

        public virtual void SetInvoiceeCityName(String invoiceeCityName) {
            this.invoiceeCityName = invoiceeCityName;
        }

        public virtual void SetInvoiceeCountryID(String invoiceeCountryID) {
            this.invoiceeCountryID = invoiceeCountryID;
        }

        public virtual void AddInvoiceeTaxRegistration(String schemeID, String taxId) {
            invoiceeTaxRegistrationSchemeID.Add(schemeID);
            invoiceeTaxRegistrationID.Add(taxId);
        }

        public override void AddPaymentMeans(String schemeAgencyID, String id, String iban, String accountname, String
             proprietaryID, String bic, String germanBankleitzahlID, String institutionname) {
            throw new NotSupportedException("This method can only be used for the BASIC level.");
        }

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

        public override void AddApplicableTradeTax(String calculatedAmount, String calculatedAmountCurrencyID, String
             typeCode, String basisAmount, String basisAmountCurrencyID, String applicablePercent) {
            throw new NotSupportedException("This method can only be used for the BASIC level.");
        }

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

        public virtual void SetBillingStartEnd(DateTime billingStartDateTime, String billingStartDateTimeFormat, DateTime
             billingEndDateTime, String billingEndDateTimeFormat) {
            this.billingStartDateTime = billingStartDateTime;
            this.billingStartDateTimeFormat = billingStartDateTimeFormat;
            this.billingEndDateTime = billingEndDateTime;
            this.billingEndDateTimeFormat = billingEndDateTimeFormat;
        }

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

        public virtual void AddSpecifiedLogisticsServiceCharge(String[] description, String actualAmount, String actualAmountCurrency
            , String[] typeCodes, String[] categoryCodes, String[] applicablePercent) {
            this.logisticsServiceChargeDescription.Add(description);
            this.logisticsServiceChargeAmount.Add(actualAmount);
            this.logisticsServiceChargeAmountCurrency.Add(actualAmountCurrency);
            this.logisticsServiceChargeTaxTypeCode.Add(typeCodes);
            this.logisticsServiceChargeTaxCategoryCode.Add(categoryCodes);
            this.logisticsServiceChargeTaxApplicablePercent.Add(applicablePercent);
        }

        public virtual void AddSpecifiedTradePaymentTerms(String[] information, DateTime dateTime, String dateTimeFormat
            ) {
            this.tradePaymentTermsInformation.Add(information);
            this.tradePaymentTermsDueDateTime.Add(dateTime);
            this.tradePaymentTermsDueDateTimeFormat.Add(dateTimeFormat);
        }

        public virtual void SetTotalPrepaidAmount(String totalPrepaidAmount, String totalPrepaidCurrencyID) {
            this.totalPrepaidAmount = totalPrepaidAmount;
            this.totalPrepaidAmountCurrencyID = totalPrepaidCurrencyID;
        }

        public virtual void SetDuePayableAmount(String duePayableAmount, String duePayableAmountCurrencyID) {
            this.duePayableAmount = duePayableAmount;
            this.duePayableAmountCurrencyID = duePayableAmountCurrencyID;
        }

        public override void AddIncludedSupplyChainTradeLineItem(String billedQuantity, String billedQuantityUnitCode
            , String specifiedTradeProductName) {
            throw new NotSupportedException("This method can only be used for the BASIC level.");
        }

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
