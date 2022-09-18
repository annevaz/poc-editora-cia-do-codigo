using System;
using System.Threading.Tasks;
using PIOL.Business.Intefaces;
using PIOL.Business.Models;
using PIOL.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace PIOL.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MeuDbContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
        }
    }
}