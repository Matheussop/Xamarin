using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using App1_NossoChat.Model;
using Newtonsoft.Json;

namespace App1_NossoChat.Service
{
    public class ServiceWs
    {
        public static string EnderecoBase = "http://ws.spacedu.com.br/xf2018/rest/api/usuario";
        public static Usuario GetUsuario(Usuario usuario)
        {
            var URL = EnderecoBase + "/usuario";

            //StringContent param = new StringContent(string.Format("?nome={0}&password={1}", usuario.nome,usuario.password));
            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("nome",usuario.nome),
                new KeyValuePair<string, string>("password",usuario.password)
                });
            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync(URL, param).GetAwaiter().GetResult(); ;
            if(resposta.StatusCode == HttpStatusCode.OK)
            {
                //TODO - Deserializa, retornar no metodo e Salvar como Login.
            }

        }

        public static List<Chat> GetChats()
        {
            var URL = EnderecoBase + "/chats";
            List<Chat> lista = null;
            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.GetAsync(URL).GetAwaiter().GetResult();
            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                if (conteudo.Length > 2)
                {
                    lista = JsonConvert.DeserializeObject<List<Chat>>(conteudo);
                }
            }
            return lista;
        }
    }
}
