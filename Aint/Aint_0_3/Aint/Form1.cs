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
        static ViewPoint viewport;
        static Bitmap picture;
        static Color mainColor, offColor;
        static Tool curTool;
        static ToolHolder curToolType;
        static int p_size=1, applyFill=0;
        private class ToolHolder
        {
            public string id;
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
                    case "lupa1p":
                        return new Lupa1p(pBoxIn, pos);
                    case "lupa2p":
                        return new Lupa2p(pBoxIn, pos);
                    default:
                        return new Bruh(pBoxIn, pos);
                }
            }
        }
        private class ViewPoint
        {
            public Point offset;
            public int scale;
            public ViewPoint(Point offset, int scale)
            {
                this.offset = offset;
                this.scale = scale;
            }
            public Point PointTransform(Point input_p)
            {
                int x = (int)Math.Round(input_p.X / (float)scale) + offset.X;
                int y = (int)Math.Round(input_p.Y / (float)scale) + offset.Y;
                return new Point(x, y);
            }
            public Point PointDeTransform(Point input_p)
            {
                int x = (input_p.X - this.offset.X) * scale;
                int y = (input_p.Y - this.offset.Y) * scale;
                return new Point(x, y);
            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.DrawImage(picture, new RectangleF(-viewport.offset.X * viewport.scale, -viewport.offset.Y * viewport.scale, picture.Width * viewport.scale, picture.Height * viewport.scale));
            //pictureBox1.Invalidate();
        }
        private class Figure
        {
            public Point point1, point2;
            public Figure(Point f_point, Point s_point)
            {
                this.point1 = viewport.PointTransform(f_point);
                this.point2 = viewport.PointTransform(s_point);
            }
        }
        private class RectangleObj : Figure
        {
            public RectangleObj(Point f_point, Point s_point) : base(f_point, s_point) { }
            public void Draw(PictureBox pBox, Pen pen, Brush brush)
            {
                Graphics g = Graphics.FromImage(picture);
                int x = Math.Min(this.point1.X, this.point2.X),
                y = Math.Min(this.point1.Y, this.point2.Y),
                w = Math.Abs(this.point1.X - this.point2.X),
                h = Math.Abs(this.point1.Y - this.point2.Y);
                if(applyFill==1)
                    g.FillRectangle(brush, x, y, w, h);
                g.DrawRectangle(pen, x, y, w, h);
                pBox.Refresh();
            }
        }
        private class EllipseObj : Figure
        {
            public EllipseObj(Point f_point, Point s_point) : base(f_point, s_point) { }
            public void Draw(PictureBox pBox, Pen pen, Brush brush)
            {
                Graphics g = Graphics.FromImage(picture);
                int x = Math.Min(this.point1.X, this.point2.X),
                y = Math.Min(this.point1.Y, this.point2.Y),
                w = Math.Abs(this.point1.X - this.point2.X),
                h = Math.Abs(this.point1.Y - this.point2.Y);
                if(applyFill==1)
                    g.FillEllipse(brush, x, y, w, h);
                g.DrawEllipse(pen, x, y, w, h);
                pBox.Refresh();
            }
        }
        private class LineObj : Figure
        {
            public LineObj(Point f_point, Point s_point) : base(f_point, s_point) { }
            public void Draw(PictureBox pBox, Pen pen)
            {
                Graphics g = Graphics.FromImage(picture);
                g.DrawLine(pen, this.point1, this.point2);
                pBox.Refresh();
            }
        }
        private class Tool
        {
            protected Bitmap initialBM;
            protected Pen pen;
            protected SolidBrush brush;
            protected Point start_p;
            protected PictureBox pBox;
            public Tool(PictureBox pBoxIn, Point pos)
            {
                RectangleF cloneRect = new RectangleF(0, 0, picture.Width, picture.Height);
                brush = new SolidBrush(offColor);
                System.Drawing.Imaging.PixelFormat format = picture.PixelFormat;
                initialBM = picture.Clone(cloneRect, format);
                this.pen = new Pen(mainColor, p_size);
                this.start_p = pos;
                this.pBox=pBoxIn;
            }

            public virtual void MouseDown(Point cur_p)
            {
            }

            public virtual void RightClick(Point cur_p)
            {
            }
            public virtual void MouseUp(Point cur_p)
            {
            }
            public void Restore()
            {
                RectangleF cloneRect = new RectangleF(0, 0, initialBM.Width, initialBM.Height);
                System.Drawing.Imaging.PixelFormat format = initialBM.PixelFormat;
                picture = initialBM.Clone(cloneRect, format);
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
                    this.Draw(this.pen, this.brush, start_p, cur_p);
                this.start_p = cur_p;
            }
            private void Draw(Pen pen, Brush brush, Point p1, Point p2)
            {
                new LineObj(p1, p2).Draw(this.pBox, this.pen);
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
                new LineObj(p1, p2).Draw(this.pBox, this.pen);
            }
        }
        private class Lupa1p : SinglePointTool
        {
            public Lupa1p(PictureBox pBoxIn, Point pos)
                : base(pBoxIn, pos)
            {
                
            }
            public override void MouseUp(Point cur_p)
            {
                {
                    if (viewport.scale == 8) return;
                    cur_p = viewport.PointTransform(cur_p);
                    int offsetX = cur_p.X - picture.Width / (viewport.scale + 1) / 2,
                        offsetY = cur_p.Y - picture.Height / (viewport.scale + 1) / 2;
                    offsetX = Math.Min(offsetX, viewport.offset.X + picture.Width / viewport.scale - picture.Width / (1 + viewport.scale));
                    offsetX = Math.Max(offsetX, viewport.offset.X);
                    offsetY = Math.Min(offsetY, viewport.offset.Y + picture.Height / viewport.scale - picture.Width / (1 + viewport.scale));
                    offsetY = Math.Max(offsetY, viewport.offset.Y);
                    viewport.offset = new Point(offsetX, offsetY);
                    viewport.scale++;
                    pBox.Refresh();
                }
            }
            public override void RightClick(Point cur_p)
            {
                {
                    if (viewport.scale == 1) return;
                    viewport.offset.X -= Math.Max(0, viewport.offset.X + picture.Width / (viewport.scale - 1) - picture.Width);
                    viewport.offset.Y -= Math.Max(0, viewport.offset.Y + picture.Height / (viewport.scale - 1) - picture.Height);
                    viewport.scale--;
                    pBox.Refresh();
                }
            }
        }
        private class Lupa2p : DoublePointTool
        {
            Point second_point;
            double scaling;
            bool boxIsValid;
            public Lupa2p(PictureBox pBoxIn, Point pos)
                : base(pBoxIn, pos)
            {
                this.pen = new Pen(Color.Black, 1);
                pen.LineJoin = System.Drawing.Drawing2D.LineJoin.MiterClipped;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
                pen.StartCap = System.Drawing.Drawing2D.LineCap.Flat;
            }
            public override void MouseDown(Point cur_p)
            {
                int height = Math.Max(Math.Abs(cur_p.Y - start_p.Y), (picture.Height / 8));
                int width = Math.Max(Math.Abs(cur_p.X - start_p.X), (picture.Width / 8));
                int hSign = 1;
                int wSign = 1;
                if (cur_p.Y - start_p.Y != 0)
                    hSign = (cur_p.Y - start_p.Y) / Math.Abs(cur_p.Y - start_p.Y);
                if (cur_p.X - start_p.X != 0)
                    wSign = (cur_p.X - start_p.X) / Math.Abs(cur_p.X - start_p.X);
                scaling = Math.Floor(Math.Min(Math.Floor(picture.Height * viewport.scale / (float)height), Math.Floor(picture.Width * viewport.scale / (float)width)));
                scaling = Math.Min(7, Math.Max(scaling, 1));
                scaling++;
                scaling /= viewport.scale;
                this.second_point.Y = start_p.Y + (int)Math.Round(picture.Height / scaling) * hSign;
                this.second_point.X = start_p.X + (int)Math.Round(picture.Width / scaling) * wSign;
                boxIsValid = false;
                if (second_point.Y < picture.Height && second_point.Y > 0 && second_point.X < picture.Width && second_point.X > 0)
                {
                    boxIsValid = true;
                };
                if (boxIsValid&&cur_p!=start_p)
                {
                    this.Restore();
                    new RectangleObj(this.start_p, second_point).Draw(this.pBox, this.pen, this.brush);
                }
                else
                    this.Restore();
                pBox.Refresh();
            }
            public override void MouseUp(Point cur_p)
            {
                if (boxIsValid && cur_p != start_p)
                {
                    this.Restore();
                    viewport.offset = viewport.PointTransform(new Point(Math.Min(start_p.X, second_point.X), Math.Min(start_p.Y, second_point.Y)));
                    viewport.scale = (int)Math.Round(scaling * viewport.scale);
                }
                pBox.Refresh();
            }
            public override void RightClick(Point cur_p)
            {
                {
                    if (viewport.scale == 1) return;
                    viewport.offset.X -= Math.Max(0, viewport.offset.X + picture.Width / (viewport.scale - 1) - picture.Width);
                    viewport.offset.Y -= Math.Max(0, viewport.offset.Y + picture.Height / (viewport.scale - 1) - picture.Height);
                    viewport.scale--;
                }
                pBox.Refresh();
            }
        }
        private class DoublePointTool : Tool
        {
            public DoublePointTool(PictureBox pBoxIn, Point pos) : base(pBoxIn, pos) {
            }
            public override void MouseDown(Point cur_p)
            {
            }
            public override void MouseUp(Point cur_p)
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
                this.Restore();
                new RectangleObj(this.start_p, cur_p).Draw(this.pBox, this.pen, this.brush);
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
                this.Restore();
                new EllipseObj(this.start_p, cur_p).Draw(this.pBox, this.pen, this.brush);
            }
        }
        public Form1()
        {
            InitializeComponent();
            viewport = new ViewPoint(new Point(0, 0), 1);
            curToolType = new ToolHolder("pen");
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow; 
            picture = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            mainColor = mainColorBut.BackColor;
            offColor = offColorBut.BackColor;
        }


        private void Form1_Load(object sender, EventArgs e)
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

        private void lupa2pBut_Click(object sender, EventArgs e)
        {
            curToolType.ChangeTool("lupa2p");
        }

        private void lupa1pBut_Click(object sender, EventArgs e)
        {
            curToolType.ChangeTool("lupa1p");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            applyFill = (applyFill + 1) % 2;
        }

    }
}
