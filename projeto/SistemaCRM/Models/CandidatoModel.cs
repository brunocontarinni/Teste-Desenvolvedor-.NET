using API_CRM.Helper;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCRM.Models
{

    [Table("t_candidato")]
    public class CandidatoModel
    {

        [Column("id_candidato", TypeName = "int"), Required, Key]
        private readonly int id_candidato;
        [Column("nom_candidato", TypeName = "varchar(50)"), MaxLength(50, ErrorMessage = "Nome do candidato ultrapassa 50 caracteres."), Required]
        private readonly string nom_candidato;
        [Column("des_email", TypeName = "varchar(50)"), MaxLength(50, ErrorMessage = "E-mail do candidato ultrapassa 50 caracteres.")]
        private readonly string? des_email;
        [Column("num_telefone", TypeName = "varchar(15)"), MaxLength(50, ErrorMessage = "Telefone do candidato ultrapassa 15 caracteres."), Required]
        private readonly string num_telefone;
        [Column("nom_candidato", TypeName = "varchar(14)"), MaxLength(50, ErrorMessage = "CPF do candidato ultrapassa 14 caracteres."), Required]
        private readonly string num_cpf;

        public CandidatoModel(int id_candidato, string nom_candidato, string des_email, string num_telefone, string num_cpf)
        {

            this.id_candidato = id_candidato;
            this.nom_candidato = nom_candidato;
            this.des_email = des_email;
            this.num_telefone = num_telefone;
            this.num_cpf = num_cpf;

        }

        #region "Gets e Sets"

        [SwaggerSchema(Description = "Identificador do candidato.")]        
        public int Id_candidato => id_candidato;

        [SwaggerSchema(Description = "Nome do candidato.")]
        public string Nom_candidato => nom_candidato.Trim().ToUpper();


        [SwaggerSchema(Description = "E-mail do candidato.")]
        public string Des_email => (des_email == null ? "" : des_email.Trim().ToLower());


        [SwaggerSchema(Description = "Telefone do candidato (XX) ?XXXX-XXXX.")]
        public string Num_telefone => num_telefone;


        [SwaggerSchema(Description = "CPF do candidato.")]
        public string Num_cpf => num_cpf;

        #endregion

        public void Validate(bool all = false)
        {

            if (all)
            {

                if (this.id_candidato <= 0)
                    throw new ArgumentNullException("ID do candidato deve ser maior que 0.");

            }

            if (string.IsNullOrEmpty(this.nom_candidato))
                throw new ArgumentNullException("Nome do candidato deve ser informado.");

            if (this.nom_candidato.Length > 50)
                throw new ArgumentException("Nome do candidato deve possuir até 50 caracteres.");

            if (!string.IsNullOrEmpty(this.des_email) && !this.des_email.Contains("@"))
                throw new ArgumentException("E-mail inválido.");

            if (string.IsNullOrEmpty(this.num_telefone))
                throw new ArgumentNullException("Telefone do candidato deve ser informado.");

            if (this.num_telefone.Length < 9)
                throw new ArgumentException("Telefone deve possuir mais de 8 caracteres.");

            if (string.IsNullOrEmpty(this.num_cpf))
                throw new ArgumentNullException("CPF deve ser informado.");

            if (this.num_cpf.Length < 11)
                throw new ArgumentException("CPF deve possuir mais de 10 caracteres.");

            if (!Helper.IsCpf(this.num_cpf))
                throw new ArgumentException($"CPF {this.num_cpf} não é um CPF válido.");

        }

    }

}
