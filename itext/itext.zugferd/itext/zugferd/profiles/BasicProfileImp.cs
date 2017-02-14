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
    /// conforms with the Basic profile.
    /// </summary>
    public class BasicProfileImp : IBasicProfile {
        protected internal bool test;

        protected internal String id;

        protected internal String name;

        protected internal String typeCode;

        protected internal DateTime date;

        protected internal String dateFormat;

        protected internal IList<String[]> notes = new List<String[]>();

        protected internal String sellerName;

        protected internal String sellerPostcode;

        protected internal String sellerLineOne;

        protected internal String sellerLineTwo;

        protected internal String sellerCityName;

        protected internal String sellerCountryID;

        protected internal IList<String> sellerTaxRegistrationID = new List<String>();

        protected internal IList<String> sellerTaxRegistrationSchemeID = new List<String>();

        protected internal String buyerName;

        protected internal String buyerPostcode;

        protected internal String buyerLineOne;

        protected internal String buyerLineTwo;

        protected internal String buyerCityName;

        protected internal String buyerCountryID;

        protected internal IList<String> buyerTaxRegistrationID = new List<String>();

        protected internal IList<String> buyerTaxRegistrationSchemeID = new List<String>();

        protected internal DateTime deliveryDate;

        protected internal String deliveryDateFormat;

        protected internal String paymentReference;

        protected internal String invoiceCurrencyCode;

        protected internal IList<String> paymentMeansID = new List<String>();

        protected internal IList<String> paymentMeansSchemeAgencyID = new List<String>();

        protected internal IList<String> paymentMeansPayeeAccountIBAN = new List<String>();

        protected internal IList<String> paymentMeansPayeeAccountName = new List<String>();

        protected internal IList<String> paymentMeansPayeeAccountProprietaryID = new List<String>();

        protected internal IList<String> paymentMeansPayeeFinancialInstitutionBIC = new List<String>();

        protected internal IList<String> paymentMeansPayeeFinancialInstitutionGermanBankleitzahlID = new List<String
            >();

        protected internal IList<String> paymentMeansPayeeFinancialInstitutionName = new List<String>();

        protected internal IList<String> taxCalculatedAmount = new List<String>();

        protected internal IList<String> taxCalculatedAmountCurrencyID = new List<String>();

        protected internal IList<String> taxTypeCode = new List<String>();

        protected internal IList<String> taxBasisAmount = new List<String>();

        protected internal IList<String> taxBasisAmountCurrencyID = new List<String>();

        protected internal IList<String> taxApplicablePercent = new List<String>();

        protected internal String lineTotalAmount;

        protected internal String lineTotalAmountCurrencyID;

        protected internal String chargeTotalAmount;

        protected internal String chargeTotalAmountCurrencyID;

        protected internal String allowanceTotalAmount;

        protected internal String allowanceTotalAmountCurrencyID;

        protected internal String taxBasisTotalAmount;

        protected internal String taxBasisTotalAmountCurrencyID;

        protected internal String taxTotalAmount;

        protected internal String taxTotalAmountCurrencyID;

        protected internal String grandTotalAmount;

        protected internal String grandTotalAmountCurrencyID;

        protected internal IList<String> lineItemBilledQuantity = new List<String>();

        protected internal IList<String> lineItemBilledQuantityUnitCode = new List<String>();

        protected internal IList<String> lineItemSpecifiedTradeProductName = new List<String>();

        /// <summary>
        /// Creates a new
        /// <see cref="BasicProfileImp"/>
        /// instance
        /// </summary>
        /// <param name="testIndicator">
        /// the parameter that determines whether a test invoice is going to be created.
        /// The test indicator can be used when implementing a newly developed system. It is to mark the
        /// invoice as a "test" and thus not leading to vat issues.
        /// </param>
        public BasicProfileImp(bool testIndicator) {
            // member-variables storing all the data
            this.test = testIndicator;
        }

        // implementation of the getters
        public virtual bool GetTestIndicator() {
            return test;
        }

        public virtual String GetId() {
            return id;
        }

        public virtual String GetName() {
            return name;
        }

        public virtual String GetTypeCode() {
            return typeCode;
        }

        public virtual DateTime GetDateTime() {
            return date;
        }

        public virtual String GetDateTimeFormat() {
            return dateFormat;
        }

        public virtual String[][] GetNotes() {
            return To2DArray(notes);
        }

        public virtual String GetSellerName() {
            return sellerName;
        }

        public virtual String GetSellerPostcode() {
            return sellerPostcode;
        }

        public virtual String GetSellerLineOne() {
            return sellerLineOne;
        }

        public virtual String GetSellerLineTwo() {
            return sellerLineTwo;
        }

        public virtual String GetSellerCityName() {
            return sellerCityName;
        }

        public virtual String GetSellerCountryID() {
            return sellerCountryID;
        }

        public virtual String[] GetSellerTaxRegistrationID() {
            return To1DArray(sellerTaxRegistrationID);
        }

        public virtual String[] GetSellerTaxRegistrationSchemeID() {
            return To1DArray(sellerTaxRegistrationSchemeID);
        }

        public virtual String GetBuyerName() {
            return buyerName;
        }

        public virtual String GetBuyerPostcode() {
            return buyerPostcode;
        }

        public virtual String GetBuyerLineOne() {
            return buyerLineOne;
        }

        public virtual String GetBuyerLineTwo() {
            return buyerLineTwo;
        }

        public virtual String GetBuyerCityName() {
            return buyerCityName;
        }

        public virtual String GetBuyerCountryID() {
            return buyerCountryID;
        }

        public virtual String[] GetBuyerTaxRegistrationID() {
            return To1DArray(buyerTaxRegistrationID);
        }

        public virtual String[] GetBuyerTaxRegistrationSchemeID() {
            return To1DArray(buyerTaxRegistrationSchemeID);
        }

        public virtual DateTime GetDeliveryDateTime() {
            return deliveryDate;
        }

        public virtual String GetDeliveryDateTimeFormat() {
            return deliveryDateFormat;
        }

        public virtual String GetPaymentReference() {
            return paymentReference;
        }

        public virtual String GetInvoiceCurrencyCode() {
            return invoiceCurrencyCode;
        }

        public virtual String[] GetPaymentMeansID() {
            return To1DArray(paymentMeansID);
        }

        public virtual String[] GetPaymentMeansSchemeAgencyID() {
            return To1DArray(paymentMeansSchemeAgencyID);
        }

        public virtual String[] GetPaymentMeansPayeeAccountIBAN() {
            return To1DArray(paymentMeansPayeeAccountIBAN);
        }

        public virtual String[] GetPaymentMeansPayeeAccountAccountName() {
            return To1DArray(paymentMeansPayeeAccountName);
        }

        public virtual String[] GetPaymentMeansPayeeAccountProprietaryID() {
            return To1DArray(paymentMeansPayeeAccountProprietaryID);
        }

        public virtual String[] GetPaymentMeansPayeeFinancialInstitutionBIC() {
            return To1DArray(paymentMeansPayeeFinancialInstitutionBIC);
        }

        public virtual String[] GetPaymentMeansPayeeFinancialInstitutionGermanBankleitzahlID() {
            return To1DArray(paymentMeansPayeeFinancialInstitutionGermanBankleitzahlID);
        }

        public virtual String[] GetPaymentMeansPayeeFinancialInstitutionName() {
            return To1DArray(paymentMeansPayeeFinancialInstitutionName);
        }

        public virtual String[] GetTaxCalculatedAmount() {
            return To1DArray(taxCalculatedAmount);
        }

        public virtual String[] GetTaxCalculatedAmountCurrencyID() {
            return To1DArray(taxCalculatedAmountCurrencyID);
        }

        public virtual String[] GetTaxTypeCode() {
            return To1DArray(taxTypeCode);
        }

        public virtual String[] GetTaxBasisAmount() {
            return To1DArray(taxBasisAmount);
        }

        public virtual String[] GetTaxBasisAmountCurrencyID() {
            return To1DArray(taxBasisAmountCurrencyID);
        }

        public virtual String[] GetTaxApplicablePercent() {
            return To1DArray(taxApplicablePercent);
        }

        public virtual String GetLineTotalAmount() {
            return lineTotalAmount;
        }

        public virtual String GetLineTotalAmountCurrencyID() {
            return lineTotalAmountCurrencyID;
        }

        public virtual String GetChargeTotalAmount() {
            return chargeTotalAmount;
        }

        public virtual String GetChargeTotalAmountCurrencyID() {
            return chargeTotalAmountCurrencyID;
        }

        public virtual String GetAllowanceTotalAmount() {
            return allowanceTotalAmount;
        }

        public virtual String GetAllowanceTotalAmountCurrencyID() {
            return allowanceTotalAmountCurrencyID;
        }

        public virtual String GetTaxBasisTotalAmount() {
            return taxBasisTotalAmount;
        }

        public virtual String GetTaxBasisTotalAmountCurrencyID() {
            return taxBasisTotalAmountCurrencyID;
        }

        public virtual String GetTaxTotalAmount() {
            return taxTotalAmount;
        }

        public virtual String GetTaxTotalAmountCurrencyID() {
            return taxTotalAmountCurrencyID;
        }

        public virtual String GetGrandTotalAmount() {
            return grandTotalAmount;
        }

        public virtual String GetGrandTotalAmountCurrencyID() {
            return grandTotalAmountCurrencyID;
        }

        public virtual String[] GetLineItemBilledQuantity() {
            return To1DArray(lineItemBilledQuantity);
        }

        public virtual String[] GetLineItemBilledQuantityUnitCode() {
            return To1DArray(lineItemBilledQuantityUnitCode);
        }

        public virtual String[] GetLineItemSpecifiedTradeProductName() {
            return To1DArray(lineItemSpecifiedTradeProductName);
        }

        // implementation of the setters
        public virtual void SetTest(bool test) {
            this.test = test;
        }

        public virtual void SetId(String id) {
            this.id = id;
        }

        public virtual void SetName(String name) {
            this.name = name;
        }

        public virtual void SetTypeCode(String typeCode) {
            this.typeCode = typeCode;
        }

        public virtual void SetDate(DateTime date, String dateFormat) {
            this.date = date;
            this.dateFormat = dateFormat;
        }

        public virtual void AddNote(String[] note) {
            notes.Add(note);
        }

        public virtual void SetSellerName(String sellerName) {
            this.sellerName = sellerName;
        }

        public virtual void SetSellerPostcode(String sellerPostcode) {
            this.sellerPostcode = sellerPostcode;
        }

        public virtual void SetSellerLineOne(String sellerLineOne) {
            this.sellerLineOne = sellerLineOne;
        }

        public virtual void SetSellerLineTwo(String sellerLineTwo) {
            this.sellerLineTwo = sellerLineTwo;
        }

        public virtual void SetSellerCityName(String sellerCityName) {
            this.sellerCityName = sellerCityName;
        }

        public virtual void SetSellerCountryID(String sellerCountryID) {
            this.sellerCountryID = sellerCountryID;
        }

        public virtual void AddSellerTaxRegistration(String schemeID, String taxId) {
            sellerTaxRegistrationSchemeID.Add(schemeID);
            sellerTaxRegistrationID.Add(taxId);
        }

        public virtual void SetBuyerName(String buyerName) {
            this.buyerName = buyerName;
        }

        public virtual void SetBuyerPostcode(String buyerPostcode) {
            this.buyerPostcode = buyerPostcode;
        }

        public virtual void SetBuyerLineOne(String buyerLineOne) {
            this.buyerLineOne = buyerLineOne;
        }

        public virtual void SetBuyerLineTwo(String buyerLineTwo) {
            this.buyerLineTwo = buyerLineTwo;
        }

        public virtual void SetBuyerCityName(String buyerCityName) {
            this.buyerCityName = buyerCityName;
        }

        public virtual void SetBuyerCountryID(String buyerCountryID) {
            this.buyerCountryID = buyerCountryID;
        }

        public virtual void AddBuyerTaxRegistration(String schemeID, String taxId) {
            buyerTaxRegistrationSchemeID.Add(schemeID);
            buyerTaxRegistrationID.Add(taxId);
        }

        public virtual void SetDeliveryDate(DateTime deliveryDate, String deliveryDateFormat) {
            this.deliveryDate = deliveryDate;
            this.deliveryDateFormat = deliveryDateFormat;
        }

        public virtual void SetPaymentReference(String paymentReference) {
            this.paymentReference = paymentReference;
        }

        public virtual void SetInvoiceCurrencyCode(String invoiceCurrencyCode) {
            this.invoiceCurrencyCode = invoiceCurrencyCode;
        }

        public virtual void AddPaymentMeans(String schemeAgencyID, String id, String iban, String accountname, String
             proprietaryID, String bic, String germanBankleitzahlID, String institutionname) {
            paymentMeansID.Add(id);
            paymentMeansSchemeAgencyID.Add(schemeAgencyID);
            paymentMeansPayeeAccountIBAN.Add(iban);
            paymentMeansPayeeAccountName.Add(accountname);
            paymentMeansPayeeAccountProprietaryID.Add(proprietaryID);
            paymentMeansPayeeFinancialInstitutionBIC.Add(bic);
            paymentMeansPayeeFinancialInstitutionGermanBankleitzahlID.Add(germanBankleitzahlID);
            paymentMeansPayeeFinancialInstitutionName.Add(institutionname);
        }

        public virtual void AddApplicableTradeTax(String calculatedAmount, String calculatedAmountCurrencyID, String
             typeCode, String basisAmount, String basisAmountCurrencyID, String applicablePercent) {
            taxCalculatedAmount.Add(calculatedAmount);
            taxCalculatedAmountCurrencyID.Add(calculatedAmountCurrencyID);
            taxTypeCode.Add(typeCode);
            taxBasisAmount.Add(basisAmount);
            taxBasisAmountCurrencyID.Add(basisAmountCurrencyID);
            taxApplicablePercent.Add(applicablePercent);
        }

        public virtual void SetMonetarySummation(String lineTotalAmount, String lineTotalAmountCurrencyID, String 
            chargeTotalAmount, String chargeTotalAmountCurrencyID, String allowanceTotalAmount, String allowanceTotalAmountCurrencyID
            , String taxBasisTotalAmount, String taxBasisTotalAmountCurrencyID, String taxTotalAmount, String taxTotalAmountCurrencyID
            , String grandTotalAmount, String grandTotalAmountCurrencyID) {
            this.lineTotalAmount = lineTotalAmount;
            this.lineTotalAmountCurrencyID = lineTotalAmountCurrencyID;
            this.chargeTotalAmount = chargeTotalAmount;
            this.chargeTotalAmountCurrencyID = chargeTotalAmountCurrencyID;
            this.allowanceTotalAmount = allowanceTotalAmount;
            this.allowanceTotalAmountCurrencyID = allowanceTotalAmountCurrencyID;
            this.taxBasisTotalAmount = taxBasisTotalAmount;
            this.taxBasisTotalAmountCurrencyID = taxBasisTotalAmountCurrencyID;
            this.taxTotalAmount = taxTotalAmount;
            this.taxTotalAmountCurrencyID = taxTotalAmountCurrencyID;
            this.grandTotalAmount = grandTotalAmount;
            this.grandTotalAmountCurrencyID = grandTotalAmountCurrencyID;
        }

        public virtual void AddIncludedSupplyChainTradeLineItem(String billedQuantity, String billedQuantityUnitCode
            , String specifiedTradeProductName) {
            this.lineItemBilledQuantity.Add(billedQuantity);
            this.lineItemBilledQuantityUnitCode.Add(billedQuantityUnitCode);
            this.lineItemSpecifiedTradeProductName.Add(specifiedTradeProductName);
        }

        // helper methods
        protected internal virtual String[] To1DArray(IList<String> list) {
            return (String[])list.ToArray(new String[list.Count]);
        }

        protected internal virtual bool[] To1DArrayB(IList<bool> list) {
            bool[] b = new bool[list.Count];
            for (int i = 0; i < list.Count; i++) {
                b[i] = list[i];
            }
            return b;
        }

        protected internal virtual String[][] To2DArray(IList<String[]> list) {
            int n = list.Count;
            String[][] array = new String[n][];
            for (int i = 0; i < n; i++) {
                array[i] = list[i];
            }
            return array;
        }

        protected internal virtual bool[][] To2DArrayB(IList<bool[]> list) {
            int n = list.Count;
            bool[][] array = new bool[n][];
            for (int i = 0; i < n; i++) {
                array[i] = list[i];
            }
            return array;
        }

        protected internal virtual String[][][] To3DArray(IList<String[][]> list) {
            int n = list.Count;
            String[][][] array = new String[n][][];
            for (int i = 0; i < n; i++) {
                array[i] = list[i];
            }
            return array;
        }
    }
}
