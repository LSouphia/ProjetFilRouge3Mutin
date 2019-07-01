using ProjetMutuelle.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ProjetMutuelle;

namespace ProjetMutuelle.DAL
{
    public class ContratDAO
    {
        SqlConnection _cn = new SqlConnection();
        SqlCommand cd = new SqlCommand();
        SqlDataReader reader;

        /// <summary>
        /// Connexion
        /// </summary>
        public ContratDAO()
        {
            ConnectionStringSettings oConfig = ConfigurationManager.ConnectionStrings["BDSql"];
            _cn.ConnectionString = oConfig.ConnectionString;
        }

        /// <summary>
        /// Liste des contrats (Index)
        /// </summary>
        /// <returns>contratResults</returns>
        public List<Contrat> ListeContrat()
        {
            ConnectionStringSettings oConfig = ConfigurationManager.ConnectionStrings["BDSql"];
            if (oConfig != null)
            {
                _cn.ConnectionString = oConfig.ConnectionString;
                try
                {
                    _cn.Open();
                }
                catch
                {
                    return null;
                }
            }
            List<Contrat> contratResults = new List<Contrat>(); // pour une collection, on écrit le nom en minuscule avec un s à la fin 
            SqlCommand cd = new SqlCommand();
            cd.Connection = _cn; // Appel de la méthode "connexion" (public SqlConnection connexion())
            cd.CommandText = "SELECT * FROM Contrat";

            using (SqlDataReader dr = cd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (dr.Read())
                {
                    Contrat contrat = new Contrat();

                    contrat.IDContrat = dr["IDContrat"].ToString();
                    contrat.IDOrganisme = dr["IDOrganisme"].ToString();
                    contrat.IDUtilisateur = dr["IDUtilisateur"].ToString();
                    contrat.IDFiliale = dr["IDFiliale"].ToString();
                    contrat.IDEntreprise = dr["IDEntreprise"].ToString();
                    contrat.IDCatSocioPro = dr["IDCatSocioPro"].ToString();
                    contrat.IDStatut = dr["IDStatut"].ToString();
                    contrat.TypeContrat = dr["TypeContrat"].ToString();
                    contrat.EffectifCatSocio = (int)dr["EffectifCatSocio"];
                    contrat.AgeMoyenCatSocio = (int)dr["AgeMoyenCatSocio"];
                    contrat.DateSignContrat = (DateTime)dr["DateSignContrat"];
                    contrat.DateEffetContrat = (DateTime)dr["DateEffetContrat"];
                    contrat.DateFinContrat = (DateTime)dr["DateFinContrat"];

                    contratResults.Add(contrat);
                }
                return contratResults;
            }
        }
        /// <summary>
        /// Methode Liste Filtrée
        /// </summary>
        /// <param name="sVille"></param>
        /// <param name="mMontant"></param>
        /// <returns>entreprises</returns>
        public List<Contrat> ListeFiltrer(string Statut)
        {
            SqlConnection con = new SqlConnection();
            List<Contrat> contratListe = new List<Contrat>();
            Contrat contrat;

            cd.Connection = _cn;
            _cn.Open();
            cd.Parameters.AddWithValue("@sStatut", Statut);
            cd.CommandText = "select * from Contrat where Statut = @sStatut ";
            using (SqlDataReader dr = cd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (dr.Read())
                {
                    contrat = new Contrat();
                    contrat.IDContrat = dr["IDContrat"].ToString();
                    contrat.IDOrganisme = dr["IDOrganisme"].ToString();
                    contrat.IDUtilisateur = dr["IDUtilisateur"].ToString();
                    contrat.IDFiliale = dr["IDFiliale"].ToString();
                    contrat.IDEntreprise = dr["IDEntreprise"].ToString();
                    contrat.IDCatSocioPro = dr["IDCatSocioPro"].ToString();
                    contrat.IDStatut = dr["IDStatut"].ToString();
                    contrat.TypeContrat = dr["TypeContrat"].ToString();
                    contrat.EffectifCatSocio = (int)dr["EffectifCatSocio"];
                    contrat.AgeMoyenCatSocio = (int)dr["AgeMoyenCatSocio"];
                    contrat.DateSignContrat = (DateTime)dr["DateSignContrat"];
                    contrat.DateEffetContrat = (DateTime)dr["DateEffetContrat"];
                    contrat.DateFinContrat = (DateTime)dr["DateFinContrat"];
                    contratListe.Add(contrat);
                }
            }
            return contratListe;
        }

        /// <summary>
        /// Fiche de l'entreprise
        /// </summary>
        /// <param name="sCode">Fiche à visualiser</param>
        /// <returns>contrat</returns>
        public Contrat FicheContrat(string sCode)
        {
            ConnectionStringSettings oConfig = ConfigurationManager.ConnectionStrings["BDSql"];
            if (oConfig != null)
            {
                _cn.ConnectionString = oConfig.ConnectionString;
                try
                {
                    _cn.Open();
                }
                catch
                {
                    return null;
                }
            }
            Contrat contrat = new Contrat();
            SqlCommand cd = new SqlCommand();
            cd.Connection = _cn; // Appel de la méthode "connexion" (public SqlConnection connexion())
            cd.Parameters.AddWithValue("@sCode", sCode);
            cd.CommandText = "SELECT * FROM Contrat where IDContrat = @sCode";

            using (SqlDataReader dr = cd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (dr.Read())
                {
                    contrat.IDContrat = dr["IDContrat"].ToString();
                    contrat.IDEntreprise = dr["IDEntreprise"].ToString();
                    contrat.IDCatSocioPro = dr["IDCatSocioPro"].ToString();
                    contrat.IDFiliale = dr["IDFiliale"].ToString();
                    contrat.IDStatut = dr["IDStatut"].ToString();
                    contrat.IDUtilisateur = dr["IDUtilisateur"].ToString();
                    contrat.TypeContrat = dr["TypeContrat"].ToString();
                    contrat.EffectifCatSocio = (int)dr["EffectifCatSocio"];
                    contrat.DateSignContrat = (DateTime)dr["DateSignContrat"];
                    contrat.DateFinContrat = (DateTime)dr["DateFinContrat"];
                    contrat.DateEffetContrat = (DateTime)dr["DateEffetContrat"];
                    contrat.AgeMoyenCatSocio = (int)dr["AgeMoyenCatSocio"];
                }
                return contrat;
            }
        }

        /// <summary>
        /// methode creation d'une ligne d'un contrat dans la BDD
        /// </summary>
        /// <param name="contrat"></param>
        /// <returns></returns>
        public void CreationContrat(Contrat contrat)
        {
            _cn.Open();
            cd = _cn.CreateCommand();
            cd.Parameters.AddWithValue("@sCode", contrat.IDContrat);
            cd.Parameters.AddWithValue("@Entreprise", contrat.IDEntreprise);
            cd.Parameters.AddWithValue("@Organisme", contrat.IDOrganisme);
            cd.Parameters.AddWithValue("@Statut", contrat.IDStatut);
            cd.Parameters.AddWithValue("@Utilisateur", contrat.IDUtilisateur);
            cd.Parameters.AddWithValue("@CatSocial", contrat.IDCatSocioPro);
            cd.Parameters.AddWithValue("@Filial", contrat.IDFiliale);
            cd.Parameters.AddWithValue("@Effet", contrat.EffectifCatSocio);
            cd.Parameters.AddWithValue("@DSignature", contrat.DateSignContrat);
            cd.Parameters.AddWithValue("@DFinContrat", contrat.DateFinContrat);
            cd.Parameters.AddWithValue("@DEffetContrat", contrat.DateEffetContrat);
            cd.Parameters.AddWithValue("@Age", contrat.AgeMoyenCatSocio);
            cd.CommandText = " insert into Contrat (IDContrat ,IDEntreprise, IDOrganisme, IDStatut, IDUtilisateur, IDCatSocioPro, IDFiliale,EffectifCatSocio, DateSignContrat, DateFinContrat, DateEffetContrat, AgeMoyenCatSocio" +
                " values @Code, @Entreprise ,@Organisme,@Statut,@Utilisateur,@CatSocial,@Filial, @Effet,@DSignature,@DFinContrat,@DEffetContrat,@Age)";
            cd.CommandType = CommandType.Text;
            _cn.Close();
        }
        /// <summary>
        /// Modifier un contrat
        /// </summary>
        /// <param name="sCode">contrat à modifier</param>
        /// <param name="contrat">contrat à modifier</param>
        public void ModifierContrat(string sCode, Contrat contrat)
        {
            ConnectionStringSettings oConfig = ConfigurationManager.ConnectionStrings["BDSql"];
            SqlCommand cd = new SqlCommand();
            cd.Connection = _cn; 
            cd.Parameters.AddWithValue("@sCode", sCode);
            cd.Parameters.AddWithValue("@Entreprise", contrat.IDEntreprise);
            cd.Parameters.AddWithValue("@Organisme", contrat.IDOrganisme);
            cd.Parameters.AddWithValue("@Statut", contrat.IDStatut);
            cd.Parameters.AddWithValue("@Utilisateur", contrat.IDUtilisateur);
            cd.Parameters.AddWithValue("@CatSocial", contrat.IDCatSocioPro);
            cd.Parameters.AddWithValue("@Filial", contrat.IDFiliale);
            cd.Parameters.AddWithValue("@Effet", contrat.EffectifCatSocio);
            cd.Parameters.AddWithValue("@DSignature", contrat.DateSignContrat);
            cd.Parameters.AddWithValue("@DFinContrat", contrat.DateFinContrat);
            cd.Parameters.AddWithValue("@DEffetContrat", contrat.DateEffetContrat);
            cd.Parameters.AddWithValue("@Age", contrat.AgeMoyenCatSocio);

            cd.CommandText = "update Contrat set IDEntreprise=@Entreprise, IDOrganisme=@Organisme, IDStatut=@Statut, IDUtilisateur=@Utilisateur, IDCatSocioPro=@CatSocial, IDFiliale=@Filial, EffectifCatSocio=@Effet, DateSignContrat=@DSignature, DateFinContrat= @DFinContrat, DateEffetContrat=@DEffetContrat, AgeMoyenCatSocio=@Age from Contrat where IDContrat=@sCode";
            cd.CommandType = CommandType.Text;
            cd.ExecuteNonQuery();
            _cn.Close();
        }

        /// <summary>
        ///  methode qui construit  et renvoi un objet metier contrat 
        /// </summary>
        /// <param name="code"> code contrat</param>
        /// <returns>Objet contrat</returns>
        public Contrat Lecture(string code)
        {
            Contrat contrat = new Contrat();

            _cn.Open();
            cd = _cn.CreateCommand();
            cd.Parameters.AddWithValue("@Code", code);
            cd.CommandText = "select * from Contrat where IDContrat = @Code";
            cd.CommandType = CommandType.Text;

            using (reader = cd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                reader.Read();
                contrat.IDContrat = reader["IDContrat"].ToString();
                contrat.IDEntreprise = reader["IDEntreprise"].ToString();
                contrat.IDOrganisme = reader["IDOrganisme"].ToString();
                contrat.IDStatut = reader["IDStatut"].ToString();
                contrat.IDFiliale = reader["IDFiliale"].ToString();
                contrat.IDUtilisateur = reader["IDUtilisateur"].ToString();
                contrat.TypeContrat = reader["TypeContrat"].ToString();
                contrat.EffectifCatSocio = (int)reader["EffectifCatSocio"];
                contrat.IDCatSocioPro = reader["IDCatSocioPro"].ToString();
                contrat.DateSignContrat = (DateTime)reader["DateSignContrat"];
                contrat.DateEffetContrat = (DateTime)reader["DateEffetContrat"];
                contrat.DateFinContrat = (DateTime)reader["DateFinContrat"];
                contrat.AgeMoyenCatSocio = (int)reader["AgeMoyenCatSocio"];

            }
            return contrat;
        }

        /// <summary>
        /// methode qui suprime une entreprise
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public void SupressionContrat(string code)
        {
            _cn.Open();
            cd = _cn.CreateCommand();
            cd.Parameters.AddWithValue("@Code", code);
            cd.CommandText = "DELETE FROM Contrat WHERE IDContrat= @Code";
            cd.CommandType = CommandType.Text;

            cd.ExecuteNonQuery();
            _cn.Close();
        }

    }

}