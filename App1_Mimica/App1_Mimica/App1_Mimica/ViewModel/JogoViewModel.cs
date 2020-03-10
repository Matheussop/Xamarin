using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using App1_Mimica.Model;

namespace App1_Mimica.ViewModel
{
    class JogoViewModel : INotifyPropertyChanged
    {
        private short _Rodada;
        public short Rodada
        {
            get { return _Rodada; }
            set { _Rodada = value; OnPropertyChenged("Rodada"); }
        }
        public string NumeroGrupo { get; set; }
        public string NomeGrupo { get; set; }
        public Grupo Grupo { get; set; }
        private byte _PalavraPontuacao;
        public byte PalavraPontuacao
        {
            get { return _PalavraPontuacao; }
            set { _PalavraPontuacao = value; OnPropertyChenged("Palavra"); }
        }
        public string Palavra
        {
            get { return _Palavra; }
            set { _Palavra = value; OnPropertyChenged("PalavraPontuacao"); }
        }
        private string _Palavra;
       
       
        private string _TextoContagem;
        public string TextoContagem
        {
            get { return _TextoContagem; }
            set { _TextoContagem = value; OnPropertyChenged("TextoContagem"); }
        }

        private bool _IsVisibleContainerContagem;
        public bool IsVisibleContainerContagem
        {
            get { return _IsVisibleContainerContagem; }
            set { _IsVisibleContainerContagem = value; OnPropertyChenged("IsVisibleContainerContagem"); }
        }
        private bool _IsVisibleBtnIniciar;
        public bool IsVisibleBtnIniciar
        {
            get { return _IsVisibleBtnIniciar; }
            set { _IsVisibleBtnIniciar = value; OnPropertyChenged("IsVisibleBtnIniciar"); }
        }
        private bool _IsVisibleBtnMostrar;
        public bool IsVisibleBtnMostrar
        {
            get { return _IsVisibleBtnMostrar; }
            set { _IsVisibleBtnMostrar = value; OnPropertyChenged("IsVisibleBtnMostrar"); }
        }

        private Command _MostrarPalavra;
        public Command MostrarPalavra
        {
            get { return _MostrarPalavra; }
            set { _MostrarPalavra = value; OnPropertyChenged("MostrarPalavra"); }
        }
        public Command Acertou { get; set; }
        public Command Errou { get; set; }
        public Command Iniciar { get; set; }

        public JogoViewModel(Grupo grupo)
        {
            if(grupo == Armazenamento.Armazenamento.Jogo.Grupo1)
            {
                NumeroGrupo = " Grupo 1 ";
            }
            else
            {
                NumeroGrupo = " Grupo 2 ";
            }
            Palavra = "**********";
            Grupo = grupo;
            Rodada = Armazenamento.Armazenamento.RodadaAtual;
            NomeGrupo = grupo.Nome;
            IsVisibleBtnMostrar = true;
            IsVisibleContainerContagem = false;
            IsVisibleBtnIniciar = false;
            MostrarPalavra = new Command(MostrarPalavraAction);
            Acertou = new Command(AcertouAction);
            Errou = new Command(ErrouAction);
            Iniciar = new Command(IniciarAction);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void MostrarPalavraAction()
        {

            var NumNivel = Armazenamento.Armazenamento.Jogo.NivelNumerico;
            if (NumNivel == 0)
            {
                Random rd = new Random();
                int nivel = rd.Next(0,3);
                int ind = rd.Next(0, Armazenamento.Armazenamento.Palavras[nivel].Length);
                Palavra = Armazenamento.Armazenamento.Palavras[nivel][ind];
                PalavraPontuacao =(byte)((nivel == 0) ? 1 : (nivel==1) ? 3 : 5);
            }
            else if (NumNivel == 1)
            {
                Random rd = new Random();
                int ind =  rd.Next(0, Armazenamento.Armazenamento.Palavras[NumNivel - 1].Length);
                Palavra = Armazenamento.Armazenamento.Palavras[NumNivel - 1][ind];
                PalavraPontuacao = 1 ;
            }
            else if(NumNivel == 2 )
            {
                Random rd = new Random();
                int ind = rd.Next(0, Armazenamento.Armazenamento.Palavras[NumNivel - 1].Length);
                Palavra = Armazenamento.Armazenamento.Palavras[NumNivel - 1][ind];
                PalavraPontuacao = 3;
            }else{
                Random rd = new Random();
                int ind = rd.Next(0, Armazenamento.Armazenamento.Palavras[NumNivel - 1].Length);
                Palavra = Armazenamento.Armazenamento.Palavras[NumNivel - 1][ind];
                PalavraPontuacao = 5;
            }

            IsVisibleBtnMostrar = false;
            IsVisibleBtnIniciar = true;
        }

        public void IniciarAction()
        {
            IsVisibleBtnIniciar = false;
            IsVisibleContainerContagem = true;
            //Quando o tmepo zerar parar o jogo 
            Rodada = Armazenamento.Armazenamento.RodadaAtual;
            int i = Armazenamento.Armazenamento.Jogo.Tempo;
            TextoContagem = i.ToString();
            i--;
            Device.StartTimer(TimeSpan.FromSeconds(1), ()=> {
                TextoContagem = i.ToString();
                i--;
                if(i < 0)
                {
                    TextoContagem = "Esgotou o tempo"; 
                }
                return true;
            });
        }
        public void ErrouAction()
        {
            //TODO - Ir para a Tela do Jogo no Grupo seguinte(1, ou 2 ).
            GoProximoGrupo();
        }
        public void AcertouAction()
        {
         
            Grupo.Pontuacao += PalavraPontuacao;
            GoProximoGrupo();
            //TODO - Ir para a Tela do Jogo no Grupo seguinte(1, ou 2 ).
        }
        private void GoProximoGrupo()
        {
            //TODO verificar se a rodada terminou
            Grupo grupo;
            if (Armazenamento.Armazenamento.Jogo.Grupo1 == Grupo)
            {
                grupo = Armazenamento.Armazenamento.Jogo.Grupo2;
            }
            else
            {
                grupo = Armazenamento.Armazenamento.Jogo.Grupo1;
                Armazenamento.Armazenamento.RodadaAtual++;
                
            }
            if (Armazenamento.Armazenamento.RodadaAtual > Armazenamento.Armazenamento.Jogo.Rodadas)
            {
                App.Current.MainPage = new View.Resultado();
            }else
            App.Current.MainPage = new View.Jogo(grupo);
        }
        private void OnPropertyChenged(string NameProperty)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }
    }
}
