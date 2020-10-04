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
        private class Tool
        {
            protected Form1 form1;
            protected Bitmap initialBM;
            public Pen pen;
            public Brush brush;
            protected Point start_p;
            protected PictureBox pBox;
            public Tool(PictureBox pBoxIn, Form1 F1)
            {
                form1 = F1;
                this.pen = (Pen)cur_pen.Clone();
                this.brush = (Brush)cur_brush.Clone();
                this.pBox = pBoxIn;
            }

            public virtual void MouseDown(Point cur_p)
            {
            }
            public virtual void MouseDown_Move(Point cur_p)
            {
            }

            public virtual void RightClick(Point cur_p)
            {
            }
            public virtual void MouseUp(Point cur_p)
            {
            }
            public virtual void CallClear()
            {
            }
            public void Store()
            {
                RectangleF cloneRect = new RectangleF(0, 0, picture.Width, picture.Height);
                System.Drawing.Imaging.PixelFormat format = picture.PixelFormat;
                initialBM = picture.Clone(cloneRect, format);
            }
            public void Restore()
            {
                RectangleF cloneRect = new RectangleF(0, 0, initialBM.Width, initialBM.Height);
                System.Drawing.Imaging.PixelFormat format = initialBM.PixelFormat;
                picture = initialBM.Clone(cloneRect, format);
            }
            public virtual void CreateProps()
            {
            }
        }
        private class SinglePointTool : Tool
        {
            public SinglePointTool(PictureBox pBoxIn, Form1 F1)
                : base(pBoxIn, F1)
            {

            }
            public override void MouseDown_Move(Point cur_p)
            {
            }
            public override void MouseDown(Point cur_p)
            {
            }
            public override void CallClear()
            {
            }
        }
        private class Bruh : SinglePointTool
        {
            public Bruh(PictureBox pBoxIn, Form1 F1)
                : base(pBoxIn, F1)
            {
            }
            public override void MouseDown_Move(Point cur_p)
            {
                this.Draw(this.pen, this.brush, start_p, cur_p);
                this.start_p = cur_p;
            }
            public override void MouseDown(Point cur_p)
            {
                this.Store();
                this.start_p = cur_p;
                this.Draw(this.pen, this.brush, start_p, cur_p);
            }
            private void Draw(Pen pen, Brush brush, Point p1, Point p2)
            {
                Shape shape = new LineObj(p1, p2);
                shape.Draw(this.pBox, this.pen, this.brush);
            }
        }
        private class Lupa1p : SinglePointTool
        {
            public Lupa1p(PictureBox pBoxIn, Form1 F1)
                : base(pBoxIn, F1)
            {

            }
            public override void MouseDown(Point cur_p)
            {
                {
                    this.Store();
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
        private class Hand : SinglePointTool
        {
            public Hand(PictureBox pBoxIn, Form1 F1)
                : base(pBoxIn, F1)
            {
            }
            public override void MouseDown(Point cur_p)
            {
                this.Store();
                this.start_p = cur_p;
                int maxOffsetX = picture.Width - picture.Width / viewport.scale, maxOffsetY = picture.Height - picture.Height / viewport.scale;
                int changeX = start_p.X - cur_p.X;
                int changeY = start_p.Y - cur_p.Y;
                viewport.offset.X = Math.Max(0, Math.Min(maxOffsetX, viewport.offset.X + changeX / 2));
                viewport.offset.Y = Math.Max(0, Math.Min(maxOffsetY, viewport.offset.Y + changeY / 2));
                pBox.Refresh();
            }
            public override void MouseDown_Move(Point cur_p)
            {
                int maxOffsetX = picture.Width - picture.Width / viewport.scale, maxOffsetY = picture.Height - picture.Height / viewport.scale;
                int changeX = start_p.X - cur_p.X;
                int changeY = start_p.Y - cur_p.Y;
                viewport.offset.X = Math.Max(0, Math.Min(maxOffsetX, viewport.offset.X + changeX / 2));
                viewport.offset.Y = Math.Max(0, Math.Min(maxOffsetY, viewport.offset.Y + changeY / 2));
                this.start_p = cur_p;
                pBox.Refresh();
            }
        }
        private class DoublePointTool : Tool
        {
            public DoublePointTool(PictureBox pBoxIn, Form1 F1)
                : base(pBoxIn, F1)
            {
            }
            public override void MouseDown(Point cur_p)
            {
            }
            public override void MouseDown_Move(Point cur_p)
            {
            }
            public override void MouseUp(Point cur_p)
            {
            }
            public override void CreateProps()
            {
            }
            public override void CallClear()
            {
            }
        }
        private class Liner : DoublePointTool
        {
            public Liner(PictureBox pBoxIn, Form1 F1)
                : base(pBoxIn, F1)
            {
            }
            public override void MouseDown(Point cur_p)
            {
                this.Store();
                this.start_p = cur_p;
                shape = new LineObj(this.start_p, start_p);
                shape.point2 = cur_p;
                shape.Draw(this.pBox, this.pen, this.brush);
            }
            public override void MouseDown_Move(Point cur_p)
            {
                this.Restore();
                shape.point2 = cur_p;
                shape.Draw(this.pBox, this.pen, this.brush);
            }
        }
        private class RectTool : DoublePointTool
        {
            public RectTool(PictureBox pBoxIn, Form1 F1)
                : base(pBoxIn, F1)
            {
            }
            public override void MouseDown(Point cur_p)
            {
                this.Store();
                this.start_p = cur_p;
                shape = new RectangleObj(this.start_p, start_p);
                shape.point2 = cur_p;
                shape.Draw(this.pBox, this.pen, this.brush);
            }
            public override void MouseDown_Move(Point cur_p)
            {
                this.Restore();
                shape.point2 = cur_p;
                shape.Draw(this.pBox, this.pen, this.brush);
            }
        }
        private class EllipseTool : DoublePointTool
        {
            public EllipseTool(PictureBox pBoxIn, Form1 F1)
                : base(pBoxIn, F1)
            {
            }
            public override void MouseDown(Point cur_p)
            {
                this.Store();
                this.start_p = cur_p;
                shape = new EllipseObj(this.start_p, start_p);
                shape.point2 = cur_p;
                shape.Draw(this.pBox, this.pen, this.brush);
            }
            public override void MouseDown_Move(Point cur_p)
            {
                this.Restore();
                shape.point2 = cur_p;
                shape.Draw(this.pBox, this.pen, this.brush);
            }
        }
        private class Lupa2p : DoublePointTool
        {
            Point second_point;
            double scaling;
            bool boxIsValid;
            public Lupa2p(PictureBox pBoxIn, Form1 F1)
                : base(pBoxIn, F1)
            {
                this.pen = new Pen(Color.Black, 1);
                pen.LineJoin = System.Drawing.Drawing2D.LineJoin.MiterClipped;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
                pen.StartCap = System.Drawing.Drawing2D.LineCap.Flat;
            }
            public override void MouseDown(Point cur_p)
            {
                this.Store();
                this.start_p = cur_p;
                Act(cur_p);
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
            public override void MouseDown_Move(Point cur_p)
            {
                 Act(cur_p);
            }
            void Act(Point cur_p)
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
                if (boxIsValid && cur_p != start_p)
                {
                    this.Restore();
                    new RectangleObj(this.start_p, second_point).Draw(this.pBox, this.pen, this.brush);
                }
                else
                    this.Restore();
                pBox.Refresh();
            }
        }
        private class PieTool : DoublePointTool
        {
            PropTrackBar angleTB1, angleTB2;
            public PieTool(PictureBox pBoxIn, Form1 F1)
                : base(pBoxIn, F1)
            {
                CreateProps();
            }
            public override void MouseDown(Point cur_p)
            {
                this.Store();
                this.start_p = cur_p;
                shape = new PieObj(this.start_p, start_p, (float)(360 / angleTB1.max_v * angleTB1.value), (float)(360 / angleTB2.max_v * angleTB2.value));
                shape.point2 = cur_p;
                shape.Draw(this.pBox, this.pen, this.brush);
            }
            public override void MouseDown_Move(Point cur_p)
            {
                this.Restore();
                shape.point2 = cur_p;
                shape.Draw(this.pBox, this.pen, this.brush);
            }
            public override void CreateProps()
            {
                angleTB1 = new PropTrackBar(60, 3, 0, 40, 0, form1);
                angleTB2 = new PropTrackBar(105, 3, 0, 40, 10, form1);
            }
            public override void CallClear()
            {
                angleTB1.ClearBar();
                angleTB2.ClearBar();
            }
        }
        private class PropTrackBar
        {
            TrackBar propTrackBarObj;
            public int value = 0, min_v, max_v;
            Form1 f1;
            public PropTrackBar(int x, int y, int min_value, int max_value, int start_value, Form1 form1)
            {
                f1 = form1;
                this.value = start_value; 
                this.min_v = min_value; 
                this.max_v = max_value;
                this.propTrackBarObj = new TrackBar();
                this.propTrackBarObj.Location = new Point(x, y);
                this.propTrackBarObj.Margin = new Padding(3,3,3,3);
                this.propTrackBarObj.Size = new System.Drawing.Size(45, 91);
                this.propTrackBarObj.Scroll += new System.EventHandler(this.propTrackBarObj_Scroll);
                this.propTrackBarObj.Minimum = min_value;
                this.propTrackBarObj.Maximum = max_value;
                this.propTrackBarObj.Value = start_value;
                this.propTrackBarObj.Orientation = Orientation.Vertical;
                this.propTrackBarObj.TickFrequency = max_value / 7;
                this.propTrackBarObj.LargeChange = max_value / 4;
                this.propTrackBarObj.SmallChange = 1;
                form1.panel1.Controls.Add(propTrackBarObj);
            }
            public void ClearBar()
            {
                f1.panel1.Controls.Remove(propTrackBarObj);
            }
            private void propTrackBarObj_Scroll(object sender, System.EventArgs e)
            {
                this.value = this.propTrackBarObj.Value;
            }
        }
    }
}