// <copyright file="iDeviceNativeMethods.cs" company="Quamotion">
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
    
    
    public partial class iDeviceNativeMethods
    {
        
        public static iDeviceError idevice_get_device_list(out System.Collections.ObjectModel.ReadOnlyCollection<string> devices, ref int count)
        {
            System.Runtime.InteropServices.ICustomMarshaler devicesMarshaler = iDeviceListMarshaler.GetInstance(null);
            System.IntPtr devicesNative = System.IntPtr.Zero;
            iDeviceError returnValue = iDeviceNativeMethods.idevice_get_device_list(out devicesNative, ref count);
            devices = ((System.Collections.ObjectModel.ReadOnlyCollection<string>)devicesMarshaler.MarshalNativeToManaged(devicesNative));
            devicesMarshaler.CleanUpNativeData(devicesNative);
            return returnValue;
        }
        
        public static iDeviceError idevice_get_udid(iDeviceHandle device, out string udid)
        {
            System.Runtime.InteropServices.ICustomMarshaler udidMarshaler = NativeStringMarshaler.GetInstance(null);
            System.IntPtr udidNative = System.IntPtr.Zero;
            iDeviceError returnValue = iDeviceNativeMethods.idevice_get_udid(device, out udidNative);
            udid = ((string)udidMarshaler.MarshalNativeToManaged(udidNative));
            udidMarshaler.CleanUpNativeData(udidNative);
            return returnValue;
        }
    }
}
