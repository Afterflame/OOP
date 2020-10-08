using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Aint
{
    public partial class Form1 : Form
    {
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.DrawImage(picture, new RectangleF(-viewport.offset.X * viewport.scale, -viewport.offset.Y * viewport.scale, picture.Width * viewport.scale, picture.Height * viewport.scale));
            //pictureBox1.Invalidate();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            refreshPens();
            refreshBrushes();
        }
        private void ColorBut_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Button b = (Button)sender;
                b.BackColor = colorDialog1.Color;
                mainColor = mainColorBut.BackColor;
                offColor = offColorBut.BackColor;
                bonusColor = bonusColorBut.BackColor;
                cur_pen.Color = mainColor;
                refreshPens();
                refreshBrushes();
                changeBrush(presetBrushes[bId]);
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            cur_pen.Width = trackBar1.Value;
            refreshPens();
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                curTool.MouseDown_Move(e.Location);
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                curTool.MouseDown(e.Location);
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                curTool.RightClick(e.Location);
            }
            if (e.Button == MouseButtons.Left)
            {
                curTool.MouseUp(e.Location);
            }
        }
        private void linerButton_Click(object sender, EventArgs e)
        {
            curTool.CallClear();
            curTool = new Liner(pictureBox1, this);
        }
        private void bruhButton_Click(object sender, EventArgs e)
        {
            curTool.CallClear();
            curTool = new Bruh(pictureBox1, this);
        }
        private void elipseButton_Click(object sender, EventArgs e)
        {
            curTool.CallClear();
            curTool = new EllipseTool(pictureBox1, this);
        }
        private void rectangleButton_Click(object sender, EventArgs e)
        {
            curTool.CallClear();
            curTool = new RectTool(pictureBox1, this);
        }
        private void lupa2pBut_Click(object sender, EventArgs e)
        {
            curTool.CallClear();
            curTool = new Lupa2p(pictureBox1, this);
        }
        private void lupa1pBut_Click(object sender, EventArgs e)
        {
            curTool.CallClear();
            curTool = new Lupa1p(pictureBox1, this);
        }
        private void handBut_Click(object sender, EventArgs e)
        {
            curTool.CallClear();
            curTool = new Hand(pictureBox1, this);
        }
        private void pieBut_Click(object sender, EventArgs e)
        {
            curTool.CallClear();
            curTool = new PieTool(pictureBox1, this);
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            changePen(presetPens[0]);
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            changePen(presetPens[1]);
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            changePen(presetPens[2]);
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            changePen(presetPens[3]);
        }
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            changePen(presetPens[4]);
        }
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            changeBrush(presetBrushes[0]);
            bId = 0;
        }
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            changeBrush(presetBrushes[1]);
            bId = 1;
        }
        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            changeBrush(presetBrushes[2]);
            bId = 2;
        }
        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            changeBrush(presetBrushes[3]);
            bId = 3;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.FileName = "save";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadJson(openFileDialog1.FileName);
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.FileName = "save";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveJson(saveFileDialog1.FileName);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}