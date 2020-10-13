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
using Encryptor;

namespace NJW_Encryptor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string key;
        private void Form1_Load(object sender, EventArgs e)
        {
            key = "password123";
            richTextBox1.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog open1 = new OpenFileDialog();
            open1.Filter = "txt|*.txt|all files|*.*";
            
                if (richTextBox1.Modified)
            {
                DialogResult result1 = MessageBox.Show("Do you want to continue? You will lose text currently in textbox.", "Continue?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.None);
                if (result1 == DialogResult.Yes)
                {
                    if (open1.ShowDialog() == DialogResult.OK)
                    {
                        StreamReader stream1 = new StreamReader(open1.FileName);
                        richTextBox1.Text = stream1.ReadToEnd();
                        stream1.Dispose();
                    }
                }
                
            }
            else
            {
                if (open1.ShowDialog() == DialogResult.OK)
                {
                    StreamReader stream2 = new StreamReader(open1.FileName);
                    richTextBox1.Text = stream2.ReadToEnd();
                    stream2.Dispose();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
richTextBox2.Text = Encryptor.Encryptor.Encrypt(richTextBox1.Text, key);
            }
            catch (Exception)
            {
                richTextBox2.Text = "Error Please check key";
                
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox2.Text = Encryptor.Encryptor.Decrypt(richTextBox1.Text, key);
            }
            catch (Exception)
            {
                richTextBox2.Text = "Error Please check key";

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your key is:\n"+key,"View Key");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmchangekey frmchangekey1 = new frmchangekey(key);
            if (frmchangekey1.ShowDialog() == DialogResult.OK)
            {
                key = frmchangekey1.changedkey;

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog save1 = new SaveFileDialog();
            save1.Filter = "txt|*.txt|All files|*.*";
            if (save1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter stream3 = new StreamWriter(save1.FileName);
                stream3.Write(richTextBox2.Text);
                stream3.Dispose();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            richTextBox1.Focus();
        }
    }
}
