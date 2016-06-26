// <copyright file="PlistNativeMethods.cs" company="Quamotion">
// Copyright (c) 2016 Quamotion. All rights reserved.
// </copyright>

namespace iMobileDevice.Plist
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
    public partial class PlistNativeMethods
    {
        
        public static void plist_dict_next_item(PlistHandle node, PlistDictIterHandle iter, out string key, out PlistHandle val)
        {
            System.Runtime.InteropServices.ICustomMarshaler keyMarshaler = NativeStringMarshaler.GetInstance(null);
            System.IntPtr keyNative = System.IntPtr.Zero;
            PlistNativeMethods.plist_dict_next_item(node, iter, out keyNative, out val);
            key = ((string)keyMarshaler.MarshalNativeToManaged(keyNative));
            keyMarshaler.CleanUpNativeData(keyNative);
        }
        
        public static void plist_dict_get_item_key(PlistHandle node, out string key)
        {
            System.Runtime.InteropServices.ICustomMarshaler keyMarshaler = NativeStringMarshaler.GetInstance(null);
            System.IntPtr keyNative = System.IntPtr.Zero;
            PlistNativeMethods.plist_dict_get_item_key(node, out keyNative);
            key = ((string)keyMarshaler.MarshalNativeToManaged(keyNative));
            keyMarshaler.CleanUpNativeData(keyNative);
        }
        
        public static void plist_get_key_val(PlistHandle node, out string val)
        {
            System.Runtime.InteropServices.ICustomMarshaler valMarshaler = NativeStringMarshaler.GetInstance(null);
            System.IntPtr valNative = System.IntPtr.Zero;
            PlistNativeMethods.plist_get_key_val(node, out valNative);
            val = ((string)valMarshaler.MarshalNativeToManaged(valNative));
            valMarshaler.CleanUpNativeData(valNative);
        }
        
        public static void plist_get_string_val(PlistHandle node, out string val)
        {
            System.Runtime.InteropServices.ICustomMarshaler valMarshaler = NativeStringMarshaler.GetInstance(null);
            System.IntPtr valNative = System.IntPtr.Zero;
            PlistNativeMethods.plist_get_string_val(node, out valNative);
            val = ((string)valMarshaler.MarshalNativeToManaged(valNative));
            valMarshaler.CleanUpNativeData(valNative);
        }
        
        public static void plist_get_data_val(PlistHandle node, out string val, ref ulong length)
        {
            System.Runtime.InteropServices.ICustomMarshaler valMarshaler = NativeStringMarshaler.GetInstance(null);
            System.IntPtr valNative = System.IntPtr.Zero;
            PlistNativeMethods.plist_get_data_val(node, out valNative, ref length);
            val = ((string)valMarshaler.MarshalNativeToManaged(valNative));
            valMarshaler.CleanUpNativeData(valNative);
        }
        
        public static void plist_to_xml(PlistHandle plist, out string plistXml, ref uint length)
        {
            System.Runtime.InteropServices.ICustomMarshaler plistXmlMarshaler = NativeStringMarshaler.GetInstance(null);
            System.IntPtr plistXmlNative = System.IntPtr.Zero;
            PlistNativeMethods.plist_to_xml(plist, out plistXmlNative, ref length);
            plistXml = ((string)plistXmlMarshaler.MarshalNativeToManaged(plistXmlNative));
            plistXmlMarshaler.CleanUpNativeData(plistXmlNative);
        }
        
        public static void plist_to_bin(PlistHandle plist, out string plistBin, ref uint length)
        {
            System.Runtime.InteropServices.ICustomMarshaler plistBinMarshaler = NativeStringMarshaler.GetInstance(null);
            System.IntPtr plistBinNative = System.IntPtr.Zero;
            PlistNativeMethods.plist_to_bin(plist, out plistBinNative, ref length);
            plistBin = ((string)plistBinMarshaler.MarshalNativeToManaged(plistBinNative));
            plistBinMarshaler.CleanUpNativeData(plistBinNative);
        }
    }
}
