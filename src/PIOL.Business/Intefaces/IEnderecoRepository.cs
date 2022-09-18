using System;
using System.Threading.Tasks;
using PIOL.Business.Models;

namespace PIOL.Business.Intefaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}