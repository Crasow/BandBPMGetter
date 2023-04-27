using BandBPMGetter.Classes;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BandBPMGetter.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        IBluetoothManager bluetoothManager = DependencyService.Get<IBluetoothManager>();
        private IBluetoothLE bluetoothLE = CrossBluetoothLE.Current;
        DeviceFinder deviceFinder = new DeviceFinder();
        public MainViewModel()
        {
            var state = bluetoothLE.State;
            Title = "Connect page";
            BluetoothState = "Bluetooth is " + state;
            OpenWebCommand = new Command(BluetoothConnectMethod);
        }

        private void BluetoothConnectMethod(object obj)
        {
            if (bluetoothManager != null)
            {
                deviceFinder.Connect();
            }
        }

        public ICommand OpenWebCommand { get; }
    }
}