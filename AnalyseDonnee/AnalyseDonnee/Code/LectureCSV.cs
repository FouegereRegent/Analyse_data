using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AnalyseDonnee.Code
{
    public static class LectureCSV
    {
        public static string[] ReadCSV(string cheminsFichier)
        {
            List<string> lignes = new List<string>();
            if (!File.Exists(cheminsFichier))
            {
                return null;
            }
            else
            {
                Stream stream = File.Open(cheminsFichier, FileMode.Open, FileAccess.Read);
                StreamReader streamreader = new StreamReader(stream, Encoding.Default);
                do
                {
                    lignes.Add(streamreader.ReadLine());
                } while (streamreader.Peek() >= 0);

                streamreader.Close();
                stream.Close();
                return lignes.ToArray();
            }
        }

        /*Calcul le nombre de colones dans la chaine de retour après la lecture du fichier csv*/
        public static uint CalculNombreColones(string[] tableau_retour)
        {
            uint nombre_colones = 1;
            string _chaine = tableau_retour[0];
            foreach(char charactere in _chaine)
            {
                nombre_colones += charactere == ';' ? (uint)1 : (uint)0;
            }
            return nombre_colones;
        }

    }
    public static class EditCSV
    {
        public static void CreateCSV(Stream stream, string[] valeurLignes)
        {
            StreamWriter streamWriter = new StreamWriter(stream);
            for(int index = 0; index < valeurLignes.Length; index++)
            {
                streamWriter.WriteLine(valeurLignes[index]);
            }
            streamWriter.Close();
            stream.Close();
        }
    }
}
