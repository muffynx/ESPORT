using CISESPORT2.NewFolder;
using CISESPORT2.NewFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CISESPORT2
{
    public partial class Team : Form
    {
        TeamClass team;
        List<PlayerClass1>listplayer = new List<PlayerClass1>();
        public Team()
        {
            InitializeComponent();
            for(int i = 0; i < 5; i++)
            {
                PlayerClass1 player = new PlayerClass1();
                player.Name = " ";
                player.lastname= " ";
                player.iD = " ";
                player.major = " ";
                player.Display = " ";
                player.mail = " ";  
                player.Number= " ";
                listplayer.Add(player);
            }
        }

        private void submit_Click(object sender, EventArgs e)
        {
            string TeamName = tbname.Text;
            team = new TeamClass();
            team.TeamName = TeamName;
            team.Member = this.listplayer;
            this.team = team;
            this.DialogResult= DialogResult.OK;     
        }

        private void flie_5_AutoSizeChanged(object sender, EventArgs e)
        {
            Button Bnn = (Button)sender;
            if (Bnn.Name == "flie_1")
            {
                FindPlayer(0,m1);
            }
            else if (Bnn.Name == "flie_2")
            {
                FindPlayer(1, m2);
            }
            else if (Bnn.Name == "flie_3")
            {
                FindPlayer(2, m4);
            }
            else if (Bnn.Name == "flie_4")
            {
                FindPlayer(3, m5);
            }
            else if (Bnn.Name == "flie_5")
            {
                FindPlayer(4, m5);
            }
        }
        public T getTeam<T>()
        {
            return (T)Convert.ChangeType(this.team, typeof(T));
        }
        private void FindPlayer(int index, TextBox textbox) 
        {
            Findlayer ff = new Findlayer();
            ff.ShowDialog();
            if(ff.DialogResult == DialogResult.OK)
            {
                listplayer[index] = ff.getPlayer();
                textbox.Text = ff.getPlayer().Name;

            }
        }

    }
}
