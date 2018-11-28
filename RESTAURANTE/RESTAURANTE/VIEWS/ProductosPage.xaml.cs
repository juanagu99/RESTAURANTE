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
	public partial class ProductosPage : ContentPage
	{
        public List<Producto> listproductos =  new List<Producto>();
        public ProductosPage (Categoria categoria)
		{
            
            CargarProductos(categoria);
            InitializeComponent ();
        }

        private async void CargarProductos(Categoria categoria)
        {
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://restauranteapis.azurewebsites.net/");
            var request = await cliente.GetAsync("/api/Producto"); 
            if (request.IsSuccessStatusCode) 
            {
                var responseJSON = await request.Content.ReadAsStringAsync(); 
                var respuesta = JsonConvert.DeserializeObject<List<Producto>>(responseJSON); 
                foreach (Producto x in respuesta)
                {
                    if (x.NombreCategoria==categoria.NombreCategoria) {
                        listproductos.Add(x);                      
                    }
                   
                }
                Listproductos.ItemsSource = listproductos;
            }
            else
            {
                await DisplayAlert(AppResources.informacion, AppResources.problemas_conexion, "Ok");
            }
        }

        private async void producto_Selected(object sender, SelectedItemChangedEventArgs e)
        {           
            var producto = (Producto)e.SelectedItem;
            //COMPRUEBO EN LA BASE DE DATOS QUE EL PRODUCTO NO ESTE AGREGADO AL PEDIDO
            bool control = false;
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://restauranteapis.azurewebsites.net/");
            var request = await cliente.GetAsync("/api/ProductoxPedido");
            if (request.IsSuccessStatusCode)
            {
                var responseJSON = await request.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<List<ProductoxPedido>>(responseJSON);
                if ( respuesta.Count > 0) { 
                foreach (ProductoxPedido x in respuesta)
                {
                    if (x.NombreProducto == producto.NombreProducto && App.session_pedido.NumeroPedido == x.NumeroPedido )
                    {
                            control = true;
                            await DisplayAlert(AppResources.informacion, AppResources.producto_escogido, "Ok");
                    }

                }                
                }
            }
            else
            {
                await DisplayAlert(AppResources.informacion, AppResources.problemas_conexion, "Ok");
            }
            if (control == false) { //si no esta agregado entonces lo agregamos
                ProductoxPedido p = new ProductoxPedido();
                p.NumeroPedido = App.session_pedido.NumeroPedido;
                p.NombreProducto = producto.NombreProducto;
                p.Cantidad = 1;
                //INSERTAMOS CON POST
                    var json = JsonConvert.SerializeObject(p);//serealizamos el contenido string a json

                    var content = new StringContent(json, Encoding.UTF8, "application/json"); //generamos un stringcontente que esderivado del http content(json,xml)

                    HttpClient Cliente = new HttpClient ();

                    var req = await Cliente.PostAsync("https://restauranteapis.azurewebsites.net/api/ProductoxPedido", content); //este es el post            
                if (req.IsSuccessStatusCode)
                {
                    await DisplayAlert(AppResources.agregado, AppResources.mensaje_agregado + producto.NombreProducto, "Ok");
                }
                else {
                    await DisplayAlert(AppResources.informacion, AppResources.problemas_conexion, "Ok");
                }
            }
           
        }
    }


}