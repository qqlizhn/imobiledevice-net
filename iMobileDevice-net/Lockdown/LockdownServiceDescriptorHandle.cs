// <copyright file="LockdownServiceDescriptorHandle.cs" company="Quamotion">
// Copyright (c) 2016 Quamotion. All rights reserved.
// </copyright>

namespace iMobileDevice.Lockdown
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
#if !NETSTANDARD1_5
    [System.Security.Permissions.SecurityPermissionAttribute(System.Security.Permissions.SecurityAction.InheritanceDemand, UnmanagedCode=true)]
#endif
#if !NETSTANDARD1_5
    [System.Security.Permissions.SecurityPermissionAttribute(System.Security.Permissions.SecurityAction.Demand, UnmanagedCode=true)]
#endif
    public partial class LockdownServiceDescriptorHandle : Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid
    {
        
        protected LockdownServiceDescriptorHandle() : 
                base(true)
        {
        }
        
        protected LockdownServiceDescriptorHandle(bool ownsHandle) : 
                base(ownsHandle)
        {
        }
        
        public static LockdownServiceDescriptorHandle Zero
        {
            get
            {
                return LockdownServiceDescriptorHandle.DangerousCreate(System.IntPtr.Zero);
            }
        }
        
#if !NETSTANDARD1_5
        [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute(System.Runtime.ConstrainedExecution.Consistency.WillNotCorruptState, System.Runtime.ConstrainedExecution.Cer.MayFail)]
#endif
        protected override bool ReleaseHandle()
        {
            System.Diagnostics.Debug.WriteLine("Releasing {0} {1}", this.GetType().Name, this.handle);
            return (LibiMobileDevice.Instance.Lockdown.lockdownd_service_descriptor_free(this.handle) == LockdownError.Success);
        }
        
        public static LockdownServiceDescriptorHandle DangerousCreate(System.IntPtr unsafeHandle, bool ownsHandle)
        {
            LockdownServiceDescriptorHandle safeHandle;
            safeHandle = new LockdownServiceDescriptorHandle(ownsHandle);
            safeHandle.SetHandle(unsafeHandle);
            return safeHandle;
        }
        
        public static LockdownServiceDescriptorHandle DangerousCreate(System.IntPtr unsafeHandle)
        {
            return LockdownServiceDescriptorHandle.DangerousCreate(unsafeHandle, true);
        }
        
        public override string ToString()
        {
            return string.Format("{0} ({1})", this.handle, "LockdownServiceDescriptorHandle");
        }
        
        public override bool Equals(object obj)
        {
            if (((obj != null) & (obj.GetType() == typeof(LockdownServiceDescriptorHandle))))
            {
                return ((LockdownServiceDescriptorHandle)obj).handle.Equals(this.handle);
            }
            else
            {
                return false;
            }
        }
        
        public override int GetHashCode()
        {
            return this.handle.GetHashCode();
        }
    }
}
