using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedagio.ViewsModels
{
    public class PassagensPedagioBuscaChaveViewsModels
    {
        public int PassagemPedagioId { get; set; }
	    public string Placa { get; set; }
        public string Rodovia { get; set; }
        public string Praca { get; set; }
        public decimal Valor { get; set; }
        public int EixoAbaixado { get; set; }
        public int ExioSuspenso { get; set; }
    }
}
