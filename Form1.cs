using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FFCO2MeOS
{
    public partial class Form1 : Form
    {
        string[] donneesEntree = null;
        List<string> donneesSortie = new List<string>();

        #region Pays
        Dictionary<string,string> Pays = new Dictionary<string,string>(){
        {"Afghanistan","AFG"},
        {"Albania","ALB"},
        {"Algeria","ALG"},
        {"Andorra","AND"},
        {"Angola","ANG"},
        {"Antigua and Barbuda","ANT"},
        {"Argentina","ARG"},
        {"Armenia","ARM"},
        {"Aruba","ARU"},
        {"American Samoa","ASA"},
        {"Australia","AUS"},
        {"Austria","AUT"},
        {"Azerbaijan","AZE"},
        {"Bahamas","BAH"},
        {"Bangladesh","BAN"},
        {"Barbados","BAR"},
        {"Burundi","BDI"},
        {"Belgium","BEL"},
        {"Benin","BEN"},
        {"Bermuda","BER"},
        {"Bhutan","BHU"},
        {"Bosnia and Herzegovina","BIH"},
        {"Belize","BIZ"},
        {"Belarus","BLR"},
        {"Bolivia","BOL"},
        {"Botswana","BOT"},
        {"Brazil","BRA"},
        {"Bahrain","BRN"},
        {"Brunei","BRU"},
        {"Bulgaria","BUL"},
        {"Burkina Faso","BUR"},
        {"Central African Republic","CAF"},
        {"Cambodia","CAM"},
        {"Canada","CAN"},
        {"Cayman Islands","CAY"},
        {"Congo","CGO"},
        {"Chad","CHA"},
        {"Chile","CHI"},
        {"China","CHN"},
        {"Ivory Coast","CIV"},
        {"Cameroon","CMR"},
        {"DR Congo","COD"},
        {"Cook Islands","COK"},
        {"Colombia","COL"},
        {"Comoros","COM"},
        {"Cape Verde","CPV"},
        {"Costa Rica","CRC"},
        {"Croatia","CRO"},
        {"Cuba","CUB"},
        {"Cyprus","CYP"},
        {"Czech Republic","CZE"},
        {"Denmark","DEN"},
        {"Djibouti","DJI"},
        {"Dominica","DMA"},
        {"Dominican Republic","DOM"},
        {"Ecuador","ECU"},
        {"Egypt","EGY"},
        {"Eritrea","ERI"},
        {"El Salvador","ESA"},
        {"Spain","ESP"},
        {"Estonia","EST"},
        {"Ethiopia","ETH"},
        {"Fiji","FIJ"},
        {"Finland","FIN"},
        {"France","FRA"},
        {"Federated States of Micronesia","FSM"},
        {"Gabon","GAB"},
        {"The Gambia","GAM"},
        {"Great Britain","GBR"},
        {"Guinea-Bissau","GBS"},
        {"Georgia","GEO"},
        {"Equatorial Guinea","GEQ"},
        {"Germany","GER"},
        {"Ghana","GHA"},
        {"Greece","GRE"},
        {"Grenada","GRN"},
        {"Guatemala","GUA"},
        {"Guinea","GUI"},
        {"Guam","GUM"},
        {"Guyana","GUY"},
        {"Haiti","HAI"},
        {"Hong Kong","HKG"},
        {"Honduras","HON"},
        {"Hungary","HUN"},
        {"Indonesia","INA"},
        {"India","IND"},
        {"Iran","IRI"},
        {"Ireland","IRL"},
        {"Iraq","IRQ"},
        {"Iceland","ISL"},
        {"Israel","ISR"},
        {"Virgin Islands","ISV"},
        {"Italy","ITA"},
        {"British Virgin Islands","IVB"},
        {"Jamaica","JAM"},
        {"Jordan","JOR"},
        {"Japan","JPN"},
        {"Kazakhstan","KAZ"},
        {"Kenya","KEN"},
        {"Kyrgyzstan","KGZ"},
        {"Kiribati","KIR"},
        {"South Korea","KOR"},
        {"Saudi Arabia","KSA"},
        {"Kuwait","KUW"},
        {"Laos","LAO"},
        {"Latvia","LAT"},
        {"Libya","LBA"},
        {"Liberia","LBR"},
        {"Saint Lucia","LCA"},
        {"Lesotho","LES"},
        {"Lebanon","LIB"},
        {"Liechtenstein","LIE"},
        {"Lithuania","LTU"},
        {"Luxembourg","LUX"},
        {"Madagascar","MAD"},
        {"Morocco","MAR"},
        {"Malaysia","MAS"},
        {"Malawi","MAW"},
        {"Moldova","MDA"},
        {"Maldives","MDV"},
        {"Mexico","MEX"},
        {"Mongolia","MGL"},
        {"Marshall Islands","MHL"},
        {"Macedonia","MKD"},
        {"Mali","MLI"},
        {"Malta","MLT"},
        {"Montenegro","MNE"},
        {"Monaco","MON"},
        {"Mozambique","MOZ"},
        {"Mauritius","MRI"},
        {"Mauritania","MTN"},
        {"Myanmar","MYA"},
        {"Namibia","NAM"},
        {"Nicaragua","NCA"},
        {"Netherlands","NED"},
        {"Nepal","NEP"},
        {"Nigeria","NGR"},
        {"Niger","NIG"},
        {"Norway","NOR"},
        {"Nauru","NRU"},
        {"New Zealand","NZL"},
        {"Oman","OMA"},
        {"Pakistan","PAK"},
        {"Panama","PAN"},
        {"Paraguay","PAR"},
        {"Peru","PER"},
        {"Philippines","PHI"},
        {"Palestine","PLE"},
        {"Palau","PLW"},
        {"Papua New Guinea","PNG"},
        {"Poland","POL"},
        {"Portugal","POR"},
        {"North Korea","PRK"},
        {"Puerto Rico","PUR"},
        {"Qatar","QAT"},
        {"Romania","ROU"},
        {"South Africa","RSA"},
        {"Russia","RUS"},
        {"Rwanda","RWA"},
        {"Samoa","SAM"},
        {"Senegal","SEN"},
        {"Seychelles","SEY"},
        {"Singapore","SIN"},
        {"Saint Kitts and Nevis","SKN"},
        {"Sierra Leone","SLE"},
        {"Slovenia","SLO"},
        {"San Marino","SMR"},
        {"Solomon Islands","SOL"},
        {"Somalia","SOM"},
        {"Serbia","SRB"},
        {"Sri Lanka","SRI"},
        {"São Tomé and Príncipe","STP"},
        {"Sudan","SUD"},
        {"Switzerland","SUI"},
        {"Suriname","SUR"},
        {"Slovakia","SVK"},
        {"Sweden","SWE"},
        {"Swaziland","SWZ"},
        {"Syria","SYR"},
        {"Tanzania","TAN"},
        {"Tonga","TGA"},
        {"Thailand","THA"},
        {"Tajikistan","TJK"},
        {"Turkmenistan","TKM"},
        {"Timor-Leste","TLS"},
        {"Togo","TOG"},
        {"Chinese Taipei[5]","TPE"},
        {"Trinidad and Tobago","TTO"},
        {"Tunisia","TUN"},
        {"Turkey","TUR"},
        {"Tuvalu","TUV"},
        {"United Arab Emirates","UAE"},
        {"Uganda","UGA"},
        {"Ukraine","UKR"},
        {"Uruguay","URU"},
        {"United States","USA"},
        {"Uzbekistan","UZB"},
        {"Vanuatu","VAN"},
        {"Venezuela","VEN"},
        {"Vietnam","VIE"},
        {"Saint Vincent and the Grenadines","VIN"},
        {"Yemen","YEM"},
        {"Zambia","ZAM"},
        {"Zimbabwe","ZIM"}
        };
        #endregion


        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCharger_Click(object sender, EventArgs e)
        {
            donneesSortie = new List<string>();
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                donneesEntree = File.ReadAllLines(openFileDialog1.FileName, Encoding.Default);

                label1.Text = openFileDialog1.SafeFileName;

                buttonConvertir.Visible = true;
                buttonConvertir.Enabled = true;
            }
        }

        private void Ecrire(int nbrIndente, string ligne)
        {
            string sortie = "";
            for (int i = 0; i < nbrIndente; i++)
            {
                sortie += "\t";
            }
            sortie += ligne;
            donneesSortie.Add(sortie);
            
        }

        private void buttonConvertir_Click(object sender, EventArgs e)
        {
            string nomFicOut = openFileDialog1.FileName;
            string sortie = "";
            nomFicOut = Path.GetFileNameWithoutExtension(nomFicOut);
            saveFileDialog1.InitialDirectory = Path.GetDirectoryName(openFileDialog1.FileName);
            saveFileDialog1.FileName = nomFicOut;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sortie = saveFileDialog1.FileName;
                Conversion();

                File.WriteAllLines(sortie, donneesSortie, Encoding.UTF8);
            }
        }

        private void Conversion()
        {
            richTextBox1.Text = "";
            richTextBox1.Show();
            //creation de l'entete
            int nbr=0;
            progressBar1.Value = 0;
            progressBar1.Maximum = donneesEntree.Length;
            progressBar1.Show();
            string dt = DateTime.Now.ToString("yyyy-mm-ddTHH:mm:ss");
            Ecrire(0, "<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            Ecrire(0, "<CompetitorList creator=\"ffco2MeOS\" createTime=\"" + dt + "\" iofVersion=\"3.0\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://www.orienteering.org/datastandard/3.0\">");
            int lig=1;
            foreach (string ligne in donneesEntree)
            {
                string[] ligne_decoupee = ligne.Split(';');
                if (ligne_decoupee.Length > 12 && lig!=1)
                {
                    Ecrire(1, "<Competitor>");
                    string licence = ligne_decoupee[0].Trim();
                    string puce = ligne_decoupee[1].Trim();
                    string nom, prenom;
                    if (checkBox1.Checked)
                    {
                        nom = ligne_decoupee[3].Trim();
                        prenom = ligne_decoupee[2].Trim();
                    }
                    else
                    {
                        nom = ligne_decoupee[2].Trim();
                        prenom = ligne_decoupee[3].Trim();
                    }
                    string annee_naissance = ligne_decoupee[4].Trim();
                    string sexe = "?";
                    if (ligne_decoupee[4].Trim() == "F")
                        sexe = "F";
                    else if (ligne_decoupee[4].Trim() == "H")
                        sexe = "M";
                    string num_club = ligne_decoupee[7].Trim();
                    string nom_club = ligne_decoupee[8].Trim();
                    string nationalite = ligne_decoupee[9].Trim();
                    string nom_court_categ = ligne_decoupee[11].Trim();
                    string nom_long_categ = ligne_decoupee[12].Trim();
                    //<person>
                    if (sexe == "?")
                        Ecrire(2, "<Person>");
                    else
                        Ecrire(2, "<Person sex=\"" + sexe + "\">");
                    Ecrire(3, "<Id>" + licence + "</Id>");
                    Ecrire(3, "<Name>");
                    Ecrire(4, "<Family>" + nom + "</Family>");
                    Ecrire(4, "<Given>" + prenom + "</Given>");
                    Ecrire(3, "</Name>");
                    Ecrire(3, "<BirthDate>" + annee_naissance + "-01-01</BirthDate>");
                    Ecrire(3, "<Nationality code=\"" + GetCountryCode(nationalite) + "\">" + nationalite + "</Nationality>");
                    Ecrire(2, "</Person>");
                    //<organisation>
                    Ecrire(2, "<Organisation>");
                    Ecrire(3, "<Id>" + num_club + "</Id>");
                    Ecrire(3, "<Name>" + nom_club + "</Name>");
                    Ecrire(3, "<Nationality code=\"" + GetCountryCode(nationalite) + "\">" + nationalite + "</Nationality>");
                    Ecrire(2, "</Organisation>");

                    //<ControlCard>
                    Ecrire(2, "<ControlCard punchingSystem=\"SI\">" + puce + "</ControlCard>");

                    //<class>
                    Ecrire(2, "<Class>");
                    Ecrire(3, "<Id>" + nom_court_categ + "</Id>");
                    Ecrire(3, "<Name>" + nom_long_categ + "</Name>");
                    Ecrire(2, "</Class>");

                    Ecrire(1, "</Competitor>");
                    nbr++;
                }
                else if(lig!=1)
                {
                    richTextBox1.Text += "Erreur ligne " + lig.ToString() + ". Nombre de paramètres insuffisant."+Environment.NewLine;
                }
                progressBar1.Value = lig;
                progressBar1.Show();
                lig++;
            }
            Ecrire(0, "</CompetitorList>");
            richTextBox1.Text += "nb lignes converties = " + nbr.ToString() + " sur " + (lig-1).ToString() + "." + Environment.NewLine;
            richTextBox1.Text += "N.B. : Un écart de 1 est normal (ligne de titre)" + Environment.NewLine;
            richTextBox1.Show();
        }

        private string GetCountryCode(string pays)
        {
            return Pays[pays];
        }
        
    }

}
