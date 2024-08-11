using System;
using MySql.Data.MySqlClient;
using DatabaseConnectionSpace;

namespace MySqlCreation
{
    class Creator
    {
        public static void InitiliazeCreations(MySqlConnection connection, bool logs=false)
        {
            CreateDatabase(connection, logs);
            CreateTables(connection, logs);
        }

        static void CreateDatabase(MySqlConnection connection, bool logs=false)
        {
            string dbName = "testeDotNet";
            try
            {
                if (logs)
                {
                Console.WriteLine("Conectado ao MariaDB com sucesso.");
                }

                string createDB = $"CREATE DATABASE IF NOT EXISTS {dbName}";
                using (var command = new MySqlCommand(createDB, connection))
                {
                    command.ExecuteNonQuery();
                    if (logs)
                    {
                        Console.WriteLine($"Database {dbName} criado com sucesso.");
                    }
                }

                connection.ChangeDatabase(dbName);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao criar o banco de dados: {ex.Message}");
            }
        }

        static void CreateTables(MySqlConnection connection, bool logs=false)
        {
            try
            {
                if (logs)
                {
                    Console.WriteLine("Conectado ao banco de dados com sucesso.");
                }
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS processo_seletivo (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        nome VARCHAR(100) NOT NULL,
                        data_inicio DATE,
                        data_termino DATE
                    );

                    CREATE TABLE IF NOT EXISTS candidato (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        nome VARCHAR(100) NOT NULL,
                        email VARCHAR(100) NOT NULL,
                        telefone VARCHAR(11) NOT NULL,
                        cpf VARCHAR(11) NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS oferta (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        nome VARCHAR(100) NOT NULL,
                        descricao VARCHAR(100) NOT NULL,
                        vagas_disponiveis INT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS inscricao (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        numero_inscricao INT NOT NULL,
                        data DATE,
                        status BOOLEAN DEFAULT TRUE,
                        id_lead INT,
                        id_processo_seletivo INT,
                        id_oferta INT,
                        FOREIGN KEY (id_lead) REFERENCES candidato(id),
                        FOREIGN KEY (id_processo_seletivo) REFERENCES processo_seletivo(id),
                        FOREIGN KEY (id_oferta) REFERENCES oferta(id)
                    );
                ";

                using (var command = new MySqlCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                    if (logs)
                    {
                        Console.WriteLine("Tabelas criadas com sucesso.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao criar tabelas: {ex.Message}");
                Console.WriteLine($"Erro ao criar tabelas: {ex.StackTrace}");
            }
        }
    }
}