using Android.App;
using Android.Graphics;
using Android.Widget;
using BandBPMGetter.Classes;

[assembly: Xamarin.Forms.Dependency(typeof(ARIS_C2_mobile.Droid.ToastHelper))]
namespace ARIS_C2_mobile.Droid
{
    public class ToastHelper : IToastDisplayer
    {
        public void LongAlert(string message)
        {
            using Toast toast = Toast.MakeText(Application.Context, message, ToastLength.Long);
            toast.View.SetBackgroundColor(Color.ParseColor("#FAA526"));
            toast.Show();
        }

        public void ShortAlert(string message, ToastType toastType)
        {
            using Toast toast = Toast.MakeText(Application.Context, message, ToastLength.Short);
            switch (toastType)
            {
                case ToastType.Success:
                    toast.View.SetBackgroundColor(Color.ParseColor("#19AE6F"));
                    break;
                case ToastType.Warning:
                    toast.View.SetBackgroundColor(Color.ParseColor("#FAA526"));
                    break;
                case ToastType.Danger:
                    toast.View.SetBackgroundColor(Color.ParseColor("#EA3B3B"));
                    break;
                case ToastType.Info:
                    toast.View.SetBackgroundColor(Color.ParseColor("#566372"));
                    break;
            }
            toast.Show();
        }
    }
}