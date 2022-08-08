using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace Dominio
{
    public class datos
    {

        public bool Login(string disco)
        {
            using (var client = new HttpClient())
            {
                string url = "http://golpedeestadochk.xyz/checker/log.php?disco=" + disco;
                client.DefaultRequestHeaders.Clear();
                var response = client.GetAsync(url).Result;
                var res = response.Content.ReadAsStringAsync().Result;
                if (res == "on")
                {
                    using (var clientt = new HttpClient())
                    {
                        string urel = "http://golpedeestadochk.xyz/checker/info.php?disco=" + disco;
                        clientt.DefaultRequestHeaders.Clear();
                        var responsee = clientt.GetAsync(urel).Result;
                        var ress = responsee.Content.ReadAsStringAsync().Result;
                        String[] resultado = ress.Split('|');
                        cache.user = resultado[0];
                        cache.creditos = resultado[1];
                        cache.licencia = resultado[2];
                        int creditos = Int32.Parse(resultado[1]);
                        if (creditos > 5)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }

            }
        }
        public bool Register(string user, string licencia, string disco)
        {
            using (var client = new HttpClient())
            {
                string url = "http://golpedeestadochk.xyz/checker/register.php?user=" + user + "&licencia=" + licencia + "&disco=" + disco;
                client.DefaultRequestHeaders.Clear();
                var response = client.GetAsync(url).Result;
                var res = response.Content.ReadAsStringAsync().Result;
                if (res == "on")
                {
                    using (var clientt = new HttpClient())
                    {
                        string urel = "http://golpedeestadochk.xyz/checker/info.php?disco=" + disco;
                        clientt.DefaultRequestHeaders.Clear();
                        var responsee = clientt.GetAsync(urel).Result;
                        var ress = responsee.Content.ReadAsStringAsync().Result;
                        String[] resultado = ress.Split('|');
                        cache.user = resultado[0];
                        cache.creditos = resultado[1];
                        cache.licencia = resultado[2];

                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public string Discount(string user)
        {
            using (var client = new HttpClient())
            {
                string url = "http://golpedeestadochk.xyz/checker/descontarcreditos.php?user=" + user;
                client.DefaultRequestHeaders.Clear();
                var response = client.GetAsync(url).Result;
                var res = response.Content.ReadAsStringAsync().Result;
                return res;
            }
        }

        public string bin(string user, string cc, string gate)
        {
            using (var client = new HttpClient())
            {
                string url = "http://golpedeestadochk.xyz/checker/lives.php?cc=" + cc + "&user=" + user + "&gate="+gate;
                client.DefaultRequestHeaders.Clear();
                var response = client.GetAsync(url).Result;
                var res = response.Content.ReadAsStringAsync().Result;
                return res;
            }
        }

    }
}
