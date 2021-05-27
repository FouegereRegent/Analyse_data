using System;
using System.Collections.Generic;


namespace AnalyseDonnee.Code
{
    public class Agence
    {
        /*Déclaration des propriéter*/
        public int moyenne_resultat_delai_prise_en_compte { get; private set; }
        public int moyenne_resultat_delai_realisation_prog { get; private set; }
        public int moyenne_delai_cloture { get; private set; }
        public string acronyme_agence { get; private set; }
        /*Déclaration des variables*/
        public List<DateTime> DateDemande;
        public List<DateTime> DatePriseEnCompte;
        public List<DateTime> DateRealisationProg;
        public List<DateTime> DateCloture;
        private int[] DelaiPriseEnCompte;
        private int[] DelaiRealisation;
        private int[] DelaiCloture;

        public Agence(string acronyme_agence)
        {
            this.acronyme_agence = acronyme_agence;
            
            DateDemande = new List<DateTime>();
            DatePriseEnCompte = new List<DateTime>();
            DateRealisationProg = new List<DateTime>();
            DateCloture = new List<DateTime>();
        }

        /*Permet de tous calculer*/
        public void Calcul()
        {
            Func<int[], int> CalcMoyenne = (tab_valeur) => {
                double result = 0;
                for(int index = 0; index < tab_valeur.Length; index++)
                {
                    result += tab_valeur[index];
                }
                return (int)Math.Round((result/tab_valeur.Length));
            };

            this.DelaiPriseEnCompte = this.CalculDelais(DateDemande.ToArray(), DatePriseEnCompte.ToArray());
            this.DelaiRealisation = this.CalculDelais(DatePriseEnCompte.ToArray(), DateRealisationProg.ToArray());
            this.DelaiCloture = this.CalculDelais(DatePriseEnCompte.ToArray(), DateCloture.ToArray());

            this.moyenne_delai_cloture = CalcMoyenne(DelaiCloture);
            this.moyenne_resultat_delai_prise_en_compte = CalcMoyenne(DelaiPriseEnCompte);
            this.moyenne_resultat_delai_realisation_prog = CalcMoyenne(DelaiRealisation);

        }

        private int[] CalculDelais(DateTime[] debut, DateTime[] fin)
        {
            int[] result = new int[debut.Length];

            for(int index = 0; index < result.Length; index++)
            {
                result[index] = (fin[index] - debut[index]).Days >= 0 ? (fin[index] - debut[index]).Days : 0;
            }
            return result;
        }
    }
}
