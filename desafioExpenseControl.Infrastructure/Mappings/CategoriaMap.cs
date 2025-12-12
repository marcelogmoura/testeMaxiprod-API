using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ExpenseControl.Domain.Entities;

namespace ExpenseControl.Infrastructure.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("TB_CATEGORIAS");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("ID");

            builder.Property(c => c.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Finalidade)
                .HasColumnName("FINALIDADE")
                .HasConversion<int>() //salvar int no banco
                .IsRequired();
        }
    }
}