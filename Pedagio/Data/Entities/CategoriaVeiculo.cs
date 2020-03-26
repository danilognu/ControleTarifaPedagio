

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedagio.Data.Entities
{
    public class CategoriaVeiculo
    {
        [Key]
        public int CategoriaId { get; set; }

        public int Numero { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Descricao { get; set; }
    }
}
