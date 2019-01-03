using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityApi.Repositorio.Identity
{
    public class IdentityRepositorio:IIdentityRepositorio
    {
        public bool VerificarSenhaAtual(string senhaAtual)
        {
            //senhaAtualCadastrada deveria verificar no BD se senha está de acordo com a cadastrada
            //como é um Mock, não será implementado um BD
            string senhaAtualCadastrada = senhaAtual;

            return senhaAtualCadastrada.Equals(senhaAtual);
        }

        public bool SalvarSenhaNova(string senhaNova)
        {
            SalvarSenha();
            return true;
        }

        private void SalvarSenha()
        {
            //salvar senha atual no banco
        }
    }
}
