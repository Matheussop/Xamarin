using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_Xamrin.Master
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menu : MasterDetailPage
	{
		public Menu ()
		{
			InitializeComponent ();
		}

        private void GoPafinaPerfil1(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Pages.Perfil1());
            IsPresented = false;
        }

        private void GoPafinaXamarin(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Pages.Xamarin());
            IsPresented = false;
        }
    }
}