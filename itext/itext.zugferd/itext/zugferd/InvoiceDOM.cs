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
using System.IO;
using Javax.Xml.Parsers;
using Javax.Xml.Transform;
using Javax.Xml.Transform.Dom;
using Javax.Xml.Transform.Stream;
using Org.W3c.Dom;
using iText.Zugferd.Exceptions;
using iText.Zugferd.Profiles;
using iText.Zugferd.Validation;
using iText.Zugferd.Validation.Basic;
using iText.Zugferd.Validation.Comfort;

using System.Collections.Generic;
using System.Reflection;
using Versions.Attributes;
using System.IO;
namespace iText.Zugferd {
    public class InvoiceDOM {
        public static readonly CountryCode COUNTRY_CODE = new CountryCode();

        public static readonly CurrencyCode CURR_CODE = new CurrencyCode();

        public static readonly DateFormatCode DF_CODE = new DateFormatCode();

        public static readonly GlobalIdentifierCode GI_CODE = new GlobalIdentifierCode();

        public static readonly MeasurementUnitCode M_UNIT_CODE = new MeasurementUnitCode();

        public static readonly NumberChecker DEC2 = new NumberChecker(NumberChecker.TWO_DECIMALS);

        public static readonly NumberChecker DEC4 = new NumberChecker(NumberChecker.FOUR_DECIMALS);

        public static readonly PaymentMeansCode PM_CODE = new PaymentMeansCode();

        public static readonly TaxCategoryCode TC_CODE = new TaxCategoryCode();

        public static readonly TaxIDTypeCode TIDT_CODE = new TaxIDTypeCode();

        public static readonly TaxTypeCode TT_CODE = new TaxTypeCode();

        protected internal readonly Document doc;

        /// <summary>Creates an object that will import data into an XML template.</summary>
        /// <param name="data">
        /// If this is an instance of BASICInvoice, the BASIC profile will be used;
        /// If this is an instance of COMFORTInvoice, the COMFORT profile will be used.
        /// </param>
        /// <exception cref="Javax.Xml.Parsers.ParserConfigurationException"/>
        /// <exception cref="Org.Xml.Sax.SAXException"/>
        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="iText.Zugferd.Exceptions.DataIncompleteException"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        public InvoiceDOM(IBasicProfile data) {
            // code checkers
            // The DOM document
            String licenseKeyClassName = "iText.License.LicenseKey, itext.licensekey";
            String licenseKeyProductClassName = "iText.License.LicenseKeyProduct, itext.licensekey";
            String licenseKeyFeatureClassName = "iText.LicenseKey.LicenseKeyProductFeature, itext.licensekey";
            String checkLicenseKeyMethodName = "ScheduledCheck";
            Type licenseKeyClass = GetClass(licenseKeyClassName);
            if ( licenseKeyClass != null ) {
                Type licenseKeyProductClass = GetClass(licenseKeyProductClassName);
                Type licenseKeyProductFeatureClass = GetClass(licenseKeyFeatureClassName);
                Array array = Array.CreateInstance(licenseKeyProductFeatureClass, 0);
                object[] objects = new object[] { "pdfInvoice", 1, 0, array };
                Object productObject = System.Activator.CreateInstance(licenseKeyProductClass, objects);
                MethodInfo m = licenseKeyClass.GetMethod(checkLicenseKeyMethodName);
                m.Invoke(System.Activator.CreateInstance(licenseKeyClass), new object[] {productObject});
            }
            // loading the XML template
            DocumentBuilderFactory docFactory = DocumentBuilderFactory.NewInstance();
            DocumentBuilder docBuilder = docFactory.NewDocumentBuilder();
            Stream @is = new FileStream("./src/test/resources/xml/zugferd-template.xml", FileMode.Open, FileAccess.Read
                );
            doc = docBuilder.Parse(@is);
            // importing the data
            ImportData(doc, data);
        }

        private static Type GetClass(string className)
        {
            String licenseKeyClassFullName = null;
            Assembly assembly = typeof(InvoiceDOM).Assembly;
            Attribute keyVersionAttr = assembly.GetCustomAttribute(typeof(KeyVersionAttribute));
            if (keyVersionAttr is KeyVersionAttribute)
            {
                String keyVersion = ((KeyVersionAttribute)keyVersionAttr).KeyVersion;
                String format = "{0}, Version={1}, Culture=neutral, PublicKeyToken=8354ae6d2174ddca";
                licenseKeyClassFullName = String.Format(format, className, keyVersion);
            }
            Type type = null;
            if (licenseKeyClassFullName != null)
            {
                String fileLoadExceptionMessage = null;
                try
                {
                    type = System.Type.GetType(licenseKeyClassFullName);
                }
                catch (FileLoadException fileLoadException)
                {
                    fileLoadExceptionMessage = fileLoadException.Message;
                }
                if (fileLoadExceptionMessage != null)
                {
                    try
                    {
                        type = System.Type.GetType(className);
                    }
                    catch
                    {
                        // empty
                    }
                }
            }
            return type;
        }

        // top-level import methods
        /// <summary>Imports the data into the XML template.</summary>
        /// <param name="doc">the Document object we are going to populate</param>
        /// <param name="data">the interface that gives us access to the data</param>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        /// <exception cref="iText.Zugferd.Exceptions.DataIncompleteException"/>
        private void ImportData(Document doc, IBasicProfile data) {
            if (!data.GetTestIndicator()) {
                throw new InvalidCodeException("false", "the test indicator: the ZUGFeRD functionality is still in beta; contact sales@itextpdf.com for more info."
                    );
            }
            ImportSpecifiedExchangedDocumentContext((Element)doc.GetElementsByTagName("rsm:SpecifiedExchangedDocumentContext"
                ).Item(0), data);
            ImportHeaderExchangedDocument((Element)doc.GetElementsByTagName("rsm:HeaderExchangedDocument").Item(0), data
                );
            ImportSpecifiedSupplyChainTradeTransaction((Element)doc.GetElementsByTagName("rsm:SpecifiedSupplyChainTradeTransaction"
                ).Item(0), data);
        }

        /// <summary>Imports the data for the following tag: rsm:SpecifiedExchangedDocumentContext</summary>
        /// <param name="element">the rsm:SpecifiedExchangedDocumentContext element</param>
        /// <param name="data">the invoice data</param>
        protected internal virtual void ImportSpecifiedExchangedDocumentContext(Element element, IBasicProfile data
            ) {
            // TestIndicator (optional)
            ImportContent(element, "udt:Indicator", data.GetTestIndicator() ? "true" : "false");
        }

        /// <summary>Imports the data for the following tag: rsm:HeaderExchangedDocument</summary>
        /// <param name="element">the rsm:HeaderExchangedDocument element</param>
        /// <param name="data">the invoice data</param>
        /// <exception cref="iText.Zugferd.Exceptions.DataIncompleteException"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportHeaderExchangedDocument(Element element, IBasicProfile data) {
            // ID (required)
            Check(data.GetId(), "HeaderExchangedDocument > ID");
            ImportContent(element, "ram:ID", data.GetId());
            // Name (required)
            Check(data.GetName(), "HeaderExchangedDocument > Name");
            ImportContent(element, "ram:Name", data.GetName());
            // TypeCode (required)
            DocumentTypeCode dtCode = new DocumentTypeCode(data is IComfortProfile ? DocumentTypeCode.COMFORT : DocumentTypeCode
                .BASIC);
            ImportContent(element, "ram:TypeCode", dtCode.Check(data.GetTypeCode()));
            // IssueDateTime (required)
            Check(data.GetDateTimeFormat(), "HeaderExchangedDocument > DateTimeString");
            ImportDateTime(element, "udt:DateTimeString", data.GetDateTimeFormat(), data.GetDateTime());
            // IncludedNote (optional): header level
            String[][] notes = data.GetNotes();
            String[] notesCodes = null;
            if (data is IComfortProfile) {
                notesCodes = ((IComfortProfile)data).GetNotesCodes();
            }
            ImportIncludedNotes(element, FreeTextSubjectCode.HEADER, notes, notesCodes);
        }

        // Sub-level import methods
        /// <summary>Helper method to set the content of a tag.</summary>
        /// <param name="parent">the parent element of the tag</param>
        /// <param name="tag">the tag for which we want to set the content</param>
        /// <param name="content">the new content for the tag</param>
        /// <param name="attributes">
        /// a sequence of attributes of which
        /// the odd elements are keys, the even elements the
        /// corresponding value.
        /// </param>
        protected internal virtual void ImportContent(Element parent, String tag, String content, params String[] 
            attributes) {
            Node node = parent.GetElementsByTagName(tag).Item(0);
            // content
            node.SetTextContent(content);
            // attributes
            if (attributes == null || attributes.Length == 0) {
                return;
            }
            int n = attributes.Length;
            String attrName;
            String attrValue;
            NamedNodeMap attrs = node.GetAttributes();
            Node attr;
            for (int i = 0; i < n; i++) {
                attrName = attributes[i];
                if (++i == n) {
                    continue;
                }
                attrValue = attributes[i];
                attr = attrs.GetNamedItem(attrName);
                if (attr != null) {
                    attr.SetTextContent(attrValue);
                }
            }
        }

        /// <summary>Set the content of a date tag along with the attribute that defines the format.</summary>
        /// <param name="parent">the parent element that holds the date tag</param>
        /// <param name="tag">the date tag we want to change</param>
        /// <param name="dateTimeFormat">the format that will be used as an attribute</param>
        /// <param name="dateTime">the actual date</param>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportDateTime(Element parent, String tag, String dateTimeFormat, DateTime
             dateTime) {
            if (dateTimeFormat == null) {
                return;
            }
            ImportContent(parent, tag, DF_CODE.ConvertToString(dateTime, DF_CODE.Check(dateTimeFormat)), "format", dateTimeFormat
                );
        }

        /// <summary>
        /// Includes notes and (in case of the COMFORT profile) the subject codes
        /// for those notes.
        /// </summary>
        /// <param name="parent">the parent element of the tag we want to change</param>
        /// <param name="level">the level where the notices are added (header or line)</param>
        /// <param name="notes">array of notes</param>
        /// <param name="notesCodes">
        /// array of codes for the notes.
        /// If not null, notes and notesCodes need to have an equal number of elements.
        /// </param>
        /// <exception cref="iText.Zugferd.Exceptions.DataIncompleteException"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportIncludedNotes(Element parent, int level, String[][] notes, String[] 
            notesCodes) {
            if (notes == null) {
                return;
            }
            Node includedNoteNode = parent.GetElementsByTagName("ram:IncludedNote").Item(0);
            int n = notes.Length;
            FreeTextSubjectCode ftsCode = new FreeTextSubjectCode(level);
            if (notesCodes != null && n != notesCodes.Length) {
                throw new DataIncompleteException("Number of included notes is not equal to number of codes for included notes."
                    );
            }
            for (int i = 0; i < n; i++) {
                Element noteNode = (Element)includedNoteNode.CloneNode(true);
                Node content = noteNode.GetElementsByTagName("ram:Content").Item(0);
                foreach (String note in notes[i]) {
                    Node newNode = content.CloneNode(true);
                    newNode.SetTextContent(note);
                    noteNode.InsertBefore(newNode, content);
                }
                if (notesCodes != null) {
                    Node code = noteNode.GetElementsByTagName("ram:SubjectCode").Item(0);
                    code.SetTextContent(ftsCode.Check(notesCodes[i]));
                }
                parent.InsertBefore(noteNode, includedNoteNode);
            }
        }

        /// <summary>Imports the data for the following tag: rsm:SpecifiedSupplyChainTradeTransaction</summary>
        /// <param name="element"/>
        /// <param name="data">the invoice data</param>
        /// <exception cref="iText.Zugferd.Exceptions.DataIncompleteException"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportSpecifiedSupplyChainTradeTransaction(Element element, IBasicProfile 
            data) {
            IComfortProfile comfortData = null;
            if (data is IComfortProfile) {
                comfortData = (IComfortProfile)data;
            }
            /* ram:ApplicableSupplyChainTradeAgreement */
            // buyer reference (optional; comfort only)
            if (comfortData != null) {
                String buyerReference = comfortData.GetBuyerReference();
                ImportContent(element, "ram:BuyerReference", buyerReference);
            }
            // SellerTradeParty (required)
            Check(data.GetSellerName(), "SpecifiedSupplyChainTradeTransaction > ApplicableSupplyChainTradeAgreement > SellerTradeParty > Name"
                );
            ImportSellerTradeParty(element, data);
            // BuyerTradeParty (required)
            Check(data.GetBuyerName(), "SpecifiedSupplyChainTradeTransaction > ApplicableSupplyChainTradeAgreement > BuyerTradeParty > Name"
                );
            ImportBuyerTradeParty(element, data);
            /* ram:ApplicableSupplyChainTradeDelivery */
            if (comfortData != null) {
                // BuyerOrderReferencedDocument (optional)
                Element document = (Element)element.GetElementsByTagName("ram:BuyerOrderReferencedDocument").Item(0);
                ImportDateTime(document, "ram:IssueDateTime", comfortData.GetBuyerOrderReferencedDocumentIssueDateTimeFormat
                    (), comfortData.GetBuyerOrderReferencedDocumentIssueDateTime());
                ImportContent(document, "ram:ID", comfortData.GetBuyerOrderReferencedDocumentID());
                // ContractReferencedDocument (optional)
                document = (Element)element.GetElementsByTagName("ram:ContractReferencedDocument").Item(0);
                ImportDateTime(document, "ram:IssueDateTime", comfortData.GetContractReferencedDocumentIssueDateTimeFormat
                    (), comfortData.GetContractReferencedDocumentIssueDateTime());
                ImportContent(document, "ram:ID", comfortData.GetContractReferencedDocumentID());
                // CustomerOrderReferencedDocument (optional)
                document = (Element)element.GetElementsByTagName("ram:CustomerOrderReferencedDocument").Item(0);
                ImportDateTime(document, "ram:IssueDateTime", comfortData.GetCustomerOrderReferencedDocumentIssueDateTimeFormat
                    (), comfortData.GetCustomerOrderReferencedDocumentIssueDateTime());
                ImportContent(document, "ram:ID", comfortData.GetCustomerOrderReferencedDocumentID());
            }
            /* ram:ApplicableSupplyChainTradeDelivery */
            // ActualDeliverySupplyChainEvent (optional)
            Element parent = (Element)element.GetElementsByTagName("ram:ActualDeliverySupplyChainEvent").Item(0);
            ImportDateTime(parent, "udt:DateTimeString", data.GetDeliveryDateTimeFormat(), data.GetDeliveryDateTime());
            // DeliveryNoteReferencedDocument (optional)
            if (comfortData != null) {
                Element document = (Element)element.GetElementsByTagName("ram:DeliveryNoteReferencedDocument").Item(0);
                ImportDateTime(document, "ram:IssueDateTime", comfortData.GetDeliveryNoteReferencedDocumentIssueDateTimeFormat
                    (), comfortData.GetDeliveryNoteReferencedDocumentIssueDateTime());
                ImportContent(document, "ram:ID", comfortData.GetDeliveryNoteReferencedDocumentID());
            }
            /* ram:ApplicableSupplyChainTradeSettlement */
            // ram:PaymentReference (optional)
            ImportContent(element, "ram:PaymentReference", data.GetPaymentReference());
            // ram:InvoiceCurrencyCode (required)
            ImportContent(element, "ram:InvoiceCurrencyCode", CURR_CODE.Check(data.GetInvoiceCurrencyCode()));
            // ram:InvoiceeTradeParty (optional)
            if (comfortData != null) {
                ImportInvoiceeTradeParty(element, comfortData);
            }
            // ram:SpecifiedTradeSettlementPaymentMeans
            parent = (Element)element.GetElementsByTagName("ram:ApplicableSupplyChainTradeSettlement").Item(0);
            ImportPaymentMeans(parent, data);
            // ram:ApplicableTradeTax
            ImportTax(parent, data);
            if (comfortData != null) {
                // ram:BillingSpecifiedPeriod
                Element period = (Element)element.GetElementsByTagName("ram:BillingSpecifiedPeriod").Item(0);
                Element start = (Element)period.GetElementsByTagName("ram:StartDateTime").Item(0);
                ImportDateTime(start, "udt:DateTimeString", comfortData.GetBillingStartDateTimeFormat(), comfortData.GetBillingStartDateTime
                    ());
                // ContractReferencedDocument (optional)
                Element end = (Element)period.GetElementsByTagName("ram:EndDateTime").Item(0);
                ImportDateTime(end, "udt:DateTimeString", comfortData.GetBillingEndDateTimeFormat(), comfortData.GetBillingEndDateTime
                    ());
                // ram:SpecifiedTradeAllowanceCharge
                ImportSpecifiedTradeAllowanceCharge(parent, comfortData);
                // ram:SpecifiedLogisticsServiceCharge
                ImportSpecifiedLogisticsServiceCharge(parent, comfortData);
                // ram:SpecifiedTradePaymentTerms
                ImportSpecifiedTradePaymentTerms(parent, comfortData);
            }
            // ram:SpecifiedTradeSettlementMonetarySummation
            Check(DEC2.Check(data.GetLineTotalAmount()), "SpecifiedTradeSettlementMonetarySummation > LineTotalAmount"
                );
            Check(CURR_CODE.Check(data.GetLineTotalAmountCurrencyID()), "SpecifiedTradeSettlementMonetarySummation > LineTotalAmount . currencyID"
                );
            ImportContent(element, "ram:LineTotalAmount", data.GetLineTotalAmount(), "currencyID", data.GetLineTotalAmountCurrencyID
                ());
            Check(DEC2.Check(data.GetChargeTotalAmount()), "SpecifiedTradeSettlementMonetarySummation > ChargeTotalAmount"
                );
            Check(CURR_CODE.Check(data.GetChargeTotalAmountCurrencyID()), "SpecifiedTradeSettlementMonetarySummation > ChargeTotalAmount . currencyID"
                );
            ImportContent(element, "ram:ChargeTotalAmount", data.GetChargeTotalAmount(), "currencyID", data.GetChargeTotalAmountCurrencyID
                ());
            Check(DEC2.Check(data.GetAllowanceTotalAmount()), "SpecifiedTradeSettlementMonetarySummation > AllowanceTotalAmount"
                );
            Check(CURR_CODE.Check(data.GetAllowanceTotalAmountCurrencyID()), "SpecifiedTradeSettlementMonetarySummation > AllowanceTotalAmount . currencyID"
                );
            ImportContent(element, "ram:AllowanceTotalAmount", data.GetAllowanceTotalAmount(), "currencyID", data.GetAllowanceTotalAmountCurrencyID
                ());
            Check(DEC2.Check(data.GetTaxBasisTotalAmount()), "SpecifiedTradeSettlementMonetarySummation > TaxBasisTotalAmount"
                );
            Check(CURR_CODE.Check(data.GetTaxBasisTotalAmountCurrencyID()), "SpecifiedTradeSettlementMonetarySummation > TaxBasisTotalAmount . currencyID"
                );
            ImportContent(element, "ram:TaxBasisTotalAmount", data.GetTaxBasisTotalAmount(), "currencyID", data.GetTaxBasisTotalAmountCurrencyID
                ());
            Check(DEC2.Check(data.GetTaxTotalAmount()), "SpecifiedTradeSettlementMonetarySummation > TaxTotalAmount");
            Check(CURR_CODE.Check(data.GetTaxTotalAmountCurrencyID()), "SpecifiedTradeSettlementMonetarySummation > TaxTotalAmount . currencyID"
                );
            ImportContent(element, "ram:TaxTotalAmount", data.GetTaxTotalAmount(), "currencyID", data.GetTaxTotalAmountCurrencyID
                ());
            Check(DEC2.Check(data.GetGrandTotalAmount()), "SpecifiedTradeSettlementMonetarySummation > GrandTotalAmount"
                );
            Check(CURR_CODE.Check(data.GetGrandTotalAmountCurrencyID()), "SpecifiedTradeSettlementMonetarySummation > GrandTotalAmount . currencyID"
                );
            ImportContent(element, "ram:GrandTotalAmount", data.GetGrandTotalAmount(), "currencyID", data.GetGrandTotalAmountCurrencyID
                ());
            if (comfortData != null) {
                ImportContent(element, "ram:TotalPrepaidAmount", comfortData.GetTotalPrepaidAmount(), "currencyID", comfortData
                    .GetTotalPrepaidAmountCurrencyID());
                ImportContent(element, "ram:DuePayableAmount", comfortData.GetDuePayableAmount(), "currencyID", comfortData
                    .GetDuePayableAmountCurrencyID());
            }
            /* ram:IncludedSupplyChainTradeLineItem */
            if (comfortData != null) {
                ImportLineItemsComfort(element, comfortData);
            }
            else {
                ImportLineItemsBasic(element, data);
            }
        }

        /// <summary>Gets the seller trade party data to import this data.</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="data">the data</param>
        /// <exception cref="iText.Zugferd.Exceptions.DataIncompleteException"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportSellerTradeParty(Element parent, IBasicProfile data) {
            String id = null;
            String[] globalID = null;
            String[] globalIDScheme = null;
            if (data is IComfortProfile) {
                id = ((IComfortProfile)data).GetSellerID();
                globalID = ((IComfortProfile)data).GetSellerGlobalID();
                globalIDScheme = ((IComfortProfile)data).GetSellerGlobalSchemeID();
            }
            String name = data.GetSellerName();
            String postcode = data.GetSellerPostcode();
            String lineOne = data.GetSellerLineOne();
            String lineTwo = data.GetSellerLineTwo();
            String cityName = data.GetSellerCityName();
            String countryID = data.GetSellerCountryID();
            String[] taxRegistrationID = data.GetSellerTaxRegistrationID();
            String[] taxRegistrationSchemeID = data.GetSellerTaxRegistrationSchemeID();
            ImportTradeParty((Element)parent.GetElementsByTagName("ram:SellerTradeParty").Item(0), id, globalID, globalIDScheme
                , name, postcode, lineOne, lineTwo, cityName, countryID, taxRegistrationID, taxRegistrationSchemeID);
        }

        /// <summary>Gets the buyer trade party data to import this data.</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="data">the data</param>
        /// <exception cref="iText.Zugferd.Exceptions.DataIncompleteException"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportBuyerTradeParty(Element parent, IBasicProfile data) {
            String id = null;
            String[] globalID = null;
            String[] globalIDScheme = null;
            if (data is IComfortProfile) {
                id = ((IComfortProfile)data).GetBuyerID();
                globalID = ((IComfortProfile)data).GetBuyerGlobalID();
                globalIDScheme = ((IComfortProfile)data).GetBuyerGlobalSchemeID();
            }
            String name = data.GetBuyerName();
            String postcode = data.GetBuyerPostcode();
            String lineOne = data.GetBuyerLineOne();
            String lineTwo = data.GetBuyerLineTwo();
            String cityName = data.GetBuyerCityName();
            String countryID = data.GetBuyerCountryID();
            String[] taxRegistrationID = data.GetBuyerTaxRegistrationID();
            String[] taxRegistrationSchemeID = data.GetBuyerTaxRegistrationSchemeID();
            ImportTradeParty((Element)parent.GetElementsByTagName("ram:BuyerTradeParty").Item(0), id, globalID, globalIDScheme
                , name, postcode, lineOne, lineTwo, cityName, countryID, taxRegistrationID, taxRegistrationSchemeID);
        }

        /// <summary>Gets the invoicee party data to import this data.</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="data">the data</param>
        /// <exception cref="iText.Zugferd.Exceptions.DataIncompleteException"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportInvoiceeTradeParty(Element parent, IComfortProfile data) {
            String name = data.GetInvoiceeName();
            if (name == null) {
                return;
            }
            String id = data.GetInvoiceeID();
            String[] globalID = data.GetInvoiceeGlobalID();
            String[] globalIDScheme = data.GetInvoiceeGlobalSchemeID();
            String postcode = data.GetInvoiceePostcode();
            String lineOne = data.GetInvoiceeLineOne();
            String lineTwo = data.GetInvoiceeLineTwo();
            String cityName = data.GetInvoiceeCityName();
            String countryID = data.GetInvoiceeCountryID();
            String[] taxRegistrationID = data.GetInvoiceeTaxRegistrationID();
            String[] taxRegistrationSchemeID = data.GetInvoiceeTaxRegistrationSchemeID();
            ImportTradeParty((Element)parent.GetElementsByTagName("ram:InvoiceeTradeParty").Item(0), id, globalID, globalIDScheme
                , name, postcode, lineOne, lineTwo, cityName, countryID, taxRegistrationID, taxRegistrationSchemeID);
        }

        /// <summary>Imports trade party information (could be seller, buyer or invoicee).</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="id"/>
        /// <param name="globalID"/>
        /// <param name="globalIDScheme"/>
        /// <param name="name"/>
        /// <param name="postcode"/>
        /// <param name="lineOne"/>
        /// <param name="lineTwo"/>
        /// <param name="countryID"/>
        /// <param name="cityName"/>
        /// <param name="taxRegistrationID"/>
        /// <param name="taxRegistrationSchemeID"/>
        /// <exception cref="iText.Zugferd.Exceptions.DataIncompleteException"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportTradeParty(Element parent, String id, String[] globalID, String[] globalIDScheme
            , String name, String postcode, String lineOne, String lineTwo, String cityName, String countryID, String
            [] taxRegistrationID, String[] taxRegistrationSchemeID) {
            Node node;
            if (id != null) {
                node = parent.GetElementsByTagName("ram:ID").Item(0);
                node.SetTextContent(id);
            }
            if (globalID != null) {
                int n = globalID.Length;
                if (globalIDScheme == null || globalIDScheme.Length != n) {
                    throw new DataIncompleteException("Number of global ID schemes is not equal to number of global IDs.");
                }
                node = parent.GetElementsByTagName("ram:GlobalID").Item(0);
                for (int i = 0; i < n; i++) {
                    Element idNode = (Element)node.CloneNode(true);
                    NamedNodeMap attrs = idNode.GetAttributes();
                    idNode.SetTextContent(globalID[i]);
                    Node schemeID = attrs.GetNamedItem("schemeID");
                    schemeID.SetTextContent(GI_CODE.Check(globalIDScheme[i]));
                    parent.InsertBefore(idNode, node);
                }
            }
            ImportContent(parent, "ram:Name", name);
            ImportContent(parent, "ram:PostcodeCode", postcode);
            ImportContent(parent, "ram:LineOne", lineOne);
            ImportContent(parent, "ram:LineTwo", lineTwo);
            ImportContent(parent, "ram:CityName", cityName);
            if (countryID != null) {
                ImportContent(parent, "ram:CountryID", COUNTRY_CODE.Check(countryID));
            }
            int n_1 = taxRegistrationID.Length;
            if (taxRegistrationSchemeID != null && taxRegistrationSchemeID.Length != n_1) {
                throw new DataIncompleteException("Number of tax ID schemes is not equal to number of tax IDs.");
            }
            Element tax = (Element)parent.GetElementsByTagName("ram:SpecifiedTaxRegistration").Item(0);
            node = tax.GetElementsByTagName("ram:ID").Item(0);
            for (int i_1 = 0; i_1 < n_1; i_1++) {
                Element idNode = (Element)node.CloneNode(true);
                idNode.SetTextContent(taxRegistrationID[i_1]);
                NamedNodeMap attrs = idNode.GetAttributes();
                Node schemeID = attrs.GetNamedItem("schemeID");
                schemeID.SetTextContent(TIDT_CODE.Check(taxRegistrationSchemeID[i_1]));
                tax.InsertBefore(idNode, node);
            }
        }

        /// <summary>Gets the payment means data to imports this data.</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="data">the data</param>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportPaymentMeans(Element parent, IBasicProfile data) {
            String[] pmID = data.GetPaymentMeansID();
            int n = pmID.Length;
            String[] pmTypeCode = new String[n];
            String[][] pmInformation = new String[n][];
            String[] pmSchemeAgencyID = data.GetPaymentMeansSchemeAgencyID();
            String[] pmPayerIBAN = new String[n];
            String[] pmPayerProprietaryID = new String[n];
            String[] pmIBAN = data.GetPaymentMeansPayeeAccountIBAN();
            String[] pmAccountName = data.GetPaymentMeansPayeeAccountAccountName();
            String[] pmAccountID = data.GetPaymentMeansPayeeAccountProprietaryID();
            String[] pmPayerBIC = new String[n];
            String[] pmPayerGermanBankleitzahlID = new String[n];
            String[] pmPayerFinancialInst = new String[n];
            String[] pmBIC = data.GetPaymentMeansPayeeFinancialInstitutionBIC();
            String[] pmGermanBankleitzahlID = data.GetPaymentMeansPayeeFinancialInstitutionGermanBankleitzahlID();
            String[] pmFinancialInst = data.GetPaymentMeansPayeeFinancialInstitutionName();
            if (data is IComfortProfile) {
                IComfortProfile comfortData = (IComfortProfile)data;
                pmTypeCode = comfortData.GetPaymentMeansTypeCode();
                pmInformation = comfortData.GetPaymentMeansInformation();
                pmPayerIBAN = comfortData.GetPaymentMeansPayerAccountIBAN();
                pmPayerProprietaryID = comfortData.GetPaymentMeansPayerAccountProprietaryID();
                pmPayerBIC = comfortData.GetPaymentMeansPayerFinancialInstitutionBIC();
                pmPayerGermanBankleitzahlID = comfortData.GetPaymentMeansPayerFinancialInstitutionGermanBankleitzahlID();
                pmPayerFinancialInst = comfortData.GetPaymentMeansPayerFinancialInstitutionName();
            }
            Node node = parent.GetElementsByTagName("ram:SpecifiedTradeSettlementPaymentMeans").Item(0);
            for (int i = 0; i < pmID.Length; i++) {
                Node newNode = node.CloneNode(true);
                this.ImportPaymentMeans((Element)newNode, pmTypeCode[i], pmInformation[i], pmID[i], pmSchemeAgencyID[i], pmPayerIBAN
                    [i], pmPayerProprietaryID[i], pmIBAN[i], pmAccountName[i], pmAccountID[i], pmPayerBIC[i], pmPayerGermanBankleitzahlID
                    [i], pmPayerFinancialInst[i], pmBIC[i], pmGermanBankleitzahlID[i], pmFinancialInst[i]);
                parent.InsertBefore(newNode, node);
            }
        }

        /// <summary>Imports payment means data.</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="typeCode"/>
        /// <param name="information"/>
        /// <param name="id"/>
        /// <param name="scheme"/>
        /// <param name="payerIban"/>
        /// <param name="payerProprietaryID"/>
        /// <param name="iban"/>
        /// <param name="accID"/>
        /// <param name="accName"/>
        /// <param name="payerBic"/>
        /// <param name="payerBank"/>
        /// <param name="inst"/>
        /// <param name="bic"/>
        /// <param name="bank"/>
        /// <param name="payerInst"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportPaymentMeans(Element parent, String typeCode, String[] information, 
            String id, String scheme, String payerIban, String payerProprietaryID, String iban, String accName, String
             accID, String payerBic, String payerBank, String payerInst, String bic, String bank, String inst) {
            if (typeCode != null) {
                ImportContent(parent, "ram:TypeCode", PM_CODE.Check(typeCode));
            }
            if (information != null) {
                Node node = parent.GetElementsByTagName("ram:Information").Item(0);
                foreach (String info in information) {
                    Node newNode = node.CloneNode(true);
                    newNode.SetTextContent(info);
                    parent.InsertBefore(newNode, node);
                }
            }
            ImportContent(parent, "ram:ID", id, "schemeAgencyID", scheme);
            Element payer = (Element)parent.GetElementsByTagName("ram:PayerPartyDebtorFinancialAccount").Item(0);
            ImportContent(payer, "ram:IBANID", payerIban);
            ImportContent(payer, "ram:ProprietaryID", payerProprietaryID);
            Element payee = (Element)parent.GetElementsByTagName("ram:PayeePartyCreditorFinancialAccount").Item(0);
            ImportContent(payee, "ram:IBANID", iban);
            ImportContent(payee, "ram:AccountName", accName);
            ImportContent(payee, "ram:ProprietaryID", accID);
            payer = (Element)parent.GetElementsByTagName("ram:PayerSpecifiedDebtorFinancialInstitution").Item(0);
            ImportContent(payer, "ram:BICID", payerBic);
            ImportContent(payer, "ram:GermanBankleitzahlID", payerBank);
            ImportContent(payer, "ram:Name", payerInst);
            payee = (Element)parent.GetElementsByTagName("ram:PayeeSpecifiedCreditorFinancialInstitution").Item(0);
            ImportContent(payee, "ram:BICID", bic);
            ImportContent(payee, "ram:GermanBankleitzahlID", bank);
            ImportContent(payee, "ram:Name", inst);
        }

        /// <summary>Gets tax data to import the this data.</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="data">the data</param>
        /// <exception cref="iText.Zugferd.Exceptions.DataIncompleteException"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportTax(Element parent, IBasicProfile data) {
            String[] calculated = data.GetTaxCalculatedAmount();
            int n = calculated.Length;
            String[] calculatedCurr = data.GetTaxCalculatedAmountCurrencyID();
            String[] typeCode = data.GetTaxTypeCode();
            String[] exemptionReason = new String[n];
            String[] basisAmount = data.GetTaxBasisAmount();
            String[] basisAmountCurr = data.GetTaxBasisAmountCurrencyID();
            String[] category = new String[n];
            String[] percent = data.GetTaxApplicablePercent();
            if (data is IComfortProfile) {
                IComfortProfile comfortData = (IComfortProfile)data;
                exemptionReason = comfortData.GetTaxExemptionReason();
                category = comfortData.GetTaxCategoryCode();
            }
            Node node = parent.GetElementsByTagName("ram:ApplicableTradeTax").Item(0);
            for (int i = 0; i < n; i++) {
                Node newNode = node.CloneNode(true);
                this.ImportTax((Element)newNode, calculated[i], calculatedCurr[i], typeCode[i], exemptionReason[i], basisAmount
                    [i], basisAmountCurr[i], category[i], percent[i]);
                parent.InsertBefore(newNode, node);
            }
        }

        /// <summary>Imports tax data.</summary>
        /// <param name="parent"/>
        /// <param name="calculatedAmount"/>
        /// <param name="currencyID"/>
        /// <param name="typeCode"/>
        /// <param name="exemptionReason"/>
        /// <param name="basisAmount"/>
        /// <param name="basisAmountCurr"/>
        /// <param name="category"/>
        /// <param name="percent"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        /// <exception cref="iText.Zugferd.Exceptions.DataIncompleteException"/>
        protected internal virtual void ImportTax(Element parent, String calculatedAmount, String currencyID, String
             typeCode, String exemptionReason, String basisAmount, String basisAmountCurr, String category, String
             percent) {
            // Calculated amount (required; 2 decimals)
            Check(CURR_CODE.Check(currencyID), "ApplicableTradeTax > CalculatedAmount > CurrencyID");
            ImportContent(parent, "ram:CalculatedAmount", DEC2.Check(calculatedAmount), "currencyID", currencyID);
            // TypeCode (required)
            Check(typeCode, "ApplicableTradeTax > TypeCode");
            ImportContent(parent, "ram:TypeCode", TT_CODE.Check(typeCode));
            // exemption reason (optional)
            ImportContent(parent, "ram:ExemptionReason", exemptionReason);
            // basis amount (required, 2 decimals)
            Check(CURR_CODE.Check(basisAmountCurr), "ApplicableTradeTax > BasisAmount > CurrencyID");
            ImportContent(parent, "ram:BasisAmount", DEC2.Check(basisAmount), "currencyID", basisAmountCurr);
            // Category code (optional)
            if (category != null) {
                ImportContent(parent, "ram:CategoryCode", TC_CODE.Check(category));
            }
            // Applicable percent (required; 2 decimals)
            ImportContent(parent, "ram:ApplicablePercent", DEC2.Check(percent));
        }

        /// <summary>Gets specified trade allowance charge data to import the this data.</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="data">the data</param>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportSpecifiedTradeAllowanceCharge(Element parent, IComfortProfile data) {
            bool?[] indicator = data.GetSpecifiedTradeAllowanceChargeIndicator();
            String[] actualAmount = data.GetSpecifiedTradeAllowanceChargeActualAmount();
            String[] actualAmountCurr = data.GetSpecifiedTradeAllowanceChargeActualAmountCurrency();
            String[] reason = data.GetSpecifiedTradeAllowanceChargeReason();
            String[][] typeCode = data.GetSpecifiedTradeAllowanceChargeTaxTypeCode();
            String[][] categoryCode = data.GetSpecifiedTradeAllowanceChargeTaxCategoryCode();
            String[][] percent = data.GetSpecifiedTradeAllowanceChargeTaxApplicablePercent();
            Node node = (Element)parent.GetElementsByTagName("ram:SpecifiedTradeAllowanceCharge").Item(0);
            for (int i = 0; i < indicator.Length; i++) {
                Node newNode = node.CloneNode(true);
                this.ImportSpecifiedTradeAllowanceCharge((Element)newNode, indicator[i], actualAmount[i], actualAmountCurr
                    [i], reason[i], typeCode[i], categoryCode[i], percent[i]);
                parent.InsertBefore(newNode, node);
            }
        }

        /// <summary>Imports specified trade allowance charge.</summary>
        /// <param name="parent"/>
        /// <param name="indicator"/>
        /// <param name="actualAmount"/>
        /// <param name="actualAmountCurrency"/>
        /// <param name="reason"/>
        /// <param name="typeCode"/>
        /// <param name="categoryCode"/>
        /// <param name="percent"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportSpecifiedTradeAllowanceCharge(Element parent, bool indicator, String
             actualAmount, String actualAmountCurrency, String reason, String[] typeCode, String[] categoryCode, String
            [] percent) {
            ImportContent(parent, "udt:Indicator", indicator ? "true" : "false");
            ImportContent(parent, "ram:ActualAmount", DEC4.Check(actualAmount), "currencyID", CURR_CODE.Check(actualAmountCurrency
                ));
            ImportContent(parent, "ram:Reason", reason);
            Node node = parent.GetElementsByTagName("ram:CategoryTradeTax").Item(0);
            for (int i = 0; i < typeCode.Length; i++) {
                Element newNode = (Element)node.CloneNode(true);
                ImportContent(newNode, "ram:TypeCode", TT_CODE.Check(typeCode[i]));
                ImportContent(newNode, "ram:CategoryCode", TC_CODE.Check(categoryCode[i]));
                ImportContent(newNode, "ram:ApplicablePercent", DEC2.Check(percent[i]));
                parent.InsertBefore(newNode, node);
            }
        }

        /// <summary>Gets specified logistics service charge data to import the this data.</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="data">the data</param>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportSpecifiedLogisticsServiceCharge(Element parent, IComfortProfile data
            ) {
            String[][] description = data.GetSpecifiedLogisticsServiceChargeDescription();
            String[] appliedAmount = data.GetSpecifiedLogisticsServiceChargeAmount();
            String[] appliedAmountCurr = data.GetSpecifiedLogisticsServiceChargeAmountCurrency();
            String[][] typeCode = data.GetSpecifiedLogisticsServiceChargeTaxTypeCode();
            String[][] categoryCode = data.GetSpecifiedLogisticsServiceChargeTaxCategoryCode();
            String[][] percent = data.GetSpecifiedLogisticsServiceChargeTaxApplicablePercent();
            Node node = parent.GetElementsByTagName("ram:SpecifiedLogisticsServiceCharge").Item(0);
            for (int i = 0; i < appliedAmount.Length; i++) {
                Node newNode = node.CloneNode(true);
                this.ImportSpecifiedLogisticsServiceCharge((Element)newNode, description[i], appliedAmount[i], appliedAmountCurr
                    [i], typeCode[i], categoryCode[i], percent[i]);
                parent.InsertBefore(newNode, node);
            }
        }

        /// <summary>Imports specified logistics service charge data.</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="description"/>
        /// <param name="appliedAmount"/>
        /// <param name="currencyID"/>
        /// <param name="typeCode"/>
        /// <param name="categoryCode"/>
        /// <param name="percent"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportSpecifiedLogisticsServiceCharge(Element parent, String[] description
            , String appliedAmount, String currencyID, String[] typeCode, String[] categoryCode, String[] percent) {
            Node node = parent.GetElementsByTagName("ram:Description").Item(0);
            foreach (String d in description) {
                Node newNode = node.CloneNode(true);
                newNode.SetTextContent(d);
                parent.InsertBefore(newNode, node);
            }
            ImportContent(parent, "ram:AppliedAmount", DEC4.Check(appliedAmount), "currencyID", CURR_CODE.Check(currencyID
                ));
            node = parent.GetElementsByTagName("ram:AppliedTradeTax").Item(0);
            for (int i = 0; i < typeCode.Length; i++) {
                Element newNode = (Element)node.CloneNode(true);
                ImportContent(newNode, "ram:TypeCode", TT_CODE.Check(typeCode[i]));
                ImportContent(newNode, "ram:CategoryCode", TC_CODE.Check(categoryCode[i]));
                ImportContent(newNode, "ram:ApplicablePercent", DEC2.Check(percent[i]));
                parent.InsertBefore(newNode, node);
            }
        }

        /// <summary>Gets specified trade payment terms data to import the this data.</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="data">the data</param>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportSpecifiedTradePaymentTerms(Element parent, IComfortProfile data) {
            String[][] description = data.GetSpecifiedTradePaymentTermsDescription();
            DateTime[] dateTime = data.GetSpecifiedTradePaymentTermsDueDateTime();
            String[] dateTimeFormat = data.GetSpecifiedTradePaymentTermsDueDateTimeFormat();
            Node node = parent.GetElementsByTagName("ram:SpecifiedTradePaymentTerms").Item(0);
            for (int i = 0; i < description.Length; i++) {
                Node newNode = node.CloneNode(true);
                this.ImportSpecifiedTradePaymentTerms((Element)newNode, description[i], dateTime[i], dateTimeFormat[i]);
                parent.InsertBefore(newNode, node);
            }
        }

        /// <summary>Imports specified trade payment terms.</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="description"/>
        /// <param name="dateTime"/>
        /// <param name="dateTimeFormat"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportSpecifiedTradePaymentTerms(Element parent, String[] description, DateTime
             dateTime, String dateTimeFormat) {
            Node node = parent.GetElementsByTagName("ram:Description").Item(0);
            foreach (String d in description) {
                Node newNode = node.CloneNode(true);
                newNode.SetTextContent(d);
                parent.InsertBefore(newNode, node);
            }
            if (dateTimeFormat != null) {
                ImportDateTime(parent, "udt:DateTimeString", dateTimeFormat, dateTime);
            }
        }

        /// <summary>Gets line item data to import the this data (comfort profile).</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="data">the data</param>
        /// <exception cref="iText.Zugferd.Exceptions.DataIncompleteException"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportLineItemsComfort(Element parent, IComfortProfile data) {
            String[] lineIDs = data.GetLineItemLineID();
            if (lineIDs.Length == 0) {
                throw new DataIncompleteException("You can create an invoice without any line items");
            }
            String[][][] includedNote = data.GetLineItemIncludedNote();
            String[] grossPriceChargeAmount = data.GetLineItemGrossPriceChargeAmount();
            String[] grossPriceChargeAmountCurrencyID = data.GetLineItemGrossPriceChargeAmountCurrencyID();
            String[] grossPriceBasisQuantity = data.GetLineItemGrossPriceBasisQuantity();
            String[] grossPriceBasisQuantityCode = data.GetLineItemGrossPriceBasisQuantityCode();
            bool?[][] grossPriceTradeAllowanceChargeIndicator = data.GetLineItemGrossPriceTradeAllowanceChargeIndicator
                ();
            String[][] grossPriceTradeAllowanceChargeActualAmount = data.GetLineItemGrossPriceTradeAllowanceChargeActualAmount
                ();
            String[][] grossPriceTradeAllowanceChargeActualAmountCurrencyID = data.GetLineItemGrossPriceTradeAllowanceChargeActualAmountCurrencyID
                ();
            String[][] grossPriceTradeAllowanceChargeReason = data.GetLineItemGrossPriceTradeAllowanceChargeReason();
            String[] netPriceChargeAmount = data.GetLineItemNetPriceChargeAmount();
            String[] netPriceChargeAmountCurrencyID = data.GetLineItemNetPriceChargeAmountCurrencyID();
            String[] netPriceBasisQuantity = data.GetLineItemNetPriceBasisQuantity();
            String[] netPriceBasisQuantityCode = data.GetLineItemNetPriceBasisQuantityCode();
            String[] billedQuantity = data.GetLineItemBilledQuantity();
            // BASIC
            String[] billedQuantityUnitCode = data.GetLineItemBilledQuantityUnitCode();
            String[][] settlementTaxTypeCode = data.GetLineItemSettlementTaxTypeCode();
            String[][] settlementTaxExemptionReason = data.GetLineItemSettlementTaxExemptionReason();
            String[][] settlementTaxCategoryCode = data.GetLineItemSettlementTaxCategoryCode();
            String[][] settlementTaxApplicablePercent = data.GetLineItemSettlementTaxApplicablePercent();
            String[] totalAmount = data.GetLineItemLineTotalAmount();
            String[] totalAmountCurrencyID = data.GetLineItemLineTotalAmountCurrencyID();
            String[] specifiedTradeProductGlobalID = data.GetLineItemSpecifiedTradeProductGlobalID();
            String[] specifiedTradeProductSchemeID = data.GetLineItemSpecifiedTradeProductSchemeID();
            String[] specifiedTradeProductSellerAssignedID = data.GetLineItemSpecifiedTradeProductSellerAssignedID();
            String[] specifiedTradeProductBuyerAssignedID = data.GetLineItemSpecifiedTradeProductBuyerAssignedID();
            String[] specifiedTradeProductName = data.GetLineItemSpecifiedTradeProductName();
            // BASIC
            String[] specifiedTradeProductDescription = data.GetLineItemSpecifiedTradeProductDescription();
            Node node = parent.GetElementsByTagName("ram:IncludedSupplyChainTradeLineItem").Item(0);
            for (int i = 0; i < lineIDs.Length; i++) {
                Node newNode = node.CloneNode(true);
                ImportLineItemComfort((Element)newNode, lineIDs[i], includedNote[i], grossPriceChargeAmount[i], grossPriceChargeAmountCurrencyID
                    [i], grossPriceBasisQuantity[i], grossPriceBasisQuantityCode[i], grossPriceTradeAllowanceChargeIndicator
                    [i], grossPriceTradeAllowanceChargeActualAmount[i], grossPriceTradeAllowanceChargeActualAmountCurrencyID
                    [i], grossPriceTradeAllowanceChargeReason[i], netPriceChargeAmount[i], netPriceChargeAmountCurrencyID[
                    i], netPriceBasisQuantity[i], netPriceBasisQuantityCode[i], billedQuantity[i], billedQuantityUnitCode[
                    i], settlementTaxTypeCode[i], settlementTaxExemptionReason[i], settlementTaxCategoryCode[i], settlementTaxApplicablePercent
                    [i], totalAmount[i], totalAmountCurrencyID[i], specifiedTradeProductGlobalID[i], specifiedTradeProductSchemeID
                    [i], specifiedTradeProductSellerAssignedID[i], specifiedTradeProductBuyerAssignedID[i], specifiedTradeProductName
                    [i], specifiedTradeProductDescription[i]);
                parent.InsertBefore(newNode, node);
            }
        }

        /// <summary>Imports line item data (comfort profile).</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="lineID"/>
        /// <param name="note"/>
        /// <param name="grossPriceChargeAmount"/>
        /// <param name="grossPriceChargeAmountCurrencyID"/>
        /// <param name="grossPriceBasisQuantity"/>
        /// <param name="grossPriceBasisQuantityCode"/>
        /// <param name="grossPriceTradeAllowanceChargeIndicator"/>
        /// <param name="grossPriceTradeAllowanceChargeActualAmount"/>
        /// <param name="grossPriceTradeAllowanceChargeActualAmountCurrencyID"/>
        /// <param name="grossPriceTradeAllowanceChargeReason"/>
        /// <param name="netPriceChargeAmount"/>
        /// <param name="netPriceChargeAmountCurrencyID"/>
        /// <param name="netPriceBasisQuantity"/>
        /// <param name="netPriceBasisQuantityCode"/>
        /// <param name="billedQuantity"/>
        /// <param name="billedQuantityCode"/>
        /// <param name="settlementTaxTypeCode"/>
        /// <param name="settlementTaxExemptionReason"/>
        /// <param name="settlementTaxCategoryCode"/>
        /// <param name="settlementTaxApplicablePercent"/>
        /// <param name="totalAmount"/>
        /// <param name="totalAmountCurrencyID"/>
        /// <param name="specifiedTradeProductGlobalID"/>
        /// <param name="specifiedTradeProductSchemeID"/>
        /// <param name="specifiedTradeProductSellerAssignedID"/>
        /// <param name="specifiedTradeProductBuyerAssignedID"/>
        /// <param name="specifiedTradeProductName"/>
        /// <param name="specifiedTradeProductDescription"/>
        /// <exception cref="iText.Zugferd.Exceptions.DataIncompleteException"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportLineItemComfort(Element parent, String lineID, String[][] note, String
             grossPriceChargeAmount, String grossPriceChargeAmountCurrencyID, String grossPriceBasisQuantity, String
             grossPriceBasisQuantityCode, bool?[] grossPriceTradeAllowanceChargeIndicator, String[] grossPriceTradeAllowanceChargeActualAmount
            , String[] grossPriceTradeAllowanceChargeActualAmountCurrencyID, String[] grossPriceTradeAllowanceChargeReason
            , String netPriceChargeAmount, String netPriceChargeAmountCurrencyID, String netPriceBasisQuantity, String
             netPriceBasisQuantityCode, String billedQuantity, String billedQuantityCode, String[] settlementTaxTypeCode
            , String[] settlementTaxExemptionReason, String[] settlementTaxCategoryCode, String[] settlementTaxApplicablePercent
            , String totalAmount, String totalAmountCurrencyID, String specifiedTradeProductGlobalID, String specifiedTradeProductSchemeID
            , String specifiedTradeProductSellerAssignedID, String specifiedTradeProductBuyerAssignedID, String specifiedTradeProductName
            , String specifiedTradeProductDescription) {
            /* ram:AssociatedDocumentLineDocument */
            Element sub = (Element)parent.GetElementsByTagName("ram:AssociatedDocumentLineDocument").Item(0);
            ImportContent(sub, "ram:LineID", lineID);
            ImportIncludedNotes(sub, FreeTextSubjectCode.LINE, note, null);
            /* ram:SpecifiedSupplyChainTradeAgreement */
            // ram:GrossPriceProductTradePrice
            if (grossPriceChargeAmount != null) {
                sub = (Element)parent.GetElementsByTagName("ram:GrossPriceProductTradePrice").Item(0);
                ImportContent(sub, "ram:ChargeAmount", DEC4.Check(grossPriceChargeAmount), "currencyID", CURR_CODE.Check(grossPriceChargeAmountCurrencyID
                    ));
                if (grossPriceBasisQuantity != null) {
                    ImportContent(sub, "ram:BasisQuantity", DEC4.Check(grossPriceBasisQuantity), "unitCode", M_UNIT_CODE.Check
                        (grossPriceBasisQuantityCode));
                }
                Node node = sub.GetElementsByTagName("ram:AppliedTradeAllowanceCharge").Item(0);
                if (grossPriceTradeAllowanceChargeIndicator != null) {
                    for (int i = 0; i < grossPriceTradeAllowanceChargeIndicator.Length; i++) {
                        Node newNode = node.CloneNode(true);
                        ImportAppliedTradeAllowanceCharge((Element)newNode, grossPriceTradeAllowanceChargeIndicator[i], grossPriceTradeAllowanceChargeActualAmount
                            [i], grossPriceTradeAllowanceChargeActualAmountCurrencyID[i], grossPriceTradeAllowanceChargeReason[i]);
                        sub.InsertBefore(newNode, node);
                    }
                }
            }
            // ram:NetPriceProductTradePrice
            if (netPriceChargeAmount != null) {
                sub = (Element)parent.GetElementsByTagName("ram:NetPriceProductTradePrice").Item(0);
                ImportContent(sub, "ram:ChargeAmount", DEC4.Check(netPriceChargeAmount), "currencyID", CURR_CODE.Check(netPriceChargeAmountCurrencyID
                    ));
                if (netPriceBasisQuantity != null) {
                    ImportContent(sub, "ram:BasisQuantity", DEC4.Check(netPriceBasisQuantity), "unitCode", M_UNIT_CODE.Check(netPriceBasisQuantityCode
                        ));
                }
            }
            /* ram:SpecifiedSupplyChainTradeDelivery */
            sub = (Element)parent.GetElementsByTagName("ram:SpecifiedSupplyChainTradeDelivery").Item(0);
            ImportContent(sub, "ram:BilledQuantity", DEC4.Check(billedQuantity), "unitCode", M_UNIT_CODE.Check(billedQuantityCode
                ));
            /* ram:SpecifiedSupplyChainTradeSettlement */
            sub = (Element)parent.GetElementsByTagName("ram:SpecifiedSupplyChainTradeSettlement").Item(0);
            Node node_1 = sub.GetElementsByTagName("ram:ApplicableTradeTax").Item(0);
            for (int i_1 = 0; i_1 < settlementTaxApplicablePercent.Length; i_1++) {
                Node newNode = node_1.CloneNode(true);
                this.ImportTax((Element)newNode, settlementTaxTypeCode[i_1], settlementTaxExemptionReason[i_1], settlementTaxCategoryCode
                    [i_1], settlementTaxApplicablePercent[i_1]);
                sub.InsertBefore(newNode, node_1);
            }
            ImportContent(sub, "ram:LineTotalAmount", totalAmount, "currencyID", totalAmountCurrencyID);
            /* ram:SpecifiedTradeProduct */
            sub = (Element)parent.GetElementsByTagName("ram:SpecifiedTradeProduct").Item(0);
            if (specifiedTradeProductGlobalID != null) {
                ImportContent(sub, "ram:GlobalID", specifiedTradeProductGlobalID, "schemeID", GI_CODE.Check(specifiedTradeProductSchemeID
                    ));
            }
            ImportContent(sub, "ram:SellerAssignedID", specifiedTradeProductSellerAssignedID);
            ImportContent(sub, "ram:BuyerAssignedID", specifiedTradeProductBuyerAssignedID);
            ImportContent(sub, "ram:Name", specifiedTradeProductName);
            ImportContent(sub, "ram:Description", specifiedTradeProductDescription);
        }

        /// <summary>Imports applied trade allowance charge data (line items).</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="indicator"/>
        /// <param name="actualAmount"/>
        /// <param name="currencyID"/>
        /// <param name="reason"/>
        /// <exception cref="iText.Zugferd.Exceptions.DataIncompleteException"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportAppliedTradeAllowanceCharge(Element parent, bool indicator, String actualAmount
            , String currencyID, String reason) {
            ImportContent(parent, "udt:Indicator", indicator ? "true" : "false");
            Check(DEC4.Check(actualAmount), "AppliedTradeAllowanceCharge > ActualAmount");
            ImportContent(parent, "ram:ActualAmount", actualAmount, "currencyID", CURR_CODE.Check(currencyID));
            ImportContent(parent, "ram:Reason", reason);
        }

        /// <summary>Imports tax data.</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="typeCode"/>
        /// <param name="exemptionReason"/>
        /// <param name="category"/>
        /// <param name="percent"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        /// <exception cref="iText.Zugferd.Exceptions.DataIncompleteException"/>
        protected internal virtual void ImportTax(Element parent, String typeCode, String exemptionReason, String 
            category, String percent) {
            // Calculated amount (required; 2 decimals)
            // TypeCode (required)
            Check(typeCode, "ApplicableTradeTax > TypeCode");
            ImportContent(parent, "ram:TypeCode", TT_CODE.Check(typeCode));
            // exemption reason (optional)
            ImportContent(parent, "ram:ExemptionReason", exemptionReason);
            // Category code (optional)
            if (category != null) {
                ImportContent(parent, "ram:CategoryCode", TC_CODE.Check(category));
            }
            // Applicable percent (required; 2 decimals)
            ImportContent(parent, "ram:ApplicablePercent", DEC2.Check(percent));
        }

        /// <summary>Gets line data to import the this data (basic profile).</summary>
        /// <param name="parent"/>
        /// <param name="data"/>
        /// <exception cref="iText.Zugferd.Exceptions.DataIncompleteException"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportLineItemsBasic(Element parent, IBasicProfile data) {
            String[] quantity = data.GetLineItemBilledQuantity();
            if (quantity.Length == 0) {
                throw new DataIncompleteException("You can create an invoice without any line items");
            }
            String[] quantityCode = data.GetLineItemBilledQuantityUnitCode();
            String[] name = data.GetLineItemSpecifiedTradeProductName();
            Node node = parent.GetElementsByTagName("ram:IncludedSupplyChainTradeLineItem").Item(0);
            for (int i = 0; i < quantity.Length; i++) {
                Node newNode = node.CloneNode(true);
                ImportLineItemBasic((Element)newNode, quantity[i], quantityCode[i], name[i]);
                parent.InsertBefore(newNode, node);
            }
        }

        /// <summary>Imports the data for a line item (basic profile)</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="quantity"/>
        /// <param name="code"/>
        /// <param name="name"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportLineItemBasic(Element parent, String quantity, String code, String name
            ) {
            Element sub = (Element)parent.GetElementsByTagName("ram:SpecifiedSupplyChainTradeDelivery").Item(0);
            ImportContent(sub, "ram:BilledQuantity", DEC4.Check(quantity), "unitCode", M_UNIT_CODE.Check(code));
            sub = (Element)parent.GetElementsByTagName("ram:SpecifiedTradeProduct").Item(0);
            ImportContent(sub, "ram:Name", name);
        }

        // XML methods
        /// <summary>Exports the Document as an XML file.</summary>
        /// <returns>a byte[] with the data in XML format</returns>
        /// <exception cref="Javax.Xml.Transform.TransformerException"/>
        public virtual byte[] ToXML() {
            RemoveEmptyNodes(doc);
            TransformerFactory transformerFactory = TransformerFactory.NewInstance();
            Transformer transformer = transformerFactory.NewTransformer();
            transformer.SetOutputProperty(OutputKeys.METHOD, "xml");
            transformer.SetOutputProperty(OutputKeys.INDENT, "yes");
            transformer.SetOutputProperty("{http://xml.apache.org/xslt}indent-amount", "4");
            DOMSource source = new DOMSource(doc);
            MemoryStream @out = new MemoryStream();
            Result result = new StreamResult(@out);
            transformer.Transform(source, result);
            return @out.ToArray();
        }

        /// <summary>
        /// It is forbidden for a ZUGFeRD XML to contain empty tags, hence
        /// we use this method recursively to remove empty nodes.
        /// </summary>
        /// <param name="node">the node from which we want to remove the empty nodes</param>
        protected internal static void RemoveEmptyNodes(Node node) {
            NodeList list = node.GetChildNodes();
            for (int i = list.GetLength() - 1; i >= 0; i--) {
                RemoveEmptyNodes(list.Item(i));
            }
            bool emptyElement = node.GetNodeType() == Node.ELEMENT_NODE && node.GetChildNodes().GetLength() == 0;
            bool emptyText = node.GetNodeType() == Node.TEXT_NODE && node.GetNodeValue().Trim().Length == 0;
            if (emptyElement || emptyText) {
                node.GetParentNode().RemoveChild(node);
            }
        }

        // helper methods
        /// <summary>Checks if a string is empty and throws a DataIncompleteException if so.</summary>
        /// <param name="s">the String to check</param>
        /// <param name="message">the message if an exception is thrown</param>
        /// <exception cref="iText.Zugferd.Exceptions.DataIncompleteException"/>
        protected internal virtual void Check(String s, String message) {
            if (s == null || s.Trim().Length == 0) {
                throw new DataIncompleteException(message);
            }
        }
    }
}
