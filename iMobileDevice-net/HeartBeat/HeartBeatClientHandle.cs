// <copyright file="HeartBeatClientHandle.cs" company="Quamotion">
// Copyright (c) 2016 Quamotion. All rights reserved.
// </copyright>

namespace iMobileDevice.HeartBeat
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
    public partial class HeartBeatClientHandle : Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid
    {
        
        protected HeartBeatClientHandle() : 
                base(true)
        {
        }
        
        protected HeartBeatClientHandle(bool ownsHandle) : 
                base(ownsHandle)
        {
        }
        
        public static HeartBeatClientHandle Zero
        {
            get
            {
                return HeartBeatClientHandle.DangerousCreate(System.IntPtr.Zero);
            }
        }
        
#if !NETSTANDARD1_5
        [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute(System.Runtime.ConstrainedExecution.Consistency.WillNotCorruptState, System.Runtime.ConstrainedExecution.Cer.MayFail)]
#endif
        protected override bool ReleaseHandle()
        {
            System.Diagnostics.Debug.WriteLine("Releasing {0} {1}", this.GetType().Name, this.handle);
            return (LibiMobileDevice.Instance.HeartBeat.heartbeat_client_free(this.handle) == HeartBeatError.Success);
        }
        
        public static HeartBeatClientHandle DangerousCreate(System.IntPtr unsafeHandle, bool ownsHandle)
        {
            HeartBeatClientHandle safeHandle;
            safeHandle = new HeartBeatClientHandle(ownsHandle);
            safeHandle.SetHandle(unsafeHandle);
            return safeHandle;
        }
        
        public static HeartBeatClientHandle DangerousCreate(System.IntPtr unsafeHandle)
        {
            return HeartBeatClientHandle.DangerousCreate(unsafeHandle, true);
        }
        
        public override string ToString()
        {
            return string.Format("{0} ({1})", this.handle, "HeartBeatClientHandle");
        }
        
        public override bool Equals(object obj)
        {
            if (((obj != null) & (obj.GetType() == typeof(HeartBeatClientHandle))))
            {
                return ((HeartBeatClientHandle)obj).handle.Equals(this.handle);
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
