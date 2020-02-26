﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCep.Servico.Modelo;
using App01_ConsultarCep.Servico;

namespace App01_ConsultarCep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            //TODO - Lógica do programa

            //TODO - Validações
            string cep = CEP.Text.Trim();
            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {3}, {2}, {0}, {1} ", end.localidade, end.uf, end.logradouro, end.bairro);
                    } 
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP informado: " + cep, "OK");
                    }
                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }
            }

        }

        private bool isValidCEP(string cep)
        {
            bool valid = true;
           /* if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve conter 8 caracteres.", "OK");
                valid = false;
            }*/
            int NovoCEP = 0;
            if(!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("ERRO", "CEP deve ser composto apenas por números.", "OK");

                valid = false;
            }
            return valid;
        }
    }
}
