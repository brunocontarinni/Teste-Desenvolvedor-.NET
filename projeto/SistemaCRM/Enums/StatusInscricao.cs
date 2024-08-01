using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace SistemaCRM.Enums
{

    [SwaggerSchema(Description = "Status da Inscrição.")]
    public enum StatusInscricao
    {

        [Description("Inscrito")]
        INSCRITO = 1,

        [Description("Deferido")]
        APROVADO = 2,

        [Description("Indeferido")]
        REPROVADO = 3,

    }

}
