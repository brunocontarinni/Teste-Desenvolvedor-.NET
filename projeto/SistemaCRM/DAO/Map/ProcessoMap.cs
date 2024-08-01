using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCRM.Models;

namespace SistemaCRM.DAO.Map
{

    public class ProcessoMap : IEntityTypeConfiguration<ProcessoModel>
    {

        public void Configure(EntityTypeBuilder<ProcessoModel> builder)
        {

            builder.HasKey(x => x.Id_processo);
            builder.Property(x => x.Nom_processo).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Dt_inicio).IsRequired();
            builder.Property(x => x.Dt_termino).IsRequired();

        }

    }
}
