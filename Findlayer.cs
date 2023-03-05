using ESPORT.playerrr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESPORT
{
    public partial class Findlayer : Form
    {
        PlayerClass1 Player;
        public Findlayer()
        {
            InitializeComponent();
            foreach(PlayerClass1 player_ in Players.instant.listplayer) 
            {
                dataGridView1.Rows.Add(player_.Name, player_.lastname, player_.iD, player_.major, player_.Display, player_.mail, player_.Number, player_.Age);
            }
        }
        public PlayerClass1 getPlayer()
        {
            return Player;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            PlayerClass1 pp = Players.instant.listplayer[dataGridView1.CurrentRow.Index];
            Player = pp;
            this.DialogResult= DialogResult.OK;
        }
    }
}
