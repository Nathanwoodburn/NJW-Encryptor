using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NJW_Encryptor
{
    public partial class frmchangekey : Form
    {
        public string changedkey { get; set; }
        //public string ReturnValue2 { get; set; }
        string key;
        public frmchangekey(string ckey)
        {
            InitializeComponent();
            key = ckey;
        }

        private void frmchangekey_Load(object sender, EventArgs e)
        {
            textBox1.Text = key;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changedkey = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.UseSystemPasswordChar == true)
                textBox1.UseSystemPasswordChar = false;
            else
                textBox1.UseSystemPasswordChar = true;

          
         
        }
    }
}
