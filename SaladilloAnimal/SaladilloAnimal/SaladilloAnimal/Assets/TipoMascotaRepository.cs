using SaladilloAnimal.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloAnimal.Assets
{
    /// <summary>
    /// Repositorio que nos permite acceder a la tabla TIPO_MASCOTA de la BD
    /// </summary>
    public class TipoMascotaRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        public TipoMascotaRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<TipoMascota>().Wait();
        }

        /// <summary>
        /// Agrega un tipo de mascota a la BD
        /// </summary>
        /// <param name="idTipoMascota"></param>
        /// <param name="tipoMascota"></param>
        /// <returns></returns>
        public async Task AgregarTipoMascota(int idTipoMascota, string tipoMascota)
        {
            int result = 0;
            try
            {
                result = await conn.InsertAsync(new TipoMascota
                {
                    Id = idTipoMascota,
                    Tipo_Mascota = tipoMascota,
                });

                StatusMessage = string.Format("{0} record(s) added.", result);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add. Error: {1}", ex.Message);
            }

        }


        /// <summary>
        /// Para obtener una lista con todos los tipos de mascotas registrados
        /// </summary>
        /// <returns><List<TipoMascota></returns>
        public async Task<List<TipoMascota>> ObtenerTiposMascota()
        {
            List<TipoMascota> listaTipoMascotaas;
            try
            {
                listaTipoMascotaas = await conn.Table<TipoMascota>().ToListAsync();
            }
            catch (Exception e)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", e.Message);
                listaTipoMascotaas = new List<TipoMascota>();
            }

            return listaTipoMascotaas;
        }
    }
}
