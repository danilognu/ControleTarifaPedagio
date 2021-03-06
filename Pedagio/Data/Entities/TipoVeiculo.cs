﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pedagio.Data.Entities
{
    public class TipoVeiculo
    {
        [Key]
        public int TipoVeiculoId { get; set; }
        public string Nome { get; set; }
        public int PessoaIdCad { get; set; }
        public int PessoaIdEmp { get; set; }
        public int Status { get; set; }
    }
}
