using BiblioMetierDLL;
using ProjetMutuelle.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetMutuelle.BLL
{
    public class EntrepriseManager
    {
        private static EntrepriseManager _instance;
        EntrepriseDAO _entrepriseDAO = new EntrepriseDAO();

        /// <summary>
        /// Singleton
        /// </summary>
        public static EntrepriseManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EntrepriseManager();
                return _instance;
            }
        }

        /// <summary>
        /// Liste entreprise complète
        /// </summary>
        /// <returns>Liste()</returns>
        public List<EntrepriseMere> Liste()
        {
            return _entrepriseDAO.Liste();
        }

        /// <summary>
        /// Fiche
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Fiche (string id)</returns>
        public EntrepriseMere Fiche(string id)
        {
            return _entrepriseDAO.Fiche(id);
        }

        /// <summary>
        /// Création
        /// </summary>
        /// <param name="entreprise"></param>
        public bool Creer(EntrepriseMere entreprise)
        {
            try
            {
                _entrepriseDAO.Creer(entreprise);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Modifier
        /// </summary>
        /// <param name="entreprise"></param>
        /// <returns>false ou true</returns>
        public bool Modifier(string id, EntrepriseMere entreprise)
        {
            try
            {
                _entrepriseDAO.Modifier(entreprise);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Supprimer
        /// </summary>
        /// <param name="id"></param>
        public void Supprimer(string id)
        {
            _entrepriseDAO.Supprimer(id);
        }
    }
}