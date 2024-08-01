using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCRM.Models
{

    [Table("t_processo")]
    public class ProcessoModel
    {

        [Column("id_processo", TypeName = "int"), Required, Key]
        private readonly int id_processo;
        [Column("nom_processo", TypeName = "varchar(50)"), MaxLength(50,ErrorMessage = "Nome do processo ultrapassa 50 caracteres."), Required]
        private readonly string nom_processo;
        [Column("dt_inicio", TypeName = "date"), Required]
        private readonly DateTime dt_inicio;
        [Column("dt_termino", TypeName = "date"), Required]
        private readonly DateTime dt_termino;

        public ProcessoModel(int id_processo, string nom_processo, DateTime dt_inicio, DateTime dt_termino)
        {

            this.id_processo = id_processo;
            this.nom_processo = nom_processo.ToUpper();
            this.dt_inicio = dt_inicio;
            this.dt_termino = dt_termino;

        }

        #region "Gets e Sets"

        [SwaggerSchema(Description = "Identificador do processo.")]
        public int Id_processo => id_processo;

        [SwaggerSchema(Description = "Nome do processo.")]
        public string Nom_processo => nom_processo.ToUpper();

        [SwaggerSchema(Description = "Data de Início do processo.")]
        public DateTime Dt_inicio => dt_inicio;

        [SwaggerSchema(Description = "Data de Término do processo.")]
        public DateTime Dt_termino => dt_termino;

        #endregion

        public void Validate(bool all = false)
        {

            if (all)
            {

                if (this.id_processo <= 0)
                    throw new ArgumentNullException("ID do processo deve ser maior que 0.");

            }

            if (string.IsNullOrEmpty(this.nom_processo))
                throw new ArgumentNullException("Nome do processo deve ser informado.");

            if (this.nom_processo.Length > 50)
                throw new ArgumentException("Nome do nom_processo deve possuir até 50 caracteres.");

            if (this.dt_inicio > this.dt_termino)
                throw new ArgumentException("Data de término deve ser igual ou superior a data de início.");

        }

    }

}
