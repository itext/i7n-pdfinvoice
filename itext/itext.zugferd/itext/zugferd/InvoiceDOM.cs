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
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using iText.IO.Util;
using System.Collections.Generic;
using System.Reflection;
using Versions.Attributes;
using System.IO;
using iText.Zugferd.Exceptions;
using iText.Zugferd.Profiles;
using iText.Zugferd.Validation;
using iText.Zugferd.Validation.Basic;
using iText.Zugferd.Validation.Comfort;

namespace iText.Zugferd {
    /// <summary>
    /// The Class InvoiceDOM.
    /// </summary>
    public class InvoiceDOM {
        private const String PRODUCT_NAME = "pdfInvoice";
        private const int PRODUCT_MAJOR = 1;
        private const int PRODUCT_MINOR = 0;

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

        protected internal readonly XDocument doc;

        private IDictionary<String, XNamespace> nsMapping = new Dictionary<string, XNamespace>();
        private XNamespace rsm;
        private XNamespace ram;

        /// <summary>Creates an object that will import data into an XML template.</summary>
        /// <param name="data">
        /// If this is an instance of BASICInvoice, the BASIC profile will be used;
        /// If this is an instance of COMFORTInvoice, the COMFORT profile will be used.
        /// </param>
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
            doc = XDocument.Load(ResourceUtil.GetResourceStream("iText.Zugferd.Xml.zugferd-template.xml", typeof(InvoiceDOM)));
            XElement root = doc.FirstNode as XElement;
            nsMapping["rsm"] = rsm = root.GetNamespaceOfPrefix("rsm");
            nsMapping["udt"] = root.GetNamespaceOfPrefix("udt");
            nsMapping["ram"] = ram = root.GetNamespaceOfPrefix("ram");
            // importing the data
            ImportData(root, data);
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
        private void ImportData(XElement doc, IBasicProfile data) {
            ImportSpecifiedExchangedDocumentContext(doc.Descendants(rsm + "SpecifiedExchangedDocumentContext").First(), data);
            ImportHeaderExchangedDocument(doc.Descendants(rsm + "HeaderExchangedDocument").First(), data
                );
            ImportSpecifiedSupplyChainTradeTransaction(doc.Descendants(rsm + "SpecifiedSupplyChainTradeTransaction").First(), data);
        }

        /// <summary>Imports the data for the following tag: rsm:SpecifiedExchangedDocumentContext</summary>
        /// <param name="element">the rsm:SpecifiedExchangedDocumentContext element</param>
        /// <param name="data">the invoice data</param>
        protected internal virtual void ImportSpecifiedExchangedDocumentContext(XElement element, IBasicProfile data
            ) {
            // TestIndicator (optional)
            ImportContent(element, "udt:Indicator", data.GetTestIndicator() ? "true" : "false");
        }

        /// <summary>Imports the data for the following tag: rsm:HeaderExchangedDocument.</summary>
        /// <param name="element">the rsm:HeaderExchangedDocument element</param>
        /// <param name="data">the invoice data</param>
        /// <exception cref="iText.Zugferd.Exceptions.DataIncompleteException"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportHeaderExchangedDocument(XElement element, IBasicProfile data) {
            // ID (required)
            Check(data.GetId(), "HeaderExchangedDocument > ID");
            ImportContent(element, "ram:ID", data.GetId());
            // Name (required)
            Check(data.GetName(), "HeaderExchangedDocument > Name");
            ImportContent(element, "ram:Name", data.GetName());
            // TypeCode (required)
            DocumentTypeCode dtCode =
                new DocumentTypeCode(data is IComfortProfile
                    ? DocumentTypeCode.COMFORT
                    : DocumentTypeCode
                        .BASIC);
            ImportContent(element, "ram:TypeCode", dtCode.Check(data.GetTypeCode()));
            // IssueDateTime (required)
            Check(data.GetDateTimeFormat(), "HeaderExchangedDocument > DateTimeString");
            ImportDateTime(element, "udt:DateTimeString", data.GetDateTimeFormat(), data.GetDateTime());
            // IncludedNote (optional): header level
            String[][] notes = data.GetNotes();
            String[] notesCodes = null;
            if (data is IComfortProfile) {
                notesCodes = ((IComfortProfile) data).GetNotesCodes();
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
        protected internal virtual void ImportContent(XElement parent, String tag, String content,
            params String[] attributes) {
            int colonIndex = tag.IndexOf(":");
            String ns = colonIndex != -1 ? tag.Substring(0, colonIndex) : null;
            XName name = ns != null ? nsMapping[ns] + tag.Substring(colonIndex + 1) : tag.Substring(colonIndex + 1);
            XElement node = parent.Descendants(name).First();
            // content
            node.Add(new XText(content ?? ""));
            // attributes
            if (attributes == null || attributes.Length == 0) {
                return;
            }
            int n = attributes.Length;
            String attrName;
            String attrValue;
            XAttribute attr;
            for (int i = 0; i < n; i++) {
                attrName = attributes[i];
                if (++i == n) {
                    continue;
                }
                attrValue = attributes[i];
                attr = node.Attribute(attrName);
                if (attr != null) {
                    attr.Value = attrValue;
                }
            }
        }

        /// <summary>Set the content of a date tag along with the attribute that defines the format.</summary>
        /// <param name="parent">the parent element that holds the date tag</param>
        /// <param name="tag">the date tag we want to change</param>
        /// <param name="dateTimeFormat">the format that will be used as an attribute</param>
        /// <param name="dateTime">the actual date</param>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportDateTime(XElement parent, String tag, String dateTimeFormat, DateTime
            dateTime) {
            if (dateTimeFormat == null) {
                return;
            }
            ImportContent(parent, tag, DF_CODE.ConvertToString(dateTime, DF_CODE.Check(dateTimeFormat)), "format",
                dateTimeFormat
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
        protected internal virtual void ImportIncludedNotes(XElement parent, int level, String[][] notes, String[]
            notesCodes) {
            if (notes == null) {
                return;
            }
            XElement includedNoteNode = parent.Descendants(ram + "IncludedNote").First();
            int n = notes.Length;
            FreeTextSubjectCode ftsCode = new FreeTextSubjectCode(level);
            if (notesCodes != null && n != notesCodes.Length) {
                throw new DataIncompleteException(
                    "Number of included notes is not equal to number of codes for included notes."
                    );
            }
            for (int i = 0; i < n; i++) {
                XElement noteNode = new XElement(includedNoteNode);
                XElement content = noteNode.Descendants(ram + "Content").First();
                foreach (String note in notes[i]) {
                    XElement newNode = new XElement(content);
                    newNode.Add(new XText(note));
                    content.AddBeforeSelf(newNode);
                }
                if (notesCodes != null) {
                    XElement code = noteNode.Descendants(ram + "SubjectCode").First();
                    code.Add(new XText(ftsCode.Check(notesCodes[i])));
                }
                includedNoteNode.AddBeforeSelf(noteNode);
            }
        }

        /// <summary>Imports the data for the following tag: rsm:SpecifiedSupplyChainTradeTransaction</summary>
        /// <param name="element"/>
        /// <param name="data">the invoice data</param>
        /// <exception cref="iText.Zugferd.Exceptions.DataIncompleteException"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportSpecifiedSupplyChainTradeTransaction(XElement element, IBasicProfile
            data) {
            IComfortProfile comfortData = null;
            if (data is IComfortProfile) {
                comfortData = (IComfortProfile) data;
            }
            /* ram:ApplicableSupplyChainTradeAgreement */
            // buyer reference (optional; comfort only)
            if (comfortData != null) {
                String buyerReference = comfortData.GetBuyerReference();
                ImportContent(element, "ram:BuyerReference", buyerReference);
            }
            // SellerTradeParty (required)
            Check(data.GetSellerName(),
                "SpecifiedSupplyChainTradeTransaction > ApplicableSupplyChainTradeAgreement > SellerTradeParty > Name"
                );
            ImportSellerTradeParty(element, data);
            // BuyerTradeParty (required)
            Check(data.GetBuyerName(),
                "SpecifiedSupplyChainTradeTransaction > ApplicableSupplyChainTradeAgreement > BuyerTradeParty > Name"
                );
            ImportBuyerTradeParty(element, data);
            /* ram:ApplicableSupplyChainTradeDelivery */
            if (comfortData != null) {
                // BuyerOrderReferencedDocument (optional)
                XElement document = element.Descendants(ram + "BuyerOrderReferencedDocument").First();
                ImportDateTime(document, "ram:IssueDateTime",
                    comfortData.GetBuyerOrderReferencedDocumentIssueDateTimeFormat
                        (), comfortData.GetBuyerOrderReferencedDocumentIssueDateTime());
                ImportContent(document, "ram:ID", comfortData.GetBuyerOrderReferencedDocumentID());
                // ContractReferencedDocument (optional)
                document = element.Descendants(ram + "ContractReferencedDocument").First();
                ImportDateTime(document, "ram:IssueDateTime",
                    comfortData.GetContractReferencedDocumentIssueDateTimeFormat
                        (), comfortData.GetContractReferencedDocumentIssueDateTime());
                ImportContent(document, "ram:ID", comfortData.GetContractReferencedDocumentID());
                // CustomerOrderReferencedDocument (optional)
                document = element.Descendants(ram + "CustomerOrderReferencedDocument").First();
                ImportDateTime(document, "ram:IssueDateTime",
                    comfortData.GetCustomerOrderReferencedDocumentIssueDateTimeFormat
                        (), comfortData.GetCustomerOrderReferencedDocumentIssueDateTime());
                ImportContent(document, "ram:ID", comfortData.GetCustomerOrderReferencedDocumentID());
            }
            /* ram:ApplicableSupplyChainTradeDelivery */
            // ActualDeliverySupplyChainEvent (optional)
            XElement parent = element.Descendants(ram + "ActualDeliverySupplyChainEvent").First();
            ImportDateTime(parent, "udt:DateTimeString", data.GetDeliveryDateTimeFormat(), data.GetDeliveryDateTime());
            // DeliveryNoteReferencedDocument (optional)
            if (comfortData != null) {
                XElement document = element.Descendants(ram + "DeliveryNoteReferencedDocument").First();
                ImportDateTime(document, "ram:IssueDateTime",
                    comfortData.GetDeliveryNoteReferencedDocumentIssueDateTimeFormat
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
            parent = element.Descendants(ram + "ApplicableSupplyChainTradeSettlement").First();
            ImportPaymentMeans(parent, data);
            // ram:ApplicableTradeTax
            ImportTax(parent, data);
            if (comfortData != null) {
                // ram:BillingSpecifiedPeriod
                XElement period = element.Descendants(ram + "BillingSpecifiedPeriod").First();
                XElement start = period.Descendants(ram + "StartDateTime").First();
                ImportDateTime(start, "udt:DateTimeString", comfortData.GetBillingStartDateTimeFormat(),
                    comfortData.GetBillingStartDateTime
                        ());
                // ContractReferencedDocument (optional)
                XElement end = period.Descendants(ram + "EndDateTime").First();
                ImportDateTime(end, "udt:DateTimeString", comfortData.GetBillingEndDateTimeFormat(),
                    comfortData.GetBillingEndDateTime
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
            Check(CURR_CODE.Check(data.GetLineTotalAmountCurrencyID()),
                "SpecifiedTradeSettlementMonetarySummation > LineTotalAmount . currencyID"
                );
            ImportContent(element, "ram:LineTotalAmount", data.GetLineTotalAmount(), "currencyID",
                data.GetLineTotalAmountCurrencyID
                    ());
            Check(DEC2.Check(data.GetChargeTotalAmount()),
                "SpecifiedTradeSettlementMonetarySummation > ChargeTotalAmount"
                );
            Check(CURR_CODE.Check(data.GetChargeTotalAmountCurrencyID()),
                "SpecifiedTradeSettlementMonetarySummation > ChargeTotalAmount . currencyID"
                );
            ImportContent(element, "ram:ChargeTotalAmount", data.GetChargeTotalAmount(), "currencyID",
                data.GetChargeTotalAmountCurrencyID
                    ());
            Check(DEC2.Check(data.GetAllowanceTotalAmount()),
                "SpecifiedTradeSettlementMonetarySummation > AllowanceTotalAmount"
                );
            Check(CURR_CODE.Check(data.GetAllowanceTotalAmountCurrencyID()),
                "SpecifiedTradeSettlementMonetarySummation > AllowanceTotalAmount . currencyID"
                );
            ImportContent(element, "ram:AllowanceTotalAmount", data.GetAllowanceTotalAmount(), "currencyID",
                data.GetAllowanceTotalAmountCurrencyID
                    ());
            Check(DEC2.Check(data.GetTaxBasisTotalAmount()),
                "SpecifiedTradeSettlementMonetarySummation > TaxBasisTotalAmount"
                );
            Check(CURR_CODE.Check(data.GetTaxBasisTotalAmountCurrencyID()),
                "SpecifiedTradeSettlementMonetarySummation > TaxBasisTotalAmount . currencyID"
                );
            ImportContent(element, "ram:TaxBasisTotalAmount", data.GetTaxBasisTotalAmount(), "currencyID",
                data.GetTaxBasisTotalAmountCurrencyID
                    ());
            Check(DEC2.Check(data.GetTaxTotalAmount()), "SpecifiedTradeSettlementMonetarySummation > TaxTotalAmount");
            Check(CURR_CODE.Check(data.GetTaxTotalAmountCurrencyID()),
                "SpecifiedTradeSettlementMonetarySummation > TaxTotalAmount . currencyID"
                );
            ImportContent(element, "ram:TaxTotalAmount", data.GetTaxTotalAmount(), "currencyID",
                data.GetTaxTotalAmountCurrencyID
                    ());
            Check(DEC2.Check(data.GetGrandTotalAmount()), "SpecifiedTradeSettlementMonetarySummation > GrandTotalAmount"
                );
            Check(CURR_CODE.Check(data.GetGrandTotalAmountCurrencyID()),
                "SpecifiedTradeSettlementMonetarySummation > GrandTotalAmount . currencyID"
                );
            ImportContent(element, "ram:GrandTotalAmount", data.GetGrandTotalAmount(), "currencyID",
                data.GetGrandTotalAmountCurrencyID
                    ());
            if (comfortData != null) {
                ImportContent(element, "ram:TotalPrepaidAmount", comfortData.GetTotalPrepaidAmount(), "currencyID",
                    comfortData
                        .GetTotalPrepaidAmountCurrencyID());
                ImportContent(element, "ram:DuePayableAmount", comfortData.GetDuePayableAmount(), "currencyID",
                    comfortData
                        .GetDuePayableAmountCurrencyID());
            }
            /* ram:IncludedSupplyChainTradeLineItem */
            if (comfortData != null) {
                ImportLineItemsComfort(element, comfortData);
            } else {
                ImportLineItemsBasic(element, data);
            }
        }

        /// <summary>Gets the seller trade party data to import this data.</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="data">the data</param>
        /// <exception cref="iText.Zugferd.Exceptions.DataIncompleteException"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportSellerTradeParty(XElement parent, IBasicProfile data) {
            String id = null;
            String[] globalID = null;
            String[] globalIDScheme = null;
            if (data is IComfortProfile) {
                id = ((IComfortProfile) data).GetSellerID();
                globalID = ((IComfortProfile) data).GetSellerGlobalID();
                globalIDScheme = ((IComfortProfile) data).GetSellerGlobalSchemeID();
            }
            String name = data.GetSellerName();
            String postcode = data.GetSellerPostcode();
            String lineOne = data.GetSellerLineOne();
            String lineTwo = data.GetSellerLineTwo();
            String cityName = data.GetSellerCityName();
            String countryID = data.GetSellerCountryID();
            String[] taxRegistrationID = data.GetSellerTaxRegistrationID();
            String[] taxRegistrationSchemeID = data.GetSellerTaxRegistrationSchemeID();
            ImportTradeParty(parent.Descendants(ram + "SellerTradeParty").First(), id, globalID, globalIDScheme
                , name, postcode, lineOne, lineTwo, cityName, countryID, taxRegistrationID, taxRegistrationSchemeID);
        }

        /// <summary>Gets the buyer trade party data to import this data.</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="data">the data</param>
        /// <exception cref="iText.Zugferd.Exceptions.DataIncompleteException"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportBuyerTradeParty(XElement parent, IBasicProfile data) {
            String id = null;
            String[] globalID = null;
            String[] globalIDScheme = null;
            if (data is IComfortProfile) {
                id = ((IComfortProfile) data).GetBuyerID();
                globalID = ((IComfortProfile) data).GetBuyerGlobalID();
                globalIDScheme = ((IComfortProfile) data).GetBuyerGlobalSchemeID();
            }
            String name = data.GetBuyerName();
            String postcode = data.GetBuyerPostcode();
            String lineOne = data.GetBuyerLineOne();
            String lineTwo = data.GetBuyerLineTwo();
            String cityName = data.GetBuyerCityName();
            String countryID = data.GetBuyerCountryID();
            String[] taxRegistrationID = data.GetBuyerTaxRegistrationID();
            String[] taxRegistrationSchemeID = data.GetBuyerTaxRegistrationSchemeID();
            ImportTradeParty(parent.Descendants(ram + "BuyerTradeParty").First(), id, globalID, globalIDScheme
                , name, postcode, lineOne, lineTwo, cityName, countryID, taxRegistrationID, taxRegistrationSchemeID);
        }

        /// <summary>Gets the invoicee party data to import this data.</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="data">the data</param>
        /// <exception cref="iText.Zugferd.Exceptions.DataIncompleteException"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportInvoiceeTradeParty(XElement parent, IComfortProfile data) {
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
            ImportTradeParty(parent.Descendants(ram + "InvoiceeTradeParty").First(), id, globalID, globalIDScheme
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
        protected internal virtual void ImportTradeParty(XElement parent, String id, String[] globalID,
            String[] globalIDScheme
            , String name, String postcode, String lineOne, String lineTwo, String cityName, String countryID, String
                [] taxRegistrationID, String[] taxRegistrationSchemeID) {
            XElement node;
            if (id != null) {
                node = parent.Descendants(ram + "ID").First();
                node.Add(new XText(id));
            }
            if (globalID != null) {
                int n = globalID.Length;
                if (globalIDScheme == null || globalIDScheme.Length != n) {
                    throw new DataIncompleteException(
                        "Number of global ID schemes is not equal to number of global IDs.");
                }
                node = parent.Descendants(ram + "GlobalID").First();
                for (int i = 0; i < n; i++) {
                    XElement idNode = new XElement(node);
                    idNode.Add(new XText(globalID[i]));
                    XAttribute schemeID = idNode.Attribute("schemeID");
                    schemeID.Value = GI_CODE.Check(globalIDScheme[i]);
                    node.AddBeforeSelf(idNode);
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
            XElement tax = parent.Descendants(ram + "SpecifiedTaxRegistration").First();
            node = tax.Descendants(ram + "ID").First();
            for (int i_1 = 0; i_1 < n_1; i_1++) {
                XElement idNode = new XElement(node);
                idNode.Add(new XText(taxRegistrationID[i_1]));
                XAttribute schemeID = idNode.Attribute("schemeID");
                schemeID.Value = TIDT_CODE.Check(taxRegistrationSchemeID[i_1]);

                node.AddBeforeSelf(idNode);
            }
        }

        /// <summary>Gets the payment means data to imports this data.</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="data">the data</param>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportPaymentMeans(XElement parent, IBasicProfile data) {
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
                IComfortProfile comfortData = (IComfortProfile) data;
                pmTypeCode = comfortData.GetPaymentMeansTypeCode();
                pmInformation = comfortData.GetPaymentMeansInformation();
                pmPayerIBAN = comfortData.GetPaymentMeansPayerAccountIBAN();
                pmPayerProprietaryID = comfortData.GetPaymentMeansPayerAccountProprietaryID();
                pmPayerBIC = comfortData.GetPaymentMeansPayerFinancialInstitutionBIC();
                pmPayerGermanBankleitzahlID = comfortData.GetPaymentMeansPayerFinancialInstitutionGermanBankleitzahlID();
                pmPayerFinancialInst = comfortData.GetPaymentMeansPayerFinancialInstitutionName();
            }
            XElement node = parent.Descendants(ram + "SpecifiedTradeSettlementPaymentMeans").First();
            for (int i = 0; i < pmID.Length; i++) {
                XElement newNode = new XElement(node);
                this.ImportPaymentMeans(newNode, pmTypeCode[i], pmInformation[i], pmID[i], pmSchemeAgencyID[i],
                    pmPayerIBAN
                        [i], pmPayerProprietaryID[i], pmIBAN[i], pmAccountName[i], pmAccountID[i], pmPayerBIC[i],
                    pmPayerGermanBankleitzahlID
                        [i], pmPayerFinancialInst[i], pmBIC[i], pmGermanBankleitzahlID[i], pmFinancialInst[i]);
                node.AddBeforeSelf(newNode);
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
        protected internal virtual void ImportPaymentMeans(XElement parent, String typeCode, String[] information,
            String id, String scheme, String payerIban, String payerProprietaryID, String iban, String accName, String
                accID, String payerBic, String payerBank, String payerInst, String bic, String bank, String inst) {
            if (typeCode != null) {
                ImportContent(parent, "ram:TypeCode", PM_CODE.Check(typeCode));
            }
            if (information != null) {
                XElement node = parent.Descendants(ram + "Information").First();
                foreach (String info in information) {
                    XElement newNode = new XElement(node);
                    newNode.Add(new XText(info));
                    node.AddBeforeSelf(newNode);
                }
            }
            ImportContent(parent, "ram:ID", id, "schemeAgencyID", scheme);
            XElement payer = parent.Descendants(ram + "PayerPartyDebtorFinancialAccount").First();
            ImportContent(payer, "ram:IBANID", payerIban);
            ImportContent(payer, "ram:ProprietaryID", payerProprietaryID);
            XElement payee = parent.Descendants(ram + "PayeePartyCreditorFinancialAccount").First();
            ImportContent(payee, "ram:IBANID", iban);
            ImportContent(payee, "ram:AccountName", accName);
            ImportContent(payee, "ram:ProprietaryID", accID);
            payer = parent.Descendants(ram + "PayerSpecifiedDebtorFinancialInstitution").First();
            ImportContent(payer, "ram:BICID", payerBic);
            ImportContent(payer, "ram:GermanBankleitzahlID", payerBank);
            ImportContent(payer, "ram:Name", payerInst);
            payee = parent.Descendants(ram + "PayeeSpecifiedCreditorFinancialInstitution").First();
            ImportContent(payee, "ram:BICID", bic);
            ImportContent(payee, "ram:GermanBankleitzahlID", bank);
            ImportContent(payee, "ram:Name", inst);
        }

        /// <summary>Gets tax data to import the this data.</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="data">the data</param>
        /// <exception cref="iText.Zugferd.Exceptions.DataIncompleteException"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportTax(XElement parent, IBasicProfile data) {
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
                IComfortProfile comfortData = (IComfortProfile) data;
                exemptionReason = comfortData.GetTaxExemptionReason();
                category = comfortData.GetTaxCategoryCode();
            }
            XElement node = parent.Descendants(ram + "ApplicableTradeTax").First();
            for (int i = 0; i < n; i++) {
                XElement newNode = new XElement(node);
                this.ImportTax(newNode, calculated[i], calculatedCurr[i], typeCode[i], exemptionReason[i], basisAmount
                    [i], basisAmountCurr[i], category[i], percent[i]);
                node.AddBeforeSelf(newNode);
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
        protected internal virtual void ImportTax(XElement parent, String calculatedAmount, String currencyID, String
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
        protected internal virtual void ImportSpecifiedTradeAllowanceCharge(XElement parent, IComfortProfile data) {
            bool[] indicator = data.GetSpecifiedTradeAllowanceChargeIndicator();
            String[] actualAmount = data.GetSpecifiedTradeAllowanceChargeActualAmount();
            String[] actualAmountCurr = data.GetSpecifiedTradeAllowanceChargeActualAmountCurrency();
            String[] reason = data.GetSpecifiedTradeAllowanceChargeReason();
            String[][] typeCode = data.GetSpecifiedTradeAllowanceChargeTaxTypeCode();
            String[][] categoryCode = data.GetSpecifiedTradeAllowanceChargeTaxCategoryCode();
            String[][] percent = data.GetSpecifiedTradeAllowanceChargeTaxApplicablePercent();
            XElement node = parent.Descendants(ram + "SpecifiedTradeAllowanceCharge").First();
            for (int i = 0; i < indicator.Length; i++) {
                XElement newNode = new XElement(node);
                this.ImportSpecifiedTradeAllowanceCharge(newNode, indicator[i], actualAmount[i], actualAmountCurr
                    [i], reason[i], typeCode[i], categoryCode[i], percent[i]);
                node.AddBeforeSelf(newNode);
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
        protected internal virtual void ImportSpecifiedTradeAllowanceCharge(XElement parent, bool indicator, String
            actualAmount, String actualAmountCurrency, String reason, String[] typeCode, String[] categoryCode, String
                [] percent) {
            ImportContent(parent, "udt:Indicator", indicator ? "true" : "false");
            ImportContent(parent, "ram:ActualAmount", DEC4.Check(actualAmount), "currencyID",
                CURR_CODE.Check(actualAmountCurrency
                    ));
            ImportContent(parent, "ram:Reason", reason);
            XElement node = parent.Descendants(ram + "CategoryTradeTax").First();
            for (int i = 0; i < typeCode.Length; i++) {
                XElement newNode = new XElement(node);
                ImportContent(newNode, "ram:TypeCode", TT_CODE.Check(typeCode[i]));
                ImportContent(newNode, "ram:CategoryCode", TC_CODE.Check(categoryCode[i]));
                ImportContent(newNode, "ram:ApplicablePercent", DEC2.Check(percent[i]));
                node.AddBeforeSelf(newNode);
            }
        }

        /// <summary>Gets specified logistics service charge data to import the this data.</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="data">the data</param>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportSpecifiedLogisticsServiceCharge(XElement parent, IComfortProfile data
            ) {
            String[][] description = data.GetSpecifiedLogisticsServiceChargeDescription();
            String[] appliedAmount = data.GetSpecifiedLogisticsServiceChargeAmount();
            String[] appliedAmountCurr = data.GetSpecifiedLogisticsServiceChargeAmountCurrency();
            String[][] typeCode = data.GetSpecifiedLogisticsServiceChargeTaxTypeCode();
            String[][] categoryCode = data.GetSpecifiedLogisticsServiceChargeTaxCategoryCode();
            String[][] percent = data.GetSpecifiedLogisticsServiceChargeTaxApplicablePercent();
            XElement node = parent.Descendants(ram + "SpecifiedLogisticsServiceCharge").First();
            for (int i = 0; i < appliedAmount.Length; i++) {
                XElement newNode = new XElement(node);
                this.ImportSpecifiedLogisticsServiceCharge(newNode, description[i], appliedAmount[i], appliedAmountCurr
                    [i], typeCode[i], categoryCode[i], percent[i]);
                node.AddBeforeSelf(newNode);
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
        protected internal virtual void ImportSpecifiedLogisticsServiceCharge(XElement parent, String[] description
            , String appliedAmount, String currencyID, String[] typeCode, String[] categoryCode, String[] percent) {
            XElement node = parent.Descendants(ram + "Description").First();
            foreach (String d in description) {
                XElement newNode = new XElement(node);
                newNode.Add(new XText(d));
                node.AddBeforeSelf(newNode);
            }
            ImportContent(parent, "ram:AppliedAmount", DEC4.Check(appliedAmount), "currencyID",
                CURR_CODE.Check(currencyID
                    ));
            node = parent.Descendants(ram + "AppliedTradeTax").First();
            for (int i = 0; i < typeCode.Length; i++) {
                XElement newNode = new XElement(node);
                ImportContent(newNode, "ram:TypeCode", TT_CODE.Check(typeCode[i]));
                ImportContent(newNode, "ram:CategoryCode", TC_CODE.Check(categoryCode[i]));
                ImportContent(newNode, "ram:ApplicablePercent", DEC2.Check(percent[i]));
                node.AddBeforeSelf(newNode);
            }
        }

        /// <summary>Gets specified trade payment terms data to import the this data.</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="data">the data</param>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportSpecifiedTradePaymentTerms(XElement parent, IComfortProfile data) {
            String[][] description = data.GetSpecifiedTradePaymentTermsDescription();
            DateTime[] dateTime = data.GetSpecifiedTradePaymentTermsDueDateTime();
            String[] dateTimeFormat = data.GetSpecifiedTradePaymentTermsDueDateTimeFormat();
            XElement node = parent.Descendants(ram + "SpecifiedTradePaymentTerms").First();
            for (int i = 0; i < description.Length; i++) {
                XElement newNode = new XElement(node);
                this.ImportSpecifiedTradePaymentTerms(newNode, description[i], dateTime[i], dateTimeFormat[i]);
                node.AddBeforeSelf(newNode);
            }
        }

        /// <summary>Imports specified trade payment terms.</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="description"/>
        /// <param name="dateTime"/>
        /// <param name="dateTimeFormat"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportSpecifiedTradePaymentTerms(XElement parent, String[] description, DateTime
            dateTime, String dateTimeFormat) {
            XElement node = parent.Descendants(ram + "Description").First();
            foreach (String d in description) {
                XElement newNode = new XElement(node);
                newNode.Add(new XText(d));
                node.AddBeforeSelf(newNode);
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
        protected internal virtual void ImportLineItemsComfort(XElement parent, IComfortProfile data) {
            String[] lineIDs = data.GetLineItemLineID();
            if (lineIDs.Length == 0) {
                throw new DataIncompleteException("You can create an invoice without any line items");
            }
            String[][][] includedNote = data.GetLineItemIncludedNote();
            String[] grossPriceChargeAmount = data.GetLineItemGrossPriceChargeAmount();
            String[] grossPriceChargeAmountCurrencyID = data.GetLineItemGrossPriceChargeAmountCurrencyID();
            String[] grossPriceBasisQuantity = data.GetLineItemGrossPriceBasisQuantity();
            String[] grossPriceBasisQuantityCode = data.GetLineItemGrossPriceBasisQuantityCode();
            bool[][] grossPriceTradeAllowanceChargeIndicator = data.GetLineItemGrossPriceTradeAllowanceChargeIndicator
                ();
            String[][] grossPriceTradeAllowanceChargeActualAmount =
                data.GetLineItemGrossPriceTradeAllowanceChargeActualAmount
                    ();
            String[][] grossPriceTradeAllowanceChargeActualAmountCurrencyID =
                data.GetLineItemGrossPriceTradeAllowanceChargeActualAmountCurrencyID
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
            XElement node = parent.Descendants(ram + "IncludedSupplyChainTradeLineItem").First();
            for (int i = 0; i < lineIDs.Length; i++) {
                XElement newNode = new XElement(node);
                ImportLineItemComfort(newNode, lineIDs[i], includedNote[i], grossPriceChargeAmount[i],
                    grossPriceChargeAmountCurrencyID
                        [i], grossPriceBasisQuantity[i], grossPriceBasisQuantityCode[i],
                    grossPriceTradeAllowanceChargeIndicator
                        [i], grossPriceTradeAllowanceChargeActualAmount[i],
                    grossPriceTradeAllowanceChargeActualAmountCurrencyID
                        [i], grossPriceTradeAllowanceChargeReason[i], netPriceChargeAmount[i],
                    netPriceChargeAmountCurrencyID[
                        i], netPriceBasisQuantity[i], netPriceBasisQuantityCode[i], billedQuantity[i],
                    billedQuantityUnitCode[
                        i], settlementTaxTypeCode[i], settlementTaxExemptionReason[i], settlementTaxCategoryCode[i],
                    settlementTaxApplicablePercent
                        [i], totalAmount[i], totalAmountCurrencyID[i], specifiedTradeProductGlobalID[i],
                    specifiedTradeProductSchemeID
                        [i], specifiedTradeProductSellerAssignedID[i], specifiedTradeProductBuyerAssignedID[i],
                    specifiedTradeProductName
                        [i], specifiedTradeProductDescription[i]);
                node.AddBeforeSelf(newNode);
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
        protected internal virtual void ImportLineItemComfort(XElement parent, String lineID, String[][] note, String
            grossPriceChargeAmount, String grossPriceChargeAmountCurrencyID, String grossPriceBasisQuantity, String
                grossPriceBasisQuantityCode, bool[] grossPriceTradeAllowanceChargeIndicator,
            String[] grossPriceTradeAllowanceChargeActualAmount
            , String[] grossPriceTradeAllowanceChargeActualAmountCurrencyID,
            String[] grossPriceTradeAllowanceChargeReason
            , String netPriceChargeAmount, String netPriceChargeAmountCurrencyID, String netPriceBasisQuantity, String
                netPriceBasisQuantityCode, String billedQuantity, String billedQuantityCode,
            String[] settlementTaxTypeCode
            , String[] settlementTaxExemptionReason, String[] settlementTaxCategoryCode,
            String[] settlementTaxApplicablePercent
            , String totalAmount, String totalAmountCurrencyID, String specifiedTradeProductGlobalID,
            String specifiedTradeProductSchemeID
            , String specifiedTradeProductSellerAssignedID, String specifiedTradeProductBuyerAssignedID,
            String specifiedTradeProductName
            , String specifiedTradeProductDescription) {
            /* ram:AssociatedDocumentLineDocument */
            XElement sub = parent.Descendants(ram + "AssociatedDocumentLineDocument").First();
            ImportContent(sub, "ram:LineID", lineID);
            ImportIncludedNotes(sub, FreeTextSubjectCode.LINE, note, null);
            /* ram:SpecifiedSupplyChainTradeAgreement */
            // ram:GrossPriceProductTradePrice
            if (grossPriceChargeAmount != null) {
                sub = parent.Descendants(ram + "GrossPriceProductTradePrice").First();
                ImportContent(sub, "ram:ChargeAmount", DEC4.Check(grossPriceChargeAmount), "currencyID",
                    CURR_CODE.Check(grossPriceChargeAmountCurrencyID
                        ));
                if (grossPriceBasisQuantity != null) {
                    ImportContent(sub, "ram:BasisQuantity", DEC4.Check(grossPriceBasisQuantity), "unitCode",
                        M_UNIT_CODE.Check
                            (grossPriceBasisQuantityCode));
                }
                XElement node = sub.Descendants(ram + "AppliedTradeAllowanceCharge").First();
                if (grossPriceTradeAllowanceChargeIndicator != null) {
                    for (int i = 0; i < grossPriceTradeAllowanceChargeIndicator.Length; i++) {
                        XElement newNode = new XElement(node);
                        ImportAppliedTradeAllowanceCharge(newNode, grossPriceTradeAllowanceChargeIndicator[i],
                            grossPriceTradeAllowanceChargeActualAmount
                                [i], grossPriceTradeAllowanceChargeActualAmountCurrencyID[i],
                            grossPriceTradeAllowanceChargeReason[i]);
                        node.AddBeforeSelf(newNode);
                    }
                }
            }
            // ram:NetPriceProductTradePrice
            if (netPriceChargeAmount != null) {
                sub = parent.Descendants(ram + "NetPriceProductTradePrice").First();
                ImportContent(sub, "ram:ChargeAmount", DEC4.Check(netPriceChargeAmount), "currencyID",
                    CURR_CODE.Check(netPriceChargeAmountCurrencyID
                        ));
                if (netPriceBasisQuantity != null) {
                    ImportContent(sub, "ram:BasisQuantity", DEC4.Check(netPriceBasisQuantity), "unitCode",
                        M_UNIT_CODE.Check(netPriceBasisQuantityCode
                            ));
                }
            }
            /* ram:SpecifiedSupplyChainTradeDelivery */
            sub = parent.Descendants(ram + "SpecifiedSupplyChainTradeDelivery").First();
            ImportContent(sub, "ram:BilledQuantity", DEC4.Check(billedQuantity), "unitCode",
                M_UNIT_CODE.Check(billedQuantityCode
                    ));
            /* ram:SpecifiedSupplyChainTradeSettlement */
            sub = parent.Descendants(ram + "SpecifiedSupplyChainTradeSettlement").First();
            XElement node_1 = sub.Descendants(ram + "ApplicableTradeTax").First();
            for (int i_1 = 0; i_1 < settlementTaxApplicablePercent.Length; i_1++) {
                XElement newNode = new XElement(node_1);
                this.ImportTax(newNode, settlementTaxTypeCode[i_1], settlementTaxExemptionReason[i_1],
                    settlementTaxCategoryCode
                        [i_1], settlementTaxApplicablePercent[i_1]);
                node_1.AddBeforeSelf(newNode);
            }
            ImportContent(sub, "ram:LineTotalAmount", totalAmount, "currencyID", totalAmountCurrencyID);
            /* ram:SpecifiedTradeProduct */
            sub = parent.Descendants(ram + "SpecifiedTradeProduct").First();
            if (specifiedTradeProductGlobalID != null) {
                ImportContent(sub, "ram:GlobalID", specifiedTradeProductGlobalID, "schemeID",
                    GI_CODE.Check(specifiedTradeProductSchemeID
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
        protected internal virtual void ImportAppliedTradeAllowanceCharge(XElement parent, bool indicator,
            String actualAmount
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
        protected internal virtual void ImportTax(XElement parent, String typeCode, String exemptionReason, String
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
        protected internal virtual void ImportLineItemsBasic(XElement parent, IBasicProfile data) {
            String[] quantity = data.GetLineItemBilledQuantity();
            if (quantity.Length == 0) {
                throw new DataIncompleteException("You can create an invoice without any line items");
            }
            String[] quantityCode = data.GetLineItemBilledQuantityUnitCode();
            String[] name = data.GetLineItemSpecifiedTradeProductName();
            XElement node = parent.Descendants(ram + "IncludedSupplyChainTradeLineItem").First();
            for (int i = 0; i < quantity.Length; i++) {
                XElement newNode = new XElement(node);
                ImportLineItemBasic(newNode, quantity[i], quantityCode[i], name[i]);
                node.AddBeforeSelf(newNode);
            }
        }

        /// <summary>Imports the data for a line item (basic profile)</summary>
        /// <param name="parent">the parent element</param>
        /// <param name="quantity"/>
        /// <param name="code"/>
        /// <param name="name"/>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException"/>
        protected internal virtual void ImportLineItemBasic(XElement parent, String quantity, String code, String name) {
            XElement sub = parent.Descendants(ram + "SpecifiedSupplyChainTradeDelivery").First();
            ImportContent(sub, "ram:BilledQuantity", DEC4.Check(quantity), "unitCode", M_UNIT_CODE.Check(code));
            sub = parent.Descendants(ram + "SpecifiedTradeProduct").First();
            ImportContent(sub, "ram:Name", name);
        }

        // XML methods
        /// <summary>Exports the Document as an XML file.</summary>
        /// <returns>a byte[] with the data in XML format</returns>
        /// <exception cref="Javax.Xml.Transform.TransformerException"/>
        public virtual byte[] ToXML() {
            RemoveEmptyNodes(doc.FirstNode);
            MemoryStream fout = new MemoryStream();
            if (doc != null) {
                XmlWriterSettings settings = new XmlWriterSettings {
                    Encoding = new UpperCaseUTF8Encoding(false),
                    OmitXmlDeclaration = !(doc is XDocument),
                    Indent = true,
                    IndentChars = "    "
                };
                XmlWriter writer = XmlWriter.Create(fout, settings);
                doc.WriteTo(writer);
#if !NETSTANDARD1_6
                writer.Close();
#else
                writer.Dispose();
#endif
            }
            fout.Dispose();
            return fout.ToArray();
        }

        /// <summary>
        /// It is forbidden for a ZUGFeRD XML to contain empty tags, hence
        /// we use this method recursively to remove empty nodes.
        /// </summary>
        /// <param name="node">the node from which we want to remove the empty nodes</param>
        protected internal static void RemoveEmptyNodes(XNode node) {
            if (node is XText && (node as XText).Value.Trim().Length == 0)
                node.Remove();
            else if (node is XElement) {
                XElement el = node as XElement;
                XNode[] children = el.Nodes().ToArray();
                foreach (XNode child in children) {
                    RemoveEmptyNodes(child);
                }

                XAttribute[] attrs = el.Attributes().ToArray();
                foreach (XAttribute attr in attrs) {
                    if (attr.Value.Trim().Length == 0) {
                        attr.Remove();
                    }
                }

                if (!el.HasAttributes && !el.Nodes().Any()) {
                    el.Remove();
                }
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

        private class UpperCaseUTF8Encoding : UTF8Encoding {
            // Code from a blog http://www.distribucon.com/blog/CategoryView,category,XML.aspx
            //
            // Dan Miser - Thoughts from Dan Miser
            // Tuesday, January 29, 2008 
            // He used the Reflector to understand the heirarchy of the encoding class
            //
            //      Back to Reflector, and I notice that the Encoding.WebName is the property used to
            //      write out the encoding string. I now create a descendant class of UTF8Encoding.
            //      The class is listed below. Now I just call XmlTextWriter, passing in
            //      UpperCaseUTF8Encoding.UpperCaseUTF8 for the Encoding type, and everything works
            //      perfectly. - Dan Miser

            public UpperCaseUTF8Encoding() : base() {
            }

            public UpperCaseUTF8Encoding(bool encoderShouldEmitUTF8Identifier) : base(encoderShouldEmitUTF8Identifier) {
            }

            public override string WebName {
                get { return base.WebName.ToUpper(); }
            }

            public static UpperCaseUTF8Encoding UpperCaseUTF8 {
                get {
                    if (upperCaseUtf8Encoding == null) {
                        upperCaseUtf8Encoding = new UpperCaseUTF8Encoding();
                    }
                    return upperCaseUtf8Encoding;
                }
            }

            private static UpperCaseUTF8Encoding upperCaseUtf8Encoding = null;
        }
    }
}
