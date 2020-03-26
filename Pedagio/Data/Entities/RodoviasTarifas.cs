using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pedagio.Data.Entities
{
    public class RodoviasTarifas
    {
        [Key]
        public int RodoviaTarifaId { get; set; }
        public int RodoviaId { get; set; }
        public string AssociateCompKNownName { get; set; } //ASSOCIATE_COMP_KNOWN_NAME
        public string Praca { get; set; } // PRACA
        public string VehicleClassId { get; set; } //VEHICLE_CLASS_ID
        public string Name { get; set; }
        public string DateHourProgramStart { get; set; } //DATE_HOUR_PROGRAM_START
        public string Value { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Rodovia { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Km { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Cidade { get; set; }
    }
}
