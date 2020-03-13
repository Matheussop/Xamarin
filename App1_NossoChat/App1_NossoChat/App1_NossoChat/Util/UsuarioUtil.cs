using App1_NossoChat.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1_NossoChat.Util
{
    public class UsuarioUtil
    {
        public static void SetUsuarioLogado(Usuario user)
        {
            App.Current.Properties["LOGIN"] = JsonConvert.SerializeObject(user);
        }
        public static Usuario GetUsuarioLogado()
        {
            Usuario user = null;
            if (App.Current.Properties.ContainsKey("LOGIN"))
            {
                 user = JsonConvert.DeserializeObject<Usuario>((string)App.Current.Properties["LOGIN"]);
            }
            return user;
        }
    }
}
