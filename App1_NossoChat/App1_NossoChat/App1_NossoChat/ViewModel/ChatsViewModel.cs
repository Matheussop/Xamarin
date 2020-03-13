using App1_NossoChat.Model;
using App1_NossoChat.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1_NossoChat.ViewModel
{
    public class ChatsViewModel : INotifyPropertyChanged
    {
        private bool _Carregando;
        public bool Carregando
        {
            get { return _Carregando; }
            set { _Carregando = value; PropertyChanged(this, new PropertyChangedEventArgs("Carregando")); }
        }
        private Chat _SelectedItemChat;
        public Chat SelectedItemChat
        {
            get { return _SelectedItemChat; }
            set
            {
                _SelectedItemChat = value; OnPropertyChanged("SelectedItemChat");
                GoPaginaMensagem(value);
            }
        }
        private List<Chat> _Chats;
        public List<Chat> Chats
        {
            get { return _Chats; }
            set { _Chats = value; OnPropertyChanged("Chats"); }
        }

        public Command AdicionarCommand { get; set; }
        public Command OrdenarCommand { get; set; }
        public Command AtualizarCommand { get; set; }

        public ChatsViewModel()
        {
           try
            {
                Task.Run(() => CarregarChats());
                AdicionarCommand = new Command(Adicionar);
                OrdenarCommand = new Command(Ordenar);
                AtualizarCommand = new Command(Atualizar);
                Carregando = false;
            }
            catch
            {

            }
        }
        private async Task CarregarChats()
        {
            try
            {
                Carregando = true;
                Chats = await ServiceWs.GetChatsAsync();
                Carregando = false;
            }
            catch(Exception e)
            {
                Carregando = false;
            }

        }
        private void Adicionar() {
            ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.CadastrarChat());
        }
        private void Ordenar() {
            Chats = Chats.OrderBy(a => a.nome).ToList();
        }
        private void Atualizar() {
            Task.Run(() => CarregarChats());
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if(!(PropertyChanged is null))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
        private void GoPaginaMensagem(Chat chat)
        {
            if(chat != null)
            {
                SelectedItemChat = null;
                ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.Mensagem(chat));
            }
        }
    }
}
