using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using App1_Vagas.Modelos;

namespace App1_Vagas.Banco
{
    class DataBase
    {
        private SQLiteConnection _conexao;
        
        public DataBase()
        {
            _conexao = new SQLiteConnection();
        }

        public void Cadastro(Vagas vaga)
        {

        }

        public List<Vagas> Consultar()
        {
            return null;
        }
        public Vagas ObterVagaPorId(int id)
        {
            return null;
        }
        public void Atualizacao(Vagas vaga)
        {

        }
        public void Exclusao(int id)
        {

        }
    }
}
