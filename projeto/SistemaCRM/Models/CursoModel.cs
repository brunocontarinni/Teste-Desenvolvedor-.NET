using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCRM.Models
{

    [Table("t_curso")]
    public class CursoModel
    {

        [Column("id_curso", TypeName = "int"), Required, Key]
        private readonly int id_curso;
        [Column("nom_curso", TypeName = "varchar(50)"), MaxLength(50, ErrorMessage = "Nome da oferta ultrapassa 50 caracteres."), Required]
        private readonly string nom_curso;
        [Column("des_curso", TypeName = "varchar(255)"), MaxLength(50, ErrorMessage = "Descrição da oferta ultrapassa 255 caracteres."), Required]
        private readonly string des_curso;
        [Column("num_vagas", TypeName = "int"), Required]
        private readonly int num_vagas;

        public CursoModel(int id_curso, string nom_curso, string des_curso, int num_vagas)
        {

            this.id_curso = id_curso;
            this.nom_curso = nom_curso;
            this.des_curso = des_curso;
            this.num_vagas = num_vagas;

        }

        #region "Gets e Sets"


        [SwaggerSchema(Description = "Identificador do curso.")]
        public int Id_curso => id_curso;

        [SwaggerSchema(Description = "Nome do curso.")]
        public string Nom_curso => nom_curso.Trim().ToUpper();

        [SwaggerSchema(Description = "Descrição do curso.")]
        public string Des_curso => des_curso.Trim();

        [SwaggerSchema(Description = "Quantidade de vagas disponíveis.")]
        public int Num_vagas => num_vagas;

        #endregion

        public void Validate(bool all = false)
        {

            if (all)
            {

                if (this.id_curso <= 0)
                    throw new ArgumentNullException("ID do curso deve ser maior que 0.");

            }

            if (string.IsNullOrEmpty(this.nom_curso))
                throw new ArgumentNullException("Nome do curso deve ser informado.");

            if (this.nom_curso.Length > 50)
                throw new ArgumentException("Nome do curso deve possuir até 50 caracteres.");

            if (string.IsNullOrEmpty(this.des_curso))
                throw new ArgumentNullException("Descrição do curso deve ser informado.");

            if (this.des_curso.Length > 255)
                throw new ArgumentException("Descrição do curso deve possuir até 255 caracteres.");

            if (this.num_vagas <= 0)
                throw new ArgumentNullException("Quantidade de vagas deve ser maior que 0.");

        }

    }
}
