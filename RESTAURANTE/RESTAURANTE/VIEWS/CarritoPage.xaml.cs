using DOMINIO;
using Newtonsoft.Json;
using RESTAURANTE.Resources;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RESTAURANTE.VIEWS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarritoPage : ContentPage
    {

        public CarritoPage()
        {
            InitializeComponent();

        }
        private async void CargarProductos()
        {

            List<ProductoxPedido> listproductos = new List<ProductoxPedido>();
            HttpClient cliente = new HttpClient();
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
                if (listproductos.Count > 0)
                {
                    carritovacio.IsVisible = false;
                    Listproductos.IsVisible = true;
                }
                else
                {
                    Listproductos.IsVisible = false;
                    carritovacio.IsVisible = true;

                }
                Listproductos.ItemsSource = listproductos;


            }
            else
            {
                await DisplayAlert(AppResources.informacion, AppResources.problemas_conexion, "Ok");
            }

        }

        private void btnrecargar(object sender, EventArgs e)
        {
            CargarProductos();
        }


        private async void btnpedir(object sender, EventArgs e)
        {
            if (App.session_pedido.confirmado == false)
            {
                List<ProductoxPedido> listproductos = new List<ProductoxPedido>();
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri("https://restauranteapis.azurewebsites.net/");
                var request = await cliente.GetAsync("/api/ProductoxPedido");
                if (request.IsSuccessStatusCode)
                {
                    var responseJSON = await request.Content.ReadAsStringAsync();
                    var respuesta = JsonConvert.DeserializeObject<List<ProductoxPedido>>(responseJSON);
                    var cadena = ""; var cont = 1;
                    foreach (ProductoxPedido x in respuesta)
                    {
                        if (x.NumeroPedido == App.session_pedido.NumeroPedido)
                        {
                            listproductos.Add(x);
                            cadena += cont + "." + x.NombreProducto + " ";
                            cont++;
                        }

                    }
                    if (listproductos.Count > 0)
                    {
                        bool x = await DisplayAlert(AppResources.informacion, AppResources.confirmar_pedido_pregunta+" "+ cadena, "Aceptar", "Cancelar");
                        if (x == true)
                        {
                            App.session_pedido.confirmado = true;
                            var json = JsonConvert.SerializeObject(App.session_pedido);
                            var content = new StringContent(json, Encoding.UTF8, "application/json");
                            var result = await cliente.PutAsync(string.Concat("https://restauranteapis.azurewebsites.net/api/Pedido/"), content);
                            if (result.IsSuccessStatusCode)
                            {
                                await DisplayAlert(AppResources.informacion, AppResources.pedido_enviado, "Ok");
                            }
                            else
                            {
                                App.session_pedido.confirmado = false;
                                await DisplayAlert(AppResources.informacion, AppResources.vuelva_intentar, "Ok");
                            }
                        }
                    }
                    else
                    {
                        await DisplayAlert(AppResources.informacion, AppResources.no_escogido_productos, "Ok");

                    }
                }
                else
                {
                    await DisplayAlert(AppResources.informacion, AppResources.problemas_conexion, "Ok");
                }
            }
            else
            {
                await DisplayAlert(AppResources.informacion, AppResources.pedido_confirmado , "Ok");
            }
        }


        private async void btnquitar(object sender, EventArgs e)
        {
            if (!App.session_pedido.confirmado)
            {
                var button = sender as Button;
                var productoxpedido = button?.BindingContext as ProductoxPedido;

                HttpClient cliente1 = new HttpClient();
                var result = await cliente1.DeleteAsync(String.Concat("https://restauranteapis.azurewebsites.net/api/ProductoxPedido/", productoxpedido.Id));
                if (!result.IsSuccessStatusCode)
                {
                    await DisplayAlert(AppResources.informacion, AppResources.vuelva_intentar, "Ok");
                }
                else
                {

                    List<ProductoxPedido> listproductos = new List<ProductoxPedido>();
                    HttpClient cliente = new HttpClient();
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
                        if (listproductos.Count > 0)
                        {
                            carritovacio.IsVisible = false;
                            Listproductos.IsVisible = true;
                        }
                        else
                        {
                            Listproductos.IsVisible = false;
                            carritovacio.IsVisible = true;

                        }
                        Listproductos.ItemsSource = listproductos;
                    }
                }

            }
            else {
                await DisplayAlert( AppResources.informacion, AppResources.pedido_confirmado2, "Ok");
            }
        }

        private async void btneditar(object sender, EventArgs e)
        {
            if (!App.session_pedido.confirmado)
            {
                var button = sender as Button;
                var productoxpedido = button?.BindingContext as ProductoxPedido;
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                await PopupNavigation.PushAsync(new VentanaEmergente(productoxpedido, Listproductos));
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
            }
            else {
                await DisplayAlert(AppResources.informacion, AppResources.pedido_confirmado2 , "Ok");
            }
        }
    }
    }
