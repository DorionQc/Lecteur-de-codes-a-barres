/***************************
 * Samuel Goulet, Samuel Talbot, Dominic Bobay
 * Octobre 2016
 * Lab du lecteur de codes à barres
 *****************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace Lab_Barres_Codes
{
    public partial class frmBarresCodes : Form
    {
        // Trame reçue
        string m_Trame;

        // Tableau contenant les prix des items, en string
        // m_Prix[x, 0] = Nom de l'item
        // m_Prix[x, 1] = Prix de l'item
        string[,] m_Prix;

        // Tableau contenant l'inventaire
        // m_Inventaire[x, 0] = Nom de l'item
        // m_Inventaire[x, 1] = Quantité en inventaire
        string[,] m_Inventaire;

        // Si la configuration s'est déjà effectuée
        bool m_Config;

        // Nombre de NAKs envoyés
        // À 10, la communication est coupée
        int m_NAKCount;

        public frmBarresCodes()
        {
            // Initialisation
            InitializeComponent();
            cbVitesse.SelectedIndex = 3;
            RafraichirListeNom();
            m_Prix = FichierTo2DArray("Prix.txt");
            m_Inventaire = FichierTo2DArray("Inventaire.txt");
            m_Config = false;
            m_NAKCount = 0;
        }

        /// <summary>
        /// Méthode principale de programme
        /// </summary>
        private void Receive()
        {
            // S'exécute sur un autre thread, puisque c'est la DataReceive qui l'appelle.
            // C'est peu important à savoir, sauf quand vient le temps d'intéragir avec la fenêtre

            if (m_NAKCount == 10)
            {
                MessageBox.Show("Boucle infinie? On ne fait que s'envoyer des NAKs D:");
                m_NAKCount = 0;
                Port.Write(((char)24).ToString());
                string s = Port.ReadExisting();
                return;
            }
            m_NAKCount++;
            DateTime Date;
            StringBuilder sb = new StringBuilder();
            string Message = "";
            int Checksum;
            string Temp;

            int IndexItem;
            double Prix, Taxe, Total;
            int Inventaire;

            #region Info Regex
            /*
                Un regex est, en gros, un string qui représente un pattern, que l'on pourra utiliser pour "matcher" d'autres strings plus tard
                Par exemple, Regex rgBanane = new Regex(@"^Banane$"); est un regex très simple qui "match" les occurences du mot "Banane", seul sur une ligne
                Tout comme dans les opérations mathématiques, les parenthèses (()) permettent de regrouper des données et de modifier les priorités d'opérations
                [abc] = a, b ou c
                (a|b|c) = a, b, ou c 
                [a-d] = N'importe quoi entre a et d
                [a-zA-Z0-9] = N'importe quoi entre a et z, A et Z ou 0 et 9
                . = N'importe quoi, autre qu'une nouvelle ligne
                ^ = Début de string
                $ = Fin de string
                [a-z]{9} = 9 occurences de caractères entre a et z
                [a-z]{,9} = Au maximum 9 occurences de caractères entre a et z
                [a-z]{4,8} = Entre 4 et 8 occurences """
                .+ = Au moins une occurence d'un caractère quelconque
                .* = 0 ou plus de n'importe quoi
                .? = Soit 0 ou 1 de n'importe quoi
                    (Vous pouvez remplacer le '.' pour n'importe quoi... [a-z]+ = Au moins une occurence de caractères entre a et z)
                \. \? \* \+ ... = N'interprète pas le caractère
                [a-z]+? = Au moins un caractère entre a et z, mais le moins possible
                (?<=(expression)) = Recherche l'expression avant le match
                    (?<=(a)).$ match 'c' dans "ac", car il y a un 'a' avant le 'c'
                (?=(expression)) = Recherche l'expression après le match
            */
            #endregion

            // Pattern pour le regex de la trame complète
            // Commence par STX(invisible), puis deux char quelconques(.), 12 chiffres de 0 à 9 (date et heure), peu importe (nom),
            // 2 char quelconques, une virgule, peu importe (la data), une virgule, 2 chiffres hexadécimaux et un ETX
            // Il y a deux caractères invisibles. Un STX au début (après le ^) et un ETX(invisible) à la fin
            // Les virgules sont juste des virgules
            string TrameCompletePattern = @"^..([0-9]{12}).+?..,.+?,(([0-9A-Fa-f]){2})"; // <3
            
            // Pattern de la data
            // Commence par une virgule (excluse), contient quelque chose, puis finit par une virgule (excluse)
            string MessagePattern = @"(?<=,).+?(?=,)";

            // Pattern de la date
            // Commence par STX et deux char quelconques exclus, puis 12 chiffres.
            // Il y a un STX invisible après le ^
            string DatePattern = @"(?<=^..)[0-9]{12}";
            Regex rgTrameComplete = new Regex(TrameCompletePattern);
            Regex rgDate = new Regex(DatePattern);
            Regex rgMessage = new Regex(MessagePattern);

            // Lit la trame
            m_Trame = rgTrameComplete.Match(LireTrame()).ToString();

            // Vérifie sa validité
            if (m_Trame.Length < 2)
            {
                if (Port.IsOpen)
                    Port.Write(((char)24).ToString()); // Cancel!
                return; // Rien reçu
            }

            if (!rgTrameComplete.IsMatch(m_Trame))
            {
                if (Port.IsOpen)
                    Port.Write(((char)0x15).ToString()); // NAK!
                return;
            }

            // Retrouve les éléments importants de la trame
            // Date
            Temp = rgDate.Match(m_Trame).ToString();
            Date = StringToDateTime(Temp);

            // Data
            Temp = rgMessage.Match(m_Trame).ToString();
            Message = Temp.Trim();

            // Checksum
            Temp = m_Trame.Substring(m_Trame.Length - 3, 2);
            Checksum = Convert.ToInt32(Temp, 16);

            // Vérification du checksum
            if (Checksum != CalculerChecksum(m_Trame.Substring(0, m_Trame.Length - 3)))
            {
                if (Port.IsOpen)
                    Port.Write(((char)0x15).ToString());
                MessageBox.Show("NAK");
                Ecrit("Erreur.txt", m_Trame);

                return;
            }
            else
                Ecrit("Reception.txt", m_Trame);

            // Vérification de la date
            if (!CheckDate(Date))
            {
                MessageBox.Show("Congé férié!");
                return;
            }

            // .. et de l'heure
            if (!CheckHeure(Date))
            {
                MessageBox.Show("Merci pour le bénévolat ;)");
                return;
            }

            // Recherche du prix et de l'inventaire
            // Les variables membres m_Prix et m_Inventaires sont initialisées lors de l'ouverture du programme
            // Elle contiennent le prix et le nombre de chaque item en stock dans un tableau 2d
            // m_Prix[x, 0] contient le nom de l'item x, m_Prix[x, 1] contient le prix de l'item x
            // Même principe pour m_Inventaire
            // (Voir le constructeur et la méthode FichierTo2DArray)

            IndexItem = 0;
            while (IndexItem < m_Prix.Length / 2 && m_Prix[IndexItem, 0] != Message)
                IndexItem++;

            if (IndexItem == m_Prix.Length / 2)
            {
                MessageBox.Show("Item invalide");
                return;
            }

            if (!double.TryParse(m_Prix[IndexItem, 1], out Prix))
            {
                if (!double.TryParse(m_Prix[IndexItem, 1].Replace('.', ','), out Prix)) // Dépend du langage de Windows :(
                {
                    MessageBox.Show("Il semble y avoir un problème avec les prix dans la base de donnée...\nVeuillez contacter un superviseur immédiatement.");
                    return;
                }
            }
            if (!int.TryParse(m_Inventaire[IndexItem, 1], out Inventaire))
            {
                MessageBox.Show("Il semble y avoir un problème avec l'inventaire dans la base de donnée...\nVeuillez contacter un superviseur immédiatement.");
                return;
            }

            // Décrémentation (et vérification) de l'inventaire

            if (Inventaire > 0)
                Inventaire--;
            else
            {
                MessageBox.Show("Nous n'avons plus de cet item :(");
                return;
            }

            m_Inventaire[IndexItem, 1] = Inventaire.ToString();
            Taxe = Prix * 0.15; // Approximativement, un calcul plus précis s'impose
            Total = Prix + Taxe;

            // Écriture de l'inventaire dans le fichier (Oui, ce n'est pas très optimisé, mais bon..)

            for (int i = 0; i < m_Inventaire.Length / 2; i++)
            {
                sb.Append(m_Inventaire[i, 0]);
                sb.Append(":");
                sb.Append(m_Inventaire[i, 1]);
                sb.Append("\r\n");
            }

            Ecrit("Inventaire.txt", sb.ToString().TrimEnd('\r', '\n', ' '), FileMode.Truncate, FileAccess.Write);

            // Écriture des boites de texte

            Invoke(new Action(() =>
            {
                txtNom.Text = Message;
                txtPrix.Text = Prix.ToString();
                txtTaxe.Text = Taxe.ToString();
                txtTotal.Text = Total.ToString();
                txtSum.Text = Checksum.ToString("X");
                txtQuantite.Text = Inventaire.ToString();
                txtDate.Text = Date.ToString("hh:mm:ss, dd, MM, yyyy");
            }));

            m_NAKCount = 0;

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RafraichirListeNom();
            /*if (Port.IsOpen)
            {
                Port.Write((char)0x02 + "Hey!" + (char)0x03);
            }*/
        }

        /// <summary>
        /// Lance la connection du port, incluant la configuration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnecter_Click(object sender, EventArgs e)
        {
            if (Port.IsOpen)
            {
                return;
            }

            if (!m_Config)
            {
                if (!Configuration())
                {
                    MessageBox.Show("Impossible d'ouvrir le port. Vérifiez vos connections et vos paramètres");
                    return;
                }
                m_Config = true;
            }

            try
            {
                Port.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Port.BreakState = false;

            btnConnecter.Enabled = false;
            btnDeconnecter.Enabled = true;

            cbNom.Enabled = false;
            btnRefresh.Enabled = false;

            if (Port.BytesToRead > 0)
            {
                string s = Port.ReadExisting(); // Vide le buffer
            }
        }

        /// <summary>
        /// Ferme le port :D
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeconnecter_Click(object sender, EventArgs e)
        {
            Port.BreakState = true;
            Port.Close();
            //bool[] wtf = { rbPair.Checked, rbImpair.Checked, rbAucune.Checked };
            btnConnecter.Enabled = true;
            btnDeconnecter.Enabled = false;
            /*rbPair.Checked = wtf[0];
            rbImpair.Checked = wtf[1];
            rbAucune.Checked = wtf[2];*/

            // Si vous êtes capables de comprendre WHY THE FUCK THIS SHIT HAPPENS, dites-le moi <3
        }

        /// <summary>
        /// Recherche les ports utilisés par l'ordinateur et met à jour le ComboBox
        /// </summary>
        private void RafraichirListeNom()
        {
            string[] tNom = SerialPort.GetPortNames();
            cbNom.Items.Clear();
            cbNom.Items.AddRange(tNom);
            if (cbNom.Items.Count > 0)
            {
                cbNom.Enabled = true;
                cbNom.SelectedIndex = 0;
            }
            else
            {
                cbNom.Enabled = false;
            }
        }


        /// <summary>
        /// Lancé lorsque le port reçoit des données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Receive();
        }

        /// <summary>
        /// Lis la trame reçue et la retourne en string.
        /// </summary>
        /// <returns>La trame reçue. Retourne un NAK si le port est fermé ou la trame est vide</returns>
        private string LireTrame()
        {
            if (Port.IsOpen && Port.BytesToRead > 0)
            {
                System.Threading.Thread.Sleep(250);
                string s = Port.ReadTo(((char)0x03).ToString());
                s += (char)0x03;
                return s;
            }
            return ((char)0x15).ToString();
        }


        /// <summary>
        /// Vérifie que l'heure est valide
        /// </summary>
        /// <param name="Date">DateTime à vérifier</param>
        /// <returns>True si l'heure est valide</returns>
        private bool CheckHeure(DateTime Date)
        {
            return (Date.Hour > 7 && Date.Hour < 18);
        }

        /// <summary>
        /// Vérifie que la date est valide
        /// </summary>
        /// <param name="Date">DateTime à vérifier</param>
        /// <returns>True si la date n'est pas fériée</returns>
        private bool CheckDate(DateTime Date)
        {
            DateTime[] tConge = new DateTime[3]
            {
                new DateTime(1970, 1, 1, 0, 0, 0),
                new DateTime(1970, 12, 25, 0, 0 ,0),
                new DateTime(1970, 5, 14, 0, 0, 0)
            };
            int i = 0;
            while (i < tConge.Length && !(tConge[i].Month == Date.Month && tConge[i].Day == Date.Day))
                i++;
            return i == tConge.Length;
        }

        /// <summary>
        /// Calcule le checksum de la trame
        /// </summary>
        /// <param name="Trame">Trame à calculer, sans le checksum et le ETX</param>
        /// <returns>Un entier représentant le checksum (entre 0 et FF)</returns>
        private int CalculerChecksum(string Trame)
        {
            int Total = 0;
            foreach (char c in Trame)
                Total += c;

            return Total & 0x000000ff;
        }

        /// <summary>
        /// Convertit le string de la trame en DateTime
        /// </summary>
        /// <param name="s">String contenant les 12 chiffres de la date</param>
        /// <returns>Un DateTime représentant la date</returns>
        private DateTime StringToDateTime(string s)
        {
            if (s.Length != 12)
                return new DateTime(0, 0, 0, 0, 0, 0);

            int[] Val = new int[6];
            int i = 0;
            while (i < 6 && int.TryParse( ((s.Substring(2 * i, 2)).ToString()) , out Val[i]))
                i++;

            Val[2] += 2000;
            // An, Mois, Jour, Heure, Minute, Seconde
            return new DateTime(Val[2], Val[0], Val[1], Val[3], Val[4], Val[5]);

        }


        // Appelé lorsqu'un bouton de parité est pesé
        private void PariteChange(object sender, EventArgs e)
        {
            if (rbPair.Checked)
                Port.Parity = Parity.Even;
            else if (rbImpair.Checked)
                Port.Parity = Parity.Odd;
            else
                Port.Parity = Parity.None;
        }

        // Appelé lorsqu'un bouton de bit d'arrêt est changé
        private void BitArretChange(object sender, EventArgs e)
        {
            if (rbBitArret.Checked)
                Port.StopBits = StopBits.One;
            else
                Port.StopBits = StopBits.Two;
        }

        // Appelé lorsqu'un bouton de nombre d'octet est changé
        private void NbOctetChange(object sender, EventArgs e)
        {
            if (rbHuit.Checked)
                Port.DataBits = 8;
            else
                Port.DataBits = 7;
        }

        // Appelé lorsque le ComboBox de Vitesse est changé
        private void cbVitesse_SelectedIndexChanged(object sender, EventArgs e)
        {
            Port.BaudRate = Convert.ToInt32(cbVitesse.Items[cbVitesse.SelectedIndex]);
        }

        /// <summary>
        /// Configure le port, selon les contrôles
        /// </summary>
        /// <returns>True si les configurations sont vaildes</returns>
        private bool Configuration()
        {
            if (cbNom.SelectedIndex != -1)
                Port.PortName = cbNom.Items[cbNom.SelectedIndex].ToString();
            else
                return false;

            Port.BaudRate = Convert.ToInt32(cbVitesse.Items[cbVitesse.SelectedIndex]);

            if (rbHuit.Checked)
                Port.DataBits = 8;
            else
                Port.DataBits = 7;

            if (rbPair.Checked)
                Port.Parity = Parity.Even;
            else if (rbImpair.Checked)
                Port.Parity = Parity.Odd;
            else
                Port.Parity = Parity.None;

            if (rbBitArret.Checked)
                Port.StopBits = StopBits.One;
            else
                Port.StopBits = StopBits.Two;

            return true;

        }


        /// <summary>
        /// Écrit quelque chose dans un fichier
        /// </summary>
        /// <param name="File">Chemin vers le fichier</param>
        /// <param name="s">Texte à écrire</param>
        /// <param name="mode">Mode d'ouverture du fichier</param>
        /// <param name="acces">Mode d'accès au fichier</param>
        private void Ecrit(string File, string s, FileMode mode, FileAccess acces)
        {
            FileStream fs = new FileStream(File, mode, acces);
            for (int i = 0; i < s.Length; i++)
            {
                fs.WriteByte((byte)s[i]);
            }
            fs.WriteByte((byte)'\r');
            fs.WriteByte((byte)'\n');
            fs.Close();
        }

        /// <summary>
        /// Écrit quelque chose dans un fichier, par défaut en mode "Append"
        /// </summary>
        /// <param name="File">Chemin vers le fichier</param>
        /// <param name="s">Texte à écrire</param>
        private void Ecrit(string File, string s)
        {
            Ecrit(File, s, FileMode.Append, FileAccess.Write);
        }

        /// <summary>
        /// Lis un fichier de format item:propriété, et le convertit en tableau 2D
        /// </summary>
        /// <param name="file">Chemin vers le fichier</param>
        /// <returns>Tableau 2D contenant.. Tout, sous le format Nom / Propriété</returns>
        private string[,] FichierTo2DArray(string file)
        {
            if (!File.Exists(file))
            {
                MessageBox.Show("Le fichier " + file + " n'existe pas!!! D:");
                File.Create(file).Close();
                if (file.Contains("Prix.txt"))
                {
                    string s = Properties.Resources.Prix;
                    File.AppendAllText(file, s);
                }
                else if (file.Contains("Inventaire.txt"))
                {
                    string s = Properties.Resources.Inventaire;
                    File.AppendAllText(file, s);
                }
            }
            string[] Contenu = File.ReadAllLines(file);
            string[] Temp;
            string[,] ret = new string[Contenu.Length, 2];
            bool Continue = true;
            int i = 0;
            while (i < Contenu.Length && Continue)
            {
                Temp = Contenu[i].Split(':'); // Format Nom:Propriété
                if (Temp.Length == 2)
                {
                    ret[i, 0] = Temp[0]; // Nom
                    ret[i, 1] = Temp[1]; // Propriété
                }
                else
                    Continue = false; // Le fichier ne correspond pas au format :(
                i++;
            }
            if (!Continue || Contenu.Length != 4)
            {
                File.Delete(file);
                return FichierTo2DArray(file); // Crée un nouveau fichier
            }
            return ret;
        }

        private void TransmitionChange(object sender, EventArgs e)
        {
            /*if (rbActif.Checked)
                Port.BreakState = false;
            else
                Port.BreakState = true;*/
        }
    }
}
