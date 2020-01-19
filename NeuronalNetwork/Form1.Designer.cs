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
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weightMatritzenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ansichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hiddenInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hiddenOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorHiddenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
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
            this.button1.Location = new System.Drawing.Point(899, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 47);
            this.button1.TabIndex = 7;
            this.button1.Text = "Create Network";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(899, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 47);
            this.button2.TabIndex = 8;
            this.button2.Text = "Train Network";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(899, 226);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 47);
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
            this.öffnenToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem2,
            this.toolStripSeparator2,
            this.beendenToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(47, 20);
            this.toolStripMenuItem1.Text = "Datei";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "Optionen";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weightMatritzenToolStripMenuItem});
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
            // öffnenToolStripMenuItem
            // 
            this.öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
            this.öffnenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.öffnenToolStripMenuItem.Text = "Öffnen";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 564);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Hi";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

