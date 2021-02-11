using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CorePeliculasAlexGM.Models
{
    [Table("PELICULAS")]
    public class Pelicula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPelicula { get; set; }
        public int IdGenero { get; set; }
        public string Titulo { get; set; }
        public string Argumento { get; set; }
        public string Foto { get; set; }
        public DateTime Fecha_Estreno { get; set; }
        public string Actores { get; set; }
        public string Director { get; set; }
        public int Precio { get; set; }
        public string YouTube { get; set; }
        public string EnlaceVideo { get; set; }
    }
}
