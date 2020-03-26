using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedagio.Data
{
    public interface ILoginRepository
    {
        int BuscaUsuario(string user, string password);
    }
}
