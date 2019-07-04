namespace BiblioMetierBOL.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using MutBiblioMetierBOLIn.Models;

    public partial class ModelEf1 : DbContext
    {
        public ModelEf1()
            : base("name=ModelEf1")
        {
        }

        public DbSet<Ape> Apes { get; set; }
        public DbSet<Casd_utilisation> Casd_utilisation { get; set; }
        public  DbSet<CategorieSocioPro> CategorieSocioProes { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public  DbSet<ContactEntreprise> ContactEntreprises { get; set; }
        public DbSet<Contrat> Contrats { get; set; }
        public  DbSet<Droit> Droits { get; set; }
        public DbSet<EntrepriseMere> EntrepriseMeres { get; set; }
        public DbSet<Filiale> Filiales { get; set; }
        public  DbSet<Garantie> Garanties { get; set; }
        public  DbSet<Organisme> Organismes { get; set; }
        public  DbSet<Personne> Personnes { get; set; }
        public  DbSet<Service> Services { get; set; }
        public  DbSet<Statut> Statuts { get; set; }
        public  DbSet<TrancheSalaire> TrancheSalaires { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ape>()
                .Property(e => e.IDApe)
                .IsUnicode(false);

            modelBuilder.Entity<Ape>()
                .Property(e => e.NomApe)
                .IsUnicode(false);

            modelBuilder.Entity<Casd_utilisation>()
                .Property(e => e.IDCasUtilisation)
                .IsUnicode(false);

            modelBuilder.Entity<Casd_utilisation>()
                .Property(e => e.LibelleCasUtil)
                .IsUnicode(false);

            modelBuilder.Entity<Casd_utilisation>()
                .HasMany(e => e.Droits)
                .WithRequired(e => e.Casd_utilisation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CategorieSocioPro>()
                .Property(e => e.IDCatSocioPro)
                .IsUnicode(false);

            modelBuilder.Entity<CategorieSocioPro>()
                .Property(e => e.TypeCatSocioPro)
                .IsUnicode(false);

            modelBuilder.Entity<CategorieSocioPro>()
                .HasMany(e => e.Contrats)
                .WithRequired(e => e.CategorieSocioPro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Condition>()
                .Property(e => e.IDConditions)
                .IsUnicode(false);

            modelBuilder.Entity<Condition>()
                .Property(e => e.TypeConditions)
                .IsUnicode(false);

            modelBuilder.Entity<Condition>()
                .HasMany(e => e.Garanties)
                .WithMany(e => e.Conditions)
                .Map(m => m.ToTable("LienGC").MapLeftKey("IDConditions").MapRightKey("IDGarantie"));

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

            modelBuilder.Entity<Droit>()
                .Property(e => e.IDUtilisateur)
                .IsUnicode(false);

            modelBuilder.Entity<Droit>()
                .Property(e => e.IDCasUtilisation)
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

            modelBuilder.Entity<EntrepriseMere>()
                .HasMany(e => e.Filiales)
                .WithRequired(e => e.EntrepriseMere)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EntrepriseMere>()
                .HasMany(e => e.Personnes)
                .WithRequired(e => e.EntrepriseMere)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Filiale>()
                .Property(e => e.IDFiliale)
                .IsUnicode(false);

            modelBuilder.Entity<Filiale>()
                .Property(e => e.IDEntreprise)
                .IsUnicode(false);

            modelBuilder.Entity<Filiale>()
                .Property(e => e.NomFil)
                .IsUnicode(false);

            modelBuilder.Entity<Filiale>()
                .Property(e => e.AdresseFil)
                .IsUnicode(false);

            modelBuilder.Entity<Filiale>()
                .Property(e => e.CodePostalFil)
                .IsFixedLength();

            modelBuilder.Entity<Filiale>()
                .Property(e => e.VilleFil)
                .IsFixedLength();

            modelBuilder.Entity<Filiale>()
                .Property(e => e.TelFil)
                .IsFixedLength();

            modelBuilder.Entity<Garantie>()
                .Property(e => e.IDGarantie)
                .IsUnicode(false);

            modelBuilder.Entity<Garantie>()
                .Property(e => e.TypeGarantie)
                .IsUnicode(false);

            modelBuilder.Entity<Organisme>()
                .Property(e => e.IDOrganisme)
                .IsUnicode(false);

            modelBuilder.Entity<Organisme>()
                .Property(e => e.NomOrga)
                .IsUnicode(false);

            modelBuilder.Entity<Organisme>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<Organisme>()
                .Property(e => e.Ville)
                .IsUnicode(false);

            modelBuilder.Entity<Organisme>()
                .Property(e => e.Tel)
                .IsUnicode(false);

            modelBuilder.Entity<Organisme>()
                .Property(e => e.Mail)
                .IsUnicode(false);

            modelBuilder.Entity<Organisme>()
                .HasMany(e => e.Services)
                .WithMany(e => e.Organismes)
                .Map(m => m.ToTable("Lien").MapLeftKey("IDOrganisme").MapRightKey("IDService"));

            modelBuilder.Entity<Personne>()
                .Property(e => e.iDPerso)
                .IsUnicode(false);

            modelBuilder.Entity<Personne>()
                .Property(e => e.iDCatSocioPro)
                .IsUnicode(false);

            modelBuilder.Entity<Personne>()
                .Property(e => e.iDEntreprise)
                .IsUnicode(false);

            modelBuilder.Entity<Personne>()
                .Property(e => e.nomPers)
                .IsUnicode(false);

            modelBuilder.Entity<Personne>()
                .Property(e => e.prenomPers)
                .IsUnicode(false);

            modelBuilder.Entity<Personne>()
                .Property(e => e.situationFamPers)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.IDService)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.LibelleService)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.Utilisateurs)
                .WithRequired(e => e.Service)
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

            modelBuilder.Entity<TrancheSalaire>()
                .Property(e => e.IDTrancheSal)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.IDUtilisateur)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.IDService)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.NomUtilisateur)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.PrenomUtilisateur)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.MotDePasseUtilisateur)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .HasMany(e => e.Droits)
                .WithRequired(e => e.Utilisateur)
                .WillCascadeOnDelete(false);
        }
    }
}
