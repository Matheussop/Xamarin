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
	public partial class EditarVaga : ContentPage
	{
        private Vagas vaga { set; get; }
		public EditarVaga (Vagas vaga)
		{
			InitializeComponent ();
            this.vaga = vaga;
            Vaga.Text = vaga.NomeVaga;
            Quantidade.Text = vaga.Quantidade.ToString();
            Cidade.Text = vaga.Cidade;
            Descricao.Text = vaga.Descricao;
            TipoContratacao.IsToggled = (vaga.TipoContratacao == "CLT") ? false : true ;
            Salario.Text = vaga.Salario.ToString();
            Empresa.Text = vaga.Empresa;
            Telefone.Text = vaga.Telefone;
            Email.Text = vaga.Email;
		}

        private void SalvarAction(object sender, EventArgs e)
        {
            vaga.NomeVaga = Vaga.Text;
            vaga.Quantidade = short.Parse(Quantidade.Text);
            vaga.Salario = double.Parse(Salario.Text);
            vaga.Cidade = Cidade.Text;
            vaga.Empresa = Empresa.Text;
            vaga.Descricao = Descricao.Text;
            vaga.TipoContratacao = (TipoContratacao.IsToggled) ? "PJ" : "CLT";
            vaga.Telefone = Telefone.Text;
            vaga.Email = Email.Text;

            DataBase db = new DataBase();
            db.Atualizacao(vaga);

            App.Current.MainPage = new NavigationPage(new MinhasVagasCadastrada());
        }
    }
}