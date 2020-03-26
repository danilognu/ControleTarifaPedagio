using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pedagio.Data.Entities;
using Pedagio.ViewsModels;

namespace Pedagio.Data
{
    public interface IComparacaoArquivosRepository
    {
        void Salvar(ComparacaoArquivos arquivos);
    }
}
