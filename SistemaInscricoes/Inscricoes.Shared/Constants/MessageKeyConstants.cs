namespace Inscricoes.Shared.Constants;

public static class MessageKeyConstants
{
	// System
	public const string MESSAGE_ERROR = "message.error.somethingWentWrong";

	// Data Validation
	public const string MESSAGE_ERROR_ID_IS_REQUIRED = "message.error.idIsRequired";
	public const string MESSAGE_ERROR_EMAIL_IS_REQUIRED = "message.error.emailIsRequired";
	public const string MESSAGE_ERROR_EMAIL_INVALID = "message.error.emailInvalid";
	public const string MESSAGE_ERROR_PHONE_IS_REQUIRED = "message.error.phoneIsRequired";
	public const string MESSAGE_ERROR_PHONE_INVALID = "message.error.phoneInvalid";
	public const string MESSAGE_ERROR_CPF_IS_REQUIRED = "message.error.cpfIsRequired";
	public const string MESSAGE_ERROR_CPF_INVALID = "message.error.cpfInvalid";
	public const string MESSAGE_ERROR_NAME_IS_REQUIRED = "message.error.nameIsRequired";
	public const string MESSAGE_ERROR_FIELD_STRING_LENGTH = "message.error.fieldStringLength";
	public const string MESSAGE_ERROR_FIELD_INT_INTERVAL = "message.error.fieldIntInterval";
	public const string MESSAGE_ERROR_DATE_IS_REQUIRED = "message.error.dateIsRequired";
	public const string MESSAGE_ERROR_STATUS_IS_REQUIRED = "message.error.statusIsRequired";

	// Lead
	public const string MESSAGE_ERROR_LEAD_VALIDATE = "message.error.leadValidate";
	public const string MESSAGE_ERROR_LEAD_NOT_FOUND = "message.error.leadNotFound";
	public const string MESSAGE_ERROR_LEAD_CPF_ALREADY_EXISTS = "message.error.leadCpfAlreadyExists";
	public const string MESSAGE_ERROR_LEAD_EMAIL_ALREADY_EXISTS = "message.error.leadEmailAlreadyExists";

	// Inscricao
	public const string MESSAGE_ERROR_INSCRICAO_VALIDATE = "message.error.inscricaoValidate";
	public const string MESSAGE_ERROR_INSCRICAO_NOT_FOUND = "message.error.inscricaoNotFound";
	public const string MESSAGE_ERROR_INSCRICAO_ALREADY_EXISTS = "message.error.inscricaoAlreadyExists";
	public const string MESSAGE_ERROR_INSCRICAO_STATUS_IS_REQUIRED = "message.error.inscricaoStatusIsRequired";
	public const string MESSAGE_ERROR_INSCRICAO_DATE_IS_REQUIRED = "message.error.inscricaoDateIsRequired";
	public const string MESSAGE_ERROR_INSCRICAO_CPF_IS_REQUIRED = "message.error.inscricaoCpfIsRequired";

	// Oferta
	public const string MESSAGE_ERROR_OFERTA_VALIDATE = "message.error.ofertaValidate";
	public const string MESSAGE_ERROR_OFERTA_NOT_FOUND = "message.error.ofertaNotFound";
	public const string MESSAGE_ERROR_OFERTA_NAME_IS_REQUIRED = "message.error.ofertaNameIsRequired";
	public const string MESSAGE_ERROR_OFERTA_VAGAS_DISPONIVEIS_IS_REQUIRED = "message.error.ofertaVagasDisponiveisIsRequired";
	public const string MESSAGE_ERROR_OFERTA_VAGAS_DISPONIVEIS_INVALID = "message.error.ofertaVagasDisponiveisInvalid";
	public const string MESSAGE_ERROR_OFERTA_ALREADY_EXISTS = "message.error.ofertaAlreadyExists";
	public const string MERSSAGE_ERROR_OFERTA_NO_VACANCIES = "message.error.ofertaNoVacancies";

	// Processo Seletivo
	public const string MESSAGE_ERROR_PROCESSO_SELETIVO_VALIDATE = "message.error.processoSeletivoValidate";
	public const string MESSAGE_ERROR_PROCESSO_SELETIVO_NOT_FOUND = "message.error.processoSeletivoNotFound";
	public const string MESSAGE_ERROR_PROCESSO_SELETIVO_NAME_IS_REQUIRED = "message.error.processoSeletivoNameIsRequired";
	public const string MESSAGE_ERROR_PROCESSO_SELETIVO_DATE_START_IS_REQUIRED = "message.error.processoSeletivoDateStartIsRequired";
	public const string MESSAGE_ERROR_PROCESSO_SELETIVO_DATE_END_IS_REQUIRED = "message.error.processoSeletivoDateEndIsRequired";
	public const string MESSAGE_ERROR_PROCESSO_SELETIVO_DATE_INVALID = "message.error.processoSeletivoDateInvalid";
	public const string MESSAGE_ERROR_PROCESSO_SELETIVO_ALREADY_EXISTS = "message.error.processoSeletivoAlreadyExists";
	public const string MESSAGE_ERROR_PROCESSO_SELETIVO_NOT_OPEN = "message.error.processoSeletivoNotOpen";
}
