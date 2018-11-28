using DOMINIO.MODELS;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RESTAURANTE
{
    public class Publicacionlist
    {
        public Publicacionlist(Publicacion p)
        {
            Publicacion = p;
        }
        public Publicacion Publicacion { get; set; }
        private FileImageSource source = null;
        public FileImageSource Source => source ?? (source = new FileImageSource() { File = Publicacion.Foto });
    }
}
