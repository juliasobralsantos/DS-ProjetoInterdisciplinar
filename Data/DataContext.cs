using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using EsteticaEProcedimentos.Models;
using EsteticaEProcedimentos.Controllers;
using EsteticaEProcedimentos.Utils;

namespace EsteticaEProcedimentos.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Clientes> TB_CLIENTES { get; set; }
        public DbSet<Procedimentos> TB_PROCEDIMENTOS { get; set; }
        public DbSet<Usuario> TB_USUARIOS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>().ToTable("TB_CLIENTES");
            modelBuilder.Entity<Clientes>().HasData
            (
                new Clientes() { Id = 1, Nome = "Amanda da Silva", CPF = "243.567.431-10", Telefone = 11965843278, Endereço = "Rua das Orquídeas, 295 - Morumbi", Email = "amandasilva123@gmail.com", UsuarioId =1},
                new Clientes() { Id = 2, Nome = "Maria Eduarda Oliveira", CPF = "189.298.674-23", Telefone = 11948291640, Endereço = "Rua Maria Cândida, 728 - Casa 2 - Vila Guilherme", Email = "MaduOliveira@hotmail.com", UsuarioId =1},
                new Clientes() { Id = 3, Nome = "Elisa de Souza Santos", CPF = "368.583.783-79", Telefone = 11987953869, Endereço = "Rua Olavo Egídio, 469 - Santana", Email = "silvaelisa2297@gmail.com", UsuarioId =1},
                new Clientes() { Id = 4, Nome = "Luciana Almeida", CPF = "474.973.864-84", Telefone = 11938596036, Endereço = "Av. General Ataliba Leonel, 2034 - Parada Inglesa", Email = "lucianaalmeida9@hotmail.com", UsuarioId =1},
                new Clientes() { Id = 5, Nome = "Fernanda Antunes", CPF = "282.684.290-19", Telefone = 11910384874, Endereço = "Rua da Gávea, 55 - Vila Maria", Email = "fernanda23antunes@gmail.com", UsuarioId =1},
                new Clientes() { Id = 6, Nome = "Andressa Ferreira", CPF = "173.183.286-57", Telefone = 11928462967, Endereço = "Rua Jacuna, 226 - Carandiru", Email = "andressaferreira79@hotmail.com", UsuarioId =1},
                new Clientes() { Id = 7, Nome = "Ana Luiza Lisboa", CPF = "372.293.480-48", Telefone = 11949687931, Endereço = "Av. Coronel Sezefredo Fagundes, 2847, apto. 210 - Tremembé", Email = "analulisboa1011@outlook.com", UsuarioId =1}
            );

            modelBuilder.Entity<Procedimentos>().ToTable("TB_PROCEDIMENTOS");
            modelBuilder.Entity<Procedimentos>().HasData
            (
                new Procedimentos() {Id = 1, Nome = "Drenagem Linfática", Descriçao = "Massagem local que pode ser realizada em diversas partes do corpo.", ValorProcedimento = 149.99, ProfissionalResponsavel = "Sonia"},
                new Procedimentos() {Id = 2, Nome = "Limpeza de Pele", Descriçao = "Limpeza facial com utilização de produtos, retira impurezas da pele.", ValorProcedimento = 119.99, ProfissionalResponsavel = "Solange"},
                new Procedimentos() {Id = 3, Nome = "Rádio Frequência", Descriçao = "Aparelho que utiliza da rádiofrequência para reduzir flacidez corporal.", ValorProcedimento = 99.99, ProfissionalResponsavel = "Sonia"},
                new Procedimentos() {Id = 4, Nome = "Cavitação", Descriçao = "Aparelho de ultrassom utilizado para reduzir gordura localizada.", ValorProcedimento = 89.99, ProfissionalResponsavel = "Solange"}
            );

            /*
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");
            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Clientes)
                .WithOne(e => e.Usuario)
                .HasForeignKey(e => e.UsuarioId)
                .IsRequired(false);
            */

        Usuario user = new Usuario();
        Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte[]salt);
        user.Id= 1;
        user.Nome = "Usuário";
        user.Login = "UsuarioAdmin";
        user.PasswordString =  string.Empty;
        user.PasswordHash = hash;
        user.PasswordSalt = salt;

        modelBuilder.Entity<Usuario>().HasData(user);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar").HaveMaxLength(200);
        }
    }
}