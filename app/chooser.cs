using System;
using System.Collections.Generic;

using PosterSpace;
using QueryCreatorSpace;
using appMain;
using GetterSpace;

namespace ChooserSpace
{
    class Chooser
    {
        public static void chooseFunction(string[] args, string tableName)
        {
            string[] nomeTabelas = {"candidato","oferta","processo_seletivo","inscricao"};

            if (tableName == nomeTabelas[0])
            {
                Dictionary<string, string> dictData = new Dictionary<string, string>();
                dictData = app.SetCandidatoInfo(args, dictData);

                string InsertQuery = QueryCreator.CreateInsertQuery(dictData, tableName);

                Poster.Post(InsertQuery);
            }
            if (tableName == nomeTabelas[1])
            {
                Dictionary<string, string> dictData = new Dictionary<string, string>();
                dictData = app.SetOfertaInfo(args, dictData);

                string InsertQuery = QueryCreator.CreateInsertQuery(dictData, tableName);

                Poster.Post(InsertQuery);
            }
            if (tableName == nomeTabelas[2])
            {
                Dictionary<string, string> dictData = new Dictionary<string, string>();
                dictData = app.SetProcessoInfo(args, dictData);

                string InsertQuery = QueryCreator.CreateInsertQuery(dictData, tableName);

                Poster.Post(InsertQuery);
            }
            if (tableName == nomeTabelas[3])
            {
                Dictionary<string, string> dictData = new Dictionary<string, string>();

                dictData = app.SetInscricaoInfo(args, dictData);

                string InsertQuery = QueryCreator.CreateInsertInscricaoQuery(dictData, tableName);
                Poster.Post(InsertQuery);

            }
        }
        
    }
}