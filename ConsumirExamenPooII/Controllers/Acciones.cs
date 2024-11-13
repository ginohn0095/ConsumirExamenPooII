using ConsumirExamenPooII.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsumirExamenPooII.Controllers
{
    internal class Acciones
    {
        static readonly HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:7119"),
        };
        // Obtener todos los productos de Ropa
        public async Task ObtenerRopaAsync()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/ropa");
            if (response.IsSuccessStatusCode)
            {
                var ropa = JsonConvert.DeserializeObject<List<Ropa>>(await response.Content.ReadAsStringAsync());
                foreach (var item in ropa)
                {
                    Console.WriteLine($"ID: {item.id}, Nombre: {item.Nombre}, Tipo: {item.tipo}, Talla: {item.Talla}, Precio: {item.Precio:C}");
                }
            }
            else
            {
                Console.WriteLine("Error al obtener los productos de ropa.");
            }
        }

        // Obtener un producto de Ropa por ID
        public async Task ObtenerRopaPorIdAsync(int id)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync($"api/ropa/{id}");
            if (response.IsSuccessStatusCode)
            {
                var ropa = JsonConvert.DeserializeObject<Ropa>(await response.Content.ReadAsStringAsync());
                Console.WriteLine($"ID: {ropa.id}, Nombre: {ropa.Nombre}, Tipo: {ropa.tipo}, Talla: {ropa.Talla}, Precio: {ropa.Precio:C}");
            }
            else
            {
                Console.WriteLine("Producto de ropa no encontrado.");
            }
        }

        // Crear un nuevo producto de Ropa
        public async Task CrearRopaAsync()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Console.Write("Ingrese el nombre del producto de ropa: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el tipo del producto de ropa: ");
            string tipo = Console.ReadLine();
            Console.Write("Ingrese la talla del producto de ropa: ");
            string talla = Console.ReadLine();
            Console.Write("Ingrese el precio del producto de ropa: ");
            decimal precio = decimal.Parse(Console.ReadLine());

            var ropa = new Ropa { Nombre = nombre, tipo = tipo, Talla = talla, Precio = precio };
            var json = JsonConvert.SerializeObject(ropa);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("api/ropa", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Producto de ropa creado con éxito.");
            }
            else
            {
                Console.WriteLine("Error al crear el producto de ropa.");
            }
        }

        // Actualizar un producto de Ropa
        public async Task ActualizarRopaAsync(int id)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Console.Write("Ingrese el nuevo nombre del producto de ropa: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el nuevo tipo del producto de ropa: ");
            string tipo = Console.ReadLine();
            Console.Write("Ingrese la nueva talla del producto de ropa: ");
            string talla = Console.ReadLine();
            Console.Write("Ingrese el nuevo precio del producto de ropa: ");
            decimal precio = decimal.Parse(Console.ReadLine());

            var ropa = new Ropa { id = id, Nombre = nombre, tipo = tipo, Talla = talla, Precio = precio };
            var json = JsonConvert.SerializeObject(ropa);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync($"api/ropa/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Producto de ropa actualizado con éxito.");
            }
            else
            {
                Console.WriteLine("Error al actualizar el producto de ropa.");
            }
        }

        // Eliminar un producto de Ropa
        public async Task EliminarRopaAsync(int id)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.DeleteAsync($"api/ropa/{id}");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Producto de ropa eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("Error al eliminar el producto de ropa.");
            }
        }
    }
}
