// <copyright file="SpringBoardServicesClientHandle.cs" company="Quamotion">
// Copyright (c) 2016 Quamotion. All rights reserved.
// </copyright>

namespace iMobileDevice.SpringBoardServices
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
    public partial class SpringBoardServicesClientHandle : Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid
    {
        
        protected SpringBoardServicesClientHandle() : 
                base(true)
        {
        }
        
        protected SpringBoardServicesClientHandle(bool ownsHandle) : 
                base(ownsHandle)
        {
        }
        
        public static SpringBoardServicesClientHandle Zero
        {
            get
            {
                return SpringBoardServicesClientHandle.DangerousCreate(System.IntPtr.Zero);
            }
        }
        
#if !NETSTANDARD1_5
        [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute(System.Runtime.ConstrainedExecution.Consistency.WillNotCorruptState, System.Runtime.ConstrainedExecution.Cer.MayFail)]
#endif
        protected override bool ReleaseHandle()
        {
            System.Diagnostics.Debug.WriteLine("Releasing {0} {1}", this.GetType().Name, this.handle);
            return (LibiMobileDevice.Instance.SpringBoardServices.sbservices_client_free(this.handle) == SpringBoardServicesError.Success);
        }
        
        public static SpringBoardServicesClientHandle DangerousCreate(System.IntPtr unsafeHandle, bool ownsHandle)
        {
            SpringBoardServicesClientHandle safeHandle;
            safeHandle = new SpringBoardServicesClientHandle(ownsHandle);
            safeHandle.SetHandle(unsafeHandle);
            return safeHandle;
        }
        
        public static SpringBoardServicesClientHandle DangerousCreate(System.IntPtr unsafeHandle)
        {
            return SpringBoardServicesClientHandle.DangerousCreate(unsafeHandle, true);
        }
        
        public override string ToString()
        {
            return string.Format("{0} ({1})", this.handle, "SpringBoardServicesClientHandle");
        }
        
        public override bool Equals(object obj)
        {
            if (((obj != null) & (obj.GetType() == typeof(SpringBoardServicesClientHandle))))
            {
                return ((SpringBoardServicesClientHandle)obj).handle.Equals(this.handle);
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
