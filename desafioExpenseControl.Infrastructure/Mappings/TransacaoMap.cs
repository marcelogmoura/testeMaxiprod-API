using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ExpenseControl.Domain.Entities;

namespace ExpenseControl.Infrastructure.Mappings
{
    public class TransacaoMap : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("TB_TRANSACOES");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("ID");

            builder.Property(t => t.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.Valor)
                .HasColumnName("VALOR")
                .HasColumnType("DECIMAL(18,2)") // Importante para dinheiro
                .IsRequired();

            builder.Property(t => t.Tipo)
                .HasColumnName("TIPO")
                .HasConversion<int>()
                .IsRequired();

            builder.Property(t => t.DataCriacao)
                .HasColumnName("DATA_CRIACAO")
                .HasDefaultValueSql("CURRENT_TIMESTAMP"); // Opcional: Banco gera data se não enviar

            // Chaves Estrangeiras
            builder.Property(t => t.PessoaId)
                .HasColumnName("PESSOA_ID")
                .IsRequired();

            builder.Property(t => t.CategoriaId)
                .HasColumnName("CATEGORIA_ID")
                .IsRequired();

            // Relacionamentos
            builder.HasOne(t => t.Pessoa)
                .WithMany(p => p.Transacoes)
                .HasForeignKey(t => t.PessoaId);

            builder.HasOne(t => t.Categoria)
                .WithMany(c => c.Transacoes)
                .HasForeignKey(t => t.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict); // Evita apagar Categoria se tiver transação usada
        }
    }
}