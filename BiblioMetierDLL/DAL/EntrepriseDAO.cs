using ProjetMutuelle.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProjetMutuelle.DAL
{
   public class EntrepriseDAO
    {
        SqlConnection _cn = new SqlConnection();

        /// <summary>
        /// Connexion
        /// </summary>
        public EntrepriseDAO()
        {
            ConnectionStringSettings oConfig = ConfigurationManager.ConnectionStrings["ModelEf"];
            _cn.ConnectionString = oConfig.ConnectionString;
        }

        /// <summary>
        /// Liste des entreprises (Index)
        /// </summary>
        /// <returns>entreprises</returns>
        public List<Entreprise> Liste()
        {
            ConnectionStringSettings oConfig = ConfigurationManager.ConnectionStrings["ModelEf"];
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
            List<Entreprise> entreprises = new List<Entreprise>(); // pour une collection, on écrit le nom en minuscule avec un s à la fin 
            SqlCommand cd = new SqlCommand();
            cd.Connection = _cn; // Appel de la méthode "connexion" (public SqlConnection connexion())
            cd.CommandText = "SELECT * FROM EntrepriseMere";

            using (SqlDataReader dr = cd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (dr.Read())
                {
                    Entreprise entreprise = new Entreprise();

                    entreprise.IDEntreprise = dr["IDEntreprise"].ToString();
                    entreprise.DesignationEntreprise = dr["DesignationEntreprise"].ToString();
                    entreprise.IDApe = dr["IDApe"].ToString();



                    entreprises.Add(entreprise);
                }
                return entreprises;
            }
        }

        /// <summary>
        /// Fiche de l'entreprise
        /// </summary>
        /// <param name="sCode">Fiche à visualiser</param>
        /// <returns>entreprise</returns>
        public Entreprise Fiche(string sCode)
        {
            ConnectionStringSettings oConfig = ConfigurationManager.ConnectionStrings["ModelEf"];
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
            Entreprise entreprise = new Entreprise();
            SqlCommand cd = new SqlCommand();
            cd.Connection = _cn; // Appel de la méthode "connexion" (public SqlConnection connexion())
            cd.Parameters.AddWithValue("@sCode", sCode);
            cd.CommandText = "SELECT * FROM EntrepriseMere INNER JOIN ContactEntreprise ON EntrepriseMere.IDEntreprise = ContactEntreprise.IDEntreprise where EntrepriseMere.IDEntreprise = @sCode";

            using (SqlDataReader dr = cd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (dr.Read())
                {
                    entreprise.IDEntreprise = dr["IDEntreprise"].ToString();
                    entreprise.IDApe = dr["IDApe"].ToString();
                    entreprise.DesignationEntreprise = dr["DesignationEntreprise"].ToString();
                    entreprise.AdresseEntreprise = dr["AdresseEntreprise"].ToString();
                    entreprise.CodePostalEntreprise = dr["CodePostalEntreprise"].ToString();
                    entreprise.VilleEntreprise = dr["VilleEntreprise"].ToString();
                    entreprise.TelEntreprise = dr["TelEntreprise"].ToString();
                    entreprise.EffectifTotal = (int)dr["EffectifTotal"];
                    entreprise.IDContact = dr["IDContact"].ToString();
                    entreprise.NomContact = dr["NomContact"].ToString();
                    entreprise.PrenomContact = dr["PrenomContact"].ToString();
                    entreprise.FonctionContact = dr["FonctionContact"].ToString();
                    entreprise.TelContact = dr["TelContact"].ToString();
                }
                return entreprise;
            }
        }

        public int Creer(Entreprise entreprise)
        {
            int n = 0;

            ConnectionStringSettings oConfig = ConfigurationManager.ConnectionStrings["ModelEf"];
            if (oConfig != null)
            {
                _cn.ConnectionString = oConfig.ConnectionString;
                try
                {
                    _cn.Open();
                }
                catch
                {
                    return -1;
                }
            }

            SqlCommand cd = new SqlCommand();
            cd.Connection = _cn;
            cd.Parameters.AddWithValue("@IDEntreprise", entreprise.IDEntreprise);
            cd.Parameters.AddWithValue("@IDApe", entreprise.IDApe);
            cd.Parameters.AddWithValue("@DesignationEntreprise", entreprise.DesignationEntreprise);
            cd.Parameters.AddWithValue("@AdresseEntreprise", entreprise.AdresseEntreprise);
            cd.Parameters.AddWithValue("@CodePostalEntreprise", entreprise.CodePostalEntreprise);
            cd.Parameters.AddWithValue("@VilleEntreprise", entreprise.VilleEntreprise);
            cd.Parameters.AddWithValue("@TelEntreprise", entreprise.TelEntreprise);
            cd.Parameters.AddWithValue("@EffectifTotal", entreprise.EffectifTotal);
            cd.Parameters.AddWithValue("@IDContact", entreprise.IDContact);
            cd.Parameters.AddWithValue("@NomContact", entreprise.NomContact);
            cd.Parameters.AddWithValue("@PrenomContact", entreprise.PrenomContact);
            cd.Parameters.AddWithValue("@FonctionContact", entreprise.FonctionContact);
            cd.Parameters.AddWithValue("@TelContact", entreprise.TelContact);

            cd.CommandText = "insert into EntrepriseMere (IDEntreprise, IDApe, DesignationEntreprise, AdresseEntreprise, CodePostalEntreprise, VilleEntreprise, TelEntreprise, EffectifTotal) values (@IDEntreprise, @IDApe, @DesignationEntreprise, @AdresseEntreprise, @CodePostalEntreprise, @VilleEntreprise, @TelEntreprise, @EffectifTotal)";
            cd.CommandText = "insert into ContactEntreprise(IDContact, NomContact, PrenomContact, FonctionContact, TelContact) values (@IDContact, @NomContact, @PrenomContact, @AFonctionContact, @TelContact)";
            cd.CommandType = CommandType.Text;
            n = cd.ExecuteNonQuery();
            _cn.Close();
            return n;
        }
    }
}
