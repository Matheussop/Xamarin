using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1_Vagas.Modelos;
using App1_Vagas.Banco;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Vagas.Paginas
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MinhasVagasCadastrada : ContentPage
	{
        List<Vagas> Lista { get; set; }
        public MinhasVagasCadastrada ()
		{
			InitializeComponent ();
            ConsultarVagas();

        }
        private void ConsultarVagas()
        {
            DataBase db = new DataBase();
            Lista = db.Consultar();
            ListaVagas.ItemsSource = Lista;

            LblCount.Text = Lista.Count.ToString();
        }

        private void EditarAction(object sender, EventArgs e)
        {
            Label lblEditar = (Label)sender;
            Vagas vaga = ((TapGestureRecognizer)lblEditar.GestureRecognizers[0]).CommandParameter as Vagas;
            Navigation.PushAsync(new EditarVaga(vaga));
        }

        private void ExcluirAction(object sender, EventArgs e)
        {
            Label lblExcluir = (Label)sender;
            Vagas vaga = ((TapGestureRecognizer)lblExcluir.GestureRecognizers[0]).CommandParameter as Vagas;
            DataBase db = new DataBase();
            db.Exclusao(vaga);
            ConsultarVagas();
        }
        private void PesquisarAction(object sender, TextChangedEventArgs e)
        {
            ListaVagas.ItemsSource = Lista.Where(a => a.NomeVaga.ToLower().Contains(e.NewTextValue)).ToList();
        }
    }
}