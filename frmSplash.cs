//******************************************
//******************************************
//Programmer: Eric Tekell
//Course: INEW 2332.7Z1
//Program Description: This program handles Tek's Kennels and Outfitting business operations.
//Form Purpose: This form is my splash screen
//******************************************
//******************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FA21_Final_Project
{
    public partial class frmSplash : Form
    {
        public int timeLeft { get; set; }
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            timeLeft = 15;
            tmrTime.Start();
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            try
            {
                if (timeLeft > 0)
                {
                    timeLeft -= 1;
                }
                else
                {
                    tmrTime.Stop();
                    this.Hide();
                    new frmLogIn().ShowDialog();
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("I'm sorry an error has occurred in the program. \n\n" +
                    "Please inform the Program Developer that the following error occurred: \n\n\n" + ex.Message,
                    "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbxSplash_Click(object sender, EventArgs e)
        {

        }
    }
}
