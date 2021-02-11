using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CorePeliculasAlexGM.Models
{
    [Table("GENEROS")]
    public class Genero
    {
        [Key]
        [Column("IDGENERO")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdGenero { get; set; }
        [Column("GENERO")]
        public string NombreGenero { get; set; }
    }
}
