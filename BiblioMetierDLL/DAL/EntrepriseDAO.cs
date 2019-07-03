using BiblioMetierDLL;
using ProjetMutuelle.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetMutuelle.DAL
{
    public class EntrepriseDAO
    {
        static EntrepriseDAO _instance;
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
        /// Singleton
        /// </summary>
        public static EntrepriseDAO Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EntrepriseDAO();
                return _instance;
            }
        }

        /// <summary>
        /// Liste des entreprises (Index)
        /// </summary>
        /// <returns>entreprises</returns>
        public List<EntrepriseMere> Liste()
        {
            //Liste avec Entity Framework
            //Requête Linq de la liste des entreprises

            using (var contexte = new ModelEf())
            {
                contexte.Configuration.ProxyCreationEnabled = false;
                contexte.Configuration.LazyLoadingEnabled = false;

                var EntrepriseQuery = from ent in contexte.EntrepriseMeres
                                      orderby ent.DesignationEntreprise
                                      select ent;
                return EntrepriseQuery.ToList();

            }
        }

        /// <summary>
        /// Fiche de l'entreprise
        /// </summary>
        /// <param name="sCode">Fiche à visualiser</param>
        /// <returns>entreprise</returns>
        public EntrepriseMere Fiche(string sCode)
        {
            using (var contexte = new ModelEf())
            {
                contexte.Configuration.ProxyCreationEnabled = false;
                contexte.Configuration.LazyLoadingEnabled = false;

                //    var entreprisecontact = from ent in contexte.EntrepriseMeres
                //                            join contact in contexte.ContactEntreprises
                //                            on ent.IDEntreprise equals contact.IDEntreprise
                //                            select new {
                //                                contact.IDContact,
                //                                contact.NomContact,
                //                                contact.PrenomContact,
                //                                contact.FonctionContact,
                //                                contact.TelContact
                //                            };
                EntrepriseMere entreprise = contexte.EntrepriseMeres.Find(sCode);
                return entreprise;

            }

        }

        public bool Creer(EntrepriseMere entreprise)
        {
            //Création avec Entity framework
            //Requête linq création des entreprises  
            try
            {
                using (ModelEf contexte = new ModelEf())
                {
                    contexte.Configuration.LazyLoadingEnabled = false;
                    contexte.Configuration.ProxyCreationEnabled = false;
                    contexte.EntrepriseMeres.Add(entreprise);
                    contexte.SaveChanges();
                    return true;
                }
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool Modifier(EntrepriseMere entreprise)
        {
            //Modification avec Entity framework
            //Requête linq modification des entreprises
            using (ModelEf contexte = new ModelEf())
            {
                try
                {
                    contexte.Configuration.ProxyCreationEnabled = false;
                    contexte.Configuration.LazyLoadingEnabled = false;

                    EntrepriseMere entrepriseCopie;

                    entrepriseCopie = contexte.EntrepriseMeres.Find(entreprise.IDEntreprise);
                    entrepriseCopie.IDEntreprise = entreprise.IDEntreprise;
                    entrepriseCopie.IDApe = entreprise.IDApe;
                    entrepriseCopie.DesignationEntreprise = entreprise.DesignationEntreprise;
                    entrepriseCopie.AdresseEntreprise = entreprise.AdresseEntreprise;
                    entrepriseCopie.CodePostalEntreprise = entreprise.CodePostalEntreprise;
                    entrepriseCopie.VilleEntreprise = entreprise.VilleEntreprise;
                    entrepriseCopie.TelEntreprise = entreprise.TelEntreprise;
                    entrepriseCopie.EffectifTotal = entreprise.EffectifTotal;

                    contexte.SaveChanges();
                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                }

            }
        }

        public bool Supprimer(string id)
        {
            //Suppression avec Entity framework
            //Requête linq suppression des entreprises

            try
            {
                using (ModelEf contexte = new ModelEf())
                {
                    contexte.Configuration.LazyLoadingEnabled = false;
                    contexte.Configuration.ProxyCreationEnabled = false;

                    EntrepriseMere entreprise;
                    entreprise = contexte.EntrepriseMeres.Find(id);
                    contexte.EntrepriseMeres.Remove(entreprise);
                    contexte.SaveChanges();
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
