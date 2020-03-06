using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SQLite;
using App1_Vagas.Modelos;
using Xamarin.Forms;

namespace App1_Vagas.Banco
{
    class DataBase
    {
        private SQLiteConnection _conexao;
        
        public DataBase()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.GetCaminho("database.sqlite");

            _conexao = new SQLiteConnection(caminho);
            _conexao.CreateTable<Vagas>();


        }

        public void Cadastro(Vagas vaga)
        {
            _conexao.Insert(vaga);
        }

        public List<Vagas> Consultar()
        {
            return _conexao.Table<Vagas>().ToList();
        }
        public List<Vagas> Pesquisar(string palavra)
        {
            return _conexao.Table<Vagas>().Where(a=>a.NomeVaga.Contains(palavra)).ToList();
        }
        public Vagas ObterVagaPorId(int id)
        {
            return _conexao.Table<Vagas>().Where(a => a.Id == id).FirstOrDefault(); 
        }
        public void Atualizacao(Vagas vaga)
        {
            _conexao.Update(vaga); 
        }
        public void Exclusao(Vagas vaga)
        {
            _conexao.Delete(vaga);
        }
    }
}
