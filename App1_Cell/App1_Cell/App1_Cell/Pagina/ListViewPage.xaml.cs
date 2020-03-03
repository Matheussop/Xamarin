using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1_Cell.Modelo;

namespace App1_Cell.Pagina
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewPage : ContentPage
	{
		public ListViewPage ()
		{
			InitializeComponent ();

            List<Funcionario> Lista = new List<Funcionario>();
            Lista.Add(new Funcionario() { Nome = "Matheus", Cargo = "Estagiario" });
            Lista.Add(new Funcionario() { Nome = "Jaime", Cargo = "Presidente" });
            Lista.Add(new Funcionario() { Nome = "Maria", Cargo = "RH" });
            Lista.Add(new Funcionario() { Nome = "Erika", Cargo = "Lider Departamento" });
            Lista.Add(new Funcionario() { Nome = "Xavier", Cargo = "Infraestrutura" });

            ListaFuncionario.ItemsSource = Lista;
        }

        private void ListaFuncionarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void ItemSelectedAction(object sender, SelectedItemChangedEventArgs e)
        {
            Funcionario func = (Funcionario)e.SelectedItem;

            Navigation.PushAsync(new Detalhe.DetailPage(func));

        }

        private void FeriasAction(object sender, EventArgs e)
        {
            MenuItem botao = (MenuItem)sender;
            Funcionario func = (Funcionario)botao.CommandParameter;

            DisplayAlert("Titulo: " + func.Nome, "Mensagem: " + func.Nome + " - " + func.Cargo, "OK");
        }

        private void AbonoAction(object sender, EventArgs e)
        {

        }
    }
}