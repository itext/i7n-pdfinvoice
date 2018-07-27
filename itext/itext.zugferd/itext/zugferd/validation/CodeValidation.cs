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
using iText.Zugferd.Exceptions;

namespace iText.Zugferd.Validation {
    /// <summary>Abstract superclass of a series of code validation classes.</summary>
    public abstract class CodeValidation {
        /// <summary>Checks if a specific code is valid.</summary>
        /// <param name="code">the value you want to check</param>
        /// <returns>true if the code is valid</returns>
        public abstract bool IsValid(String code);

        /// <summary>Checks if a specific code is valid.</summary>
        /// <param name="code">the value you want to check</param>
        /// <returns>the code that has been checked</returns>
        /// <exception cref="iText.Zugferd.Exceptions.InvalidCodeException">the invalid code exception</exception>
        public virtual String Check(String code) {
            if (code == null || !IsValid(code)) {
                throw new InvalidCodeException(code, this.GetType().FullName);
            }
            return code;
        }

        /// <summary>Checks the length of a code and if a code consists of numbers only.</summary>
        /// <param name="code">the code that needs to be checked</param>
        /// <param name="digits">the expected length of the code</param>
        /// <returns>true if the code is numeric and has the expected length</returns>
        public virtual bool IsNumeric(String code, int digits) {
            if (code.Length != digits) {
                return false;
            }
            foreach (char c in code.ToCharArray()) {
                if (c < 48 || c > 57) {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks the length of a code and if a code consists of uppercase letters
        /// from A to Z.
        /// </summary>
        /// <param name="code">the code that needs to be checked</param>
        /// <param name="chars">the expected length of the code</param>
        /// <returns>true if the code consists of letters from A to Z and has the expected length</returns>
        public virtual bool IsUppercase(String code, int chars) {
            if (code.Length != chars) {
                return false;
            }
            foreach (char c in code.ToCharArray()) {
                if (c < 65 || c > 90) {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks the length of a code and if a code consists of lowercase letters
        /// from a to z.
        /// </summary>
        /// <param name="code">the code that needs to be checked</param>
        /// <param name="chars">the expected length of the code</param>
        /// <returns>true if the code consists of letters from a to z and has the expected length</returns>
        public virtual bool IsLowercase(String code, int chars) {
            if (code.Length != chars) {
                return false;
            }
            foreach (char c in code.ToCharArray()) {
                if (c < 97 || c > 122) {
                    return false;
                }
            }
            return true;
        }
    }
}
