using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1
{
    public partial class Form1 : Form
    {

        string userName = null;
        string passWord = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            prosesLogin();
        }

        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                prosesLogin();
            }
        }

        void prosesLogin()
        {
            this.userName = username.Text;
            this.passWord = password.Text;
            if (this.userName != "" && this.passWord == "pbo123")
            {
                this.Hide();
                MenuUtama mu = new MenuUtama();
                mu.Show();
            }
            else
            {
                MessageBox.Show("Login Gagal");
                password.Text = null;
            }
        }
    }
}
