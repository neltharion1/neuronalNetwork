﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuronalNetwork
{
    public partial class ZeichnenForm : Form
    {
        private List<Point> list;
        private Bitmap bmp;
        private Bitmap vorschau;
        private Bitmap queryBmp;
        private bool mouseDown;
        Graphics g;
        private string input;        
        private bool checkColor = false;

        public string Input { get { return input; } }
        public bool CheckColor { get { return checkColor; } set { checkColor = value; } }

        public ZeichnenForm()
        {
            InitializeComponent();
            this.list = new List<Point>(); //Liste für Koordinaten instanziieren
            this.bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            list.Add(new Point(e.X, e.Y));
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseDown = false;
                using ( g = Graphics.FromImage(bmp))
                {
                    Draw(g);
                    g.Flush();
                }
                list.Clear();
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                list.Add(new Point(e.X, e.Y));
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (mouseDown)
                Draw(e.Graphics);
        }

        /// <summary>
        /// zeichnen
        /// </summary>
        private void Draw(Graphics g)
        {
            if (list.Count > 0)
            {
                byte[] bs = new byte[list.Count];
                bs[0] = (byte)PathPointType.Start;
                for (int i = 1; i < list.Count; i++)
                    bs[i] = (byte)PathPointType.Line;

                using (Pen p = new Pen(Color.White, 20))
                    g.DrawPath(p, new System.Drawing.Drawing2D.GraphicsPath(list.ToArray(), bs));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vorschau = new Bitmap(bmp, new Size(28, 28));
            pictureBox2.Image = vorschau;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bmp.Dispose();
            this.bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        public void queryZeichnung()
        {
            queryBmp = new Bitmap(bmp, new Size(28, 28));
            
            input = numericUpDown1.Value.ToString() + ",";
            int j = 0;
            int colorInt;
            for (int i = 1; i < (28 * 28) + 1; i++)
            {
                j = i - 1;
                int x = (j - ((j / 28) * 28));
                int y = (j / 28);                
                Color color = queryBmp.GetPixel(x, y);                
                colorInt = color.A;   
                if(colorInt != 0)
                {
                    checkColor = true;
                   // Console.WriteLine("ColorTrue");
                }
                input += colorInt.ToString() + ",";
            }
            input = input.Substring(0, input.Length - 1);     
        }
    }
}
