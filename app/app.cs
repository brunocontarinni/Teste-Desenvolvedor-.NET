using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

using MySqlCreation;
using DatabaseConnectionSpace;
using ChooserSpace;
using QueryCreatorSpace;
using GetterSpace;
using HashCreatorSpace;
using EmailValidatorSpace;
using FormatterSpace;
using DeleterSpace;
using PuterSpace;
namespace appMain
{
    class app
    {
        public static Dictionary<string, string> SetCandidatoInfo(string[] args, Dictionary<string, string> data)
        {
            data["nome"] = args[0];
            data["email"] = EmailValidator.IsValidEmail(args[1]) ? args[1] : null;
            data["telefone"] = args[2];
            data["cpf"] = args[3];

            return data;
        }

        public static Dictionary<string, string> SetOfertaInfo(string[] args, Dictionary<string, string> data)
        {
            data["nome"] = args[0];
            data["descricao"] = args[1];
            data["vagas_disponiveis"] = args[2];

            return data;
        }

        public static Dictionary<string, string> SetProcessoInfo(string[] args, Dictionary<string, string> data)
        {

            data["nome"] = args[0];
            data["data_inicio"] = args[1];
            data["data_termino"] = args[2];

            return data;
        }

        public static Dictionary<string, string> SetInscricaoInfo(string[] args, Dictionary<string, string> data)
        {
            Getter getter = new Getter();

            data["numero_inscricao"] = HashCreator.GenerateHash(getter.Get(QueryCreator.CreateGetNameLead(args[0])).Trim());
            data["data"] = DateTime.Today.ToString("yyyy/MM/dd");
            data["status"] = "1";
            data["id_lead"] = args[0];
            data["id_oferta"] = args[1];
            data["id_processo_seletivo"] =args[2];

            return data;
        }

        public static List<Dictionary<string, string>> InscriçõesPorCpf (string cpf)
        {
            Getter getter = new Getter();

            string numero_inscricao = HashCreator.GenerateHash(getter.Get(QueryCreator.CreateGetCPFLead(cpf)).Trim());
            string inscricoes =  getter.Get(QueryCreator.CreateGetInscricoesPorCpf(numero_inscricao));

            return Formatter.FormatInscricoesInfo(inscricoes);
        }

        public static List<Dictionary<string, string>> InscriçõesPorOferta(int id)
        {
            Getter getter = new Getter();

            string inscricoes =  getter.Get(QueryCreator.CreateGetInscricoesPorOferta(id));

            return Formatter.FormatInscricoesInfo(inscricoes);
        }

        public static List<Dictionary<string, string>> InscriçõesGerais ()
        {
            Getter getter = new Getter();

            string inscricoes =  getter.Get(QueryCreator.CreateGetQuery("inscricao"));

            return Formatter.FormatInscricoesInfo(inscricoes);
        }

        public static List<Dictionary<string, string>> GetOfertaInfo (string tableName, int id=0)
        {
            Getter getter = new Getter();
            List<Dictionary<string, string>> resultado = new List<Dictionary<string, string>>();

            string inscricoes =  getter.Get(QueryCreator.CreateGetOfertaQuery(tableName, id));

            resultado = Formatter.FormatOfertaInfo(inscricoes);

            return resultado;
        }
        public static List<Dictionary<string, string>> GetCandidatoInfo (string tableName, int id=0)
        {
            Getter getter = new Getter();
            List<Dictionary<string, string>> resultado = new List<Dictionary<string, string>>();

            string inscricoes =  getter.Get(QueryCreator.CreateGetCandidatoQuery(tableName, id));

            resultado = Formatter.FormatCandidatoInfo(inscricoes);

            return resultado;
        }
        public static List<Dictionary<string, string>> GetProcessoInfo (string tableName, int id=0)
        {
            Getter getter = new Getter();
            List<Dictionary<string, string>> resultado = new List<Dictionary<string, string>>();

            string inscricoes =  getter.Get(QueryCreator.CreateGetProcessoQuery(tableName, id));

            resultado = Formatter.FormatProcessoInfo(inscricoes);
            return resultado;
        }

        public static void DeleteItem(int id, string tableName)
        {
            Deleter.Delete(QueryCreator.CreateDeleteQuery(id, tableName));
        }

        public static void UpdateItem(int id, Dictionary<string, string> data, string tableName)
        {
            Puter.Put(QueryCreator.CreatePutQuery(id, data, tableName));
        }
    }
}