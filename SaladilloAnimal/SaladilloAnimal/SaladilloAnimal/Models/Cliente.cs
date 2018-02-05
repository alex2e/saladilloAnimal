using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaladilloAnimal.Models
{
    /// <summary>
    /// Representa a un cliente de la base de datos
    /// </summary>
    [Table("clientes")]
    public class Clientes
    {
        /// <summary>
        /// Dni del cliente
        /// </summary>
        [PrimaryKey, MaxLength(9)]
        public string Dni { get; set; }

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        [NotNull, MaxLength(20)]
        public string Cliente { get; set; }

        /// <summary>
        /// Contraseña del cliente
        /// </summary>
        [NotNull, MaxLength(9)]
        public string Password { get; set; }

        /// <summary>
        /// Id del tipo de mascota
        /// </summary>
        public int Tipo_Mascota { get; set; }

        /// <summary>
        /// Nombre de la mascota
        /// </summary>
        [MaxLength(20)]
        public string Nombre { get; set; }

        /// <summary>
        /// Edad de la mascota
        /// </summary>
        public int Edad { get; set; }

        /// <summary>
        /// Color de la mascota
        /// </summary>
        [MaxLength(20)]
        public string Color { get; set; }

        /// <summary>
        /// Peso de la mascota
        /// </summary>
        public float Peso { get; set; }

        /// <summary>
        /// Tipo 
        /// </summary>
        [MaxLength(7)]
        public string Tipo { get; set; }

    }
}
