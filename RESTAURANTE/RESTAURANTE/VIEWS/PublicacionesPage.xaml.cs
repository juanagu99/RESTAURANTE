using Newtonsoft.Json;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DOMINIO.MODELS;
using RESTAURANTE.Resources;
using System.IO;

namespace RESTAURANTE.VIEWS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PublicacionesPage : ContentPage
    {
        public PublicacionesPage()
        {
            InitializeComponent();
        }

        public static byte[] StreamToBytes(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

        private async void Take_Photo(object sender, EventArgs e)
        {
            var isinitializate = await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported || !isinitializate)
            {
                await DisplayAlert(AppResources.informacion, AppResources.camara_mensaje, "Ok");
            }
            else
            {
                var file = await CrossMedia.Current.PickPhotoAsync();
                if (file==null) { return; }

                var foto = StreamToBytes(file.GetStream()); //obtenemos la imagen como un array de bytes

                var newpublicacion = new Publicacion() //creamos el objeto publicacion para pasar a la bd
                {
                    Foto = Convert.ToString(foto) //convertimos el array de bytes a string para pasarla a la propiedad del modelo
                };          
                
                //INSERTAMOS CON POST LA PUBLICACION 
                var json = JsonConvert.SerializeObject(newpublicacion);//serealizamos el contenido string a json

                var content = new StringContent(json, Encoding.UTF8, "application/json"); //generamos un stringcontente que esderivado del http content(json,xml)

                HttpClient cliente = new HttpClient ();

                var req = await cliente.PostAsync("https://restauranteapis.azurewebsites.net/api/Publicacion", content); //este es el post            

                if (req.IsSuccessStatusCode) {

                    //TRAEMOS LAS DEMAS FOTOS
                    List<Publicacionlist> listpub = new List<Publicacionlist>();                    
                    cliente.BaseAddress = new Uri("https://restauranteapis.azurewebsites.net/");
                    var request = await cliente.GetAsync("/api/Publicacion");
                    if (request.IsSuccessStatusCode)
                    {
                        var responseJSON = await request.Content.ReadAsStringAsync();
                        var respuesta = JsonConvert.DeserializeObject<List<Publicacion>>(responseJSON);
                        foreach (Publicacion x in respuesta)
                        {
                            listpub.Add(new Publicacionlist(x));
                        }
                        ListPublicacion.ItemsSource = listpub;
                    }
                    file.Dispose();
                }
                else {
                    await DisplayAlert(AppResources.informacion, AppResources.problemas_conexion, "Ok");
                }
            }
        }

        private async void cargarpublicaciones()
        {
            //TRAEMOS LAS DEMAS FOTOS
            List<Publicacionlist> listpub = new List<Publicacionlist>();
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://restauranteapis.azurewebsites.net/");
            var request = await cliente.GetAsync("/api/Publicacion");
            if (request.IsSuccessStatusCode)
            {
                var responseJSON = await request.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<List<Publicacion>>(responseJSON);
                foreach (Publicacion x in respuesta)
                {
                    listpub.Add(new Publicacionlist(x));
                }
                ListPublicacion.ItemsSource = listpub;
            }
            else
            {
                await DisplayAlert(AppResources.informacion, AppResources.problemas_conexion, "Ok");
            }
        }

        private void btnrecargar(object sender, EventArgs e)
        {
            cargarpublicaciones();
        }
    }
}