namespace Lab_Barres_Codes
{
    partial class frmBarresCodes
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
            this.components = new System.ComponentModel.Container();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbBitArret = new System.Windows.Forms.RadioButton();
            this.rbDeuxBitArret = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbArret = new System.Windows.Forms.RadioButton();
            this.rbActif = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbHuit = new System.Windows.Forms.RadioButton();
            this.rbSept = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAucune = new System.Windows.Forms.RadioButton();
            this.rbImpair = new System.Windows.Forms.RadioButton();
            this.rbPair = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Taxe = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.Label();
            this.Prix = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuantite = new System.Windows.Forms.TextBox();
            this.txtPrix = new System.Windows.Forms.TextBox();
            this.txtTaxe = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtSum = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.cbVitesse = new System.Windows.Forms.ComboBox();
            this.btnConnecter = new System.Windows.Forms.Button();
            this.Port = new System.IO.Ports.SerialPort(this.components);
            this.cbNom = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDeconnecter = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbBitArret);
            this.groupBox3.Controls.Add(this.rbDeuxBitArret);
            this.groupBox3.Location = new System.Drawing.Point(138, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(120, 93);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Arrêt";
            // 
            // rbBitArret
            // 
            this.rbBitArret.AutoSize = true;
            this.rbBitArret.Checked = true;
            this.rbBitArret.Location = new System.Drawing.Point(6, 19);
            this.rbBitArret.Name = "rbBitArret";
            this.rbBitArret.Size = new System.Drawing.Size(88, 17);
            this.rbBitArret.TabIndex = 20;
            this.rbBitArret.TabStop = true;
            this.rbBitArret.Text = "Un  bit d\'arret";
            this.rbBitArret.UseVisualStyleBackColor = true;
            this.rbBitArret.CheckedChanged += new System.EventHandler(this.BitArretChange);
            // 
            // rbDeuxBitArret
            // 
            this.rbDeuxBitArret.AutoSize = true;
            this.rbDeuxBitArret.Location = new System.Drawing.Point(6, 42);
            this.rbDeuxBitArret.Name = "rbDeuxBitArret";
            this.rbDeuxBitArret.Size = new System.Drawing.Size(101, 17);
            this.rbDeuxBitArret.TabIndex = 21;
            this.rbDeuxBitArret.TabStop = true;
            this.rbDeuxBitArret.Text = "Deux bits d\'arret";
            this.rbDeuxBitArret.UseVisualStyleBackColor = true;
            this.rbDeuxBitArret.CheckedChanged += new System.EventHandler(this.BitArretChange);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbArret);
            this.groupBox4.Controls.Add(this.rbActif);
            this.groupBox4.Location = new System.Drawing.Point(264, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(120, 93);
            this.groupBox4.TabIndex = 34;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Transmission";
            // 
            // rbArret
            // 
            this.rbArret.AutoSize = true;
            this.rbArret.Checked = true;
            this.rbArret.Location = new System.Drawing.Point(6, 19);
            this.rbArret.Name = "rbArret";
            this.rbArret.Size = new System.Drawing.Size(47, 17);
            this.rbArret.TabIndex = 22;
            this.rbArret.TabStop = true;
            this.rbArret.Text = "Arrêt";
            this.rbArret.UseVisualStyleBackColor = true;
            this.rbArret.CheckedChanged += new System.EventHandler(this.TransmitionChange);
            // 
            // rbActif
            // 
            this.rbActif.AutoSize = true;
            this.rbActif.Location = new System.Drawing.Point(6, 42);
            this.rbActif.Name = "rbActif";
            this.rbActif.Size = new System.Drawing.Size(46, 17);
            this.rbActif.TabIndex = 23;
            this.rbActif.TabStop = true;
            this.rbActif.Text = "Actif";
            this.rbActif.UseVisualStyleBackColor = true;
            this.rbActif.CheckedChanged += new System.EventHandler(this.TransmitionChange);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbHuit);
            this.groupBox2.Controls.Add(this.rbSept);
            this.groupBox2.Location = new System.Drawing.Point(390, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(120, 93);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Octets";
            // 
            // rbHuit
            // 
            this.rbHuit.AutoSize = true;
            this.rbHuit.Checked = true;
            this.rbHuit.Location = new System.Drawing.Point(6, 42);
            this.rbHuit.Name = "rbHuit";
            this.rbHuit.Size = new System.Drawing.Size(51, 17);
            this.rbHuit.TabIndex = 25;
            this.rbHuit.TabStop = true;
            this.rbHuit.Text = "8 Bits";
            this.rbHuit.UseVisualStyleBackColor = true;
            this.rbHuit.CheckedChanged += new System.EventHandler(this.NbOctetChange);
            // 
            // rbSept
            // 
            this.rbSept.AutoSize = true;
            this.rbSept.Location = new System.Drawing.Point(6, 19);
            this.rbSept.Name = "rbSept";
            this.rbSept.Size = new System.Drawing.Size(51, 17);
            this.rbSept.TabIndex = 24;
            this.rbSept.TabStop = true;
            this.rbSept.Text = "7 Bits";
            this.rbSept.UseVisualStyleBackColor = true;
            this.rbSept.CheckedChanged += new System.EventHandler(this.NbOctetChange);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAucune);
            this.groupBox1.Controls.Add(this.rbImpair);
            this.groupBox1.Controls.Add(this.rbPair);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 93);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parite";
            // 
            // rbAucune
            // 
            this.rbAucune.AutoSize = true;
            this.rbAucune.Checked = true;
            this.rbAucune.Location = new System.Drawing.Point(6, 65);
            this.rbAucune.Name = "rbAucune";
            this.rbAucune.Size = new System.Drawing.Size(62, 17);
            this.rbAucune.TabIndex = 180;
            this.rbAucune.Text = "Aucune";
            this.rbAucune.UseVisualStyleBackColor = true;
            this.rbAucune.CheckedChanged += new System.EventHandler(this.PariteChange);
            // 
            // rbImpair
            // 
            this.rbImpair.AutoSize = true;
            this.rbImpair.Location = new System.Drawing.Point(6, 42);
            this.rbImpair.Name = "rbImpair";
            this.rbImpair.Size = new System.Drawing.Size(53, 17);
            this.rbImpair.TabIndex = 22;
            this.rbImpair.Text = "Impair";
            this.rbImpair.UseVisualStyleBackColor = true;
            this.rbImpair.CheckedChanged += new System.EventHandler(this.PariteChange);
            // 
            // rbPair
            // 
            this.rbPair.AutoSize = true;
            this.rbPair.Location = new System.Drawing.Point(6, 19);
            this.rbPair.Name = "rbPair";
            this.rbPair.Size = new System.Drawing.Size(43, 17);
            this.rbPair.TabIndex = 170;
            this.rbPair.Text = "Pair";
            this.rbPair.UseVisualStyleBackColor = true;
            this.rbPair.CheckedChanged += new System.EventHandler(this.PariteChange);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(261, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Quantite restante";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(261, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Total";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(387, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Check sum";
            // 
            // Taxe
            // 
            this.Taxe.AutoSize = true;
            this.Taxe.Location = new System.Drawing.Point(135, 172);
            this.Taxe.Name = "Taxe";
            this.Taxe.Size = new System.Drawing.Size(31, 13);
            this.Taxe.TabIndex = 27;
            this.Taxe.Text = "Taxe";
            // 
            // Date
            // 
            this.Date.AutoSize = true;
            this.Date.Location = new System.Drawing.Point(135, 132);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(30, 13);
            this.Date.TabIndex = 26;
            this.Date.Text = "Date";
            // 
            // Prix
            // 
            this.Prix.AutoSize = true;
            this.Prix.Location = new System.Drawing.Point(19, 172);
            this.Prix.Name = "Prix";
            this.Prix.Size = new System.Drawing.Size(24, 13);
            this.Prix.TabIndex = 25;
            this.Prix.Text = "Prix";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Nom";
            // 
            // txtQuantite
            // 
            this.txtQuantite.Location = new System.Drawing.Point(264, 148);
            this.txtQuantite.Name = "txtQuantite";
            this.txtQuantite.Size = new System.Drawing.Size(100, 20);
            this.txtQuantite.TabIndex = 23;
            // 
            // txtPrix
            // 
            this.txtPrix.Location = new System.Drawing.Point(12, 188);
            this.txtPrix.Name = "txtPrix";
            this.txtPrix.Size = new System.Drawing.Size(100, 20);
            this.txtPrix.TabIndex = 22;
            // 
            // txtTaxe
            // 
            this.txtTaxe.Location = new System.Drawing.Point(138, 188);
            this.txtTaxe.Name = "txtTaxe";
            this.txtTaxe.Size = new System.Drawing.Size(100, 20);
            this.txtTaxe.TabIndex = 21;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(138, 148);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(100, 20);
            this.txtDate.TabIndex = 20;
            // 
            // txtSum
            // 
            this.txtSum.Location = new System.Drawing.Point(390, 148);
            this.txtSum.Name = "txtSum";
            this.txtSum.Size = new System.Drawing.Size(100, 20);
            this.txtSum.TabIndex = 19;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(264, 188);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 18;
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(12, 148);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(100, 20);
            this.txtNom.TabIndex = 17;
            // 
            // cbVitesse
            // 
            this.cbVitesse.FormattingEnabled = true;
            this.cbVitesse.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600"});
            this.cbVitesse.Location = new System.Drawing.Point(515, 73);
            this.cbVitesse.Name = "cbVitesse";
            this.cbVitesse.Size = new System.Drawing.Size(121, 21);
            this.cbVitesse.TabIndex = 1;
            this.cbVitesse.SelectedIndexChanged += new System.EventHandler(this.cbVitesse_SelectedIndexChanged);
            // 
            // btnConnecter
            // 
            this.btnConnecter.Location = new System.Drawing.Point(516, 146);
            this.btnConnecter.Name = "btnConnecter";
            this.btnConnecter.Size = new System.Drawing.Size(120, 23);
            this.btnConnecter.TabIndex = 37;
            this.btnConnecter.Text = "Connecter";
            this.btnConnecter.UseVisualStyleBackColor = true;
            this.btnConnecter.Click += new System.EventHandler(this.btnConnecter_Click);
            // 
            // Port
            // 
            this.Port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.Port_DataReceived);
            // 
            // cbNom
            // 
            this.cbNom.FormattingEnabled = true;
            this.cbNom.Location = new System.Drawing.Point(516, 28);
            this.cbNom.Name = "cbNom";
            this.cbNom.Size = new System.Drawing.Size(84, 21);
            this.cbNom.TabIndex = 39;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(606, 28);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(30, 21);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "R";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(516, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Vitesse";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(516, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Port";
            // 
            // btnDeconnecter
            // 
            this.btnDeconnecter.Enabled = false;
            this.btnDeconnecter.Location = new System.Drawing.Point(515, 186);
            this.btnDeconnecter.Name = "btnDeconnecter";
            this.btnDeconnecter.Size = new System.Drawing.Size(120, 22);
            this.btnDeconnecter.TabIndex = 31;
            this.btnDeconnecter.Text = "Deconnecter";
            this.btnDeconnecter.UseVisualStyleBackColor = true;
            this.btnDeconnecter.Click += new System.EventHandler(this.btnDeconnecter_Click);
            // 
            // frmBarresCodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 250);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cbNom);
            this.Controls.Add(this.btnConnecter);
            this.Controls.Add(this.cbVitesse);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDeconnecter);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Taxe);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.Prix);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtQuantite);
            this.Controls.Add(this.txtPrix);
            this.Controls.Add(this.txtTaxe);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtSum);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtNom);
            this.Name = "frmBarresCodes";
            this.Text = "Lecteur de barres codes";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbBitArret;
        private System.Windows.Forms.RadioButton rbDeuxBitArret;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbArret;
        private System.Windows.Forms.RadioButton rbActif;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbHuit;
        private System.Windows.Forms.RadioButton rbSept;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbAucune;
        private System.Windows.Forms.RadioButton rbImpair;
        private System.Windows.Forms.RadioButton rbPair;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Taxe;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.Label Prix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuantite;
        private System.Windows.Forms.TextBox txtPrix;
        private System.Windows.Forms.TextBox txtTaxe;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtSum;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.ComboBox cbVitesse;
        private System.Windows.Forms.Button btnConnecter;
        private System.IO.Ports.SerialPort Port;
        private System.Windows.Forms.ComboBox cbNom;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDeconnecter;

    }
}

