using System.Collections.Generic;

namespace FormatterSpace
{
    class Formatter
    {
        public static List<Dictionary<string, string>> FormatInscricoesInfo(string inscricoes)
        {
            List<Dictionary<string, string>> blocks = new List<Dictionary<string, string>>();

            string[] parts = inscricoes.Split("\t");

            for (int i = 0; i < parts.Length; i += 3)
            {
                if (i + 2 < parts.Length)
                {
                    var bloco = new Dictionary<string, string>
                    {
                        { "Inscricao", parts[i].Trim() },
                        { "Processo", parts[i + 1].Trim() },
                        { "Oferta", parts[i + 2].Trim() }
                    };

                    blocks.Add(bloco);
                }
            }

            return blocks;
        }

        public static List<Dictionary<string, string>> FormatInscricoesAllInfo(string inscricoes)
        {
            List<Dictionary<string, string>> blocks = new List<Dictionary<string, string>>();

            string[] parts = inscricoes.Split("\t");

            for (int i = 0; i < parts.Length; i += 6)
            {
                if (i + 5 < parts.Length) 
                {
                    var bloco = new Dictionary<string, string>
                    {
                        { "Inscricao", parts[i].Trim() },
                        { "Processo", parts[i + 1].Trim() },
                        { "Oferta", parts[i + 2].Trim() },
                        { "Candidato", parts[i + 3].Trim() },
                        { "ProcessoDetalhes", parts[i + 4].Trim() },
                        { "OfertaDetalhes", parts[i + 5].Trim() }
                    };

                    blocks.Add(bloco);
                }
            }
            return blocks;
        }

        public static List<Dictionary<string, string>> FormatOfertaInfo(string inscricoes)
        {
            List<Dictionary<string, string>> blocks = new List<Dictionary<string, string>>();

            string[] parts = inscricoes.Split("\t");

            for (int i = 0; i < parts.Length; i +=3)
            {
                if (i + 2 < parts.Length)
                {
                    var bloco = new Dictionary<string, string>
                    {
                        { "Nome", parts[i].Trim() },
                        { "Descricao", parts[i + 1].Trim() },
                        { "Vagas_Disponiveis", parts[i + 2].Trim() }
                    };

                    blocks.Add(bloco);
                }
            }

            return blocks;
        }
        public static List<Dictionary<string, string>> FormatProcessoInfo(string inscricoes)
        {
            List<Dictionary<string, string>> blocks = new List<Dictionary<string, string>>();

            string[] parts = inscricoes.Split("\t");

            for (int i = 0; i < parts.Length; i += 3)
            {
                if (i + 2 < parts.Length)
                {
                    var bloco = new Dictionary<string, string>
                    {
                        { "Nome", parts[i].Trim() },
                        { "Data_inicio", parts[i + 1].Trim() },
                        { "Data_fim", parts[i + 2].Trim() }
                    };

                    blocks.Add(bloco);
                }
            }

            return blocks;
        }
        public static List<Dictionary<string, string>> FormatCandidatoInfo(string inscricoes)
        {
            List<Dictionary<string, string>> blocks = new List<Dictionary<string, string>>();

            string[] parts = inscricoes.Split("\t");

            for (int i = 0; i < parts.Length; i += 4)
            {
                if (i + 3 < parts.Length)
                {
                    var bloco = new Dictionary<string, string>
                    {
                        { "Nome", parts[i].Trim() },
                        { "Email", parts[i + 1].Trim() },
                        { "Telefone", parts[i + 2].Trim() },
                        { "CPF", parts[i + 3].Trim() }
                    };

                    blocks.Add(bloco);
                }
            }

            return blocks;
        }
    }
}