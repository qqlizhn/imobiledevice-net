// <copyright file="NotificationProxyErrorExtensions.cs" company="Quamotion">
// Copyright (c) 2016 Quamotion. All rights reserved.
// </copyright>

namespace iMobileDevice.NotificationProxy
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
    public static class NotificationProxyErrorExtensions
    {
        
        public static void ThrowOnError(this NotificationProxyError value)
        {
            if ((value != NotificationProxyError.Success))
            {
                throw new NotificationProxyException(value);
            }
        }
        
        public static bool IsError(this NotificationProxyError value)
        {
            return (value != NotificationProxyError.Success);
        }
    }
}
