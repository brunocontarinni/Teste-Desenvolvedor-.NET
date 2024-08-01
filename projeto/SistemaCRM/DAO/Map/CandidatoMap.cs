using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCRM.Models;

namespace SistemaCRM.DAO.Map
{
    public class CandidatoMap : IEntityTypeConfiguration<CandidatoModel>
    {

        public void Configure(EntityTypeBuilder<CandidatoModel> builder)
        {

            builder.HasKey(x => x.Id_candidato);
            builder.Property(x => x.Nom_candidato).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Des_email).HasMaxLength(50);
            builder.Property(x => x.Num_telefone).IsRequired();
            builder.Property(x => x.Num_cpf).IsRequired();

        }

    }
}
