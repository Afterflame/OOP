using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aint
{
    public partial class Form1 : Form
    {
        Bitmap picture;
        int pastX, pastY;
        Color mainColor, offColor;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow; 
            picture = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pastX = pastY = 0;
            mainColor = mainColorBut.BackColor;
            offColor = offColorBut.BackColor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Pen p = new Pen(mainColor, trackBar1.Value);
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Graphics g=Graphics.FromImage(picture);
            if (e.Button == MouseButtons.Left)
            {
                g.DrawLine(p, pastX, pastY, e.X, e.Y);
                pictureBox1.Image = picture;
            }
            pastX = e.X;
            pastY = e.Y;
        }


        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
        }
        private void ColorBut_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog()==DialogResult.OK)
            {
                Button b=(Button)sender;
                b.BackColor = colorDialog1.Color;
                mainColor = mainColorBut.BackColor;
                offColor = offColorBut.BackColor;
            }
        }
    }
}
