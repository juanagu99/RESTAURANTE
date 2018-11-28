using DOMINIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace RESTAURANTE
{
    public partial class App : Application
    {
        public static Mesa session_mesa { get; set; }
        public static Pedido session_pedido { get; set; }
        public static Empleado session_mesero { get; set; }

        public App()
        {
            session_mesa = new Mesa();
            session_pedido = new Pedido();
            session_mesero = new Empleado();
            session_mesa.NumeroMesa = 1;
            session_mesero.Idempleado = 1;
            CrearPedido(); 
            GenerarPedido();
            InitializeComponent();
            var navigationPage = new NavigationPage(new LoginPage());    
            navigationPage.BarBackgroundColor = Color.Maroon;
            navigationPage.BarTextColor = Color.Gold;
            MainPage = navigationPage;
        }
        public void CrearPedido() {
            session_pedido.NumeroMesa = session_mesa.NumeroMesa;
            session_pedido.Idempleado = session_mesero.Idempleado;
            session_pedido.confirmado = false;
        }
        public async void GenerarPedido()
        {
            var json = JsonConvert.SerializeObject(session_pedido);//serealizamos el contenido string a json

            var content = new StringContent(json, Encoding.UTF8, "application/json"); //generamos un stringcontente que esderivado del http content(json,xml)

            HttpClient Cliente = new HttpClient { };        
           
            var request = await Cliente.PostAsync("https://restauranteapis.azurewebsites.net/api/Pedido", content); //este es el post            

            if (request.IsSuccessStatusCode) {
                var responsejson = await request.Content.ReadAsStringAsync();
                var nuevoobjeto = JsonConvert.DeserializeObject<Pedido>(responsejson);
                session_pedido.NumeroPedido = nuevoobjeto.NumeroPedido;
            }
        }

    }

}

