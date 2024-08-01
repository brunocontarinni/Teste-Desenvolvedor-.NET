using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCRM.Models;

namespace SistemaCRM.DAO.Map
{
    public class InscricaoMap : IEntityTypeConfiguration<InscricaoModel>
    {

        public void Configure(EntityTypeBuilder<InscricaoModel> builder)
        {

            builder.HasKey(x => x.Id_inscricao);
            builder.Property(x => x.Num_inscricao).IsRequired().HasMaxLength(16);
            builder.Property(x => x.Dt_inscricao).IsRequired();
            builder.Property(x => x.Tag_status).IsRequired();
            builder.Property(x => x.id_candidato).IsRequired();
            builder.Property(x => x.id_processo).IsRequired();
            builder.Property(x => x.id_curso).IsRequired();

            builder.HasOne(x => x.Candidadto);
            builder.HasOne(x => x.Curso);
            builder.HasOne(x => x.Processo);

        }
    }
}
