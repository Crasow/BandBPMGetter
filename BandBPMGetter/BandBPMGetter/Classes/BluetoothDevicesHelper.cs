using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BandBPMGetter.Classes
{
    internal class BluetoothDevicesHelper
    {
        IBluetoothManager _bluetoothManager;

        public BluetoothDevicesHelper()
        {
            _bluetoothManager = DependencyService.Get<IBluetoothManager>();
        }

        public void Connect()
        {
            _bluetoothManager.Connect();
        }
    }
}
