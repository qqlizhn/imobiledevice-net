// <copyright file="MobileImageMounterErrorExtensions.cs" company="Quamotion">
// Copyright (c) 2016 Quamotion. All rights reserved.
// </copyright>

namespace iMobileDevice.MobileImageMounter
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
    public static class MobileImageMounterErrorExtensions
    {
        
        public static void ThrowOnError(this MobileImageMounterError value)
        {
            if ((value != MobileImageMounterError.Success))
            {
                throw new MobileImageMounterException(value);
            }
        }
        
        public static bool IsError(this MobileImageMounterError value)
        {
            return (value != MobileImageMounterError.Success);
        }
    }
}
