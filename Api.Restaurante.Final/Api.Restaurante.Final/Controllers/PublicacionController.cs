using Api.Restaurante.Final.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Api.Restaurante.Final.Controllers
{
    public class PublicacionController : ApiController
    {
        public static byte[] StreamToBytes(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
        [HttpGet]
        public IEnumerable<Publicacion> Get()
        {
            using (var context = new Context())
            {
                var list = context.Publicacion.ToList();
                list.ForEach(x => x.Foto = Url.Content("~" + "/" + "Content/Imagenes/" + x.Foto));
                return list ;
            }
        }
        [HttpPost]
        public Publicacion Post(Publicacion publicacion)
        {     //obtenemos el objeto publicacion; en la propiedad foto tiene 
              //el string con el array de bytes;con esto no va a quedar en la BD
              //asi que solo se trae el contenido asi y se guarda en la carpeta
              //Content/Imagenes con un un id autogenerado con GUID y despues cambiamos el 
              //contenido de foto de la BD donde se guardara la nueva ruta de la imagen              
             
            using (var context = new Context())
            {
               // var imagen = publicacion.Foto;      
                //MemoryStream array = new MemoryStream(Encoding.UTF8.GetBytes(imagen)); //convertimos el string de nuevo a un array de bytes
                Guid path_bd = Guid.NewGuid();
                publicacion.Foto = path_bd + ".jpg";
                context.Publicacion.Add(publicacion);
                context.SaveChanges();
               // System.IO.File.WriteAllBytes( "url" , StreamToBytes(array));  
                return publicacion;
            }
        }
    }
}
