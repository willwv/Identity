using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityApi.Repositorio.Identity
{
    public interface IIdentityRepositorio
    {
        bool VerificarSenhaAtual(string senhaAtual);
        bool SalvarSenhaNova(string senhaNova);
    }
}
