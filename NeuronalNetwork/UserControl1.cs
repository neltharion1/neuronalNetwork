using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuronalNetwork
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public void createMatr(double[,] matr)
        {
            int i,j;
            int matrRow = matr.GetLength(0);
            int matrCol = matr.GetLength(1);
            for (i = 0; i < matrCol; i++)
            {
                dataGridView1.Columns.Add("Column_" + i, "H_Matrix_" + i);
            }
            for (i = 0; i < matrRow; i++)
            {
                dataGridView1.Rows.Add();
            }

            for (i = 0; i < matrRow; i++)
            {
                for (j = 0; j < matrCol; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = matr[i, j];
                }
            }

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
