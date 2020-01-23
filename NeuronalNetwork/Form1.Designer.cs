namespace NeuronalNetwork
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1_input = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2_hidden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3_output = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorHidden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4_inout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5_out = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.target = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.error = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.öffnenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.trainingsdatenÖffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matizenöffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weightMatritzenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zeichnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ansichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hiddenInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hiddenOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorHiddenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1_input,
            this.Column2_hidden,
            this.Column3_output,
            this.errorHidden,
            this.Column4_inout,
            this.Column5_out,
            this.target,
            this.error});
            this.dataGridView1.Location = new System.Drawing.Point(12, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(849, 496);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1_input
            // 
            this.Column1_input.HeaderText = "Input Layer";
            this.Column1_input.Name = "Column1_input";
            // 
            // Column2_hidden
            // 
            this.Column2_hidden.HeaderText = "Input Hidden";
            this.Column2_hidden.Name = "Column2_hidden";
            this.Column2_hidden.ReadOnly = true;
            // 
            // Column3_output
            // 
            this.Column3_output.HeaderText = "Output Hidden";
            this.Column3_output.Name = "Column3_output";
            this.Column3_output.ReadOnly = true;
            // 
            // errorHidden
            // 
            this.errorHidden.HeaderText = "Error Hidden";
            this.errorHidden.Name = "errorHidden";
            this.errorHidden.ReadOnly = true;
            // 
            // Column4_inout
            // 
            this.Column4_inout.HeaderText = "Input output";
            this.Column4_inout.Name = "Column4_inout";
            this.Column4_inout.ReadOnly = true;
            // 
            // Column5_out
            // 
            this.Column5_out.HeaderText = "Output Layer";
            this.Column5_out.Name = "Column5_out";
            this.Column5_out.ReadOnly = true;
            // 
            // target
            // 
            this.target.HeaderText = "Target";
            this.target.Name = "target";
            // 
            // error
            // 
            this.error.HeaderText = "Error";
            this.error.Name = "error";
            this.error.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(867, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 35);
            this.button1.TabIndex = 7;
            this.button1.Text = "Create Network";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(974, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 35);
            this.button2.TabIndex = 8;
            this.button2.Text = "Train Network";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(920, 497);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 69);
            this.button3.TabIndex = 9;
            this.button3.Text = "Query Network";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.bearbeitenToolStripMenuItem,
            this.ansichtToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1077, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.öffnenToolStripMenuItem1,
            this.speichernToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem2,
            this.toolStripSeparator2,
            this.beendenToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(47, 20);
            this.toolStripMenuItem1.Text = "Datei";
            // 
            // öffnenToolStripMenuItem1
            // 
            this.öffnenToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trainingsdatenÖffnenToolStripMenuItem,
            this.matizenöffnenToolStripMenuItem});
            this.öffnenToolStripMenuItem1.Name = "öffnenToolStripMenuItem1";
            this.öffnenToolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.öffnenToolStripMenuItem1.Text = "Öffnen";
            // 
            // trainingsdatenÖffnenToolStripMenuItem
            // 
            this.trainingsdatenÖffnenToolStripMenuItem.Name = "trainingsdatenÖffnenToolStripMenuItem";
            this.trainingsdatenÖffnenToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.trainingsdatenÖffnenToolStripMenuItem.Text = "Daten";
            this.trainingsdatenÖffnenToolStripMenuItem.Click += new System.EventHandler(this.trainingsdatenÖffnenToolStripMenuItem_Click);
            // 
            // matizenöffnenToolStripMenuItem
            // 
            this.matizenöffnenToolStripMenuItem.Name = "matizenöffnenToolStripMenuItem";
            this.matizenöffnenToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.matizenöffnenToolStripMenuItem.Text = "Matizenöffnen";
            this.matizenöffnenToolStripMenuItem.Click += new System.EventHandler(this.matizenöffnenToolStripMenuItem_Click);
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.speichernToolStripMenuItem.Text = "Speichern";
            this.speichernToolStripMenuItem.Click += new System.EventHandler(this.speichernToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(125, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem2.Text = "Optionen";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(125, 6);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weightMatritzenToolStripMenuItem,
            this.zeichnenToolStripMenuItem});
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.bearbeitenToolStripMenuItem.Text = "Bearbeiten";
            // 
            // weightMatritzenToolStripMenuItem
            // 
            this.weightMatritzenToolStripMenuItem.Name = "weightMatritzenToolStripMenuItem";
            this.weightMatritzenToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.weightMatritzenToolStripMenuItem.Text = "Weight-Matritzen";
            this.weightMatritzenToolStripMenuItem.Click += new System.EventHandler(this.weightMatritzenToolStripMenuItem_Click);
            // 
            // zeichnenToolStripMenuItem
            // 
            this.zeichnenToolStripMenuItem.Name = "zeichnenToolStripMenuItem";
            this.zeichnenToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.zeichnenToolStripMenuItem.Text = "Zeichnen";
            this.zeichnenToolStripMenuItem.Click += new System.EventHandler(this.zeichnenToolStripMenuItem_Click);
            // 
            // ansichtToolStripMenuItem
            // 
            this.ansichtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hiddenInputToolStripMenuItem,
            this.hiddenOutputToolStripMenuItem,
            this.errorHiddenToolStripMenuItem,
            this.inputOutputToolStripMenuItem,
            this.errorToolStripMenuItem});
            this.ansichtToolStripMenuItem.Name = "ansichtToolStripMenuItem";
            this.ansichtToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.ansichtToolStripMenuItem.Text = "Ansicht";
            // 
            // hiddenInputToolStripMenuItem
            // 
            this.hiddenInputToolStripMenuItem.Checked = true;
            this.hiddenInputToolStripMenuItem.CheckOnClick = true;
            this.hiddenInputToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hiddenInputToolStripMenuItem.Name = "hiddenInputToolStripMenuItem";
            this.hiddenInputToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.hiddenInputToolStripMenuItem.Text = "Hidden Input";
            this.hiddenInputToolStripMenuItem.Click += new System.EventHandler(this.hiddenInputToolStripMenuItem_Click);
            // 
            // hiddenOutputToolStripMenuItem
            // 
            this.hiddenOutputToolStripMenuItem.Checked = true;
            this.hiddenOutputToolStripMenuItem.CheckOnClick = true;
            this.hiddenOutputToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hiddenOutputToolStripMenuItem.Name = "hiddenOutputToolStripMenuItem";
            this.hiddenOutputToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.hiddenOutputToolStripMenuItem.Text = "Hidden Output";
            this.hiddenOutputToolStripMenuItem.Click += new System.EventHandler(this.hiddenOutputToolStripMenuItem_Click);
            // 
            // errorHiddenToolStripMenuItem
            // 
            this.errorHiddenToolStripMenuItem.Checked = true;
            this.errorHiddenToolStripMenuItem.CheckOnClick = true;
            this.errorHiddenToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.errorHiddenToolStripMenuItem.Name = "errorHiddenToolStripMenuItem";
            this.errorHiddenToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.errorHiddenToolStripMenuItem.Text = "Error Hidden";
            this.errorHiddenToolStripMenuItem.Click += new System.EventHandler(this.errorHiddenToolStripMenuItem_Click);
            // 
            // inputOutputToolStripMenuItem
            // 
            this.inputOutputToolStripMenuItem.Checked = true;
            this.inputOutputToolStripMenuItem.CheckOnClick = true;
            this.inputOutputToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.inputOutputToolStripMenuItem.Name = "inputOutputToolStripMenuItem";
            this.inputOutputToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.inputOutputToolStripMenuItem.Text = "Input Output";
            this.inputOutputToolStripMenuItem.Click += new System.EventHandler(this.inputOutputToolStripMenuItem_Click);
            // 
            // errorToolStripMenuItem
            // 
            this.errorToolStripMenuItem.Checked = true;
            this.errorToolStripMenuItem.CheckOnClick = true;
            this.errorToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.errorToolStripMenuItem.Name = "errorToolStripMenuItem";
            this.errorToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.errorToolStripMenuItem.Text = "Error";
            this.errorToolStripMenuItem.Click += new System.EventHandler(this.errorToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(867, 126);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(111, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Manuelle Eingabe";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox1.Location = new System.Drawing.Point(867, 172);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(867, 328);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(90, 17);
            this.checkBox2.TabIndex = 13;
            this.checkBox2.Text = "Show Images";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 548);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(849, 23);
            this.progressBar1.TabIndex = 14;
            this.progressBar1.Visible = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(867, 149);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(77, 17);
            this.checkBox3.TabIndex = 15;
            this.checkBox3.Text = "Zeichnung";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(936, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Epochs";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(985, 87);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(70, 20);
            this.numericUpDown1.TabIndex = 17;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(928, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Network Performance";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(965, 367);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 19;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox2.Location = new System.Drawing.Point(955, 426);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(65, 65);
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(952, 410);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Vom Netz erkannt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 578);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Neuronales Netz";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1_input;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2_hidden;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3_output;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorHidden;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4_inout;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5_out;
        private System.Windows.Forms.DataGridViewTextBoxColumn target;
        private System.Windows.Forms.DataGridViewTextBoxColumn error;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weightMatritzenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ansichtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hiddenInputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hiddenOutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem errorHiddenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputOutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem errorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem matizenöffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainingsdatenÖffnenToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.ToolStripMenuItem zeichnenToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
    }
}

