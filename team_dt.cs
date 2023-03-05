using CISESPORT2.NewFolder;
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

namespace CISESPORT2
{
    public partial class team_dt : Form
    {
        List<TeamClass> Listteam = new List<TeamClass>();
        public team_dt()
        {
            InitializeComponent();
        }

        private void newteamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Team ta= new Team();
            ta.ShowDialog();
            if(ta.DialogResult== DialogResult.OK) 
            {
                TeamClass team = ta.getTeam<TeamClass>();
                team.TeamName = ta.getTeam<TeamClass>().TeamName;
                team.Member = ta.getTeam<TeamClass>().Member;
                Listteam.Add(team);
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add(team.TeamName, team.Member[0].Name, team.Member[1].Name, team.Member[2].Name, team.Member[3].Name, team.Member[4].Name);
            }
        }
        private void RefreshDataGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (TeamClass team in Listteam)
            {
                dataGridView1.Rows.Add(team.TeamName, team.Member[0].Name, team.Member[1].Name, team.Member[2].Name, team.Member[3].Name, team.Member[4].Name);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = "Teams";
            saveFile.Filter = "Json|*.json";
            saveFile.ShowDialog();
            if (saveFile.FileName != "")
            {
                string json = JsonConvert.SerializeObject(Listteam, Formatting.Indented);
                File.WriteAllText(saveFile.FileName, json);

            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.FileName = "Teams";
            openfile.Filter = "Json|*.json";
            openfile.ShowDialog();
            if (openfile.FileName != "")
            {
                Listteam = JsonConvert.DeserializeObject<List<TeamClass>>(File.ReadAllText(openfile.FileName));
                RefreshDataGrid();
            }

        }

    }
        

}

        
