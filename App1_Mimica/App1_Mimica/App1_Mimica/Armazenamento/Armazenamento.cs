using System;
using System.Collections.Generic;
using System.Text;
using App1_Mimica.Model;

namespace App1_Mimica.Armazenamento
{
    public class Armazenamento
    {
        public static Jogo Jogo { get; set; }
        public static short RodadaAtual { get; set; } 

        public static string[][] Palavras =
        {
            //Faceis Pontuação 1:
            new string[] {"Olho", "Língua","Chinelo","Milho","Chutar","Bola","Marchar","Estátua", "Pintor", "Frio","Abraço"},
            //Medias Pontuação 3:
            new string[] {"Mímico", "Ódio", "Cadeado", "Bandeira", "Modelo", "Sentir Dor","Papai Noel","Sanfona","Coelho","Xadrez","Internet","Calculadora"},
            //Dificeis Pontuação 5:
            new string[] { "Grilo", "Capivara", "Templo", "Estojo", "Estrada", "Cápsula", "Infinito", "Planeta terra", "Divisa", "Comer Macarrão","Debate","Micróbio","Matrix","E.T."},
        };
    }
}
