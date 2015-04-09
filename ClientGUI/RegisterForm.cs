using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client;

namespace ClientGUI
{
    public partial class RegisterForm : Form, ClientInterface
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterButtonClick(object sender, EventArgs e)
        {
            LoginForm.App.Register(nome.Text, username.Text, password.Text, Int32.Parse(diginotes.Text));
            this.SetVisibleCore(false);
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void UpdateQuotation(float quot)
        {
            Console.WriteLine("New Diginote Quotation: {0}", quot);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
