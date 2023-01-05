using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestorTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace gestorTarefas.Context
{
    public class TarefasContext : DbContext
    {
        public TarefasContext(DbContextOptions<TarefasContext> options) : base(options)
        {
            
        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}