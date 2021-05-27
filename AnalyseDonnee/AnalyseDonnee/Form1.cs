using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using AnalyseDonnee.Code;
using System.IO;

namespace AnalyseDonnee
{
    public partial class Form1 : Form
    {
        private OpenFileDialog openfile;
        private SaveFileDialog savefile;
        private Thread[] thread_calcul;
        private string path_source;
        private string path_dest;

        public Form1()
        {
            InitializeComponent();

            /*Initialisation du openfiledialog*/
            openfile = new OpenFileDialog();
            savefile = new SaveFileDialog();
            openfile.Filter = "fichier csv (*.csv)|*.csv";
            openfile.FilterIndex = 1;
            savefile.Filter = "fichier csv (*.csv)|*.csv";
            savefile.FilterIndex = 1;
            savefile.Title = "Enregistrer";

            thread_calcul = new Thread[4];
        }

        private void button_recherche_file(object sender, EventArgs e)
        {
            if(path_source != null && path_dest != null && path_dest != "")
            {
                int index = 0;
                string[] result_csv = new string[5];
                string[] test = LectureCSV.ReadCSV(path_source);
                uint nombreColones = LectureCSV.CalculNombreColones(test);
                string[,] matrice = Trie.MatriceData(test, (int)nombreColones, test.Length);
                int numColones = Trie.NumColoneKey(test[0], "agence");
                Dictionary<string, Agence> essaie = Trie.TrieTicket(matrice, test[0], test.Length - 1);
                foreach (KeyValuePair<string, Agence> kvp in essaie)
                {
                    thread_calcul[index] = new Thread(new ThreadStart(kvp.Value.Calcul));
                    index++;
                }
                for (index = 0; index < thread_calcul.Length; index++)
                {
                    thread_calcul[index].Start();
                }
                for (index = 0; index < thread_calcul.Length; index++)
                {
                    thread_calcul[index].Join();
                }
                index = 1;
                result_csv[0] = ";Delais  prise en compte (j);Delais de real. prog (j);Delai de cloture (j);";
                foreach (KeyValuePair<string, Agence> kvp in essaie)
                {
                    result_csv[index] = "Agence " + kvp.Value.acronyme_agence + ";" +Convert.ToString(kvp.Value.moyenne_resultat_delai_prise_en_compte) + ";" + Convert.ToString(kvp.Value.moyenne_resultat_delai_realisation_prog) + ";" + Convert.ToString(kvp.Value.moyenne_delai_cloture) + ";";
                    index++;
                }
                Stream stream = savefile.OpenFile();
                EditCSV.CreateCSV(stream, result_csv);

                MessageBox.Show("Traitement Finis");
            }
        }
        private void choiceFile_Click(object sender, EventArgs e)
        {
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                this.path_source = this.openfile.FileName;
                this.textBoxSource.Text = this.path_source;
            }
        }

        private void buttonDestination_Click(object sender, EventArgs e)
        {
            if(savefile.ShowDialog() == DialogResult.OK)
            {
                this.path_dest = this.savefile.FileName;
                this.textBoxDest.Text = this.path_dest;
            }
        }
    }
}
