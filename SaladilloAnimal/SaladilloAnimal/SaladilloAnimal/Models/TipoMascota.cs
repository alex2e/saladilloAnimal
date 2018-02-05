using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaladilloAnimal.Models
{
    /// <summary>
    /// Tabla de tipos de mascota
    /// </summary>
    [Table("TIPO_MASCOTA")]
    public class TipoMascota
    {
        /// <summary>
        /// Id del tipo de mascota
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// Tipo de mascota
        /// </summary>
        [Unique, NotNull, MaxLength(15)]
        public string Tipo_Mascota { get; set; }
    }
}
