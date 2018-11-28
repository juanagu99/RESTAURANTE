using RESTAURANTE.Resources;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RESTAURANTE.VIEWS
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LlamarPage : ContentPage
	{
		public LlamarPage ()
		{
			InitializeComponent ();           
        }

        private async void btnllamar(object sender, EventArgs e)
        {
            await DisplayAlert(AppResources.informacion, AppResources.mesero_viene + " . . ", "Ok");
        }
    }
}