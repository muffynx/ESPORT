using CISESPORT.playerrr;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CISESPORT
{
    public partial class Players : Form
    {
        public static Players instant;
        public List<PlayerClass1> listplayer = new List<PlayerClass1>();
        public Players()
        {
            InitializeComponent();
            instant = this;
        }

        public void newplayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Playerre pyr = new Playerre();
            pyr.ShowDialog(); 
            if(pyr.DialogResult == DialogResult.OK) 
            {
                listplayer.Add(pyr.getPlayer());
                RefreshDataGrid();
            }
        }
        private void RefreshDataGrid() 
        {
            dataGridView1.Rows.Clear();
            foreach (PlayerClass1 player_ in listplayer)
            {
                dataGridView1.Rows.Add(player_.Name, player_.lastname, player_.iD, player_.major, player_.Display, player_.mail, player_.Number, player_.Age);
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile= new SaveFileDialog();
            saveFile.FileName = "Player";
            saveFile.Filter = "Json|*.json";
            saveFile.ShowDialog();
            if(saveFile.FileName != "") 
            {
                string json = JsonConvert.SerializeObject(listplayer, Formatting.Indented);
                File.WriteAllText(saveFile.FileName, json);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.FileName = "Players";
            openfile.Filter = "Json|*.json";
            openfile.ShowDialog();
            if (openfile.FileName != "")
            {
                listplayer = JsonConvert.DeserializeObject<List<PlayerClass>>(File.ReadAllText(openfile.FileName));
                RefreshDataGrid();
            }
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            team_dt tmm = new team_dt();
            tmm.ShowDialog();

        }

        private void Players_Load(object sender, EventArgs e)
        {
            //
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
