// <copyright file="iDeviceApi.cs" company="Quamotion">
// Copyright (c) 2016 Quamotion. All rights reserved.
// </copyright>

namespace iMobileDevice.iDevice
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
    public partial class iDeviceApi : IiDeviceApi
    {
        
        /// <summary>
        /// Set the level of debugging.
        /// </summary>
        /// <param name="level">
        /// Set to 0 for no debug output or 1 to enable debug output.
        /// </param>
        public virtual void idevice_set_debug_level(int level)
        {
            iDeviceNativeMethods.idevice_set_debug_level(level);
        }
        
        /// <summary>
        /// Register a callback function that will be called when device add/remove
        /// events occur.
        /// </summary>
        /// <param name="callback">
        /// Callback function to call.
        /// </param>
        /// <param name="user_data">
        /// Application-specific data passed as parameter
        /// to the registered callback function.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS on success or an error value when an error occured.
        /// </returns>
        public virtual iDeviceError idevice_event_subscribe(iDeviceEventCallBack callback, System.IntPtr userData)
        {
            return iDeviceNativeMethods.idevice_event_subscribe(callback, userData);
        }
        
        /// <summary>
        /// Release the event callback function that has been registered with
        /// idevice_event_subscribe().
        /// </summary>
        /// <returns>
        /// IDEVICE_E_SUCCESS on success or an error value when an error occured.
        /// </returns>
        public virtual iDeviceError idevice_event_unsubscribe()
        {
            return iDeviceNativeMethods.idevice_event_unsubscribe();
        }
        
        /// <summary>
        /// Get a list of currently available devices.
        /// </summary>
        /// <param name="devices">
        /// List of udids of devices that are currently available.
        /// This list is terminated by a NULL pointer.
        /// </param>
        /// <param name="count">
        /// Number of devices found.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS on success or an error value when an error occured.
        /// </returns>
        public virtual iDeviceError idevice_get_device_list(out System.Collections.ObjectModel.ReadOnlyCollection<string> devices, ref int count)
        {
            return iDeviceNativeMethods.idevice_get_device_list(out devices, ref count);
        }
        
        /// <summary>
        /// Free a list of device udids.
        /// </summary>
        /// <param name="devices">
        /// List of udids to free.
        /// </param>
        /// <returns>
        /// Always returnes IDEVICE_E_SUCCESS.
        /// </returns>
        public virtual iDeviceError idevice_device_list_free(System.IntPtr devices)
        {
            return iDeviceNativeMethods.idevice_device_list_free(devices);
        }
        
        /// <summary>
        /// Creates an idevice_t structure for the device specified by udid,
        /// if the device is available.
        /// </summary>
        /// <param name="device">
        /// Upon calling this function, a pointer to a location of type
        /// idevice_t. On successful return, this location will be populated.
        /// </param>
        /// <param name="udid">
        /// The UDID to match.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS if ok, otherwise an error code.
        /// </returns>
        /// <remarks>
        /// The resulting idevice_t structure has to be freed with
        /// idevice_free() if it is no longer used.
        /// </remarks>
        public virtual iDeviceError idevice_new(out iDeviceHandle device, string udid)
        {
            return iDeviceNativeMethods.idevice_new(out device, udid);
        }
        
        /// <summary>
        /// Cleans up an idevice structure, then frees the structure itself.
        /// This is a library-level function; deals directly with the device to tear
        /// down relations, but otherwise is mostly internal.
        /// </summary>
        /// <param name="device">
        /// idevice_t to free.
        /// </param>
        public virtual iDeviceError idevice_free(System.IntPtr device)
        {
            return iDeviceNativeMethods.idevice_free(device);
        }
        
        /// <summary>
        /// Set up a connection to the given device.
        /// </summary>
        /// <param name="device">
        /// The device to connect to.
        /// </param>
        /// <param name="port">
        /// The destination port to connect to.
        /// </param>
        /// <param name="connection">
        /// Pointer to an idevice_connection_t that will be filled
        /// with the necessary data of the connection.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS if ok, otherwise an error code.
        /// </returns>
        public virtual iDeviceError idevice_connect(iDeviceHandle device, ushort port, out iDeviceConnectionHandle connection)
        {
            return iDeviceNativeMethods.idevice_connect(device, port, out connection);
        }
        
        /// <summary>
        /// Disconnect from the device and clean up the connection structure.
        /// </summary>
        /// <param name="connection">
        /// The connection to close.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS if ok, otherwise an error code.
        /// </returns>
        public virtual iDeviceError idevice_disconnect(System.IntPtr connection)
        {
            return iDeviceNativeMethods.idevice_disconnect(connection);
        }
        
        /// <summary>
        /// Send data to a device via the given connection.
        /// </summary>
        /// <param name="connection">
        /// The connection to send data over.
        /// </param>
        /// <param name="data">
        /// Buffer with data to send.
        /// </param>
        /// <param name="len">
        /// Size of the buffer to send.
        /// </param>
        /// <param name="sent_bytes">
        /// Pointer to an uint32_t that will be filled
        /// with the number of bytes actually sent.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS if ok, otherwise an error code.
        /// </returns>
        public virtual iDeviceError idevice_connection_send(iDeviceConnectionHandle connection, byte[] data, uint len, ref uint sentBytes)
        {
            return iDeviceNativeMethods.idevice_connection_send(connection, data, len, ref sentBytes);
        }
        
        /// <summary>
        /// Receive data from a device via the given connection.
        /// This function will return after the given timeout even if no data has been
        /// received.
        /// </summary>
        /// <param name="connection">
        /// The connection to receive data from.
        /// </param>
        /// <param name="data">
        /// Buffer that will be filled with the received data.
        /// This buffer has to be large enough to hold len bytes.
        /// </param>
        /// <param name="len">
        /// Buffer size or number of bytes to receive.
        /// </param>
        /// <param name="recv_bytes">
        /// Number of bytes actually received.
        /// </param>
        /// <param name="timeout">
        /// Timeout in milliseconds after which this function should
        /// return even if no data has been received.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS if ok, otherwise an error code.
        /// </returns>
        public virtual iDeviceError idevice_connection_receive_timeout(iDeviceConnectionHandle connection, byte[] data, uint len, ref uint recvBytes, uint timeout)
        {
            return iDeviceNativeMethods.idevice_connection_receive_timeout(connection, data, len, ref recvBytes, timeout);
        }
        
        /// <summary>
        /// Receive data from a device via the given connection.
        /// This function is like idevice_connection_receive_timeout, but with a
        /// predefined reasonable timeout.
        /// </summary>
        /// <param name="connection">
        /// The connection to receive data from.
        /// </param>
        /// <param name="data">
        /// Buffer that will be filled with the received data.
        /// This buffer has to be large enough to hold len bytes.
        /// </param>
        /// <param name="len">
        /// Buffer size or number of bytes to receive.
        /// </param>
        /// <param name="recv_bytes">
        /// Number of bytes actually received.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS if ok, otherwise an error code.
        /// </returns>
        public virtual iDeviceError idevice_connection_receive(iDeviceConnectionHandle connection, byte[] data, uint len, ref uint recvBytes)
        {
            return iDeviceNativeMethods.idevice_connection_receive(connection, data, len, ref recvBytes);
        }
        
        /// <summary>
        /// Enables SSL for the given connection.
        /// </summary>
        /// <param name="connection">
        /// The connection to enable SSL for.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS on success, IDEVICE_E_INVALID_ARG when connection
        /// is NULL or connection->ssl_data is non-NULL, or IDEVICE_E_SSL_ERROR when
        /// SSL initialization, setup, or handshake fails.
        /// </returns>
        public virtual iDeviceError idevice_connection_enable_ssl(iDeviceConnectionHandle connection)
        {
            return iDeviceNativeMethods.idevice_connection_enable_ssl(connection);
        }
        
        /// <summary>
        /// Disable SSL for the given connection.
        /// </summary>
        /// <param name="connection">
        /// The connection to disable SSL for.
        /// </param>
        /// <returns>
        /// IDEVICE_E_SUCCESS on success, IDEVICE_E_INVALID_ARG when connection
        /// is NULL. This function also returns IDEVICE_E_SUCCESS when SSL is not
        /// enabled and does no further error checking on cleanup.
        /// </returns>
        public virtual iDeviceError idevice_connection_disable_ssl(iDeviceConnectionHandle connection)
        {
            return iDeviceNativeMethods.idevice_connection_disable_ssl(connection);
        }
        
        /// <summary>
        /// Gets the handle of the device. Depends on the connection type.
        /// </summary>
        public virtual iDeviceError idevice_get_handle(iDeviceHandle device, ref uint handle)
        {
            return iDeviceNativeMethods.idevice_get_handle(device, ref handle);
        }
        
        /// <summary>
        /// Gets the unique id for the device.
        /// </summary>
        public virtual iDeviceError idevice_get_udid(iDeviceHandle device, out string udid)
        {
            return iDeviceNativeMethods.idevice_get_udid(device, out udid);
        }
    }
}
