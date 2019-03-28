using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace consoleWebApi
{
    public class UsuarioRepositorio
    {
        HttpClient client = new HttpClient();

        public UsuarioRepositorio()
        {
#if DEBUG
            client.BaseAddress = new Uri("http://localhost:33422");
#else
            client.BaseAddress = new Uri("");
#endif
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            HttpResponseMessage response = await client.GetAsync("api/Usuarios");
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Usuario>>(dados);
            }

            return new List<Usuario>();
        }
    }
}
