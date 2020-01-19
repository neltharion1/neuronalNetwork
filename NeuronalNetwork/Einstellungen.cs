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
    public partial class Einstellungen : Form
    {
        
        public Einstellungen()
        {
            InitializeComponent();

            numericUpDown1.Value = Properties.Settings.Default.InputNodes;
            numericUpDown2.Value = Properties.Settings.Default.HiddenNodes;
            numericUpDown3.Value = Properties.Settings.Default.OutputNodes;
            numericUpDown4.Value = Properties.Settings.Default.HiddenLayer;
            textBox1.Text = Properties.Settings.Default.LearnRate;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.InputNodes = (int)numericUpDown1.Value;
            Properties.Settings.Default.HiddenNodes = (int)numericUpDown2.Value;
            Properties.Settings.Default.OutputNodes = (int)numericUpDown3.Value;
            Properties.Settings.Default.HiddenLayer = (int)numericUpDown4.Value;
            Properties.Settings.Default.LearnRate = textBox1.Text;         
           
            SetSetting("InputNodes", numericUpDown1.Value.ToString());
            SetSetting("HiddenNodes", numericUpDown2.Value.ToString());
            SetSetting("OutputNodes", numericUpDown3.Value.ToString());
            SetSetting("HiddenLayer", numericUpDown4.Value.ToString());
            SetSetting("LearnRate", textBox1.Text);
            this.Close();
        }

        private static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        private static void SetSetting(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (configuration.AppSettings.Settings[key] == null)
            {
                configuration.AppSettings.Settings.Add(key, value);
            }
            configuration.AppSettings.Settings[key].Value = value; 
            
            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("userSettings");
        }

    }
}
