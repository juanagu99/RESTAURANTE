using DOMINIO.MODELS;
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

namespace RESTAURANTE
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}
        private async void ingresar_btn(object sender, EventArgs e)
        {
            mensaje.IsVisible = false;
            if (!String.IsNullOrEmpty(editusuario.Text))
            {
                if (!String.IsNullOrEmpty(editcontraseña.Text))
                {
                    //Enviamos con el metodo post el usuario
                    LoginEmpleado empleado = new LoginEmpleado();
                    empleado.Usuario = editusuario.Text; empleado.Contraseña = editcontraseña.Text;
                    var json = JsonConvert.SerializeObject(empleado);//serealizamos el contenido string a json
                    var content = new StringContent(json, Encoding.UTF8, "application/json"); //generamos un stringcontent que es el codigo que se manda por post 
                    HttpClient Cliente = new HttpClient();
                    var respuesta_servidor = await Cliente.PostAsync("https://restauranteapis.azurewebsites.net/api/Login", content); //este es el post            
                    if (respuesta_servidor.IsSuccessStatusCode)
                    {
                        var autenticacion_json = await respuesta_servidor.Content.ReadAsStringAsync();
                        var autenticacion = JsonConvert.DeserializeObject<Autenticacion>(autenticacion_json);
                        if (autenticacion.respuesta == 0)
                        {
                            mensaje.Text = AppResources.usuario_invalido;
                            mensaje.IsVisible = true;
                        }
                        else if (autenticacion.respuesta == 1)
                        {
                            mensaje.Text = AppResources.contraseña_invalida;
                            mensaje.IsVisible = true;
                        }
                        else if (autenticacion.respuesta == 2)
                        {
                            await Navigation.PushAsync(new MainPage());
                        }
                    }
                }
                else
                {
                    mensaje.Text = AppResources.contraseña_invalida;
                    mensaje.IsVisible = true;
                }
            }
            else
            {
                mensaje.Text = AppResources.usuario_invalido;
                mensaje.IsVisible = true;
            }

        }
    }
}