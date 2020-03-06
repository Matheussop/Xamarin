using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1_Vagas.Modelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1_Vagas.Banco;

namespace App1_Vagas.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroVaga : ContentPage
	{
		public CadastroVaga ()
		{
			InitializeComponent ();
		}

        private void SalvarAction(object sender, EventArgs e)
        {
            //TODO - Obter dados da tela
            Vagas vaga = new Vagas();
            vaga.NomeVaga = Vaga.Text;
            vaga.Quantidade = short.Parse(Quantidade.Text);
            vaga.Salario = double.Parse(Salario.Text);
            vaga.Empresa = Empresa.Text;
            vaga.Cidade = Cidade.Text;
            vaga.Descricao = Descricao.Text;
            vaga.TipoContratacao = (TipoContratacao.IsToggled) ? "PJ" : "CLT";
            vaga.Telefone = Telefone.Text;
            vaga.Email = Email.Text;

            //Salvar informações no Banco
            DataBase bd = new DataBase();
            bd.Cadastro(vaga);

            //TODO - Voltar para a tela de pesquisa
            App.Current.MainPage = new NavigationPage(new ConsultaVagas());
        }
    }
}