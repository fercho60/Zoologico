using System.Web.Helpers;
using System.Windows.Markup;
using Newtonsoft.Json; // Corregido el nombre del paquete


namespace ProyectoApiTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            var rutaEspecies = "api/Especies";

            httpClient.BaseAddress = new Uri("https://localhost:7146/");
            
            //Lectura de datos
            var response = httpClient.GetAsync("api/Especies").Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var especies = Newtonsoft.Json.JsonConvert.DeserializeObject<Zoologico_Modelos.ApiResult<List<Zoologico_Modelos.Especie>>>(json);


            //Insercion de datos
            var nuevaEspecie = new Zoologico_Modelos.Especie
            {
                codigo = 0,
                NombreComun = "Tigre"
            };
            
            //Invocar al servicio para insertar la nueva especie
            var especieJson = Newtonsoft.Json.JsonConvert.SerializeObject(nuevaEspecie);
            var content = new StringContent(especieJson, System.Text.Encoding.UTF8, "application/json");
            response = httpClient.PostAsync(rutaEspecies, content).Result;
            json = response.Content.ReadAsStringAsync().Result;

            //Deserializar la respuesta
            var especieCreada = Newtonsoft.Json.JsonConvert.DeserializeObject<Zoologico_Modelos.ApiResult<Zoologico_Modelos.Especie>>(json);

            //Actualizacion de datos
            especieCreada.Data.NombreComun = "Tigre de Bengala 2";
            especieJson = Newtonsoft.Json.JsonConvert.SerializeObject(especieCreada.Data);
            content = new StringContent(especieJson, System.Text.Encoding.UTF8, "application/json");
            response = httpClient.PutAsync($"{rutaEspecies}/{especieCreada.Data.codigo}", content).Result;
            json = response.Content.ReadAsStringAsync().Result;
            var especieActualizada = Newtonsoft.Json.JsonConvert.DeserializeObject<Zoologico_Modelos.ApiResult<Zoologico_Modelos.Especie>>(json);

            //Eliminacion de datos
            response = httpClient.DeleteAsync($"{rutaEspecies}/{especieCreada.Data.codigo}").Result;
            json = response.Content.ReadAsStringAsync().Result;
            var especieEliminada = Newtonsoft.Json.JsonConvert.DeserializeObject<Zoologico_Modelos.ApiResult<Zoologico_Modelos.Especie>>(json);


            Console.WriteLine(json);
            Console.ReadLine();
        }
    }
}
