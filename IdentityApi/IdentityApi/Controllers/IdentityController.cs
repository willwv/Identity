using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityApi.Model;
using IdentityApi.Repositorio.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private IdentityRepositorio identityRepositorio = new IdentityRepositorio();
        // GET api/values
        [HttpGet("{usuario}")]
        public ActionResult<ObjetoRetorno> ValidarUsuario(string usuario, [FromBody] string senha)
        {
            bool sucesso;
            string mensagem = string.Empty;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                sucesso = false;
                mensagem = "Nome e senha são obrigatórios";
            }
            else
            {
                sucesso = true;
                mensagem = "Logado com Sucesso!";
            }

            return new ObjetoRetorno() { Sucesso = sucesso, Mensagem = mensagem};
        }

        [HttpPut("{usuario}")]
        public ActionResult<ObjetoRetorno> AlterarSenha(int usuario, [FromBody] Senhas senhas)
        {
            bool sucesso;
            string mensagem = string.Empty;

            if (senhas.SenhaAntiga.Equals(senhas.SenhaNova))
            {
                sucesso = false;
                mensagem = "A senha atual deve ser diferente da antiga.";
            }
            else if (identityRepositorio.VerificarSenhaAtual(senhas.SenhaAntiga))
            {
                identityRepositorio.SalvarSenhaNova(senhas.SenhaNova);
                sucesso = true;
                mensagem = "A senha foi alterada.";
            }
            else
            {
                sucesso = false;
                mensagem = "Dados inconsistentes.";
            }

            return new ObjetoRetorno() { Sucesso = sucesso, Mensagem = mensagem };
        }
    }
}
