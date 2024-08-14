﻿using System.ComponentModel.DataAnnotations.Schema;
using Teste_Desenvolvedor_.NET.Shared.Entities;

namespace Teste_Desenvolvedor_.NET.Domain.Entities
{
    public class Lead: Entity
    {
        // Construtor da Classe
        public Lead(string nome, string email, string telefone, string cpf)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            CPF = cpf;
            IsValid();
        }
        // Construtor para Migração
        private Lead() { }

        public string Nome { get;private set; } 
        public string Email { get;private set; }
        public string Telefone { get;private set; }
        public string CPF { get;private set; }


        // Lista de Notificações para armazenar erros na Entidade
        [NotMapped]
        public List<string> Notificacao { get; private set; } = new List<string>();

        //Função para Atualizar as propriedades
        public void Atualizar(string nome, string email, string telefone, string cpf)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            CPF = cpf;
            IsValid();
            Updated();
        }
        // Função para verificar se a Entidade é valida
        public void IsValid()
        {
            if(Nome.Length < 3)
                Notificacao.Add("Nome do lead deve ter no mínimo 3 caracteres");
            if(Email.Length < 3)
                Notificacao.Add("Email do lead deve ter no mínimo 3 caracteres");
            if(Telefone.Length < 9)
                Notificacao.Add("Telefone do lead deve ter no mínimo 9 caracteres");
            if(CPF.Length < 11)
                Notificacao.Add("CPF do lead deve ter no mínimo 11 caracteres");
            
        }
        // Função para adicionar notificações customizadas
        public void AddNotificacao(string key, string message)
        {
            Notificacao.Add(key + " - " + message);
        }
    }
}
