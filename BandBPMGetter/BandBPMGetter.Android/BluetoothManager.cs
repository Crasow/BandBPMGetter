using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Telecom;
using Android.Views;
using BandBPMGetter.Classes;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using static AndroidX.RecyclerView.Widget.RecyclerView;

[assembly: Xamarin.Forms.Dependency(typeof(BandBPMGetter.Droid.BluetoothManager))]
namespace BandBPMGetter.Droid
{
    internal class BluetoothManager : IBluetoothManager
    {
        private string miBandAddress = "E0:84:E1:31:BA:12";
        private BluetoothAdapter mBluetoothAdapter = null;



        public BluetoothManager()
        {

        }
        public void Connect()
        {
            mBluetoothAdapter = BluetoothAdapter.DefaultAdapter;
            var device = mBluetoothAdapter.BondedDevices.Any(x => x.Address == miBandAddress);
            if (!mBluetoothAdapter.BondedDevices.Any(x => x.Address == miBandAddress))
            {
                DependencyService.Get<IToastDisplayer>().LongAlert("Для початку роботи з KTD-2-2 його потрiбно спарувати через Bluetooth налаштування пристрою");
                return;
            }
            else
            {
                DependencyService.Get<IToastDisplayer>().ShortAlert("Успех! Ты подключился к " + device, ToastType.Success);
            }


        }

    }
}