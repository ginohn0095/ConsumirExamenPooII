using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ConsumirExamenPooII.Controllers;
using ConsumirExamenPooII.Models;

namespace ConsumirExamenPooII
{
    internal class Program
    {
        public enum Menu
        {
            ObtenerRopaAsync = 1, ObtenerRopaPorIdAsync, CrearRopaAsync, ActualizarRopaAsync, EliminarRopaAsync, Salir
        }
        static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
              Acciones acciones = new Acciones();
                bool exit = false;

                while (!exit)
                {
                    switch (Seleccion())
                    {
                        case Menu.ObtenerRopaAsync:
                            await acciones.ObtenerRopaAsync();
                            break;
                        case Menu.ObtenerRopaPorIdAsync:
                            Console.Write("Ingrese el ID del producto de ropa: ");
                            int idObtener = int.Parse(Console.ReadLine());
                            await acciones.ObtenerRopaPorIdAsync(idObtener);
                            break;
                        case Menu.CrearRopaAsync:
                            await acciones.CrearRopaAsync();
                            break;
                        case Menu.ActualizarRopaAsync:
                            Console.Write("Ingrese el ID del producto de ropa a actualizar: ");
                            int idActualizar = int.Parse(Console.ReadLine());
                            await acciones.ActualizarRopaAsync(idActualizar);
                            break;
                        case Menu.EliminarRopaAsync:
                            Console.Write("Ingrese el ID del producto de ropa a eliminar: ");
                            int idEliminar = int.Parse(Console.ReadLine());
                            await acciones.EliminarRopaAsync(idEliminar);
                            break;
                        case Menu.Salir:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente de nuevo.");
                            break;
                    }
                }
            }

            static Menu Seleccion()
            {
                Console.WriteLine("Seleccione la opción que desea realizar:");
                Console.WriteLine("1) Obtener registro completo de ropa");
                Console.WriteLine("2) Obtener registro de ropa por ID");
                Console.WriteLine("3) Crear registro de ropa");
                Console.WriteLine("4) Actualizar registro de ropa");
                Console.WriteLine("5) Eliminar registro de ropa");
                Console.WriteLine("6) Salir");

                try
                {
                    Menu opc = (Menu)Convert.ToInt32(Console.ReadLine());
                    return opc;
                }
                catch (Exception)
                {
                    Console.WriteLine("La opción seleccionada no es válida. Intente de nuevo.");
                    return 0;
                }
            }
        }
    }

