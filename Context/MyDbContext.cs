using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TP_ES2.Entities;

#nullable disable

namespace TP_ES2.Context
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ativo> Ativos { get; set; }
        public virtual DbSet<Conta> Contas { get; set; }
        public virtual DbSet<Depositosapraso> Depositosaprasos { get; set; }
        public virtual DbSet<Fundoinvestimento> Fundoinvestimentos { get; set; }
        public virtual DbSet<Imovei> Imoveis { get; set; }
        public virtual DbSet<Movimento> Movimentos { get; set; }
        public virtual DbSet<Taxaaplicadum> Taxaaplicada { get; set; }
        public virtual DbSet<Tiposutilizador> Tiposutilizadors { get; set; }
        public virtual DbSet<Titulare> Titulares { get; set; }
        public virtual DbSet<Utilizadore> Utilizadores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=es2;User name=es2;Password=es2");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Ativo>(entity =>
            {
                entity.HasKey(e => e.IdAtivo)
                    .HasName("ativos_pk");

                entity.ToTable("ativos");

                entity.HasIndex(e => e.IdAtivo, "ativos_idativos_uindex")
                    .IsUnique();

                entity.Property(e => e.IdAtivo).HasColumnName("idAtivo");

                entity.Property(e => e.Datainicio)
                    .HasColumnType("date")
                    .HasColumnName("datainicio")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.Duracaomeses).HasColumnName("duracaomeses");

                entity.Property(e => e.IdUtilizador).HasColumnName("id_utilizador");

                entity.Property(e => e.Impost).HasColumnName("impost");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .HasColumnName("nome");

                entity.HasOne(d => d.IdUtilizadorNavigation)
                    .WithMany(p => p.Ativos)
                    .HasForeignKey(d => d.IdUtilizador)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ativos_utilizadores_idutilizador_fk");
            });

            modelBuilder.Entity<Conta>(entity =>
            {
                entity.HasKey(e => e.IdConta)
                    .HasName("conta_pk");

                entity.ToTable("contas");

                entity.HasIndex(e => e.IdConta, "contas_idconta_uindex")
                    .IsUnique();

                entity.Property(e => e.IdConta).HasColumnName("idConta");

                entity.Property(e => e.Banco)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("banco");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nome");

                entity.Property(e => e.Numconta)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("numconta");
            });

            modelBuilder.Entity<Depositosapraso>(entity =>
            {
                entity.HasKey(e => e.IdDeposito)
                    .HasName("deposito_pk");

                entity.ToTable("depositosapraso");

                entity.HasIndex(e => e.IdDeposito, "depositos_iddeposito_uindex")
                    .IsUnique();

                entity.Property(e => e.IdDeposito).HasColumnName("idDeposito");

                entity.Property(e => e.IdConta).HasColumnName("id_conta");

                entity.Property(e => e.Montanteaplicado)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("montanteaplicado");

                entity.Property(e => e.Taxajuroanual).HasColumnName("taxajuroanual");

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.IdContaNavigation)
                    .WithMany(p => p.Depositosaprasos)
                    .HasForeignKey(d => d.IdConta)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("depositos_conta_idconta_fk");
            });

            modelBuilder.Entity<Fundoinvestimento>(entity =>
            {
                entity.HasKey(e => e.IdFundo)
                    .HasName("fundo_pk");

                entity.ToTable("fundoinvestimento");

                entity.HasIndex(e => e.IdFundo, "fundoinvestimento_idfundo_uindex")
                    .IsUnique();

                entity.Property(e => e.IdFundo).HasColumnName("idFundo");

                entity.Property(e => e.Montanteinvestido).HasColumnName("montanteinvestido");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nome");

                entity.Property(e => e.Taxajuro).HasColumnName("taxajuro");
            });

            modelBuilder.Entity<Imovei>(entity =>
            {
                entity.HasKey(e => e.IdImovel)
                    .HasName("imoveis_pk");

                entity.ToTable("imoveis");

                entity.HasIndex(e => e.IdImovel, "imoveis_idimovel_uindex")
                    .IsUnique();

                entity.Property(e => e.IdImovel).HasColumnName("idImovel");

                entity.Property(e => e.Designacao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("designacao");

                entity.Property(e => e.Localizacao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("localizacao");

                entity.Property(e => e.Valoranualdespesas).HasColumnName("valoranualdespesas");

                entity.Property(e => e.Valorderenda).HasColumnName("valorderenda");

                entity.Property(e => e.Valordoimovel).HasColumnName("valordoimovel");

                entity.Property(e => e.Valormensalcondominio).HasColumnName("valormensalcondominio");
            });

            modelBuilder.Entity<Movimento>(entity =>
            {
                entity.HasKey(e => e.IdMovimento)
                    .HasName("movimentos_pk");

                entity.ToTable("movimentos");

                entity.HasIndex(e => e.IdMovimento, "movimentos_idmovimentos_uindex")
                    .IsUnique();

                entity.Property(e => e.IdMovimento).HasColumnName("idMovimento");

                entity.Property(e => e.Data)
                    .HasColumnType("date")
                    .HasColumnName("data")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.IdAtivo).HasColumnName("id_ativo");

                entity.Property(e => e.Taxa).HasColumnName("taxa");

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.IdAtivoNavigation)
                    .WithMany(p => p.Movimentos)
                    .HasForeignKey(d => d.IdAtivo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("movimentos_ativos_idativo_fk");
            });

            modelBuilder.Entity<Taxaaplicadum>(entity =>
            {
                entity.HasKey(e => e.IdTaxa)
                    .HasName("taxa_pk");

                entity.ToTable("taxaaplicada");

                entity.HasIndex(e => e.IdTaxa, "taxaaplicada_idtaxa_uindex")
                    .IsUnique();

                entity.Property(e => e.IdTaxa).HasColumnName("idTaxa");

                entity.Property(e => e.IdFundo).HasColumnName("id_Fundo");

                entity.Property(e => e.Mes).HasColumnName("mes");

                entity.Property(e => e.Taxa).HasColumnName("taxa");

                entity.HasOne(d => d.IdFundoNavigation)
                    .WithMany(p => p.Taxaaplicada)
                    .HasForeignKey(d => d.IdFundo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("taxa_fundo_idfundo_fk");
            });

            modelBuilder.Entity<Tiposutilizador>(entity =>
            {
                entity.HasKey(e => e.IdTipoUtilizador)
                    .HasName("tiposutilizador_pk");

                entity.ToTable("tiposutilizador");

                entity.HasIndex(e => e.IdTipoUtilizador, "tiposutilizador_idtipoutilizador_uindex")
                    .IsUnique();

                entity.Property(e => e.IdTipoUtilizador).HasColumnName("idTipoUtilizador");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Titulare>(entity =>
            {
                entity.HasKey(e => e.IdTitular)
                    .HasName("titular_pk");

                entity.ToTable("titulares");

                entity.HasIndex(e => e.IdTitular, "titulares_idtitular_uindex")
                    .IsUnique();

                entity.Property(e => e.IdTitular).HasColumnName("idTitular");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.IdConta).HasColumnName("id_conta");

                entity.Property(e => e.Primeironome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("primeironome");

                entity.Property(e => e.Ultimonome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("ultimonome");

                entity.HasOne(d => d.IdContaNavigation)
                    .WithMany(p => p.Titulares)
                    .HasForeignKey(d => d.IdConta)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("titulares_conta_idconta_fk");
            });

            modelBuilder.Entity<Utilizadore>(entity =>
            {
                entity.HasKey(e => e.IdUtilizador)
                    .HasName("utilizadores_pk");

                entity.ToTable("utilizadores");

                entity.HasIndex(e => e.IdUtilizador, "utilizadores_idutilizador_uindex")
                    .IsUnique();

                entity.Property(e => e.IdUtilizador).HasColumnName("idUtilizador");

                entity.Property(e => e.Datanascimento)
                    .HasColumnType("date")
                    .HasColumnName("datanascimento");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUtilizador).HasColumnName("id_tipoUtilizador");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .HasColumnName("nome");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Primeironome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("primeironome");

                entity.Property(e => e.Ultimonome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("ultimonome");

                entity.HasOne(d => d.IdTipoUtilizadorNavigation)
                    .WithMany(p => p.Utilizadores)
                    .HasForeignKey(d => d.IdTipoUtilizador)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tipos_utilizadores_idtipoutilizador_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
