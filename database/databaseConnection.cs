using System;
using System.Text;
using MySql.Data.MySqlClient;
using MySqlCreation;

namespace DatabaseConnectionSpace
{
    public class Connector
    {
        public static MySqlConnection GetConnector()
        {
            string connectionString = "Server=172.19.0.2;User ID=root;";
            return new MySqlConnection(connectionString);
        }

        public static void Operator(string query)
        {

            try{
                using (MySqlConnection connection = GetConnector())
                {
                    connection.Open();
                    MySqlCreation.Creator.InitiliazeCreations(connection, false);
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine($"query:{query} executada com sucesso");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao criar tabelas: {ex.Message}");
                Console.WriteLine($"Erro ao criar tabelas: {ex.StackTrace}");
                if (ex.Number == 1049 | ex.Number == 1146 )
                {
                    using (MySqlConnection connection = Connector.GetConnector())
                    {
                        MySqlCreation.Creator.InitiliazeCreations(connection);
                    }
                    Operator(query);
                }
            }
        }
        
        public static string OperatorGetter(string query)
        {
            string result = "";
            try
            {
                using (MySqlConnection connection = GetConnector())
                {
                    connection.Open();

                    MySqlCreation.Creator.InitiliazeCreations(connection, false);

                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            var stringBuilder = new StringBuilder();

                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    stringBuilder.Append(reader[i] + "\t");
                                }
                                stringBuilder.AppendLine();
                            }
                            result = stringBuilder.ToString();
                        }
                    }
                }
                return result;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao executar consulta: {ex.Message}");
                Console.WriteLine($"Erro ao executar consulta: {ex.StackTrace}");
                return result;
            }
        }
    }
}