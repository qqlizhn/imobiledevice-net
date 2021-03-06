// <copyright file="PlistDictIterHandle.cs" company="Quamotion">
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
    
    
    [System.Security.Permissions.SecurityPermissionAttribute(System.Security.Permissions.SecurityAction.InheritanceDemand, UnmanagedCode=true)]
    [System.Security.Permissions.SecurityPermissionAttribute(System.Security.Permissions.SecurityAction.Demand, UnmanagedCode=true)]
    public partial class PlistDictIterHandle : Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid
    {
        
        protected PlistDictIterHandle() : 
                base(true)
        {
        }
        
        protected PlistDictIterHandle(bool ownsHandle) : 
                base(ownsHandle)
        {
        }
        
        public static PlistDictIterHandle Zero
        {
            get
            {
                return PlistDictIterHandle.DangerousCreate(System.IntPtr.Zero);
            }
        }
        
        [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute(System.Runtime.ConstrainedExecution.Consistency.WillNotCorruptState, System.Runtime.ConstrainedExecution.Cer.MayFail)]
        protected override bool ReleaseHandle()
        {
            return true;
        }
        
        public static PlistDictIterHandle DangerousCreate(System.IntPtr unsafeHandle, bool ownsHandle)
        {
            PlistDictIterHandle safeHandle;
            safeHandle = new PlistDictIterHandle(ownsHandle);
            safeHandle.SetHandle(unsafeHandle);
            return safeHandle;
        }
        
        public static PlistDictIterHandle DangerousCreate(System.IntPtr unsafeHandle)
        {
            return PlistDictIterHandle.DangerousCreate(unsafeHandle, true);
        }
    }
}
