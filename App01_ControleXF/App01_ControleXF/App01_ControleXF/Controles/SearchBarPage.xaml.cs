using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ControleXF.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchBarPage : ContentPage
	{
        private List<String> empresasTI;

        public SearchBarPage ()
		{
			InitializeComponent ();

            empresasTI = new List<string>();
            empresasTI.Add("Microsoft");
            empresasTI.Add("Apple");
            empresasTI.Add("Oracle");
            empresasTI.Add("IBM");
            empresasTI.Add("SAP");
            empresasTI.Add("Uber");
            empresasTI.Add("Bradesco");
            empresasTI.Add("TecBan");
            empresasTI.Add("Otimiza");
            empresasTI.Add("Carrefur");
            empresasTI.Add("Petrobras");
            empresasTI.Add("ADM");
            empresasTI.Add("Gol");
            empresasTI.Add("Azul");
            empresasTI.Add("Copasa");
            empresasTI.Add("Elo");
            if (File.Exists("teste.txt"))
            {
                ListResult.Children.Add(new Label { Text = "Exite" });
                foreach (string text in File.ReadLines("teste.txt"))
                {
                    if(text.Length > 0)
                    empresasTI.Add(text.Substring(4));
                }
            }


            Preencher(empresasTI);

		}
        private void Preencher(List<string> empresasTI)
        {
            ListResult.Children.Clear();
            foreach (var empresa in empresasTI)
            {
                ListResult.Children.Add(new Label { Text = empresa });
            }
        }

        private void Pesquisar(object sender, TextChangedEventArgs e)
        {
            var resultado = empresasTI.Where(a=> a.ToLower().Contains(e.NewTextValue.ToLower())).ToList<String>();
            Preencher(resultado);
        }
    }
}