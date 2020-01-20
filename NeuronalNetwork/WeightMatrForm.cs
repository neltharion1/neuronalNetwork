using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuronalNetwork
{
    public partial class WeightMatrForm : Form
    {
        public WeightMatrForm()
        {
            InitializeComponent();
        }

        public void viewMatr(double[,] wih, double[,] who, List<double[,]> weightList)
        {
            int i,j;
            int wihRow = wih.GetLength(0);
            int wihCol = wih.GetLength(1);
            int whoRow = who.GetLength(0);
            int whoCol = who.GetLength(1);
            

            for (i = 0; i < weightList.Count(); i++)
            {
                UserControl1 uc = new UserControl1();
                TabPage tp = new TabPage();
                uc.createMatr(weightList[i]);
                tp.Controls.Add(uc);
                tp.Name = "w_matr_"+i;
                tp.Text = "W-Matrix_H-" + i;                
                this.tabControl1.TabPages.Add(tp);

            }

            for (i = 0; i < wihRow; i++)
            {
                dataGridView2.Columns.Add("Column_" + i, "WIH_" + i);
            }
            for (i = 0; i < wihCol; i++)
            {
                dataGridView2.Rows.Add();
            }

            for (i = 0; i < whoRow; i++)
            {
                dataGridView1.Columns.Add("Column_" + i, "WHO_" + i);
            }
            for (i = 0; i < whoCol; i++)
            {
                dataGridView1.Rows.Add();
            }
            
            for(i=0; i < wihRow; i++)
            {
                for (j = 0; j < wihCol; j++)
                {
                    dataGridView2.Rows[j].Cells[i].Value = wih[i, j];
                }
            }
            for (i = 0; i < whoRow; i++)
            {
                for (j = 0; j < whoCol; j++)
                {
                    dataGridView1.Rows[j].Cells[i].Value = who[i, j];
                }
            }
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

    }
}
