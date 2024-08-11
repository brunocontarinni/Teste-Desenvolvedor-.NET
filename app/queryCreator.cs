using System;
using System.Collections.Generic;
using System.Linq;
namespace QueryCreatorSpace
{
    class QueryCreator
    {
        public static string CreateInsertQuery(Dictionary<string, string> data, string tableName)
        {
            string query = $"INSERT INTO {tableName} (";
            foreach (KeyValuePair<string,string> item in data)
            {
                query+= $" {item.Key},";
            }
            query = query.Remove(query.Length -1);

            query += ") VALUES (";

            foreach (KeyValuePair<string,string> item in data)
            {
                query+= $" '{data[item.Key]}',";
            }
            query = query.Remove(query.Length -1);
            query += ");";
            return query;
        }
        public static string CreateInsertInscricaoQuery(Dictionary<string, string> data, string tableName)
        {
            string query = $"INSERT INTO {tableName} (";
            foreach (KeyValuePair<string,string> item in data)
            {
                query+= $" {item.Key},";
            }
            query = query.Remove(query.Length -1);

            query += ") VALUES (";

            var keys = data.Keys.ToList(); 
            for (int i = 0; i < keys.Count(); i++)
            {
                var key = keys[i];
                if (i >= 2){
                    query += $" {data[key]},";
                }
                else{
                    query += $" '{data[key]}',";
                }
            }
            query = query.Remove(query.Length -1);
            query += ");";
            return query;
        }
        public static string CreateDeleteQuery(int id, string tableName)
        {
            string query = $"DELETE FROM {tableName} where id={id}";
            return query;
        }

        public static string CreatePutQuery(int id, Dictionary<string, string> data, string tableName)
        {
            string query = $"UPDATE {tableName} SET ";
            foreach (KeyValuePair<string,string> item in data)
            {
                query+= $" {item.Key} = '{item.Value}',";
            }
            query = query.Remove(query.Length -1);
            query += $" WHERE id = {id}";

            return query;
        }

        public static string CreateGetQuery(string tableName, int id=0)
        {
            string query = "";
            if (tableName == "inscricao")
            {
                query = $@"
                                SELECT numero_inscricao, data, status, candidato.nome, processo_seletivo.nome, oferta.nome
                                FROM inscricao
                                JOIN processo_seletivo on processo_seletivo.id = inscricao.id_processo_seletivo 
                                JOIN oferta on oferta.id = inscricao.id_oferta 
                                JOIN candidato on candidato.id = inscricao.id_lead 
                            ";
                if(id != 0)
                {
                    query += $" WHERE id={id}";
                } 
                return query;
            }
            query = $"SELECT * FROM {tableName}";
            if(id != 0)
            {
                query += $" WHERE id={id}";
            }
            Console.WriteLine(query);
            return query;
        }

        public static string CreateGetCandidatoQuery(string tableName, int id=0)
        {
            string query = "";
            query = $"SELECT nome, email, telefone, cpf FROM {tableName}";
            if(id != 0)
            {
                query+= $" WHERE id = {id}";
            }
            return query;
        }
        public static string CreateGetOfertaQuery(string tableName, int id=0)
        {
            string query = "";
            query = $"SELECT nome, descricao, vagas_disponiveis FROM {tableName}";
            if(id != 0)
            {
                query+= $" WHERE id = {id}";
            }
            return query;
        }
        public static string CreateGetProcessoQuery(string tableName, int id=0)
        {
            string query = "";
            query = $"SELECT nome, data_inicio, data_termino FROM {tableName}";
            if(id != 0)
            {
                query+= $" WHERE id = {id}";
            }
            return query;
        }


        public static string CreateGetCPFLead(string cpf)
        {
            string query = $"SELECT id from candidato where cpf='{cpf}'";
            return query;
        }

        public static string CreateGetNameLead(string id)
        {
            string query = $"SELECT nome from candidato where id={id}";
            return query;
        }
        public static string CreateGetNumeroVagas(string id_oferta){
            string query = $"SELECT vagas_disponiveis FROM oferta WHERE id ='{id_oferta}'";
            return query;
        }

        public static string CreateGetInscricoesPorCpf(string numero_inscricao){
            string query = $@"
                                SELECT numero_inscricao, processo_seletivo.nome, oferta.nome 
                                FROM inscricao
                                JOIN processo_seletivo on processo_seletivo.id = inscricao.id_processo_seletivo 
                                JOIN oferta on oferta.id = inscricao.id_oferta
                                WHERE inscricao.numero_inscricao = '{numero_inscricao}';
                            ";
            return query;
        }
        public static string CreateGetInscricoesPorOferta(int id){
            string query = $@"
                                SELECT numero_inscricao, processo_seletivo.nome, oferta.nome 
                                FROM inscricao
                                JOIN processo_seletivo on processo_seletivo.id = inscricao.id_processo_seletivo 
                                JOIN oferta on oferta.id = inscricao.id_oferta
                                WHERE oferta.id = {id};
                            ";
            return query;
        }
    }
}