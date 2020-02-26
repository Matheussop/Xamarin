using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_TipoPaginaXF.TiposPagina.Tabbed
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Abas : TabbedPage
	{
		public Abas ()
		{
			InitializeComponent ();

            Children.Add(new NavigationPage(new TiposPagina.Navigation.Pagina2()) { Title = "Item 2" });
            Children.Add(new NavigationPage(new TiposPagina.Navigation.Pagina1()) { Title = "Item 3" });
        }
	}
}