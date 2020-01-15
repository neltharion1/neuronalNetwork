using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuronalNetwork
{
    public partial class Form1 : Form
    {
        int inodes = 0, hnodes = 0, onodes = 0;
        nn3S nn3SO;
        Einstellungen einstellungen;

       
  

        public Form1()
        {
           
            InitializeComponent();
            Properties.Settings.Default.InputNodes = Convert.ToInt32(GetSetting("InputNodes"));
            Properties.Settings.Default.HiddenNodes = Convert.ToInt32(GetSetting("HiddenNodes"));
            Properties.Settings.Default.OutputNodes = Convert.ToInt32(GetSetting("OutputNodes"));
            Properties.Settings.Default.LearnRate = GetSetting("LearnRate");
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
            einstellungen = new Einstellungen();
            einstellungen.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inodes = Properties.Settings.Default.InputNodes;
            hnodes = Properties.Settings.Default.HiddenNodes;
            onodes = Properties.Settings.Default.OutputNodes;
            
            nn3SO = new nn3S(inodes, hnodes, onodes);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int i, j, k;
            double[] inputs = new double[inodes];
            string input;
            for (i = 0; i < inodes; i++)
            {
                input = dataGridView1.Rows[i].Cells[0].Value.ToString();
                inputs[i] = Convert.ToDouble(input);
                Console.WriteLine("input : " + inputs[i]);
            }
            
            nn3SO.queryNN(inputs);
            for (i = 0; i < inputs.Length; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[1].Value = nn3SO.Hidden_inputs[i].ToString();
                dataGridView1.Rows[i].Cells[2].Value = nn3SO.Hidden_outputs[i].ToString();
                dataGridView1.Rows[i].Cells[3].Value = nn3SO.Final_inputs[i].ToString();
                dataGridView1.Rows[i].Cells[4].Value = nn3SO.Final_outputs[i].ToString();
            }
        }
        private static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
