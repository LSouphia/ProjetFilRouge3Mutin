using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioMetierBOL;
using BiblioMetierBOL.Models;
using BiblioMetierDAL.DAL;

namespace BiblioMetierDAL.BLL
{
    class ContratManager
    {
        private static ContratManager _instance;
        ContratDAO _ContratDAO = new ContratDAO();

        /// <summary>
        /// Singleton
        /// </summary>
        public static ContratManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ContratManager();
                return _instance;
            }
        }

        /// <summary>
        /// Liste contrat complète
        /// </summary>
        /// <returns>Liste()</returns>
        public List<Contrat> Liste()
        {
            return _ContratDAO.ListeContrat();
        }

        /// <summary>
        /// Lecture
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Lecture (string id)</returns>
        public Contrat Lecture(string id)
        {
            return _ContratDAO.Lecture(id);
        }

        /// <summary>
        /// Créer
        /// </summary>
        /// <param name="entreprise"></param>
        public bool Creation(Contrat contrat)
        {
            try
            {
                _ContratDAO.CreationContrat(contrat);
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
        public bool Modifier(string id, Contrat contrat)
        {
            try
            {
                _ContratDAO.ModifierContrat(contrat);
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
        public void Suppression(string id)
        {
            _ContratDAO.SupressionContrat(id);
        }
    }

}  


