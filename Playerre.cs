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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ESPORT
{
    public partial class Playerre : Form
    {
        PlayerClass1 player;
        public Playerre()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            string Name = tbname.Text;
            string lastname = tblastname.Text;
            string ID = tbid.Text;
            string Major = tbmajor.Text;
            string Display = tbdisplay.Text;
            string mail = tbmail.Text;
            string Number = tbphone.Text;
            int Age = int.Parse(tbage.Text);

            player = new PlayerClass1()
            {
                Name = Name,
                lastname = lastname,
                iD = ID,
                major = Major,
                Display = Display,
                mail = mail,
                Number = Number,
                Age = Age
            };
            this.DialogResult = DialogResult.OK;

        }
        public PlayerClass1 getPlayer() 
        {
            return player;
        }
    }
}
