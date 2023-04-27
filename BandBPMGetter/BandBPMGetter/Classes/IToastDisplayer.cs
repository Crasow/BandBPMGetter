using System;
using System.Collections.Generic;
using System.Text;

namespace BandBPMGetter.Classes
{
    public enum ToastType
    {
        Success, Warning, Danger, Info
    }
    public interface IToastDisplayer
    {
        void LongAlert(string message);
        void ShortAlert(string message, ToastType toastType);
    }
}
