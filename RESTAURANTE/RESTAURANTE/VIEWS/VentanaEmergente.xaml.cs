using DOMINIO;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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
	public partial class VentanaEmergente : PopupPage
	{
        ProductoxPedido pedidoeditar = new ProductoxPedido();
        ListView lv = new ListView();
		public VentanaEmergente (ProductoxPedido p, ListView x)
		{
           
			InitializeComponent ();
            pedidoeditar = p;
            lv = x;
        }

        private async void Editarbtn(object sender, EventArgs e)
        {
            if ( editcap.Text != " " )
            {
                if (Convert.ToInt32(editcap.Text)>0) {
                    pedidoeditar.Cantidad = Convert.ToInt32(editcap.Text);

                    HttpClient cliente = new HttpClient();
                    var json = JsonConvert.SerializeObject(pedidoeditar);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var result = await cliente.PutAsync(string.Concat("https://restauranteapis.azurewebsites.net/api/ProductoxPedido/"), content);
                    if (!result.IsSuccessStatusCode)
                    {
                        await DisplayAlert("Información", "Error de conexion", "Ok");
                    }
                    else {
                            List<ProductoxPedido> listproductos = new List<ProductoxPedido>();                            
                            cliente.BaseAddress = new Uri("https://restauranteapis.azurewebsites.net/");
                            var request = await cliente.GetAsync("/api/ProductoxPedido");
                            if (request.IsSuccessStatusCode)
                            {
                                var responseJSON = await request.Content.ReadAsStringAsync();
                                var respuesta = JsonConvert.DeserializeObject<List<ProductoxPedido>>(responseJSON);
                                foreach (ProductoxPedido x in respuesta)
                                {
                                    if (x.NumeroPedido == App.session_pedido.NumeroPedido)
                                    {
                                        listproductos.Add(x);
                                    }

                                }
                                 lv.ItemsSource = listproductos;
                             }
                            else
                            {
                                await DisplayAlert("Lo sentimos!", "Problemas con la conexion", "Ok");
                            }

                        }
                    }
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                    await PopupNavigation.PopAsync(true);
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
                }
                else {
                    await DisplayAlert("Información", "La cantidad debe ser mayor a cero", "Ok");
                }
            }
        }
    }
