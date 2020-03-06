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
    public partial class ConsultaVagas : ContentPage
    {
        List<Vagas> Lista { get; set; }
        public ConsultaVagas()
        {
            InitializeComponent();

            DataBase db = new DataBase();
            Lista = db.Consultar();
            ListaVagas.ItemsSource = Lista;

            LblCount.Text = Lista.Count.ToString();
        }

        private void GoCadastro(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastroVaga());
        }

        private void GoMinhasVagas(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MinhasVagasCadastrada());
        }

        private void MaisDetalheAction(object sender, EventArgs e)
        {
            Label lblDetalhe = (Label)sender;
            Vagas vaga = ((TapGestureRecognizer)lblDetalhe.GestureRecognizers[0]).CommandParameter as Vagas; 
            Navigation.PushAsync(new DetalheVaga(vaga));
        }

        private void PesquisarAction(object sender, TextChangedEventArgs e)
        {
            ListaVagas.ItemsSource = Lista.Where(a => a.NomeVaga.ToLower().Contains(e.NewTextValue)).ToList();
        }
    }
}