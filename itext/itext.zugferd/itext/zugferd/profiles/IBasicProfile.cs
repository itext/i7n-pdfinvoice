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
    /// invoice that conforms with the Basic profile.
    /// </summary>
    public interface IBasicProfile {
        /// <summary>Gets the test indicator.</summary>
        /// <returns>the test indicator</returns>
        bool GetTestIndicator();

        /// <summary>Gets the id.</summary>
        /// <returns>the id</returns>
        String GetId();

        /// <summary>Gets the name.</summary>
        /// <returns>the name</returns>
        String GetName();

        /// <summary>Gets the type code.</summary>
        /// <returns>the type code</returns>
        String GetTypeCode();

        /// <summary>Gets the date time.</summary>
        /// <returns>the date time</returns>
        DateTime GetDateTime();

        /// <summary>Gets the date time format.</summary>
        /// <returns>the date time format</returns>
        String GetDateTimeFormat();

        /// <summary>Gets the notes.</summary>
        /// <returns>the notes</returns>
        String[][] GetNotes();

        /// <summary>Gets the seller name.</summary>
        /// <returns>the seller name</returns>
        String GetSellerName();

        /// <summary>Gets the seller postcode.</summary>
        /// <returns>the seller postcode</returns>
        String GetSellerPostcode();

        /// <summary>Gets the seller line one.</summary>
        /// <returns>the seller line one</returns>
        String GetSellerLineOne();

        /// <summary>Gets the seller line two.</summary>
        /// <returns>the seller line two</returns>
        String GetSellerLineTwo();

        /// <summary>Gets the seller city name.</summary>
        /// <returns>the seller city name</returns>
        String GetSellerCityName();

        /// <summary>Gets the seller country ID.</summary>
        /// <returns>the seller country ID</returns>
        String GetSellerCountryID();

        /// <summary>Gets the seller tax registration ID.</summary>
        /// <returns>the seller tax registration ID</returns>
        String[] GetSellerTaxRegistrationID();

        /// <summary>Gets the seller tax registration scheme ID.</summary>
        /// <returns>the seller tax registration scheme ID</returns>
        String[] GetSellerTaxRegistrationSchemeID();

        /// <summary>Gets the buyer name.</summary>
        /// <returns>the buyer name</returns>
        String GetBuyerName();

        /// <summary>Gets the buyer postcode.</summary>
        /// <returns>the buyer postcode</returns>
        String GetBuyerPostcode();

        /// <summary>Gets the buyer line one.</summary>
        /// <returns>the buyer line one</returns>
        String GetBuyerLineOne();

        /// <summary>Gets the buyer line two.</summary>
        /// <returns>the buyer line two</returns>
        String GetBuyerLineTwo();

        /// <summary>Gets the buyer city name.</summary>
        /// <returns>the buyer city name</returns>
        String GetBuyerCityName();

        /// <summary>Gets the buyer country ID.</summary>
        /// <returns>the buyer country ID</returns>
        String GetBuyerCountryID();

        /// <summary>Gets the buyer tax registration ID.</summary>
        /// <returns>the buyer tax registration ID</returns>
        String[] GetBuyerTaxRegistrationID();

        /// <summary>Gets the buyer tax registration scheme ID.</summary>
        /// <returns>the buyer tax registration scheme ID</returns>
        String[] GetBuyerTaxRegistrationSchemeID();

        /// <summary>Gets the delivery date time.</summary>
        /// <returns>the delivery date time</returns>
        DateTime GetDeliveryDateTime();

        /// <summary>Gets the delivery date time format.</summary>
        /// <returns>the delivery date time format</returns>
        String GetDeliveryDateTimeFormat();

        /// <summary>Gets the payment reference.</summary>
        /// <returns>the payment reference</returns>
        String GetPaymentReference();

        /// <summary>Gets the invoice currency code.</summary>
        /// <returns>the invoice currency code</returns>
        String GetInvoiceCurrencyCode();

        /// <summary>Gets the payment means ID.</summary>
        /// <returns>the payment means ID</returns>
        String[] GetPaymentMeansID();

        /// <summary>Gets the payment means scheme agency ID.</summary>
        /// <returns>the payment means scheme agency ID</returns>
        String[] GetPaymentMeansSchemeAgencyID();

        /// <summary>Gets the payment means payee account IBAN.</summary>
        /// <returns>the payment means payee account IBAN</returns>
        String[] GetPaymentMeansPayeeAccountIBAN();

        /// <summary>Gets the payment means payee account account name.</summary>
        /// <returns>the payment means payee account account name</returns>
        String[] GetPaymentMeansPayeeAccountAccountName();

        /// <summary>Gets the payment means payee account proprietary ID.</summary>
        /// <returns>the payment means payee account proprietary ID</returns>
        String[] GetPaymentMeansPayeeAccountProprietaryID();

        /// <summary>Gets the payment means payee financial institution BIC.</summary>
        /// <returns>the payment means payee financial institution BIC</returns>
        String[] GetPaymentMeansPayeeFinancialInstitutionBIC();

        /// <summary>Gets the payment means payee financial institution german bankleitzahl ID.</summary>
        /// <returns>the payment means payee financial institution german bankleitzahl ID</returns>
        String[] GetPaymentMeansPayeeFinancialInstitutionGermanBankleitzahlID();

        /// <summary>Gets the payment means payee financial institution name.</summary>
        /// <returns>the payment means payee financial institution name</returns>
        String[] GetPaymentMeansPayeeFinancialInstitutionName();

        /// <summary>Gets the tax calculated amount.</summary>
        /// <returns>the tax calculated amount</returns>
        String[] GetTaxCalculatedAmount();

        /// <summary>Gets the tax calculated amount currency ID.</summary>
        /// <returns>the tax calculated amount currency ID</returns>
        String[] GetTaxCalculatedAmountCurrencyID();

        /// <summary>Gets the tax type code.</summary>
        /// <returns>the tax type code</returns>
        String[] GetTaxTypeCode();

        /// <summary>Gets the tax basis amount.</summary>
        /// <returns>the tax basis amount</returns>
        String[] GetTaxBasisAmount();

        /// <summary>Gets the tax basis amount currency ID.</summary>
        /// <returns>the tax basis amount currency ID</returns>
        String[] GetTaxBasisAmountCurrencyID();

        /// <summary>Gets the tax applicable percent.</summary>
        /// <returns>the tax applicable percent</returns>
        String[] GetTaxApplicablePercent();

        /// <summary>Gets the line total amount.</summary>
        /// <returns>the line total amount</returns>
        String GetLineTotalAmount();

        /// <summary>Gets the line total amount currency ID.</summary>
        /// <returns>the line total amount currency ID</returns>
        String GetLineTotalAmountCurrencyID();

        /// <summary>Gets the charge total amount.</summary>
        /// <returns>the charge total amount</returns>
        String GetChargeTotalAmount();

        /// <summary>Gets the charge total amount currency ID.</summary>
        /// <returns>the charge total amount currency ID</returns>
        String GetChargeTotalAmountCurrencyID();

        /// <summary>Gets the allowance total amount.</summary>
        /// <returns>the allowance total amount</returns>
        String GetAllowanceTotalAmount();

        /// <summary>Gets the allowance total amount currency ID.</summary>
        /// <returns>the allowance total amount currency ID</returns>
        String GetAllowanceTotalAmountCurrencyID();

        /// <summary>Gets the tax basis total amount.</summary>
        /// <returns>the tax basis total amount</returns>
        String GetTaxBasisTotalAmount();

        /// <summary>Gets the tax basis total amount currency ID.</summary>
        /// <returns>the tax basis total amount currency ID</returns>
        String GetTaxBasisTotalAmountCurrencyID();

        /// <summary>Gets the tax total amount.</summary>
        /// <returns>the tax total amount</returns>
        String GetTaxTotalAmount();

        /// <summary>Gets the tax total amount currency ID.</summary>
        /// <returns>the tax total amount currency ID</returns>
        String GetTaxTotalAmountCurrencyID();

        /// <summary>Gets the grand total amount.</summary>
        /// <returns>the grand total amount</returns>
        String GetGrandTotalAmount();

        /// <summary>Gets the grand total amount currency ID.</summary>
        /// <returns>the grand total amount currency ID</returns>
        String GetGrandTotalAmountCurrencyID();

        /// <summary>Gets the line item billed quantity.</summary>
        /// <returns>the line item billed quantity</returns>
        String[] GetLineItemBilledQuantity();

        /// <summary>Gets the line item billed quantity unit code.</summary>
        /// <returns>the line item billed quantity unit code</returns>
        String[] GetLineItemBilledQuantityUnitCode();

        /// <summary>Gets the line item specified trade product name.</summary>
        /// <returns>the line item specified trade product name</returns>
        String[] GetLineItemSpecifiedTradeProductName();
    }
}
