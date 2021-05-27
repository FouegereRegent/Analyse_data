
namespace AnalyseDonnee
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button button_file;
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.choiceFile = new System.Windows.Forms.Button();
            this.buttonDestination = new System.Windows.Forms.Button();
            this.textBoxDest = new System.Windows.Forms.TextBox();
            button_file = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_file
            // 
            button_file.AccessibleName = "LaunchProgram";
            button_file.Location = new System.Drawing.Point(359, 307);
            button_file.Name = "button_file";
            button_file.Size = new System.Drawing.Size(75, 23);
            button_file.TabIndex = 0;
            button_file.Text = "Excuter";
            button_file.UseVisualStyleBackColor = true;
            button_file.Click += new System.EventHandler(this.button_recherche_file);
            // 
            // textBoxSource
            // 
            this.textBoxSource.Location = new System.Drawing.Point(236, 223);
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.ReadOnly = true;
            this.textBoxSource.Size = new System.Drawing.Size(310, 20);
            this.textBoxSource.TabIndex = 1;
            // 
            // choiceFile
            // 
            this.choiceFile.Location = new System.Drawing.Point(552, 223);
            this.choiceFile.Name = "choiceFile";
            this.choiceFile.Size = new System.Drawing.Size(112, 20);
            this.choiceFile.TabIndex = 2;
            this.choiceFile.Text = "Choisir Fichier";
            this.choiceFile.UseVisualStyleBackColor = true;
            this.choiceFile.Click += new System.EventHandler(this.choiceFile_Click);
            // 
            // buttonDestination
            // 
            this.buttonDestination.Location = new System.Drawing.Point(552, 261);
            this.buttonDestination.Name = "buttonDestination";
            this.buttonDestination.Size = new System.Drawing.Size(112, 20);
            this.buttonDestination.TabIndex = 4;
            this.buttonDestination.Text = "Choisir Destination";
            this.buttonDestination.UseVisualStyleBackColor = true;
            this.buttonDestination.Click += new System.EventHandler(this.buttonDestination_Click);
            // 
            // textBoxDest
            // 
            this.textBoxDest.Location = new System.Drawing.Point(236, 261);
            this.textBoxDest.Name = "textBoxDest";
            this.textBoxDest.ReadOnly = true;
            this.textBoxDest.Size = new System.Drawing.Size(310, 20);
            this.textBoxDest.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonDestination);
            this.Controls.Add(this.textBoxDest);
            this.Controls.Add(this.choiceFile);
            this.Controls.Add(this.textBoxSource);
            this.Controls.Add(button_file);
            this.Name = "Form1";
            this.Text = "Suez";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.Button choiceFile;
        private System.Windows.Forms.Button buttonDestination;
        private System.Windows.Forms.TextBox textBoxDest;
    }
}

