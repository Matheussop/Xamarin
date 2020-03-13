using App1_NossoChat.Model;
using System;
using System.Collections.Generic;
using System.Text;
using App1_NossoChat.Service;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using App1_NossoChat.Util;
using System.Threading.Tasks;

namespace App1_NossoChat.ViewModel
{
    class MensagemViewModel : INotifyPropertyChanged
    {
        private bool _Carregando;
        public bool Carregando
        {
            get { return _Carregando; }
            set { _Carregando = value; PropertyChanged(this, new PropertyChangedEventArgs("Carregando")); }
        }
        private Chat chat;
        private List<Mensagem> _Mensagens;
        public List<Mensagem> Mensagens
        {
            get { return _Mensagens; }
            set
            {
                _Mensagens = value; OnPropertyChanged("Mensagens");
            }
        }
        private string _TxtMensagem;
        public string TxtMensagem
        {
            get { return _TxtMensagem; }
            set
            {
                _TxtMensagem = value; OnPropertyChanged("TxtMensagem");
            }
        }
        public Command BtnEnviarCommand { get; set; }
        public Command AtualizarCommand { get; set; }

        public MensagemViewModel(Chat chat,Entry enviar)
        {
            this.chat = chat;

            Task.Run(() => Atualizar());
            enviar.Completed += Entry_Completed;
            BtnEnviarCommand = new Command(BtnEnviar);
            AtualizarCommand = new Command(BtnAtualizarSemAsync);

            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                Task.Run(() => AtualizarSemTelaCarregando());
                return true;
            });
        }
        private void BtnAtualizarSemAsync()
        {
            Task.Run(() => AtualizarSemTelaCarregando());
        }
        void Entry_Completed(object sender, EventArgs e)
        {
            BtnEnviar();
        }
        private async Task Atualizar()
        {
            try
            {
                Carregando = true;
                Mensagens = await ServiceWs.GetMensagems(chat);
                Carregando = false;
            }
            catch(Exception e)
            {
                Carregando = false;
            }

        }
        private async Task AtualizarSemTelaCarregando()
        {
            Mensagens = await ServiceWs.GetMensagems(chat);
        }
        private void BtnEnviar()
        {
            var msg = new Mensagem()
            {
                id_usuario = UsuarioUtil.GetUsuarioLogado().id,
                mensagem = TxtMensagem,
                id_chat = chat.id
            };
            ServiceWs.InsertMensage(msg);
            Task.Run(() => BtnAtualizarSemAsync());
            TxtMensagem = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if (!(PropertyChanged is null))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}
