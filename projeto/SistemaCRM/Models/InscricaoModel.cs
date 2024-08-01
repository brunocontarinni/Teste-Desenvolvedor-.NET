using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SistemaCRM.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SistemaCRM.Models
{

    [Table("t_inscricao")]
    public class InscricaoModel
    {

        [Column("id_inscricao", TypeName = "int"), Required, Key]
        private readonly int id_inscricao;
        [Column("num_inscricao", TypeName = "varchar(16)"), MaxLength(50, ErrorMessage = "Número da inscrição ultrapassa 16 caracteres."), Required]
        private readonly string num_inscricao;
        [Column("dt_inscricao", TypeName = "date"), Required]
        private readonly DateTime dt_inscricao;
        [Column("tag_status", TypeName = "int"), Required]
        private readonly StatusInscricao tag_status;
        [Column("id_candidato", TypeName = "int"), ForeignKey("Candidadto")]
        [SwaggerSchema(Description = "Identificador do candidato.")]
        public int id_candidato { get; set; }
        [Column("id_processo", TypeName = "int"), ForeignKey("Processo")]
        [SwaggerSchema(Description = "Identificador do processo.")]
        public int id_processo { get; set; }
        [Column("id_curso", TypeName = "int"), ForeignKey("Curso")]
        [SwaggerSchema(Description = "Identificador do curso.")]
        public int id_curso { get; set; }

        [IgnoreDataMember]
        [SwaggerIgnore]
        public virtual CandidatoModel? Candidadto { get; set; }
        [IgnoreDataMember]
        [SwaggerIgnore]
        public virtual ProcessoModel? Processo { get; set; }
        [IgnoreDataMember]
        [SwaggerIgnore]
        public virtual CursoModel? Curso { get; set; }

        public InscricaoModel(int id_inscricao, string num_inscricao, DateTime dt_inscricao, StatusInscricao tag_status, int id_candidato, int id_processo, int id_curso)
        {

            this.id_inscricao = id_inscricao;
            this.num_inscricao = num_inscricao;
            this.dt_inscricao = dt_inscricao;
            this.tag_status = tag_status;
            this.id_candidato = id_candidato;
            this.id_processo = id_processo;
            this.id_curso = id_curso;

        }

        #region "Gets e Sets"

        [SwaggerSchema(Description = "Identificador da inscrição.")]
        public int Id_inscricao => id_inscricao;

        [SwaggerSchema(Description = "Número da inscrição.")]
        public string Num_inscricao => num_inscricao;

        [SwaggerSchema(Description = "Data da inscrição.")]
        public DateTime Dt_inscricao => dt_inscricao;

        [SwaggerSchema(Description = "Status da inscrição.")]
        public StatusInscricao Tag_status => tag_status;

        #endregion

    }

}
