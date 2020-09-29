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
        static Bitmap picture;
        static Color mainColor, offColor;
        static Tool curTool;
        static ToolHolder curToolType;
        static int p_size=1;
        private class ToolHolder
        {
            string id;
            public ToolHolder(string id)
            {
                this.id = id;
            }
            public void ChangeTool(string id)
            {
                this.id = id;
            }
            public Tool GimmeMyTool(PictureBox pBoxIn, Point pos)
            {
                switch (id)
                {
                    case "bruh":
                        return new Bruh(pBoxIn, pos);
                    case "eraser":
                        return new Eraser(pBoxIn, pos);
                    case "rectangle":
                        return new RectTool(pBoxIn, pos);
                    case "ellipse":
                        return new EllipseTool(pBoxIn, pos);
                    default:
                        return new Bruh(pBoxIn, pos);
                }
            }
        }
        private class Figure
        {
            public Point point1, point2;
            public Figure(Point f_point, Point s_point)
            {
                this.point1 = f_point;
                this.point2 = s_point;
            }
        }
        private class RectangleObj : Figure
        {
            public RectangleObj(Point f_point, Point s_point) : base(f_point, s_point) { }
            public void Draw(PictureBox pBox, Pen pen)
            {
                Graphics g = Graphics.FromImage(picture);
                int x = Math.Min(this.point1.X, this.point2.X),
                y = Math.Min(this.point1.Y, this.point2.Y),
                w = Math.Abs(this.point1.X - this.point2.X),
                h = Math.Abs(this.point1.Y - this.point2.Y);
                g.DrawRectangle(pen, x,y,w,h);
                pBox.Image = picture;
            }
        }
        private class EllipseObj : Figure
        {
            public EllipseObj(Point f_point, Point s_point) : base(f_point, s_point) { }
            public void Draw(PictureBox pBox, Pen pen)
            {
                Graphics g = Graphics.FromImage(picture);
                int x = Math.Min(this.point1.X, this.point2.X),
                y = Math.Min(this.point1.Y, this.point2.Y),
                w = Math.Abs(this.point1.X - this.point2.X),
                h = Math.Abs(this.point1.Y - this.point2.Y);
                g.DrawEllipse(pen, x, y, w, h);
                pBox.Image = picture;
            }
        }
        private class Line : Figure
        {
            public Line(Point f_point, Point s_point) : base(f_point, s_point) { }
            public void Draw(PictureBox pBox, Pen pen)
            {
                Graphics g = Graphics.FromImage(picture);
                g.DrawLine(pen, this.point1, this.point2);
                pBox.Image = picture;
            }
        }
        private class Tool
        {
            protected Pen pen;
            protected Point start_p;
            protected PictureBox pBox;
            public Tool(PictureBox pBoxIn, Point pos)
            {
                this.pen = new Pen(mainColor, p_size);
                this.start_p = pos;
                this.pBox=pBoxIn;
            }

            public virtual void MouseDown(Point cur_p)
            {
            }
        }
        private class SinglePointTool : Tool
        {
            public SinglePointTool(PictureBox pBoxIn, Point pos)
                : base(pBoxIn, pos) 
            {

            }
            public override void MouseDown(Point cur_p)
            {
            }
        }
        private class Bruh : SinglePointTool
        {
            public Bruh(PictureBox pBoxIn, Point pos)
                : base(pBoxIn, pos)
            {
                pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            }
            public override void MouseDown(Point cur_p)
            {
                    this.Draw(this.pen, start_p, cur_p);
                this.start_p = cur_p;
            }
            private void Draw(Pen pen, Point p1, Point p2)
            {
                new Line(p1, p2).Draw(this.pBox, this.pen);
            }
        }
        private class Eraser : SinglePointTool
        {
            public Eraser(PictureBox pBoxIn, Point pos)
                : base(pBoxIn, pos)
            {
                pen.Color = offColor;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.Square;
                pen.StartCap = System.Drawing.Drawing2D.LineCap.Square;
            }
            public override void MouseDown(Point cur_p)
            {
                this.Draw(this.pen, start_p, cur_p);
                this.start_p = cur_p;
            }
            private void Draw(Pen pen, Point p1, Point p2)
            {
                new Line(p1, p2).Draw(this.pBox, this.pen);
            }
        }
        private class DoublePointTool : Tool
        {
            protected Bitmap initialBM;
            public DoublePointTool(PictureBox pBoxIn, Point pos) : base(pBoxIn, pos) {

                RectangleF cloneRect = new RectangleF(0, 0, picture.Width, picture.Height);
                System.Drawing.Imaging.PixelFormat format = picture.PixelFormat;
                initialBM = picture.Clone(cloneRect, format);
            }
            public override void MouseDown(Point cur_p)
            {
            }
        }
        private class RectTool : DoublePointTool
        {
            public RectTool(PictureBox pBoxIn, Point pos)
                : base(pBoxIn, pos)
            {
                pen.LineJoin = System.Drawing.Drawing2D.LineJoin.MiterClipped;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
                pen.StartCap = System.Drawing.Drawing2D.LineCap.Flat;
            }
            public override void MouseDown(Point cur_p)
            {
                RectangleF cloneRect = new RectangleF(0, 0, initialBM.Width, initialBM.Height);
                System.Drawing.Imaging.PixelFormat format = initialBM.PixelFormat;
                picture = initialBM.Clone(cloneRect, format);
                new RectangleObj(this.start_p, cur_p).Draw(this.pBox, this.pen);
            }
        }
        private class EllipseTool : DoublePointTool
        {
            public EllipseTool(PictureBox pBoxIn, Point pos)
                : base(pBoxIn, pos)
            {
                pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
                pen.StartCap = System.Drawing.Drawing2D.LineCap.Flat;
            }
            public override void MouseDown(Point cur_p)
            {
                RectangleF cloneRect = new RectangleF(0, 0, initialBM.Width, initialBM.Height);
                System.Drawing.Imaging.PixelFormat format = initialBM.PixelFormat;
                picture = initialBM.Clone(cloneRect, format);
                new EllipseObj(this.start_p, cur_p).Draw(this.pBox, this.pen);
            }
        }
        public Form1()
        {
            InitializeComponent();
            curToolType = new ToolHolder("bruh");
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow; 
            picture = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            mainColor = mainColorBut.BackColor;
            offColor = offColorBut.BackColor;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ColorBut_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Button b = (Button)sender;
                b.BackColor = colorDialog1.Color;
                mainColor = mainColorBut.BackColor;
                offColor = offColorBut.BackColor;
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            p_size = trackBar1.Value;
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                curTool.MouseDown(e.Location);
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            curTool = curToolType.GimmeMyTool(pictureBox1, e.Location);
            curTool.MouseDown(e.Location);
        }

        private void eraserButton_Click(object sender, EventArgs e)
        {
            curToolType.ChangeTool("eraser");
        }

        private void bruhButton_Click(object sender, EventArgs e)
        {
            curToolType.ChangeTool("bruh");
        }

        private void elipseButton_Click(object sender, EventArgs e)
        {
            curToolType.ChangeTool("ellipse");
        }

        private void rectangleButton_Click(object sender, EventArgs e)
        {
            curToolType.ChangeTool("rectangle");
        }

    }
}
