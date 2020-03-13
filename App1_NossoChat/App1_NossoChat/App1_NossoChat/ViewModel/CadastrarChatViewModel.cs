using App1_NossoChat.Model;
using App1_NossoChat.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App1_NossoChat.ViewModel
{
    public class CadastrarChatViewModel : INotifyPropertyChanged
    {
        private string _Mensagem;
        public string Mensagem {
            get { return _Mensagem; }
            set { _Mensagem = value; OnPropertyChanged("Mensagem"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
        public string nome{get;set;}
        public Command CadastrarCommand { get; set; }

        public CadastrarChatViewModel()
        {
            CadastrarCommand = new Command(Cadastrar);
        }
        private void Cadastrar()
        {
            var chat = new Chat() { nome = nome };
            bool ok = ServiceWs.InsertChat(chat);

            if (ok)
            {
                var PaginaAtual = ((NavigationPage)App.Current.MainPage);
                var Chats = (View.Chats)PaginaAtual.RootPage;
                var ViewModel = (ChatsViewModel)Chats.BindingContext;
                if(ViewModel.AtualizarCommand.CanExecute(null))
                    ViewModel.AtualizarCommand.Execute(null);
                PaginaAtual.PopAsync();

            }
            else
                Mensagem = "Ocorreu um error no Cadastro!";

        }
    }
}
