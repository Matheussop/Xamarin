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
	public partial class ListViewButtonPage : ContentPage
	{
		public ListViewButtonPage ()
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

        private void FeriasAction(object sender, EventArgs e)
        {
            Button btnFerias = (Button)sender;
            Funcionario func = (Funcionario)btnFerias.CommandParameter;

            DisplayAlert("Ferias", "Funcionario: " + func.Nome + " - " + func.Cargo, "OK");
        }
    }
}