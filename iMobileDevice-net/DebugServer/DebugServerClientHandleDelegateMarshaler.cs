// <copyright file="DebugServerClientHandleDelegateMarshaler.cs" company="Quamotion">
// Copyright (c) 2016 Quamotion. All rights reserved.
// </copyright>

namespace iMobileDevice.DebugServer
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
    public partial class DebugServerClientHandleDelegateMarshaler : System.Runtime.InteropServices.ICustomMarshaler
    {
        
        public static System.Runtime.InteropServices.ICustomMarshaler GetInstance(string cookie)
        {
            return new DebugServerClientHandleDelegateMarshaler();
        }
        
        public void CleanUpManagedData(object managedObject)
        {
        }
        
        public void CleanUpNativeData(System.IntPtr nativeData)
        {
        }
        
        public int GetNativeDataSize()
        {
            return -1;
        }
        
        public System.IntPtr MarshalManagedToNative(object managedObject)
        {
            return System.IntPtr.Zero;
        }
        
        public object MarshalNativeToManaged(System.IntPtr nativeData)
        {
            return DebugServerClientHandle.DangerousCreate(nativeData, false);
        }
    }
}
