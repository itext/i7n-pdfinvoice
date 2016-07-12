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
using iText.IO;
using iText.IO.Log;
using iText.Kernel.Log;
using iText.Kernel.Pdf;
using iText.Kernel.XMP;
using iText.Pdfa;

using System.Collections.Generic;
using System.Reflection;
using Versions.Attributes;
using System.IO;
namespace iText.Zugferd {
    public class ZugferdDocument : PdfADocument {
        private ZugferdConformanceLevel zugferdConformanceLevel;

        public ZugferdDocument(PdfWriter writer, ZugferdConformanceLevel zugferdConformanceLevel, PdfAConformanceLevel
             pdfaConformanceLevel, PdfOutputIntent outputIntent)
            : base(writer, pdfaConformanceLevel, outputIntent) {
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
            this.zugferdConformanceLevel = zugferdConformanceLevel;
        }

        private static Type GetClass(string className)
        {
            String licenseKeyClassFullName = null;
            Assembly assembly = typeof(ZugferdDocument).Assembly;
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

        public ZugferdDocument(PdfWriter writer, ZugferdConformanceLevel zugferdConformanceLevel, PdfOutputIntent 
            outputIntent)
            : this(writer, zugferdConformanceLevel, PdfAConformanceLevel.PDF_A_3B, outputIntent) {
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
            ILogger logger = LoggerFactory.GetLogger(typeof(iText.Zugferd.ZugferdDocument));
            logger.Warn(ZugferdLogMessageConstant.WRONG_OR_NO_CONFORMANCE_LEVEL);
        }

        public ZugferdDocument(PdfWriter writer, PdfAConformanceLevel pdfaConformanceLevel, PdfOutputIntent outputIntent
            )
            : this(writer, ZugferdConformanceLevel.ZUGFeRDBasic, pdfaConformanceLevel, outputIntent) {
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
            ILogger logger = LoggerFactory.GetLogger(typeof(iText.Zugferd.ZugferdDocument));
            logger.Warn(ZugferdLogMessageConstant.NO_ZUGFERD_PROFILE_TYPE_SPECIFIED);
        }

        public ZugferdDocument(PdfWriter writer, PdfOutputIntent outputIntent)
            : this(writer, ZugferdConformanceLevel.ZUGFeRDBasic, PdfAConformanceLevel.PDF_A_3B, outputIntent) {
            ILogger logger = LoggerFactory.GetLogger(typeof(iText.Zugferd.ZugferdDocument));
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
            logger.Warn(ZugferdLogMessageConstant.WRONG_OR_NO_CONFORMANCE_LEVEL);
            logger.Warn(ZugferdLogMessageConstant.NO_ZUGFERD_PROFILE_TYPE_SPECIFIED);
        }

        protected override void AddCustomMetadataExtensions(XMPMeta xmpMeta) {
            base.AddCustomMetadataExtensions(xmpMeta);
            try {
                AddZugferdRdfDescription(xmpMeta, zugferdConformanceLevel);
            }
            catch (XMPException e) {
                ILogger logger = LoggerFactory.GetLogger(typeof(iText.Zugferd.ZugferdDocument));
                logger.Error(LogMessageConstant.EXCEPTION_WHILE_UPDATING_XMPMETADATA, e);
            }
        }

        protected override void SetChecker(PdfAConformanceLevel conformanceLevel) {
            if (!conformanceLevel.Equals(PdfAConformanceLevel.PDF_A_3B)) {
                ILogger logger = LoggerFactory.GetLogger(typeof(iText.Zugferd.ZugferdDocument));
                logger.Warn(ZugferdLogMessageConstant.WRONG_OR_NO_CONFORMANCE_LEVEL);
                checker = new ZugferdChecker(PdfAConformanceLevel.PDF_A_3B);
            }
            else {
                checker = new ZugferdChecker(conformanceLevel);
            }
        }

        protected override Counter GetCounter() {
            return CounterFactory.GetCounter(typeof(iText.Zugferd.ZugferdDocument));
        }

        /// <exception cref="iText.Kernel.XMP.XMPException"/>
        private void AddZugferdRdfDescription(XMPMeta xmpMeta, ZugferdConformanceLevel zugferdConformanceLevel) {
            switch (zugferdConformanceLevel) {
                case ZugferdConformanceLevel.ZUGFeRDBasic:
                case ZugferdConformanceLevel.ZUGFeRDComfort:
                case ZugferdConformanceLevel.ZUGFeRDExtended: {
                    XMPMeta taggedExtensionMetaComfort = XMPMetaFactory.ParseFromString(GetZugferdExtension(zugferdConformanceLevel
                        ));
                    XMPUtils.AppendProperties(taggedExtensionMetaComfort, xmpMeta, true, false);
                    break;
                }

                default: {
                    break;
                }
            }
        }

        private String GetZugferdExtension(ZugferdConformanceLevel conformanceLevel) {
            switch (conformanceLevel) {
                case ZugferdConformanceLevel.ZUGFeRDBasic: {
                    return String.Format(ZugferdXMPUtil.ZUGFERD_EXTENSION, "BASIC");
                }

                case ZugferdConformanceLevel.ZUGFeRDComfort: {
                    return String.Format(ZugferdXMPUtil.ZUGFERD_EXTENSION, "COMFORT");
                }

                case ZugferdConformanceLevel.ZUGFeRDExtended: {
                    return String.Format(ZugferdXMPUtil.ZUGFERD_EXTENSION, "EXTENDED");
                }

                default: {
                    return null;
                }
            }
        }
    }
}
