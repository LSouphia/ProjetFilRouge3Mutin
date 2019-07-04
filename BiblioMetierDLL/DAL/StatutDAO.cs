using BiblioMetierBOL;
using BiblioMetierBOL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BiblioMetierDAL.DAL
{
    public class StatutDAO
    {
        SqlConnection _cn = new SqlConnection();
        Statut statut = new Statut();

        /// <summary>
        /// Connexion
        /// </summary>
        public StatutDAO()
        {
            ConnectionStringSettings oConfig = ConfigurationManager.ConnectionStrings["ModelEf1"];
            _cn.ConnectionString = oConfig.ConnectionString;
        }

        /// <summary>
        /// Liste statut (Index)
        /// </summary>
        /// <returns>statut</returns>
        public List<Statut> ListeStatut()
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
            List<Statut> statutResults = new List<Statut>(); // pour une collection, on écrit le nom en minuscule avec un s à la fin 
            SqlCommand cd = new SqlCommand();
            cd.Connection = _cn; // Appel de la méthode "connexion" (public SqlConnection connexion())
            cd.CommandText = "select LibelleStatut from Statut";

            using (SqlDataReader dr = cd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (dr.Read())
                { 
                    Statut staut = new Statut();
                    statut.LibelleStatut = dr["LibelleStatut"].ToString();
                    statutResults.Add(statut);
                }
                return statutResults;
            }
        }

    }
}