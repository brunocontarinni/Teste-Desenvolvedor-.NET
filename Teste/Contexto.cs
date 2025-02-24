using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;
using Teste.Models;

namespace Teste
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<Inscricao> Inscricoes { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<ProcessoSeletivo> ProcessosSeletivos { get; set; }
        public DbSet<Lead> Leads { get; set; }

    }
}

