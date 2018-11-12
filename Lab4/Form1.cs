using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        List<String> dictionary;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Visible = false;
            textBox1.Visible = false;
            listBox1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ChooseFile = new OpenFileDialog();
            ChooseFile.Filter = "Text Files|*.txt";
            ChooseFile.Title = "Select text File";
            dictionary = new List<string>();
            String text;
            if (ChooseFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                text = File.ReadAllText(ChooseFile.FileName);
                foreach(String word in text.Split())
                    {
                        if (dictionary.Contains(word) == false) { dictionary.Add(word); };
                    };
                watch.Stop();
                listBox1.Items.Clear();
                label1.Text = watch.Elapsed.ToString();
                button2.Visible = true;
                textBox1.Visible = true;
                // StreamReader sr = new
                //System.IO.StreamReader(ChooseFile.FileName);
               // MessageBox.Show(sr.ReadToEnd());
                //sr.Close();
                
                
            }
            

        }
        private void label1_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            if (dictionary.Contains(textBox1.Text))
            {
                listBox1.BeginUpdate();
                if(listBox1.Items.Contains(textBox1.Text)==false){listBox1.Items.Add(textBox1.Text);}
                listBox1.EndUpdate();
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Слово не обнаружено");
                textBox1.Text = "";
            }
            watch.Stop();
            label2.Text = watch.Elapsed.ToString();
            listBox1.Visible = true;
        }



    }
}
