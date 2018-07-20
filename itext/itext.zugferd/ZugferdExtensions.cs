/*
    This file is part of the iText (R) project.
    Copyright (c) 1998-2018 iText Group NV
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
using System.IO;
using System.Linq;
using System.Reflection;

namespace iText.Zugferd {
    internal static class ZugferdExtensions {
        public static T[] ToArray<T>(this ICollection<T> col, T[] toArray) {
            T[] r;
            int colSize = col.Count;
            if (colSize <= toArray.Length) {
                col.CopyTo(toArray, 0);
                if (colSize != toArray.Length) {
                    toArray[colSize] = default(T);
                }
                r = toArray;
            } else {
                r = new T[colSize];
                col.CopyTo(r, 0);
            }

            return r;
        }

        public static String JSubstring(this String str, int beginIndex, int endIndex) {
            return str.Substring(beginIndex, endIndex - beginIndex);
        }
        
        #if !NETSTANDARD1_6
            public static Attribute GetCustomAttribute(this Assembly assembly, Type attributeType) {
                object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(attributeType, false);
                if (customAttributes.Length > 0 && customAttributes[0] is Attribute) {
                    return customAttributes[0] as Attribute;
                } else {
                    return null;
                }
            }
        #endif

            public static Assembly GetAssembly(this Type type) {
        #if !NETSTANDARD1_6
                return type.Assembly;
        #else
                return type.GetTypeInfo().Assembly;
        #endif
            }

        #if NETSTANDARD1_6
            public static MethodInfo GetMethod(this Type type, String methodName, Type[] parameterTypes) {
                return type.GetTypeInfo().GetMethod(methodName, parameterTypes);
            }

            public static MethodInfo GetMethod(this Type type, String methodName) {
                return type.GetTypeInfo().GetMethod(methodName);
            }

            public static ConstructorInfo GetConstructor(this Type type, Type[] parameterTypes) {
                return type.GetTypeInfo().GetConstructor(parameterTypes);
            }

            public static bool IsInstanceOfType(this Type type, object objToCheck) {
                return type.GetTypeInfo().IsInstanceOfType(objToCheck);
            }

            public static FieldInfo[] GetFields(this Type type, BindingFlags flags) {
                return type.GetTypeInfo().GetFields(flags);
            }

            public static byte[] GetBuffer(this MemoryStream memoryStream) {
                ArraySegment<byte> buf;
                memoryStream.TryGetBuffer(out buf);
                return buf.Array;
            }
        #endif
    }
}
