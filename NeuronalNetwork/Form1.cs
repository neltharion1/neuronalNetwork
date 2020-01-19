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
        double learningRate;
        nn3S nn3SO;
        Einstellungen einstellungen;
        ErrorForm errorForm;
        WeightMatrForm weightForm;
        double[] inputs;




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
            learningRate = Convert.ToDouble(Properties.Settings.Default.LearnRate);
            int i, j;
             j = Math.Max(inodes, hnodes);
             j = Math.Max(j, onodes);
            for (i = 0; i < j; i++)
              dataGridView1.Rows.Add();

            nn3SO = new nn3S(inodes, hnodes, onodes, learningRate);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nn3SO == null)
            {
                errorForm = new ErrorForm();
                errorForm.setError("Kein Netz gefunden");
                errorForm.Visible = true;
            }
            else
            {
                double[] targets = new double[onodes];
                string target;
                bool error = false;
                for(int i=0; i < onodes; i++)
                {
                    if (dataGridView1.Rows[i].Cells[6].Value != null)
                    {
                        target = dataGridView1.Rows[i].Cells[6].Value.ToString();
                        targets[i] = Convert.ToDouble(target);
                        Console.WriteLine("input : " + targets[i]);
                    }
                    else
                    {
                        error = true;
                    }
                }
                readInputs();
                if (error == false)
                {
                    nn3SO.train(inputs, targets);
                    displayResults();
                }
                else
                {
                    errorForm = new ErrorForm();
                    errorForm.setError("Keine Targets gefunden");
                    errorForm.Visible = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (nn3SO == null)
            {
                errorForm = new ErrorForm();
                errorForm.setError("Kein Netz gefunden");
                errorForm.Visible = true;
            }
            else
            {
                readInputs();

                nn3SO.queryNN(inputs);
                displayResults();
            }
        }

        private void readInputs()
        {
            inputs = new double[inodes];
            string input;
            bool error = false;
            for(int i=0; i < inodes; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null)
                {
                    input = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    inputs[i] = Convert.ToDouble(input);
                    Console.WriteLine("input : " + inputs[i]);
                }
                else
                {
                    error = true;
                }
            }
            if (error == true)
            {
                errorForm = new ErrorForm();
                errorForm.setError("Kein Inputs vorhanden");
                errorForm.Visible = true;
            }

        }

        private void hiddenInputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hiddenInputToolStripMenuItem.Checked)
            {
                dataGridView1.Columns["Column2_hidden"].Visible = true;
            }
            else
            {
                dataGridView1.Columns["Column2_hidden"].Visible = false;
            }
        }

        private void hiddenOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hiddenOutputToolStripMenuItem.Checked)
            {
                dataGridView1.Columns["Column3_output"].Visible = true;
            }
            else
            {
                dataGridView1.Columns["Column3_output"].Visible = false;
            }
        }

        private void errorHiddenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (errorHiddenToolStripMenuItem.Checked)
            {
                dataGridView1.Columns["errorHidden"].Visible = true;
            }
            else
            {
                dataGridView1.Columns["errorHidden"].Visible = false;
            }
        }

        private void inputOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inputOutputToolStripMenuItem.Checked)
            {
                dataGridView1.Columns["Column4_inout"].Visible = true;
            }
            else
            {
                dataGridView1.Columns["Column4_inout"].Visible = false;
            }
        }

        private void errorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (errorToolStripMenuItem.Checked)
            {
                dataGridView1.Columns["error"].Visible = true;
            }
            else
            {
                dataGridView1.Columns["error"].Visible = false;
            }
        }

        private void weightMatritzenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            weightForm = new WeightMatrForm();
            weightForm.viewMatr(nn3SO.WIH, nn3SO.WHO);
            weightForm.Visible = true;
        }

        private void displayResults()
        {
            int i, j;
           // j = Math.Max(inodes, hnodes);
           // j = Math.Max(j, onodes);
            //for (i = 0; i < j; i++)
              //  dataGridView1.Rows.Add();
            if(nn3SO.Hidden_inputs != null)
                for (i = 0; i < nn3SO.Hidden_inputs.Length; i++)
                    dataGridView1.Rows[i].Cells[1].Value = nn3SO.Hidden_inputs[i].ToString();
            if (nn3SO.Hidden_outputs != null)
                for (i = 0; i < nn3SO.Hidden_outputs.Length; i++)
                    dataGridView1.Rows[i].Cells[2].Value = nn3SO.Hidden_outputs[i].ToString();
            if (nn3SO.Final_inputs != null)
                for (i = 0; i < nn3SO.Final_inputs.Length; i++)
                 dataGridView1.Rows[i].Cells[4].Value = nn3SO.Final_inputs[i].ToString();
            if (nn3SO.Final_outputs != null)
                for (i = 0; i < nn3SO.Final_outputs.Length; i++)
                    dataGridView1.Rows[i].Cells[5].Value = nn3SO.Final_outputs[i].ToString();
            if (nn3SO.Hidden_errors != null)
                for (i = 0; i < nn3SO.Hidden_errors.Length; i++)
                    dataGridView1.Rows[i].Cells[3].Value = nn3SO.Hidden_errors[i].ToString();
            if (nn3SO.Output_errors != null)
                for (i = 0; i < nn3SO.Output_errors.Length; i++)
                    dataGridView1.Rows[i].Cells[7].Value = nn3SO.Output_errors[i].ToString();
        }


        private static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
