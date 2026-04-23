using DpTaskManager.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DpTaskManager.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //Criação da tabela Tarefas
        public DbSet<Tarefa> Tarefas { get; set; }
        public object Tarefa { get; internal set; }
    }
}