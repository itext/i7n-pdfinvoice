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
    /// conforms with the Basic profile.
    /// </summary>
    public class BasicProfileImp : IBasicProfile {
        /// <summary>The test.</summary>
        protected internal bool test;

        /// <summary>The id.</summary>
        protected internal String id;

        /// <summary>The name.</summary>
        protected internal String name;

        /// <summary>The type code.</summary>
        protected internal String typeCode;

        /// <summary>The date.</summary>
        protected internal DateTime date;

        /// <summary>The date format.</summary>
        protected internal String dateFormat;

        /// <summary>The notes.</summary>
        protected internal IList<String[]> notes = new List<String[]>();

        /// <summary>The seller name.</summary>
        protected internal String sellerName;

        /// <summary>The seller post code.</summary>
        protected internal String sellerPostcode;

        /// <summary>The seller line one.</summary>
        protected internal String sellerLineOne;

        /// <summary>The seller line two.</summary>
        protected internal String sellerLineTwo;

        /// <summary>The seller city name.</summary>
        protected internal String sellerCityName;

        /// <summary>The seller country ID.</summary>
        protected internal String sellerCountryID;

        /// <summary>The seller tax registration ID.</summary>
        protected internal IList<String> sellerTaxRegistrationID = new List<String>();

        /// <summary>The seller tax registration scheme ID.</summary>
        protected internal IList<String> sellerTaxRegistrationSchemeID = new List<String>();

        /// <summary>The buyer name.</summary>
        protected internal String buyerName;

        /// <summary>The buyer postcode.</summary>
        protected internal String buyerPostcode;

        /// <summary>The buyer line one.</summary>
        protected internal String buyerLineOne;

        /// <summary>The buyer line two.</summary>
        protected internal String buyerLineTwo;

        /// <summary>The buyer city name.</summary>
        protected internal String buyerCityName;

        /// <summary>The buyer country ID.</summary>
        protected internal String buyerCountryID;

        /// <summary>The buyer tax registration ID.</summary>
        protected internal IList<String> buyerTaxRegistrationID = new List<String>();

        /// <summary>The buyer tax registration scheme ID.</summary>
        protected internal IList<String> buyerTaxRegistrationSchemeID = new List<String>();

        /// <summary>The delivery date.</summary>
        protected internal DateTime deliveryDate;

        /// <summary>The delivery date format.</summary>
        protected internal String deliveryDateFormat;

        /// <summary>The payment reference.</summary>
        protected internal String paymentReference;

        /// <summary>The invoice currency code.</summary>
        protected internal String invoiceCurrencyCode;

        /// <summary>The payment means ID.</summary>
        protected internal IList<String> paymentMeansID = new List<String>();

        /// <summary>The payment means scheme agency ID.</summary>
        protected internal IList<String> paymentMeansSchemeAgencyID = new List<String>();

        /// <summary>The payment means payee account IBAN.</summary>
        protected internal IList<String> paymentMeansPayeeAccountIBAN = new List<String>();

        /// <summary>The payment means payee account name.</summary>
        protected internal IList<String> paymentMeansPayeeAccountName = new List<String>();

        /// <summary>The payment means payee account proprietary ID.</summary>
        protected internal IList<String> paymentMeansPayeeAccountProprietaryID = new List<String>();

        /// <summary>The payment means payee financial institution BIC.</summary>
        protected internal IList<String> paymentMeansPayeeFinancialInstitutionBIC = new List<String>();

        /// <summary>The payment means payee financial institution german bankleitzahl ID.</summary>
        protected internal IList<String> paymentMeansPayeeFinancialInstitutionGermanBankleitzahlID = new List<String
            >();

        /// <summary>The payment means payee financial institution name.</summary>
        protected internal IList<String> paymentMeansPayeeFinancialInstitutionName = new List<String>();

        /// <summary>The tax calculated amount.</summary>
        protected internal IList<String> taxCalculatedAmount = new List<String>();

        /// <summary>The tax calculated amount currency ID.</summary>
        protected internal IList<String> taxCalculatedAmountCurrencyID = new List<String>();

        /// <summary>The tax type code.</summary>
        protected internal IList<String> taxTypeCode = new List<String>();

        /// <summary>The tax basis amount.</summary>
        protected internal IList<String> taxBasisAmount = new List<String>();

        /// <summary>The tax basis amount currency ID.</summary>
        protected internal IList<String> taxBasisAmountCurrencyID = new List<String>();

        /// <summary>The tax applicable percent.</summary>
        protected internal IList<String> taxApplicablePercent = new List<String>();

        /// <summary>The line total amount.</summary>
        protected internal String lineTotalAmount;

        /// <summary>The line total amount currency ID.</summary>
        protected internal String lineTotalAmountCurrencyID;

        /// <summary>The charge total amount.</summary>
        protected internal String chargeTotalAmount;

        /// <summary>The charge total amount currency ID.</summary>
        protected internal String chargeTotalAmountCurrencyID;

        /// <summary>The allowance total amount.</summary>
        protected internal String allowanceTotalAmount;

        /// <summary>The allowance total amount currency ID.</summary>
        protected internal String allowanceTotalAmountCurrencyID;

        /// <summary>The tax basis total amount.</summary>
        protected internal String taxBasisTotalAmount;

        /// <summary>The tax basis total amount currency ID.</summary>
        protected internal String taxBasisTotalAmountCurrencyID;

        /// <summary>The tax total amount.</summary>
        protected internal String taxTotalAmount;

        /// <summary>The tax total amount currency ID.</summary>
        protected internal String taxTotalAmountCurrencyID;

        /// <summary>The grand total amount.</summary>
        protected internal String grandTotalAmount;

        /// <summary>The grand total amount currency ID.</summary>
        protected internal String grandTotalAmountCurrencyID;

        /// <summary>The line item billed quantity.</summary>
        protected internal IList<String> lineItemBilledQuantity = new List<String>();

        /// <summary>The line item billed quantity unit code.</summary>
        protected internal IList<String> lineItemBilledQuantityUnitCode = new List<String>();

        /// <summary>The line item specified trade product name.</summary>
        protected internal IList<String> lineItemSpecifiedTradeProductName = new List<String>();

        /// <summary>
        /// Creates a new
        /// <see cref="BasicProfileImp"/>
        /// instance.
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
        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getTestIndicator()
        */
        public virtual bool GetTestIndicator() {
            return test;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getId()
        */
        public virtual String GetId() {
            return id;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getName()
        */
        public virtual String GetName() {
            return name;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getTypeCode()
        */
        public virtual String GetTypeCode() {
            return typeCode;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getDateTime()
        */
        public virtual DateTime GetDateTime() {
            return date;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getDateTimeFormat()
        */
        public virtual String GetDateTimeFormat() {
            return dateFormat;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getNotes()
        */
        public virtual String[][] GetNotes() {
            return To2DArray(notes);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getSellerName()
        */
        public virtual String GetSellerName() {
            return sellerName;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getSellerPostcode()
        */
        public virtual String GetSellerPostcode() {
            return sellerPostcode;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getSellerLineOne()
        */
        public virtual String GetSellerLineOne() {
            return sellerLineOne;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getSellerLineTwo()
        */
        public virtual String GetSellerLineTwo() {
            return sellerLineTwo;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getSellerCityName()
        */
        public virtual String GetSellerCityName() {
            return sellerCityName;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getSellerCountryID()
        */
        public virtual String GetSellerCountryID() {
            return sellerCountryID;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getSellerTaxRegistrationID()
        */
        public virtual String[] GetSellerTaxRegistrationID() {
            return To1DArray(sellerTaxRegistrationID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getSellerTaxRegistrationSchemeID()
        */
        public virtual String[] GetSellerTaxRegistrationSchemeID() {
            return To1DArray(sellerTaxRegistrationSchemeID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getBuyerName()
        */
        public virtual String GetBuyerName() {
            return buyerName;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getBuyerPostcode()
        */
        public virtual String GetBuyerPostcode() {
            return buyerPostcode;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getBuyerLineOne()
        */
        public virtual String GetBuyerLineOne() {
            return buyerLineOne;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getBuyerLineTwo()
        */
        public virtual String GetBuyerLineTwo() {
            return buyerLineTwo;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getBuyerCityName()
        */
        public virtual String GetBuyerCityName() {
            return buyerCityName;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getBuyerCountryID()
        */
        public virtual String GetBuyerCountryID() {
            return buyerCountryID;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getBuyerTaxRegistrationID()
        */
        public virtual String[] GetBuyerTaxRegistrationID() {
            return To1DArray(buyerTaxRegistrationID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getBuyerTaxRegistrationSchemeID()
        */
        public virtual String[] GetBuyerTaxRegistrationSchemeID() {
            return To1DArray(buyerTaxRegistrationSchemeID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getDeliveryDateTime()
        */
        public virtual DateTime GetDeliveryDateTime() {
            return deliveryDate;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getDeliveryDateTimeFormat()
        */
        public virtual String GetDeliveryDateTimeFormat() {
            return deliveryDateFormat;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getPaymentReference()
        */
        public virtual String GetPaymentReference() {
            return paymentReference;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getInvoiceCurrencyCode()
        */
        public virtual String GetInvoiceCurrencyCode() {
            return invoiceCurrencyCode;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getPaymentMeansID()
        */
        public virtual String[] GetPaymentMeansID() {
            return To1DArray(paymentMeansID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getPaymentMeansSchemeAgencyID()
        */
        public virtual String[] GetPaymentMeansSchemeAgencyID() {
            return To1DArray(paymentMeansSchemeAgencyID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getPaymentMeansPayeeAccountIBAN()
        */
        public virtual String[] GetPaymentMeansPayeeAccountIBAN() {
            return To1DArray(paymentMeansPayeeAccountIBAN);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getPaymentMeansPayeeAccountAccountName()
        */
        public virtual String[] GetPaymentMeansPayeeAccountAccountName() {
            return To1DArray(paymentMeansPayeeAccountName);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getPaymentMeansPayeeAccountProprietaryID()
        */
        public virtual String[] GetPaymentMeansPayeeAccountProprietaryID() {
            return To1DArray(paymentMeansPayeeAccountProprietaryID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getPaymentMeansPayeeFinancialInstitutionBIC()
        */
        public virtual String[] GetPaymentMeansPayeeFinancialInstitutionBIC() {
            return To1DArray(paymentMeansPayeeFinancialInstitutionBIC);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getPaymentMeansPayeeFinancialInstitutionGermanBankleitzahlID()
        */
        public virtual String[] GetPaymentMeansPayeeFinancialInstitutionGermanBankleitzahlID() {
            return To1DArray(paymentMeansPayeeFinancialInstitutionGermanBankleitzahlID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getPaymentMeansPayeeFinancialInstitutionName()
        */
        public virtual String[] GetPaymentMeansPayeeFinancialInstitutionName() {
            return To1DArray(paymentMeansPayeeFinancialInstitutionName);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getTaxCalculatedAmount()
        */
        public virtual String[] GetTaxCalculatedAmount() {
            return To1DArray(taxCalculatedAmount);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getTaxCalculatedAmountCurrencyID()
        */
        public virtual String[] GetTaxCalculatedAmountCurrencyID() {
            return To1DArray(taxCalculatedAmountCurrencyID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getTaxTypeCode()
        */
        public virtual String[] GetTaxTypeCode() {
            return To1DArray(taxTypeCode);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getTaxBasisAmount()
        */
        public virtual String[] GetTaxBasisAmount() {
            return To1DArray(taxBasisAmount);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getTaxBasisAmountCurrencyID()
        */
        public virtual String[] GetTaxBasisAmountCurrencyID() {
            return To1DArray(taxBasisAmountCurrencyID);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getTaxApplicablePercent()
        */
        public virtual String[] GetTaxApplicablePercent() {
            return To1DArray(taxApplicablePercent);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getLineTotalAmount()
        */
        public virtual String GetLineTotalAmount() {
            return lineTotalAmount;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getLineTotalAmountCurrencyID()
        */
        public virtual String GetLineTotalAmountCurrencyID() {
            return lineTotalAmountCurrencyID;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getChargeTotalAmount()
        */
        public virtual String GetChargeTotalAmount() {
            return chargeTotalAmount;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getChargeTotalAmountCurrencyID()
        */
        public virtual String GetChargeTotalAmountCurrencyID() {
            return chargeTotalAmountCurrencyID;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getAllowanceTotalAmount()
        */
        public virtual String GetAllowanceTotalAmount() {
            return allowanceTotalAmount;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getAllowanceTotalAmountCurrencyID()
        */
        public virtual String GetAllowanceTotalAmountCurrencyID() {
            return allowanceTotalAmountCurrencyID;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getTaxBasisTotalAmount()
        */
        public virtual String GetTaxBasisTotalAmount() {
            return taxBasisTotalAmount;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getTaxBasisTotalAmountCurrencyID()
        */
        public virtual String GetTaxBasisTotalAmountCurrencyID() {
            return taxBasisTotalAmountCurrencyID;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getTaxTotalAmount()
        */
        public virtual String GetTaxTotalAmount() {
            return taxTotalAmount;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getTaxTotalAmountCurrencyID()
        */
        public virtual String GetTaxTotalAmountCurrencyID() {
            return taxTotalAmountCurrencyID;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getGrandTotalAmount()
        */
        public virtual String GetGrandTotalAmount() {
            return grandTotalAmount;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getGrandTotalAmountCurrencyID()
        */
        public virtual String GetGrandTotalAmountCurrencyID() {
            return grandTotalAmountCurrencyID;
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getLineItemBilledQuantity()
        */
        public virtual String[] GetLineItemBilledQuantity() {
            return To1DArray(lineItemBilledQuantity);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getLineItemBilledQuantityUnitCode()
        */
        public virtual String[] GetLineItemBilledQuantityUnitCode() {
            return To1DArray(lineItemBilledQuantityUnitCode);
        }

        /* (non-Javadoc)
        * @see com.itextpdf.zugferd.profiles.IBasicProfile#getLineItemSpecifiedTradeProductName()
        */
        public virtual String[] GetLineItemSpecifiedTradeProductName() {
            return To1DArray(lineItemSpecifiedTradeProductName);
        }

        // implementation of the setters
        /// <summary>Sets the test.</summary>
        /// <param name="test">the new test</param>
        public virtual void SetTest(bool test) {
            this.test = test;
        }

        /// <summary>Sets the id.</summary>
        /// <param name="id">the new id</param>
        public virtual void SetId(String id) {
            this.id = id;
        }

        /// <summary>Sets the name.</summary>
        /// <param name="name">the new name</param>
        public virtual void SetName(String name) {
            this.name = name;
        }

        /// <summary>Sets the type code.</summary>
        /// <param name="typeCode">the new type code</param>
        public virtual void SetTypeCode(String typeCode) {
            this.typeCode = typeCode;
        }

        /// <summary>Sets the date.</summary>
        /// <param name="date">the date</param>
        /// <param name="dateFormat">the date format</param>
        public virtual void SetDate(DateTime date, String dateFormat) {
            this.date = date;
            this.dateFormat = dateFormat;
        }

        /// <summary>Adds the note.</summary>
        /// <param name="note">the note</param>
        public virtual void AddNote(String[] note) {
            notes.Add(note);
        }

        /// <summary>Sets the seller name.</summary>
        /// <param name="sellerName">the new seller name</param>
        public virtual void SetSellerName(String sellerName) {
            this.sellerName = sellerName;
        }

        /// <summary>Sets the seller postcode.</summary>
        /// <param name="sellerPostcode">the new seller postcode</param>
        public virtual void SetSellerPostcode(String sellerPostcode) {
            this.sellerPostcode = sellerPostcode;
        }

        /// <summary>Sets the seller line one.</summary>
        /// <param name="sellerLineOne">the new seller line one</param>
        public virtual void SetSellerLineOne(String sellerLineOne) {
            this.sellerLineOne = sellerLineOne;
        }

        /// <summary>Sets the seller line two.</summary>
        /// <param name="sellerLineTwo">the new seller line two</param>
        public virtual void SetSellerLineTwo(String sellerLineTwo) {
            this.sellerLineTwo = sellerLineTwo;
        }

        /// <summary>Sets the seller city name.</summary>
        /// <param name="sellerCityName">the new seller city name</param>
        public virtual void SetSellerCityName(String sellerCityName) {
            this.sellerCityName = sellerCityName;
        }

        /// <summary>Sets the seller country ID.</summary>
        /// <param name="sellerCountryID">the new seller country ID</param>
        public virtual void SetSellerCountryID(String sellerCountryID) {
            this.sellerCountryID = sellerCountryID;
        }

        /// <summary>Adds the seller tax registration.</summary>
        /// <param name="schemeID">the scheme ID</param>
        /// <param name="taxId">the tax id</param>
        public virtual void AddSellerTaxRegistration(String schemeID, String taxId) {
            sellerTaxRegistrationSchemeID.Add(schemeID);
            sellerTaxRegistrationID.Add(taxId);
        }

        /// <summary>Sets the buyer name.</summary>
        /// <param name="buyerName">the new buyer name</param>
        public virtual void SetBuyerName(String buyerName) {
            this.buyerName = buyerName;
        }

        /// <summary>Sets the buyer postcode.</summary>
        /// <param name="buyerPostcode">the new buyer postcode</param>
        public virtual void SetBuyerPostcode(String buyerPostcode) {
            this.buyerPostcode = buyerPostcode;
        }

        /// <summary>Sets the buyer line one.</summary>
        /// <param name="buyerLineOne">the new buyer line one</param>
        public virtual void SetBuyerLineOne(String buyerLineOne) {
            this.buyerLineOne = buyerLineOne;
        }

        /// <summary>Sets the buyer line two.</summary>
        /// <param name="buyerLineTwo">the new buyer line two</param>
        public virtual void SetBuyerLineTwo(String buyerLineTwo) {
            this.buyerLineTwo = buyerLineTwo;
        }

        /// <summary>Sets the buyer city name.</summary>
        /// <param name="buyerCityName">the new buyer city name</param>
        public virtual void SetBuyerCityName(String buyerCityName) {
            this.buyerCityName = buyerCityName;
        }

        /// <summary>Sets the buyer country ID.</summary>
        /// <param name="buyerCountryID">the new buyer country ID</param>
        public virtual void SetBuyerCountryID(String buyerCountryID) {
            this.buyerCountryID = buyerCountryID;
        }

        /// <summary>Adds the buyer tax registration.</summary>
        /// <param name="schemeID">the scheme ID</param>
        /// <param name="taxId">the tax id</param>
        public virtual void AddBuyerTaxRegistration(String schemeID, String taxId) {
            buyerTaxRegistrationSchemeID.Add(schemeID);
            buyerTaxRegistrationID.Add(taxId);
        }

        /// <summary>Sets the delivery date.</summary>
        /// <param name="deliveryDate">the delivery date</param>
        /// <param name="deliveryDateFormat">the delivery date format</param>
        public virtual void SetDeliveryDate(DateTime deliveryDate, String deliveryDateFormat) {
            this.deliveryDate = deliveryDate;
            this.deliveryDateFormat = deliveryDateFormat;
        }

        /// <summary>Sets the payment reference.</summary>
        /// <param name="paymentReference">the new payment reference</param>
        public virtual void SetPaymentReference(String paymentReference) {
            this.paymentReference = paymentReference;
        }

        /// <summary>Sets the invoice currency code.</summary>
        /// <param name="invoiceCurrencyCode">the new invoice currency code</param>
        public virtual void SetInvoiceCurrencyCode(String invoiceCurrencyCode) {
            this.invoiceCurrencyCode = invoiceCurrencyCode;
        }

        /// <summary>Adds the payment means.</summary>
        /// <param name="schemeAgencyID">the scheme agency ID</param>
        /// <param name="id">the id</param>
        /// <param name="iban">the iban</param>
        /// <param name="accountname">the accountname</param>
        /// <param name="proprietaryID">the proprietary ID</param>
        /// <param name="bic">the bic</param>
        /// <param name="germanBankleitzahlID">the german bankleitzahl ID</param>
        /// <param name="institutionname">the institutionname</param>
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

        /// <summary>Adds the applicable trade tax.</summary>
        /// <param name="calculatedAmount">the calculated amount</param>
        /// <param name="calculatedAmountCurrencyID">the calculated amount currency ID</param>
        /// <param name="typeCode">the type code</param>
        /// <param name="basisAmount">the basis amount</param>
        /// <param name="basisAmountCurrencyID">the basis amount currency ID</param>
        /// <param name="applicablePercent">the applicable percent</param>
        public virtual void AddApplicableTradeTax(String calculatedAmount, String calculatedAmountCurrencyID, String
             typeCode, String basisAmount, String basisAmountCurrencyID, String applicablePercent) {
            taxCalculatedAmount.Add(calculatedAmount);
            taxCalculatedAmountCurrencyID.Add(calculatedAmountCurrencyID);
            taxTypeCode.Add(typeCode);
            taxBasisAmount.Add(basisAmount);
            taxBasisAmountCurrencyID.Add(basisAmountCurrencyID);
            taxApplicablePercent.Add(applicablePercent);
        }

        /// <summary>Sets the monetary summation.</summary>
        /// <param name="lineTotalAmount">the line total amount</param>
        /// <param name="lineTotalAmountCurrencyID">the line total amount currency ID</param>
        /// <param name="chargeTotalAmount">the charge total amount</param>
        /// <param name="chargeTotalAmountCurrencyID">the charge total amount currency ID</param>
        /// <param name="allowanceTotalAmount">the allowance total amount</param>
        /// <param name="allowanceTotalAmountCurrencyID">the allowance total amount currency ID</param>
        /// <param name="taxBasisTotalAmount">the tax basis total amount</param>
        /// <param name="taxBasisTotalAmountCurrencyID">the tax basis total amount currency ID</param>
        /// <param name="taxTotalAmount">the tax total amount</param>
        /// <param name="taxTotalAmountCurrencyID">the tax total amount currency ID</param>
        /// <param name="grandTotalAmount">the grand total amount</param>
        /// <param name="grandTotalAmountCurrencyID">the grand total amount currency ID</param>
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

        /// <summary>Adds the included supply chain trade line item.</summary>
        /// <param name="billedQuantity">the billed quantity</param>
        /// <param name="billedQuantityUnitCode">the billed quantity unit code</param>
        /// <param name="specifiedTradeProductName">the specified trade product name</param>
        public virtual void AddIncludedSupplyChainTradeLineItem(String billedQuantity, String billedQuantityUnitCode
            , String specifiedTradeProductName) {
            this.lineItemBilledQuantity.Add(billedQuantity);
            this.lineItemBilledQuantityUnitCode.Add(billedQuantityUnitCode);
            this.lineItemSpecifiedTradeProductName.Add(specifiedTradeProductName);
        }

        // helper methods
        /// <summary>To 1D array.</summary>
        /// <param name="list">the list</param>
        /// <returns>the string[]</returns>
        protected internal virtual String[] To1DArray(IList<String> list) {
            return (String[])list.ToArray(new String[list.Count]);
        }

        /// <summary>To 1D array (for boolean values).</summary>
        /// <param name="list">the list</param>
        /// <returns>the boolean[]</returns>
        protected internal virtual bool[] To1DArrayB(IList<bool> list) {
            bool[] b = new bool[list.Count];
            for (int i = 0; i < list.Count; i++) {
                b[i] = list[i];
            }
            return b;
        }

        /// <summary>To 2D array.</summary>
        /// <param name="list">the list</param>
        /// <returns>the string[][]</returns>
        protected internal virtual String[][] To2DArray(IList<String[]> list) {
            int n = list.Count;
            String[][] array = new String[n][];
            for (int i = 0; i < n; i++) {
                array[i] = list[i];
            }
            return array;
        }

        /// <summary>To 2D array (for boolean values).</summary>
        /// <param name="list">the list</param>
        /// <returns>the boolean[][]</returns>
        protected internal virtual bool[][] To2DArrayB(IList<bool[]> list) {
            int n = list.Count;
            bool[][] array = new bool[n][];
            for (int i = 0; i < n; i++) {
                array[i] = list[i];
            }
            return array;
        }

        /// <summary>To 3D array.</summary>
        /// <param name="list">the list</param>
        /// <returns>the string[][][]</returns>
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
