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
	public partial class ImageCellPage : ContentPage
	{
		public ImageCellPage ()
		{
			InitializeComponent ();

            InitializeComponent();

            List<Funcionario> Lista = new List<Funcionario>();
            Lista.Add(new Funcionario() { Foto = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRb9zcYg3OhilRHs6cWOuSJX50v4czCpxG0pxhYgvdTVP4stqR7", Nome = "Matheus", Cargo = "Estagiario" });
            Lista.Add(new Funcionario() { Foto= "https://2.bp.blogspot.com/-_Cpv8suMlPw/UFiqaAVggjI/AAAAAAAAAGA/XtKB6fsMwmQ/s1600/foto-de-perfil-jerry.png", Nome = "Jaime", Cargo = "Presidente" });
            Lista.Add(new Funcionario() { Foto = "https://www.microlins.com.br/galeria/repositorio/images/noticias/como-posicionar-melhor-seu-perfil-no-linkedin/07-Como-posicionar-melhor-seu-perfil-do-Linkedin.png", Nome = "Maria", Cargo = "RH" });
            Lista.Add(new Funcionario() { Foto = "https://images.vexels.com/media/users/3/140384/isolated/lists/fa2513b856a0c96691ae3c5c39629f31-avatar-de-perfil-de-menina-1.png", Nome = "Erika", Cargo = "Lider Departamento" });
            Lista.Add(new Funcionario() { Foto = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcS9zpWpj1NUC5MrHtjPluQKTCHQJBnt3N_bsYX_Go8F_o0-Dcp-", Nome = "Xavier", Cargo = "Infraestrutura" });

            ListaFuncionario.ItemsSource = Lista;
        }
	}
}