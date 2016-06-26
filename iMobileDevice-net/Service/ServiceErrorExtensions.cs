// <copyright file="ServiceErrorExtensions.cs" company="Quamotion">
// Copyright (c) 2016 Quamotion. All rights reserved.
// </copyright>

namespace iMobileDevice.Service
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
    public static class ServiceErrorExtensions
    {
        
        public static void ThrowOnError(this ServiceError value)
        {
            if ((value != ServiceError.Success))
            {
                throw new ServiceException(value);
            }
        }
        
        public static bool IsError(this ServiceError value)
        {
            return (value != ServiceError.Success);
        }
    }
}
