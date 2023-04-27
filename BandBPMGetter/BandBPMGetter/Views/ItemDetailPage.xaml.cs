using BandBPMGetter.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace BandBPMGetter.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}