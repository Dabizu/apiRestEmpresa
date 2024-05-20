using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apirest.model
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string username { get; set; }
        public string genero { get; set; }
        public int edad { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
    }
}
//comando para genera la carpeta de vinculacion de la base de datos
//Add-Migration InitDB
