// <copyright file="PinvokeErrorExtensions.cs" company="Quamotion">
// Copyright (c) 2016 Quamotion. All rights reserved.
// </copyright>

namespace iMobileDevice.Pinvoke
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
    public static class PinvokeErrorExtensions
    {
        
        public static void ThrowOnError(this PinvokeError value)
        {
            if ((value != PinvokeError.Success))
            {
                throw new PinvokeException(value);
            }
        }
        
        public static bool IsError(this PinvokeError value)
        {
            return (value != PinvokeError.Success);
        }
    }
}
