using App1_NossoChat.Model;
using App1_NossoChat.Service;
using App1_NossoChat.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App1_NossoChat.ViewModel
{
    public class PaginaInicialViewModel : INotifyPropertyChanged
    {
        private bool _Carregando;
        public bool Carregando
        {
            get { return _Carregando; }
            set { _Carregando = value; PropertyChanged(this, new PropertyChangedEventArgs("Carregando")); }
        }

        private string _Mensagem;
        public string Mensagem
        {
            get { return _Mensagem; }
            set { _Mensagem = value; PropertyChanged(this, new PropertyChangedEventArgs("Mensagem")); }
        }
        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; PropertyChanged(this, new PropertyChangedEventArgs("Nome")); }
        }
        private string _Senha;
       public string Senha
        {
            get { return _Senha; }
            set { _Senha = value; PropertyChanged(this, new PropertyChangedEventArgs("Senha")); }
        }
        public Command AcessarCommand { get; set; }


        
        public PaginaInicialViewModel(Entry t)
        {
            t.Completed += Entry_Completed ;
            AcessarCommand = new Command(Acessar);
        }
        void Entry_Completed(object sender, EventArgs e)
        {
            Acessar(); 
        }

        private async void Acessar()
        {
            Carregando = true;
            Usuario user = new Usuario();
            user.nome = Nome;
            user.password  = Senha;

            var usuarioLogado = await ServiceWs.GetUsuarioAsync(user);
            if (usuarioLogado == null)
            {
                Mensagem = "Usuario e senha não conferem";
                Carregando = false;
            }
            else
            {
                UsuarioUtil.SetUsuarioLogado(usuarioLogado);
                //App.Current.Properties["LOGIN"] = JsonConvert.SerializeObject(usuarioLogado);
                App.Current.MainPage = new NavigationPage(new View.Chats()) { BarBackgroundColor  = Color.FromHex("#5ED055"), BarTextColor = Color.White};
            }
            
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        

    }
}
