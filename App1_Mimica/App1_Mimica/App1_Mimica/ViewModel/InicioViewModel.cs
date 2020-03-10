using System;
using System.Collections.Generic;
using System.Text;
using App1_Mimica.Model;
using App1_Mimica.Armazenamento;
using System.ComponentModel;
using Xamarin.Forms;

namespace App1_Mimica.ViewModel
{
    class InicioViewModel : INotifyPropertyChanged
    {
        public Jogo Jogo { get; set; }
        public Command IniciarCommand { get; set; }
        private string _MsgError;
        public string MsgError { get { return _MsgError; } set { _MsgError = value; OnPropertyChanged("MsgError"); } }
        public InicioViewModel(){
            IniciarCommand = new Command(IniciarJogo);
            Jogo = new Jogo();
            Jogo.Grupo1 = new Grupo();
            Jogo.Grupo2 = new Grupo();

            Jogo.Tempo = 120;
            Jogo.Rodadas = 7;
        }
        private void IniciarJogo()
        {
            if (Verificacoes())
            {
                Armazenamento.Armazenamento.Jogo = this.Jogo;
                Armazenamento.Armazenamento.RodadaAtual = 1;
                App.Current.MainPage = new View.Jogo(Jogo.Grupo1);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string NameProperty)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }
        private bool Verificacoes()
        {
            bool resp = true;
            string error = "";
            if (Jogo.Tempo < 10)
            {
                error += "O tempo mínimo para uma rodada do grupo devera ser 10 segundos.";
            }
            if (Jogo.Rodadas <= 0)
            {
                if(error.Length > 0)
                {
                    error += "\n";
                }
                error += "O valor mínimo para a rodada é 1.";
            }

            if(error.Length > 0)
            {
                MsgError = error;
                resp = false;
            }
            return resp;
        }
    }
}
