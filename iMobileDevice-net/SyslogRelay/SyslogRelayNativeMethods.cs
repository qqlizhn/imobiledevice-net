// <copyright file="SyslogRelayNativeMethods.cs" company="Quamotion">
// Copyright (c) 2016 Quamotion. All rights reserved.
// </copyright>

namespace iMobileDevice.SyslogRelay
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
    public partial class SyslogRelayNativeMethods
    {
        
        const string libraryName = "libimobiledevice";
        
        /// <summary>
        /// Connects to the syslog_relay service on the specified device.
        /// </summary>
        /// <param name="device">
        /// The device to connect to.
        /// </param>
        /// <param name="service">
        /// The service descriptor returned by lockdownd_start_service.
        /// </param>
        /// <param name="client">
        /// Pointer that will point to a newly allocated
        /// syslog_relay_client_t upon successful return. Must be freed using
        /// syslog_relay_client_free() after use.
        /// </param>
        /// <returns>
        /// SYSLOG_RELAY_E_SUCCESS on success, SYSLOG_RELAY_E_INVALID_ARG when
        /// client is NULL, or an SYSLOG_RELAY_E_* error code otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute(SyslogRelayNativeMethods.libraryName, EntryPoint="syslog_relay_client_new", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern SyslogRelayError syslog_relay_client_new(iDeviceHandle device, LockdownServiceDescriptorHandle service, out SyslogRelayClientHandle client);
        
        /// <summary>
        /// Starts a new syslog_relay service on the specified device and connects to it.
        /// </summary>
        /// <param name="device">
        /// The device to connect to.
        /// </param>
        /// <param name="client">
        /// Pointer that will point to a newly allocated
        /// syslog_relay_client_t upon successful return. Must be freed using
        /// syslog_relay_client_free() after use.
        /// </param>
        /// <param name="label">
        /// The label to use for communication. Usually the program name.
        /// Pass NULL to disable sending the label in requests to lockdownd.
        /// </param>
        /// <returns>
        /// SYSLOG_RELAY_E_SUCCESS on success, or an SYSLOG_RELAY_E_* error
        /// code otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute(SyslogRelayNativeMethods.libraryName, EntryPoint="syslog_relay_client_start_service", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern SyslogRelayError syslog_relay_client_start_service(iDeviceHandle device, out SyslogRelayClientHandle client, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string label);
        
        /// <summary>
        /// Disconnects a syslog_relay client from the device and frees up the
        /// syslog_relay client data.
        /// </summary>
        /// <param name="client">
        /// The syslog_relay client to disconnect and free.
        /// </param>
        /// <returns>
        /// SYSLOG_RELAY_E_SUCCESS on success, SYSLOG_RELAY_E_INVALID_ARG when
        /// client is NULL, or an SYSLOG_RELAY_E_* error code otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute(SyslogRelayNativeMethods.libraryName, EntryPoint="syslog_relay_client_free", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern SyslogRelayError syslog_relay_client_free(System.IntPtr client);
        
        /// <summary>
        /// Starts capturing the syslog of the device using a callback.
        /// Use syslog_relay_stop_capture() to stop receiving the syslog.
        /// </summary>
        /// <param name="client">
        /// The syslog_relay client to use
        /// </param>
        /// <param name="callback">
        /// Callback to receive each character from the syslog.
        /// </param>
        /// <param name="user_data">
        /// Custom pointer passed to the callback function.
        /// </param>
        /// <returns>
        /// SYSLOG_RELAY_E_SUCCESS on success,
        /// SYSLOG_RELAY_E_INVALID_ARG when one or more parameters are
        /// invalid or SYSLOG_RELAY_E_UNKNOWN_ERROR when an unspecified
        /// error occurs or a syslog capture has already been started.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute(SyslogRelayNativeMethods.libraryName, EntryPoint="syslog_relay_start_capture", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern SyslogRelayError syslog_relay_start_capture(SyslogRelayClientHandle client, SyslogRelayReceiveCallBack callback, System.IntPtr userData);
        
        /// <summary>
        /// Stops capturing the syslog of the device.
        /// Use syslog_relay_start_capture() to start receiving the syslog.
        /// </summary>
        /// <param name="client">
        /// The syslog_relay client to use
        /// </param>
        /// <returns>
        /// SYSLOG_RELAY_E_SUCCESS on success,
        /// SYSLOG_RELAY_E_INVALID_ARG when one or more parameters are
        /// invalid or SYSLOG_RELAY_E_UNKNOWN_ERROR when an unspecified
        /// error occurs or a syslog capture has already been started.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute(SyslogRelayNativeMethods.libraryName, EntryPoint="syslog_relay_stop_capture", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern SyslogRelayError syslog_relay_stop_capture(SyslogRelayClientHandle client);
        
        /// <summary>
        /// Receives data using the given syslog_relay client with specified timeout.
        /// </summary>
        /// <param name="client">
        /// The syslog_relay client to use for receiving
        /// </param>
        /// <param name="data">
        /// Buffer that will be filled with the data received
        /// </param>
        /// <param name="size">
        /// Number of bytes to receive
        /// </param>
        /// <param name="received">
        /// Number of bytes received (can be NULL to ignore)
        /// </param>
        /// <param name="timeout">
        /// Maximum time in milliseconds to wait for data.
        /// </param>
        /// <returns>
        /// SYSLOG_RELAY_E_SUCCESS on success,
        /// SYSLOG_RELAY_E_INVALID_ARG when one or more parameters are
        /// invalid, SYSLOG_RELAY_E_MUX_ERROR when a communication error
        /// occurs, or SYSLOG_RELAY_E_UNKNOWN_ERROR when an unspecified
        /// error occurs.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute(SyslogRelayNativeMethods.libraryName, EntryPoint="syslog_relay_receive_with_timeout", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern SyslogRelayError syslog_relay_receive_with_timeout(SyslogRelayClientHandle client, byte[] data, uint size, ref uint received, uint timeout);
        
        /// <summary>
        /// Receives data from the service.
        /// </summary>
        /// <param name="client">
        /// The syslog_relay client
        /// </param>
        /// <param name="data">
        /// Buffer that will be filled with the data received
        /// </param>
        /// <param name="size">
        /// Number of bytes to receive
        /// </param>
        /// <param name="received">
        /// Number of bytes received (can be NULL to ignore)
        /// </param>
        /// <param name="timeout">
        /// Maximum time in milliseconds to wait for data.
        /// </param>
        /// <returns>
        /// SYSLOG_RELAY_E_SUCCESS on success,
        /// SYSLOG_RELAY_E_INVALID_ARG when client or plist is NULL
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute(SyslogRelayNativeMethods.libraryName, EntryPoint="syslog_relay_receive", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static extern SyslogRelayError syslog_relay_receive(SyslogRelayClientHandle client, byte[] data, uint size, ref uint received);
    }
}
