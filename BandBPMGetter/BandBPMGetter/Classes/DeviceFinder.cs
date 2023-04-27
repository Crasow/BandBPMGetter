using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;
using Plugin.BLE.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace BandBPMGetter.Classes
{
    internal class DeviceFinder
    {
        private bool connectionState = false;
        private bool iSConnectingNow = false;

        private IAdapter adapter;
        private IDevice device;

        public delegate void ISBluetoothDeviceConnected(bool val);
        public static event ISBluetoothDeviceConnected DeviceConnected;
        private List<IDevice> deviceList = new List<IDevice>();
        private Guid guid = new Guid("129e28b0a-b73c-d52b-887f-1b8ecc0776f");

        public DeviceFinder()
        {
            adapter = CrossBluetoothLE.Current.Adapter;

            adapter.DeviceDiscovered += Adapter_DeviceDiscovered;
            //adapter.DeviceConnectionLost += Adapter_DeviceConnectionLost;
            //adapter.DeviceDisconnected += Adapter_DeviceDisconnected;
            adapter.ScanTimeoutElapsed += Adapter_ScanTimeoutElapsed;
        }
        public async void Connect()
        {
            if (connectionState != true && iSConnectingNow != true)
            {
                try
                {
                    await adapter.ConnectToKnownDeviceAsync(guid);
                }
                catch (DeviceConnectionException ex)
                {
                    Console.WriteLine("Could not connect to device: " + ex.Message);
                }
                //adapter.DeviceDiscovered += (s, a) => deviceList.Add(a.Device);
                await adapter.StartScanningForDevicesAsync();
                iSConnectingNow = true;
            }
            if (connectionState == true)
            {
            }
        }
        private void Adapter_DeviceDiscovered(object sender, DeviceEventArgs e)
        {
            try
            {
                bool a = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception in Adapter_DeviceDiscovered: " + ex.Message);
            }
        }
        private void Adapter_ScanTimeoutElapsed(object sender, EventArgs e)
        {
            iSConnectingNow = false;
            try
            {
                if (connectionState == false)
                {

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        DependencyService.Get<IToastDisplayer>().ShortAlert("MiBand не знайдено. Спробуйте знову!", ToastType.Warning);
                    });
                    DeviceConnected.Invoke(connectionState);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception in Adapter_ScanTimeoutElapsed: " + ex.Message);
            }
        }
    }
}
