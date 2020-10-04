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
        private class Shape
        {
            public Point point1, point2;
            public Shape(Point f_point, Point s_point)
            {
                this.point1 = viewport.PointTransform(f_point);
                this.point2 = viewport.PointTransform(s_point);
            }
            public virtual void Draw(PictureBox pBox, Pen pen, Brush brush)
            {
            }
        }
        private class LineObj : Shape
        {
            public LineObj(Point f_point, Point s_point) : base(f_point, s_point) { }
            public override void Draw(PictureBox pBox, Pen pen, Brush brush)
            {
                Graphics g = Graphics.FromImage(picture);
                g.DrawLine(pen, this.point1, this.point2);
                pBox.Refresh();
            }
        }
        private class RectangleObj : Shape
        {
            public RectangleObj(Point f_point, Point s_point) : base(f_point, s_point) { }
            public override void Draw(PictureBox pBox, Pen pen, Brush brush)
            {
                Graphics g = Graphics.FromImage(picture);
                int x = Math.Min(this.point1.X, this.point2.X),
                y = Math.Min(this.point1.Y, this.point2.Y),
                w = Math.Abs(this.point1.X - this.point2.X),
                h = Math.Abs(this.point1.Y - this.point2.Y);
                g.FillRectangle(brush, x, y, w, h);
                g.DrawRectangle(pen, x, y, w, h);
                pBox.Refresh();
            }
        }
        private class EllipseObj : Shape
        {
            public EllipseObj(Point f_point, Point s_point) : base(f_point, s_point) { }
            public override void Draw(PictureBox pBox, Pen pen, Brush brush)
            {
                Graphics g = Graphics.FromImage(picture);
                int x = Math.Min(this.point1.X, this.point2.X),
                y = Math.Min(this.point1.Y, this.point2.Y),
                w = Math.Abs(this.point1.X - this.point2.X),
                h = Math.Abs(this.point1.Y - this.point2.Y);
                g.FillEllipse(brush, x, y, w, h);
                g.DrawEllipse(pen, x, y, w, h);
                pBox.Refresh();
            }
        }
        private class PieObj : Shape
        {
            public float start_angle, slice_angle;
            public PieObj(Point f_point, Point s_point, float start_angle, float slice_angle)
                : base(f_point, s_point)
            {
                this.start_angle = start_angle;
                this.slice_angle = slice_angle;
            }
            public override void Draw(PictureBox pBox, Pen pen, Brush brush)
            {
                Graphics g = Graphics.FromImage(picture);
                int
                x = Math.Min(this.point1.X, this.point2.X),
                y = Math.Min(this.point1.Y, this.point2.Y),
                w = Math.Abs(this.point1.X - this.point2.X),
                h = Math.Abs(this.point1.Y - this.point2.Y);
                float a1 = start_angle, a2 = start_angle+slice_angle;
                if (this.point2.Y<this.point1.Y)
                {
                    a1 = this.MirrorV(a1);
                    a2 = this.MirrorV(a2);
                    float t = a1;
                    a1 = a2;
                    a2 = t;
                }
                if (this.point2.X < this.point1.X)
                {
                    a1 = this.MirrorH(a1);
                    a2 = this.MirrorH(a2);
                    float t = a1;
                    a1 = a2;
                    a2 = t;
                }
                if (slice_angle != 0 && w!=0 && h!=0)
                {
                    g.FillPie(brush, x, y, w, h, a1, slice_angle);
                    g.DrawPie(pen, x, y, w, h, a1, slice_angle);
                }
                pBox.Refresh();
            }

            private float MirrorH(float angle)
            {
                if (angle<180)
                    return 180 - angle;
                else
                    return angle = 540 - angle;
            }
            private float MirrorV(float angle)
            {
                return 360 - angle;
            }
        }
    }
}