using BiblioMetierBOL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BiblioMetierDAL.DAL
{
    public class ContratDAO
    {
        static ContratDAO _instance;
        SqlConnection _cn = new SqlConnection();
        SqlCommand cd = new SqlCommand();

        /// <summary>
        /// Connexion
        /// </summary>
        public ContratDAO()
        {
            ConnectionStringSettings oConfig = ConfigurationManager.ConnectionStrings["ModelEf"];
            _cn.ConnectionString = oConfig.ConnectionString;
        }

        /// <summary>
        /// Singleton
        /// </summary>
        public static ContratDAO Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ContratDAO();
                return _instance;
            }
        }

        /// <summary>
        /// Liste des contrats (Index)
        /// </summary>
        /// <returns>contratResults</returns>
        public List<Contrat> ListeContrat()
        {

            using (var contexte = new ModelEf())
            {
                contexte.Configuration.LazyLoadingEnabled = false;
                contexte.Configuration.ProxyCreationEnabled = false;
                var LQuery = from L in contexte.Contrats
                             orderby L.DateSignContrat
                             select L;
                return LQuery.ToList();
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
        public bool CreationContrat(Contrat contrat)
        {
            try
            {
                using (ModelEf context = new ModelEf())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    context.Configuration.ProxyCreationEnabled = false;
                    context.Contrats.Add(contrat);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Modifier un contrat
        /// </summary>
        /// <param name="sCode">contrat à modifier</param>
        /// <param name="contrat">contrat à modifier</param>
        public bool ModifierContrat(Contrat moncontrat)
        {
            try
            {
                using (ModelEf context = new ModelEf())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    context.Configuration.ProxyCreationEnabled = false;
                    Contrat contrat;
                    // prendre en charge les modification dans le formulaire 
                    contrat = context.Contrats.Find(moncontrat.IDContrat);
                    contrat.IDOrganisme = moncontrat.IDOrganisme;
                    contrat.IDUtilisateur = moncontrat.IDUtilisateur;
                    contrat.IDFiliale = moncontrat.IDFiliale;
                    contrat.IDEntreprise = moncontrat.IDEntreprise;
                    contrat.IDCatSocioPro = moncontrat.IDCatSocioPro;
                    contrat.Statut = moncontrat.Statut;
                    contrat.TypeContrat = moncontrat.TypeContrat;
                    contrat.EffectifCatSocio = moncontrat.EffectifCatSocio;
                    contrat.AgeMoyenCatSocio = moncontrat.AgeMoyenCatSocio;
                    contrat.DateSignContrat = moncontrat.DateSignContrat;
                    contrat.DateEffetContrat = moncontrat.DateEffetContrat;
                    contrat.DateFinContrat = moncontrat.DateFinContrat;
                    contrat.EntrepriseMere = moncontrat.EntrepriseMere;
                    contrat.Statut = moncontrat.Statut;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        
        /// <summary>
        ///  methode qui construit  et renvoi un objet metier contrat 
        /// </summary>
        /// <param name="code"> code contrat</param>
        /// <returns>Objet contrat</returns>
        public Contrat Lecture(string code)
        {
            using (ModelEf context = new ModelEf())
            {
                context.Configuration.LazyLoadingEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;
                return context.Contrats.Find(code);
            }
        }

        /// <summary>
        /// methode qui suprime une entreprise
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool SupressionContrat(string code)
        {
            try
            {
                using (ModelEf context = new ModelEf())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    context.Configuration.ProxyCreationEnabled = false;
                    Contrat contrat1;
                    contrat1 = context.Contrats.Find(code);
                    context.Contrats.Remove(contrat1);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (System.Exception)
            {
                return false;
            }
        }

    }

}