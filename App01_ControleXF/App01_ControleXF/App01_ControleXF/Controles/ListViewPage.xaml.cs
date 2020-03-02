using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App01_ControleXF.Modelo;

namespace App01_ControleXF.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewPage : ContentPage
	{
		public ListViewPage ()
		{
			InitializeComponent ();

            List<Pessoa> lista = new List<Pessoa>();

            lista.Add(new Pessoa { nome ="José", idade = "20"});
            lista.Add(new Pessoa { nome ="Felipe", idade = "21"});
            lista.Add(new Pessoa { nome ="Matheus", idade = "24"});
            lista.Add(new Pessoa { nome ="Luiz", idade = "15"});
            lista.Add(new Pessoa { nome ="Henrique", idade = "26"});
            lista.Add(new Pessoa { nome ="Atilio", idade = "17"});

            ListaPessoa.ItemsSource = lista;
		}
	}
}