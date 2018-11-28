using DOMINIO;
using Newtonsoft.Json;
using RESTAURANTE.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RESTAURANTE.VIEWS
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuCategoriasPage : ContentPage
	{
		public MenuCategoriasPage() { 
            CargarCategorias();
            InitializeComponent ();
		}
        private async void CargarCategorias()
        {
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://restauranteapis.azurewebsites.net/");
            var request = await cliente.GetAsync("/api/Categoria"); 
            if (request.IsSuccessStatusCode) 
            {
                var responseJSON = await request.Content.ReadAsStringAsync();                
                var respuesta = JsonConvert.DeserializeObject<List<Categoria>>(responseJSON);
                ListCategorias.ItemsSource = respuesta;
            }
            else
            {
                await DisplayAlert(AppResources.informacion, AppResources.problemas_conexion, "Ok");
            }
        }

        private async void Item_select(object sender, SelectedItemChangedEventArgs e)
        {
            var categoria = (Categoria)e.SelectedItem;
            await Navigation.PushAsync(new ProductosPage(categoria));
        }
    }
}