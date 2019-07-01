using ProjetMutuelle.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetMutuelle.DAL
{
    public class ContactDAO
    {
        SqlConnection _cn = new SqlConnection();

        /// <summary>
        /// Connexion
        /// </summary>
        public ContactDAO()
        {
            ConnectionStringSettings oConfig = ConfigurationManager.ConnectionStrings["BDSql"];
            _cn.ConnectionString = oConfig.ConnectionString;
        }

        /// <summary>
        /// Liste des contacts (Index)
        /// </summary>
        /// <returns>contacts</returns>
        public List<Contact> Liste()
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
            List<Contact> entreprises = new List<Contact>(); // pour une collection, on écrit le nom en minuscule avec un s à la fin 
            SqlCommand cd = new SqlCommand();
            cd.Connection = _cn; // Appel de la méthode "connexion" (public SqlConnection connexion())
            cd.CommandText = "SELECT * FROM ContactEntreprise";

            using (SqlDataReader dr = cd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (dr.Read())
                {
                    Contact contact = new Contact();

                    contact.IDContact = dr["IDContact"].ToString();
                    contact.IDEntreprise = dr["IDEntreprise"].ToString();
                    contact.NomContact = dr["NomContact"].ToString();
                    contact.PrenomContact = dr["PrenomContact"].ToString();
                    contact.FonctionContact = dr["FonctionContact"].ToString();
                    contact.TelContact = dr["TelContact"].ToString();


                    entreprises.Add(contact);
                }
                return entreprises;
            }
        }

        /// <summary>
        /// Fiche de l'entreprise
        /// </summary>
        /// <param name="sCode">Fiche à visualiser</param>
        /// <returns>entreprise</returns>
        public Contact Fiche(string sCode)
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
            Contact contact = new Contact();
            SqlCommand cd = new SqlCommand();
            cd.Connection = _cn; // Appel de la méthode "connexion" (public SqlConnection connexion())
            cd.Parameters.AddWithValue("@sCode", sCode);
            cd.CommandText = "SELECT * FROM ContactEntreprise where IDContact = @sCode";

            using (SqlDataReader dr = cd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (dr.Read())
                {
                    contact.IDContact = dr["IDContact"].ToString();
                    contact.IDEntreprise = dr["IDEntreprise"].ToString();
                    contact.NomContact = dr["NomContact"].ToString();
                    contact.PrenomContact = dr["PrenomContact"].ToString();
                    contact.FonctionContact = dr["FonctionContact"].ToString();
                    contact.TelContact = dr["TelContact"].ToString();
                }
                return contact;
            }

        }
    }
}
   