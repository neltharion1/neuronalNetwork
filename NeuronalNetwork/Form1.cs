using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuronalNetwork
{
    public partial class Form1 : Form
    {
        int inodes = 0, hnodes = 0, onodes = 0, hiddenLayers=0;
        double learningRate;
        nn3S nn3SO;
        Einstellungen einstellungen;
        ErrorForm errorForm;
        WeightMatrForm weightForm;
        double[] inputs, targets;
        private string File, saveFile, matrFile;
        private List<double[]> inputsList = new List<double[]>();
        private List<double[]> traindata = new List<double[]>();
        private List<double[]> targetsdata = new List<double[]>();
        private string appName = "Neuronales Netz";
        
        
        ZeichnenForm zeichnen = new ZeichnenForm();
        private int anzahlquery = 0;
        private int richtig = 0;
        private double performanceWert;
        private Bitmap[] imgErgebnis;


        public Form1()
        {
           
            InitializeComponent();
            Properties.Settings.Default.InputNodes = Convert.ToInt32(GetSetting("InputNodes"));
            Properties.Settings.Default.HiddenNodes = Convert.ToInt32(GetSetting("HiddenNodes"));
            Properties.Settings.Default.OutputNodes = Convert.ToInt32(GetSetting("OutputNodes"));
            Properties.Settings.Default.HiddenLayer = Convert.ToInt32(GetSetting("HiddenLayer"));
            Properties.Settings.Default.LearnRate = GetSetting("LearnRate");
            Properties.Settings.Default.ReadAsync = Convert.ToBoolean(GetSetting("ReadAsync"));

            imgErgebnis = new Bitmap[10];
            imgErgebnis[0] = Properties.Resources._null;
            imgErgebnis[1] = Properties.Resources.eins;
            imgErgebnis[2] = Properties.Resources.zwei;
            imgErgebnis[3] = Properties.Resources.drei;
            imgErgebnis[4] = Properties.Resources.vier;
            imgErgebnis[5] = Properties.Resources.funf;
            imgErgebnis[6] = Properties.Resources.sechs;
            imgErgebnis[7] = Properties.Resources.sieben;
            imgErgebnis[8] = Properties.Resources.acht;
            imgErgebnis[9] = Properties.Resources.neun;
            
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

        // Create Network
        private void button1_Click(object sender, EventArgs e)
        {
            inodes = Properties.Settings.Default.InputNodes;
            hnodes = Properties.Settings.Default.HiddenNodes;
            onodes = Properties.Settings.Default.OutputNodes;
            hiddenLayers = Properties.Settings.Default.HiddenLayer;
            learningRate = Convert.ToDouble(Properties.Settings.Default.LearnRate);
            int i, j;
            inputs = new double[inodes];
            targets = new double[onodes];
            j = Math.Max(inodes, hnodes);
             j = Math.Max(j, onodes);
            for (i = 0; i < j; i++)
              dataGridView1.Rows.Add();

            nn3SO = new nn3S(inodes, hnodes, onodes, learningRate, hiddenLayers);
        }

        // Train Network
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
                targets = new double[onodes];
                string target;
                bool error = false;
                if (checkBox1.Checked)
                {
                    for (int i = 0; i < onodes; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[6].Value != null)
                        {
                            target = dataGridView1.Rows[i].Cells[6].Value.ToString();
                            targets[i] = Convert.ToDouble(target);
                           // Console.WriteLine("input : " + targets[i]);
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
                else
                {
                    if(Properties.Settings.Default.ReadAsync == true)
                    {                        
                        //Console.WriteLine("Async");

                        _ = ProcessReadAsync(true);
                       
                        

                    }
                    else
                    {
                        for (int i = 0; i < (int)numericUpDown1.Value; i++)
                        {
                            readData(true);
                            /*
                             Console.WriteLine("readdata");
                             progressBar1.Maximum = (int)numericUpDown1.Value * traindata.Count();
                             progressBar1.Step = 1;
                             progressBar1.Value = 0;
                             progressBar1.Visible = true;
                             for (int i = 0; i < (int)numericUpDown1.Value; i++)
                             {

                                 Console.WriteLine("epoch: " + i);
                                 for (int x = 0; x < traindata.Count(); x++)
                                 {
                                     nn3SO.train(traindata[x], targetsdata[x]);
                                     progressBar1.PerformStep();
                                     Console.WriteLine("train: " + x);
                                 }
                             }
                             progressBar1.Visible = false;
                             */
                            displayResults();
                        }
                    }



                }
            }
        }        

        // Query Network
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
                if (checkBox1.Checked)
                {
                    if (checkBox3.Checked)
                    {
                        zeichnen.queryZeichnung();
                        if (zeichnen.Input != null)
                        {
                            if (zeichnen.CheckColor == true)
                            {
                                int target = readInputs(zeichnen.Input, true);
                                for (int i = 0; i < onodes; i++)
                                {
                                    targets[i] = 0.01;
                                }

                                targets[target] = 0.99;
                                nn3SO.queryNN(inputs);
                                displayResults();
                                performance(target);
                                zeichnen.CheckColor = false;
                            }
                            else
                            {
                                errorForm = new ErrorForm();
                                errorForm.setError("Es wurde kein Zeichen im Zeichenfeld gefunden!");
                                errorForm.Visible = true;
                            }
                        }
                        else
                        {
                            errorForm = new ErrorForm();
                            errorForm.setError("Kein Bild gefunden!");
                            errorForm.Visible = true;
                        }
                    }
                    else
                    {
                        readInputs();

                        nn3SO.queryNN(inputs);
                        displayResults();
                    }
                    anzahlquery++;

                }
                else
                {
                    readData(false);                    
                }

            }
            
        }


        public void performance(int target)
        {
            int indexResult = Array.IndexOf(nn3SO.Final_outputs, nn3SO.Final_outputs.Max());

            
            if(target == indexResult)
            {
                richtig++;
            }

            performanceWert = Convert.ToDouble(richtig) / Convert.ToDouble(anzahlquery);
            //Console.WriteLine("performance t = i: " + target + " = " + indexResult);
            textBox1.Text = performanceWert.ToString();

            pictureBox2.Image = imgErgebnis[indexResult];
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
                    //Console.WriteLine("input : " + inputs[i]);
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

       

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Console.WriteLine("OK");
            this.Text = appName + " - " + openFileDialog1.SafeFileName;

        }

        private void weightMatritzenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nn3SO != null)
            {
                weightForm = new WeightMatrForm();
                weightForm.viewMatr(nn3SO.WIH, nn3SO.WHO, nn3SO.WeightList);
                weightForm.Visible = true;
            }
            else
            {
                errorForm = new ErrorForm();
                errorForm.setError("Kein Netz gefunden");
                errorForm.Visible = true;
            }
        }

        private void displayResults()
        {
            int i, j;
            // j = Math.Max(inodes, hnodes);
            // j = Math.Max(j, onodes);
            //for (i = 0; i < j; i++)
            //  dataGridView1.Rows.Add();
            if (inputs != null)
                for (i = 0; i < inputs.Length; i++)
                    dataGridView1.Rows[i].Cells[0].Value = inputs[i].ToString();
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
            if (targets != null)
                for (i = 0; i < targets.Length; i++)
                    dataGridView1.Rows[i].Cells[6].Value = targets[i];
            if (nn3SO.Output_errors != null)
                for (i = 0; i < nn3SO.Output_errors.Length; i++)
                    dataGridView1.Rows[i].Cells[7].Value = nn3SO.Output_errors[i].ToString();
        }


        private static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void trainingsdatenÖffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All Data (*.*) | *.* ";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                File = openFileDialog1.FileName;
            }
        }

        private void matizenöffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog2.InitialDirectory = "";
            openFileDialog2.Filter = "Text files (*.txt)|*.txt|All Data (*.*) | *.* ";
            DialogResult result = openFileDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                matrFile = openFileDialog2.FileName;
            }
            readMatrData();
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "";
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All Data (*.*) | *.* ";
            DialogResult result = saveFileDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                saveFile = saveFileDialog1.FileName;
                //Console.WriteLine(saveFile);
            }
            if (Properties.Settings.Default.ReadAsync == true)
            {
               // Console.WriteLine("Async");
                _ = ProcessWriteAsync();
            }
            else
            {
                writeData();
            }
                
        }

        private void zeichnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            zeichnen.Visible = true;
        }

        private int readInputs(string line , bool query)
        {
            int i, j;            
            string[] input;
            


            input = line.Split(',');
            for (i = 1; i < input.Length; i++)
            {
                j = i - 1;
                inputs[j] = (Convert.ToDouble(input[i])* 0.99 / 255.0) + 0.01;
                
            }
            
            if(query == true)
            {
                inputsList.Add(inputs);
                
            }

            if (checkBox2.Checked)
            {
                int color;
                Bitmap anImage;
                anImage = new Bitmap(28, 28, System.Drawing.Imaging.PixelFormat.Format16bppArgb1555);
                j = 0;
                for (i = 1; i < inputs.Length; i++)
                {
                    j = i - 1;
                    color = Convert.ToInt32(input[i]);
                    anImage.SetPixel(j - ((j / 28) * 28), (j / 28),
                             Color.FromArgb(color, color, color));
                }
                pictureBox1.Visible = true;
                pictureBox1.Image = anImage;
                //MessageBox.Show("Next");
            }

            return (Convert.ToInt32(input[0]));
        }

        private async Task ProcessReadAsync(bool train)
        {
            //traindata.Clear();
            //targetsdata.Clear();

            if (File != null)
            {
                for (int n = 0; n < (int)numericUpDown1.Value; n++)
                {
                    StreamReader sr = new StreamReader(File);
                    string line;
                    int intTarget;

                    progressBar1.Maximum = System.IO.File.ReadAllLines(File).Length;
                    // Console.WriteLine(System.IO.File.ReadAllLines(File).Length);
                    progressBar1.Visible = true;
                    progressBar1.Step = 1;
                    progressBar1.Value = 0;
                    int uj = 0;
                    while ((line = await sr.ReadLineAsync()) != null && (line != ""))
                    {
                        //Console.WriteLine(uj);
                        uj++;
                        //Console.WriteLine(line);
                        intTarget = readInputs(line, false);
                        for (int i = 0; i < onodes; i++)
                        {
                            targets[i] = 0.01;
                        }
                        targets[intTarget] = 0.99;

                        if (train == true)
                        {
                            //traindata.Add(inputs);
                            //targetsdata.Add(targets);
                            nn3SO.train(inputs, targets);
                            displayResults();
                        }
                        else
                        {
                            nn3SO.queryNN(inputs);
                            displayResults();
                        }



                        if (checkBox2.Checked)
                            MessageBox.Show("Next");

                        //progressBar1.Step += 1;
                        progressBar1.PerformStep();


                        //nn3SO.queryNN(inputs);
                        //trainCount++;
                    }
                    progressBar1.Visible = false;
                    progressBar1.Value = 0;
                }
            }
            else
            {
                errorForm = new ErrorForm();
                errorForm.setError("Keine Daten vorhanden!");
                errorForm.Visible = true;
            }

            /*if(train == true)
            {
                //Console.WriteLine("readdata");
                progressBar1.Maximum = (int)numericUpDown1.Value * traindata.Count();
                progressBar1.Step = 1;
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                for (int i = 0; i < (int)numericUpDown1.Value; i++)
                {

                    //Console.WriteLine("epoch: " + i);
                    for (int x = 0; x < traindata.Count(); x++)
                    {
                        nn3SO.train(traindata[x], targetsdata[x]);
                        progressBar1.PerformStep();
                       // Console.WriteLine("train: " + x);
                        displayResults();
                    }
                }
                progressBar1.Visible = false;
                //displayResults();
            }*/


        }

        private async Task ProcessWriteAsync()
        {
            if (saveFile != null)
            {
                List<string> saveString = new List<string>();
                string line;
                progressBar1.Visible = true;
                progressBar1.Step = 1;
                progressBar1.Value = 0;

                line = hiddenLayers.ToString() + "." + nn3SO.WIH.GetLength(0) + "." + nn3SO.WIH.GetLength(1) + ".";
                line += nn3SO.WHO.GetLength(0) + "." + nn3SO.WHO.GetLength(1) + ".";
                progressBar1.Maximum = nn3SO.WIH.GetLength(0) * nn3SO.WIH.GetLength(1);
                for (int i = 0; i < nn3SO.WIH.GetLength(0); i++)
                {
                    for (int j = 0; j < nn3SO.WIH.GetLength(1); j++)
                    {

                        line += Convert.ToString(nn3SO.WIH[i, j]);
                        line += ".";
                        progressBar1.PerformStep();
                    }
                }
                progressBar1.Value = 0;
                progressBar1.Maximum = nn3SO.WHO.GetLength(0) * nn3SO.WHO.GetLength(1);
                for (int i = 0; i < nn3SO.WHO.GetLength(0); i++)
                {

                    for (int j = 0; j < nn3SO.WHO.GetLength(1); j++)
                    {

                        line += Convert.ToString(nn3SO.WHO[i, j]);
                        line += ".";
                        progressBar1.PerformStep();
                    }

                }

                foreach (double[,] matr in nn3SO.WeightList)
                {
                    for (int i = 0; i < matr.GetLength(0); i++)
                    {

                        for (int j = 0; j < matr.GetLength(1); j++)
                        {

                            line += Convert.ToString(matr[i, j]);
                            line += ".";
                        }

                    }
                }

                line = line.Substring(0, line.Length - 1);


                using (StreamWriter sw = new StreamWriter(saveFile))
                {

                    await sw.WriteLineAsync(line);


                }
                progressBar1.Visible = false;
                MessageBox.Show("Erfolgreich gespeichert!");
            }
        }

        private void writeData()
        {
            if (saveFile != null)
            {
                List<string> saveString = new List<string>();
                string line;
                progressBar1.Visible = true;
                progressBar1.Step = 1;
                progressBar1.Value = 0;

                line = hiddenLayers.ToString() + "." + nn3SO.WIH.GetLength(0) + "." + nn3SO.WIH.GetLength(1) + ".";
                line += nn3SO.WHO.GetLength(0) + "." + nn3SO.WHO.GetLength(1) + ".";
                progressBar1.Maximum = nn3SO.WIH.GetLength(0)* nn3SO.WIH.GetLength(1);
                for (int i = 0; i < nn3SO.WIH.GetLength(0); i++)
                {                   
                    for (int j = 0; j < nn3SO.WIH.GetLength(1); j++)
                    {

                        line += Convert.ToString(nn3SO.WIH[i, j]);
                        line += ".";
                        progressBar1.PerformStep();
                    }                    
                }
                progressBar1.Value = 0;
                progressBar1.Maximum = nn3SO.WHO.GetLength(0) * nn3SO.WHO.GetLength(1);
                for (int i = 0; i < nn3SO.WHO.GetLength(0); i++)
                {
                   
                    for (int j = 0; j < nn3SO.WHO.GetLength(1); j++)
                    {

                        line += Convert.ToString(nn3SO.WHO[i, j]);
                        line += ".";
                        progressBar1.PerformStep();
                    }
                   
                }

                foreach(double[,] matr in nn3SO.WeightList)
                {
                    for (int i = 0; i < matr.GetLength(0); i++)
                    {
                        
                        for (int j = 0; j < matr.GetLength(1); j++)
                        {

                            line += Convert.ToString(matr[i, j]);
                            line += ".";
                        }
                       
                    }
                }

                line = line.Substring(0, line.Length - 1);

                
                using (StreamWriter sw = new StreamWriter(saveFile))
                {
                 
                    sw.WriteLine(line);
                    
                  
                }
                progressBar1.Visible = false;
                MessageBox.Show("Erfolgreich gespeichert!");
            }
        }

        private void readMatrData()
        {
            if (nn3SO == null)
            {
                errorForm = new ErrorForm();
                errorForm.setError("Kein Netz gefunden!");
                errorForm.Visible = true;
            }
            else
            {
                if (matrFile != null)
                {
                    StreamReader sr = new StreamReader(matrFile);
                    string line;
                    List<string> inputlist = new List<string>();
                    int i, j;
                    bool wih = false;
                    bool who = false;
                    double[,] matrix;


                    progressBar1.Maximum = System.IO.File.ReadAllLines(matrFile).Length;
                    // Console.WriteLine(System.IO.File.ReadAllLines(matrFile).Length);
                    progressBar1.Visible = true;
                    progressBar1.Step = 1;
                    progressBar1.Value = 0;
                    while ((line = sr.ReadLine()) != null && (line != ""))
                    {
                        string[] input;

                        input = line.Split('.');
                        for (i = 0; i < input.Length; i++)
                        {
                            //Console.WriteLine(input[i]);
                            inputlist.Add(input[i]);
                        }


                        progressBar1.PerformStep();
                    }
                    //progressBar1.Visible = false;

                    //hnodes = Convert.ToInt32(inputlist[2]);

                    hiddenLayers = Convert.ToInt32(inputlist[0]);
                  //  Console.WriteLine("hidden " + hiddenLayers);
                    hnodes = Convert.ToInt32(inputlist[1]);
                  //  Console.WriteLine("hnodes " + hnodes);
                    inodes = Convert.ToInt32(inputlist[2]);
                    onodes = Convert.ToInt32(inputlist[3]);
                    nn3SO.createFromData(inodes, hnodes, onodes, hiddenLayers);
                   // Console.WriteLine("count " + inputlist.Count());
                    targets = new double[onodes];

                    int z = 5;

                    progressBar1.Maximum = hnodes * inodes;
                    progressBar1.Value = 0;
                    for (i = 0; i < hnodes; i++)
                    {
                        for (j = 0; j < inodes; j++)
                        {
                            nn3SO.WIH[i, j] = Convert.ToDouble(inputlist[z]);
                            z++;
                            progressBar1.PerformStep();
                        }
                    }
                    progressBar1.Maximum = onodes * hnodes;
                    progressBar1.Value = 0;
                    for (i = 0; i < onodes; i++)
                    {
                        for (j = 0; j < hnodes; j++)
                        {
                            nn3SO.WHO[i, j] = Convert.ToDouble(inputlist[z]);
                            z++;
                            progressBar1.PerformStep();
                        }
                    }

                    progressBar1.Value = 0;
                    if (hiddenLayers != 0)
                    {
                        nn3SO.WeightList.Clear();
                        progressBar1.Maximum = hnodes * hnodes * hiddenLayers;
                    }
                    else
                    {
                        progressBar1.Maximum = hnodes * hnodes;
                    }

                    for (int k = 0; k < hiddenLayers; k++)
                    {

                        matrix = new double[hnodes, hnodes];
                        for (i = 0; i < hnodes; i++)
                        {

                            for (j = 0; j < hnodes; j++)
                            {

                                //Console.WriteLine("read "+inputlist[z]);
                                //if (!inputlist[z].Equals(""))
                                //{

                                matrix[i, j] = Convert.ToDouble(inputlist[z]);
                                // Console.WriteLine("read " + inputlist[z]);
                                //}
                                z++;
                                progressBar1.PerformStep();

                            }
                        }
                        nn3SO.WeightList.Add(matrix);

                    }

                    progressBar1.Value = 0;
                    progressBar1.Visible = false;

                }
            }
        }

        private void readData(bool train)
        {
            traindata.Clear();
            targetsdata.Clear();
            if (File != null)
            {
                StreamReader sr = new StreamReader(File);
                string line;
                int intTarget;

                progressBar1.Maximum = System.IO.File.ReadAllLines(File).Length;
               // Console.WriteLine(System.IO.File.ReadAllLines(File).Length);
                progressBar1.Visible = true;
                progressBar1.Step = 1;
                progressBar1.Value = 0;
                int uj = 0;

                while ((line =  sr.ReadLine()) != null && (line != ""))
                {
                   // Console.WriteLine(uj);
                    uj++;
                    //Console.WriteLine(line);
                    intTarget = readInputs(line, false);
                    for (int i = 0; i < onodes; i++)
                    {
                        targets[i] = 0.01;
                    }
                    targets[intTarget] = 0.99;

                    if (train == true)
                    {
                        //traindata.Add(inputs);
                        //targetsdata.Add(targets);
                        nn3SO.train(inputs, targets);
                    }
                    else
                    {
                        nn3SO.queryNN(inputs);
                        anzahlquery++;
                        performance(intTarget);

                    }
                    displayResults();


                    if (checkBox2.Checked)
                        MessageBox.Show("Next");

                    //progressBar1.Step += 1;
                    progressBar1.PerformStep();


                    //nn3SO.queryNN(inputs);
                    //trainCount++;
                }
                progressBar1.Visible = false;
                progressBar1.Value = 0;
            }
            else
            {
                errorForm = new ErrorForm();
                errorForm.setError("Keine Daten vorhanden!");
                errorForm.Visible = true;
            }
        }


    }
}
