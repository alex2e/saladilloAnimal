using SaladilloAnimal.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloAnimal.Assets
{   
    /// <summary>
    /// Repositorio que nos permite conectar con la tabla de Clientes de nuestra BD
    /// </summary>
    public class ClienteRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        public ClienteRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Clientes>().Wait();
        }

        /// <summary>
        /// Agrega un Clientes a la BD
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="nombre"></param>
        /// <param name="password"></param>
        /// <param name="idMascota"></param>
        /// <param name="nombreMascota"></param>
        /// <param name="edadMascota"></param>
        /// <param name="colorMascota"></param>
        /// <param name="pesoMascota"></param>
        /// <param name="tipoMascota"></param>
        /// <returns></returns>
        public async Task AgregarCliente(string dni, string nombre, string password, 
                                        int idMascota, string nombreMascota, int edadMascota,
                                        string colorMascota, float pesoMascota, string tipo)
        {
            int result = 0;
            try
            {
                result = await conn.InsertAsync(new Clientes
                {
                    Dni = dni,
                    Cliente = nombre,
                    Password = password,
                    Tipo_Mascota = idMascota,
                    Nombre = nombreMascota,
                    Edad = edadMascota,
                    Color = colorMascota,
                    Peso = pesoMascota,
                    Tipo = tipo,
                });

                StatusMessage = string.Format("{0} record(s) added.", result);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add. Error: {1}", ex.Message);
            }

        }


        /// <summary>
        /// Para obtener una lista con todos los clientes
        /// </summary>
        /// <returns><List<Clientes></returns>
        public async Task<List<Clientes>> ObtenerClientes()
        {
            List<Clientes> listaClientes;
            try
            {
                listaClientes = await conn.Table<Clientes>().ToListAsync();
            }
            catch (Exception e)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", e.Message);
                listaClientes = new List<Clientes>();
            }

            return listaClientes;

        }

    }
}
