// <copyright file="iDeviceListMarshaler.cs" company="Quamotion">
// Copyright (c) 2016 Quamotion. All rights reserved.
// </copyright>

namespace iMobileDevice.iDevice
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
    public class iDeviceListMarshaler : NativeStringArrayMarshaler
    {
        
        public static System.Runtime.InteropServices.ICustomMarshaler GetInstance(string cookie)
        {
            return new iDeviceListMarshaler();
        }
        
        public override void CleanUpNativeData(System.IntPtr nativeData)
        {
            LibiMobileDevice.Instance.iDevice.idevice_device_list_free(nativeData).ThrowOnError();
        }
    }
}
