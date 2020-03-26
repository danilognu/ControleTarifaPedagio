using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedagio.ViewsModels
{
    public class PassagensValePedagioCalculado
    {
        public int PassagemValePedagioId { get; set; }
        public string Placa { get; set; }
        public string Rodovia { get; set; }
        public string Praca { get; set; }
        public decimal Valor { get; set; }
        public int EixoAbaixado { get; set; }
        public int EixoSuspenso { get; set; }
        public string ValorTarifaEixoAbaixado { get; set; }
        public string ValorTarifaEixoSuspenso { get; set; }
    }
}
