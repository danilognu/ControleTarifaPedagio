using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pedagio.Data.Entities;
using Pedagio.ViewsModels;

namespace Pedagio.Data
{
    public class ComparacaoArquivosRepository : IComparacaoArquivosRepository
    {
        private readonly ApplicationDbContext _context;

        public ComparacaoArquivosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Salvar(ComparacaoArquivos arquivos)
        {
            arquivos.DataCadastro = DateTime.Today;
            _context.ComparacaoArquivos.Add(arquivos);
            _context.SaveChanges();
        }

    }
}
