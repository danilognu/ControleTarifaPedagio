using Pedagio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Pedagio.Data
{
    public class LoginRepository: ILoginRepository
    {
        private readonly ApplicationDbContext _context;

        public LoginRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public int BuscaUsuario(string user, string password)
        {
            int result = 0;
            Hash hash = new Hash(SHA512.Create());
            var _senha = hash.CriptografarSenha(password);

            var _sQuery = _context.Pessoas
                          .Where(b => b.Login == user)
                          .Where(b => b.Senha == _senha);

            foreach(var resultPessoa in _sQuery)
            {
                var nome = resultPessoa.Nome;
                var login = resultPessoa.Login;
                if(nome != null)
                {
                    result = 1;
                }

            }

            return result;

        }
    }
}
