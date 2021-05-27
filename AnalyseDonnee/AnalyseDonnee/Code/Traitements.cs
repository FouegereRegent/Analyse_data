using System;
using System.Collections.Generic;

namespace AnalyseDonnee.Code
{
    public static class Trie
    {
        /*Cette fonctions vas permettre de retourner le nom des obj_agence afin de crée les objets correspondant au agence
         La colone numéro 7 correspond au nom de l'agence*/
        public static string[] NomAgence(string[,] _matrice)
        {
            int nombreLignes = _matrice.Length / 20;
            List<string> nom_agence = new List<string>();
            for (int indexLignes = 0; indexLignes < nombreLignes; indexLignes++)
            {
                string agence = _matrice[indexLignes, 7];
                bool etat_recherche = false;
                nom_agence.ForEach(delegate (string str)
                {
                    if (str == agence && !etat_recherche)
                    {
                        etat_recherche = true;
                    }
                });

                if (!etat_recherche)
                {
                    nom_agence.Add(agence);
                }

            }
            return nom_agence.ToArray();
        }

        /*Cette fonctions vas permettre de transformer toute les données en une matrice.*/
        public static string[,] MatriceData(string[] tableau_mere, int nombreColone, int nombreLigne)
        {
            string[,] matrice = new string[nombreLigne - 1, nombreColone];

            for (int index = 1; index < tableau_mere.Length; index++)
            {
                List<char> chaine = new List<char>();
                int indexColone = 0;
                foreach (char character in tableau_mere[index])
                {
                    if (character != ';')
                    {
                        chaine.Add(character);
                    }
                    else
                    {
                        matrice[index - 1, indexColone] = new string(chaine.ToArray());
                        chaine = new List<char>();
                        indexColone++;
                    }
                }
            }

            return matrice;
        }

        /*Fonction permettant de retourner le numéro de l'agence*/
        public static int NumColoneKey(string chaine_de_base, string key)
        {
            List<char> mot_de_la_chaine = new List<char>();
            List<string> chaine = new List<string>();
            string[] tab_chaine;
            foreach (char charactere in chaine_de_base)
            {
                if (charactere != ';')
                {
                    mot_de_la_chaine.Add(charactere);
                }
                else
                {
                    chaine.Add(new string(mot_de_la_chaine.ToArray()));
                    mot_de_la_chaine = new List<char>();
                }
            }

            tab_chaine = chaine.ToArray();

            for (int index = 0; index < tab_chaine.Length; index++)
            {
                if (tab_chaine[index].ToUpper() == key.ToUpper())
                {
                    return index;
                }
            }

            return -1;
        }

        public static Dictionary<string, Agence> TrieTicket(string[,] matrice, string chaine_contruct_csv, int nombreLignes)
        {
            Dictionary<string, string> dictionnaireAgence =  new Dictionary<string, string>();
            Dictionary<string, Agence> obj_agence = new Dictionary<string, Agence>();
            Agence TME = new Agence("TME");
            Agence BME = new Agence("BME");
            Agence ONE = new Agence("ONE");
            Agence APY = new Agence("APY");
            DateTime reference = DateTime.Parse("01/01/1970");
            int NumColonesAgence = NumColoneKey(chaine_contruct_csv, "Agence");
            int NumColonesPrisEnCompte = NumColoneKey(chaine_contruct_csv, "Date Prise en compte");
            int NumColonesDemande = NumColoneKey(chaine_contruct_csv, "Date Demande");
            int NumColonesRealisation = NumColoneKey(chaine_contruct_csv, "Date Réal. Prog.");
            int NumColonesCloture = NumColoneKey(chaine_contruct_csv, "Date Cloture");

            /*Initialisations du dictionnaire : dictionnaireAgence*/
            dictionnaireAgence.Add("AG Thau Méditerranée", "TME");
            dictionnaireAgence.Add("AG Occitanie Nord Est", "ONE");
            dictionnaireAgence.Add("AG Béziers Méditerranée", "BME");
            dictionnaireAgence.Add("AG Aude Pyrénées Orientales", "APY");
            dictionnaireAgence.Add("AG Pyrénées Val de Garonne", "APY");

            /*Initilisation du dictionnaire : obj_agence*/
            obj_agence.Add("TME", TME);
            obj_agence.Add("BME", BME);
            obj_agence.Add("ONE", ONE);
            obj_agence.Add("APY", APY);
            
            for(int indexLignes = 0; indexLignes < nombreLignes; indexLignes++)
            {
                string nomAgence = matrice[indexLignes, NumColonesAgence];
                string prise_en_compte = matrice[indexLignes, NumColonesPrisEnCompte];
                string date_demande = matrice[indexLignes, NumColonesDemande];
                string date_realisation = matrice[indexLignes, NumColonesRealisation];
                string date_cloture = matrice[indexLignes, NumColonesCloture];

                if(dictionnaireAgence.ContainsKey(nomAgence) == true && date_cloture != null && date_demande != null && date_realisation != null && prise_en_compte != null)
                {
                    if(DateTime.Parse(date_cloture) != reference && DateTime.Parse(prise_en_compte) != reference && DateTime.Parse(date_realisation) != reference && DateTime.Parse(date_demande) != reference)
                    {
                        obj_agence[dictionnaireAgence[nomAgence]].DateCloture.Add(DateTime.Parse(date_cloture));
                        obj_agence[dictionnaireAgence[nomAgence]].DatePriseEnCompte.Add(DateTime.Parse(prise_en_compte));
                        obj_agence[dictionnaireAgence[nomAgence]].DateRealisationProg.Add(DateTime.Parse(date_realisation));
                        obj_agence[dictionnaireAgence[nomAgence]].DateDemande.Add(DateTime.Parse(date_demande));
                    }

                }

            }

            return obj_agence;

        }

    }
}
