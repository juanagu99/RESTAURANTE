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
	public partial class PagarPage : ContentPage
	{
		public PagarPage ()
		{
			InitializeComponent ();
		}
        private async void btnefectivo(object sender, EventArgs e)
        {
            if (App.session_pedido.confirmado == false)
            {
                await DisplayAlert(AppResources.informacion, AppResources.pedido_vacio, "Ok");
            }
            else {
                double cuenta=0;
                var list_productos = new List<Producto>();
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri("https://restauranteapis.azurewebsites.net/");
                var request1 = await cliente.GetAsync("/api/Producto");
                if (request1.IsSuccessStatusCode)
                {
                    var responseJSON = await request1.Content.ReadAsStringAsync();
                    list_productos = JsonConvert.DeserializeObject<List<Producto>>(responseJSON);
                }
                var request2 = await cliente.GetAsync("/api/ProductoxPedido");
                if (request2.IsSuccessStatusCode)
                {
                    var responseJSON = await request2.Content.ReadAsStringAsync();
                    var respuesta = JsonConvert.DeserializeObject<List<ProductoxPedido>>(responseJSON);
                    foreach (ProductoxPedido x in respuesta)
                    {
                        if (x.NumeroPedido == App.session_pedido.NumeroPedido )
                        {
                            var op = (x.Cantidad) * (list_productos.FirstOrDefault(y => y.NombreProducto == x.NombreProducto).Precio);
                            cuenta += (op);
                        }
                    }
                }
                else
                {
                    await DisplayAlert(AppResources.informacion, AppResources.problemas_conexion, "Ok");
                }
                string c = AppResources.total+ ": " + cuenta + " $";
                await DisplayAlert(AppResources.informacion, AppResources.mesero_viene + c, "Ok");
            }
        }

        private async void btntarjeta(object sender, EventArgs e)
        {
            if (App.session_pedido.confirmado == false)
            {
                await DisplayAlert(AppResources.informacion, AppResources.pedido_vacio, "Ok");
            }
            else
            {
                double cuenta = 0;
                var list_productos = new List<Producto>();
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri("https://restauranteapis.azurewebsites.net/");
                var request1 = await cliente.GetAsync("/api/Producto");
                if (request1.IsSuccessStatusCode)
                {
                    var responseJSON = await request1.Content.ReadAsStringAsync();
                    list_productos = JsonConvert.DeserializeObject<List<Producto>>(responseJSON);
                }
                var request2 = await cliente.GetAsync("/api/ProductoxPedido");
                if (request2.IsSuccessStatusCode)
                {
                    var responseJSON = await request2.Content.ReadAsStringAsync();
                    var respuesta = JsonConvert.DeserializeObject<List<ProductoxPedido>>(responseJSON);
                    foreach (ProductoxPedido x in respuesta)
                    {
                        if (x.NumeroPedido == App.session_pedido.NumeroPedido)
                        {
                            var op = (x.Cantidad) * (list_productos.FirstOrDefault(y => y.NombreProducto == x.NombreProducto).Precio);
                            cuenta += (op);
                        }
                    }
                }
                else
                {
                    await DisplayAlert(AppResources.informacion, AppResources.problemas_conexion, "Ok");
                }
                string c = AppResources.total + ": " + cuenta + " $";
                await DisplayAlert(AppResources.informacion, AppResources.mesero_datafono + c, "Ok");
            }
        }
    }
}