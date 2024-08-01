using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCRM.Models;

namespace SistemaCRM.DAO.Map
{
    public class CursoMap : IEntityTypeConfiguration<CursoModel>
    {

        public void Configure(EntityTypeBuilder<CursoModel> builder)
        {

            builder.HasKey(x => x.Id_curso);
            builder.Property(x => x.Nom_curso).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Des_curso).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Num_vagas).IsRequired();

        }

    }
}
