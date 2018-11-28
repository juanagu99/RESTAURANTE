using RESTAURANTE.VIEWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;//agregr para que el menu aparezca abajo
namespace RESTAURANTE
{
    public partial class MainPage : Xamarin.Forms.TabbedPage //heredar de esta clase para el menu
    {
        public MainPage()
        {
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
        }

    

    }
}
