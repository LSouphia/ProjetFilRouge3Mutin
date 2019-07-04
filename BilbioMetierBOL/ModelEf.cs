namespace BiblioMetierBOL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelEf : DbContext
    {
        public ModelEf()
            : base("name=ModelEf")
        {
        }

        public virtual DbSet<ContactEntreprise> ContactEntreprises { get; set; }
        public virtual DbSet<Contrat> Contrats { get; set; }
        public virtual DbSet<EntrepriseMere> EntrepriseMeres { get; set; }
        public virtual DbSet<Statut> Statuts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactEntreprise>()
                .Property(e => e.IDContact)
                .IsUnicode(false);

            modelBuilder.Entity<ContactEntreprise>()
                .Property(e => e.IDEntreprise)
                .IsUnicode(false);

            modelBuilder.Entity<ContactEntreprise>()
                .Property(e => e.NomContact)
                .IsUnicode(false);

            modelBuilder.Entity<ContactEntreprise>()
                .Property(e => e.PrenomContact)
                .IsUnicode(false);

            modelBuilder.Entity<ContactEntreprise>()
                .Property(e => e.FonctionContact)
                .IsUnicode(false);

            modelBuilder.Entity<ContactEntreprise>()
                .Property(e => e.TelContact)
                .IsUnicode(false);

            modelBuilder.Entity<Contrat>()
                .Property(e => e.IDContrat)
                .IsUnicode(false);

            modelBuilder.Entity<Contrat>()
                .Property(e => e.IDOrganisme)
                .IsUnicode(false);

            modelBuilder.Entity<Contrat>()
                .Property(e => e.IDUtilisateur)
                .IsUnicode(false);

            modelBuilder.Entity<Contrat>()
                .Property(e => e.IDFiliale)
                .IsUnicode(false);

            modelBuilder.Entity<Contrat>()
                .Property(e => e.IDEntreprise)
                .IsUnicode(false);

            modelBuilder.Entity<Contrat>()
                .Property(e => e.IDCatSocioPro)
                .IsUnicode(false);

            modelBuilder.Entity<Contrat>()
                .Property(e => e.IDStatut)
                .IsUnicode(false);

            modelBuilder.Entity<Contrat>()
                .Property(e => e.TypeContrat)
                .IsUnicode(false);

            modelBuilder.Entity<EntrepriseMere>()
                .Property(e => e.IDEntreprise)
                .IsUnicode(false);

            modelBuilder.Entity<EntrepriseMere>()
                .Property(e => e.IDApe)
                .IsUnicode(false);

            modelBuilder.Entity<EntrepriseMere>()
                .Property(e => e.DesignationEntreprise)
                .IsUnicode(false);

            modelBuilder.Entity<EntrepriseMere>()
                .Property(e => e.AdresseEntreprise)
                .IsUnicode(false);

            modelBuilder.Entity<EntrepriseMere>()
                .Property(e => e.VilleEntreprise)
                .IsUnicode(false);

            modelBuilder.Entity<EntrepriseMere>()
                .Property(e => e.TelEntreprise)
                .IsUnicode(false);

            modelBuilder.Entity<EntrepriseMere>()
                .HasMany(e => e.ContactEntreprises)
                .WithRequired(e => e.EntrepriseMere)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EntrepriseMere>()
                .HasMany(e => e.Contrats)
                .WithRequired(e => e.EntrepriseMere)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Statut>()
                .Property(e => e.IDStatut)
                .IsUnicode(false);

            modelBuilder.Entity<Statut>()
                .Property(e => e.LibelleStatut)
                .IsUnicode(false);

            modelBuilder.Entity<Statut>()
                .HasMany(e => e.Contrats)
                .WithRequired(e => e.Statut)
                .WillCascadeOnDelete(false);
        }
    }
}
