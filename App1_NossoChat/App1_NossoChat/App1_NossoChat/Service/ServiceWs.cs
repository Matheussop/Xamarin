using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using App1_NossoChat.Model;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace App1_NossoChat.Service
{
    public class ServiceWs
    {
        public static string EnderecoBase = "http://ws.spacedu.com.br/xf2018/rest/api";
        public static async System.Threading.Tasks.Task<Usuario> GetUsuarioAsync(Usuario usuario)
        {
            var URL = EnderecoBase + "/usuario";

            //StringContent param = new StringContent(string.Format("?nome={0}&password={1}", usuario.nome,usuario.password));
            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("nome",usuario.nome),
                new KeyValuePair<string, string>("password",usuario.password)
                });
            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = await requisicao.PostAsync(URL, param);
            Usuario user = null;
            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                var conteudo = await resposta.Content.ReadAsStringAsync();
                //user = JsonConvert.DeserializeObject<Usuario>(conteudo);
                 return JsonConvert.DeserializeObject<Usuario>(conteudo);
            }
            return user;

        }

        public static async System.Threading.Tasks.Task<List<Chat>> GetChatsAsync()
        {
            var URL = EnderecoBase + "/chats";
            List<Chat> lista = null;
            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = await requisicao.GetAsync(URL);
            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = await resposta.Content.ReadAsStringAsync();
                if (conteudo != null)
                {
                    if (conteudo.Length > 2)
                    {
                        lista = JsonConvert.DeserializeObject<List<Chat>>(conteudo);
                    }
                }
            }
            return lista;
        }
        public static bool InsertChat(Chat chat)
        {
            bool resp = false;
            var URL = EnderecoBase + "/chat";

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("nome",chat.nome),
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync(URL, param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                resp = true;
            }

            return resp;
        }
        public static bool RenameChat(Chat chat)
        {
            bool resp = false;
            var URL = EnderecoBase + "/chat/" + chat.id;

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("nome",chat.nome),
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PutAsync(URL, param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                resp = true;
            }

            return resp;
        }
        public static bool DeleteChat(Chat chat)
        {
            bool resp = false;
            var URL = EnderecoBase + "/chat/delete/" + chat.id;

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.DeleteAsync(URL).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                resp = true;
            }

            return resp;
        }
        public static async Task<List<Mensagem>> GetMensagems(Chat chat)
        {
            var URL = EnderecoBase + "/chat/" + chat.id + "/msg";
            List<Mensagem> lista = null;
            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = await requisicao.GetAsync(URL);

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = await resposta.Content.ReadAsStringAsync();

                if (conteudo != null)
                {

                    if (conteudo.Length > 2) {
                        lista = JsonConvert.DeserializeObject<List<Mensagem>>(conteudo);
                    }
                }
            }

            return lista;
        }
        public static bool InsertMensage(Mensagem mensagem)
        {
            bool resp = false;
            var URL = EnderecoBase + "/chat/" + mensagem.id_chat + "/msg";

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("mensagem",mensagem.mensagem),
                new KeyValuePair<string,string>("id_usuario",mensagem.id_usuario.ToString())
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync(URL, param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                resp = true;
            }

            return resp;
        }
        public static bool DeleteMensagem(Mensagem mensagem)
        {
            bool resp = false;
            var URL = EnderecoBase + "/chat/" + mensagem.id_chat + "/delete/" + mensagem.id;

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("nome",mensagem.mensagem),
                new KeyValuePair<string,string>("id_usuario",mensagem.id_chat.ToString())
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.DeleteAsync(URL).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                resp = true;
            }
            return resp;
        }
    }
}
