using PIOL.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PIOL.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>, IMapping
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.HasOne(f => f.Endereco)
                .WithOne(e => e.Fornecedor);

            builder.HasMany(f => f.Produtos)
                .WithOne(p => p.Fornecedor)
                .HasForeignKey(p => p.FornecedorId);

            builder.ToTable("Fornecedores");
        }
    }
}