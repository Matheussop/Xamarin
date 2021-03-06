﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App1_Vagas.Banco;
using App1_Vagas.UWP.Banco;
using Windows.Storage;
using System.IO;
using Xamarin.Forms;

[assembly:Dependency(typeof(Caminho))]
namespace App1_Vagas.UWP.Banco
{
    public class Caminho : ICaminho
    {
        public string GetCaminho(string NomeArquivoBanco)
        {
            string caminhoDaPasta = ApplicationData.Current.LocalFolder.Path;

            string caminhoBanco = Path.Combine(caminhoDaPasta, NomeArquivoBanco);

            return caminhoBanco;
        }
    }
}
