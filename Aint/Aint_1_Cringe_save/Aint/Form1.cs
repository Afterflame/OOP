﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Json;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;
namespace Aint
{
    public partial class Form1 : Form
    {
        static Pen[] presetPens;
        static Brush[] presetBrushes;
        static ViewPoint viewport;
        static Bitmap picture;
        static Color mainColor, offColor, bonusColor;
        static Tool curTool;
        static int bId = 0;
        static CurBrush curBrush;
        static Brush cur_brush;
        static Pen cur_pen;
        static List<Shape> shapes;
        private class CurBrush
        {
            public Color color1, color2;
            public int id;
            public CurBrush(Color color1, Color color2, int id)
            {
                this.color1 = color1;
                this.color2 = color2;
                this.id = id;
            }
            public Brush GetBrush()
            {
                switch (bId) 
                {
                    case 1: return new SolidBrush(color1);
                    case 2:return new System.Drawing.Drawing2D.HatchBrush(
                System.Drawing.Drawing2D.HatchStyle.Cross,
                bonusColor, offColor);
                    case 3:return new System.Drawing.Drawing2D.HatchBrush(
                  System.Drawing.Drawing2D.HatchStyle.LargeConfetti,
                  bonusColor, offColor);
                    default:
                        return new SolidBrush(Color.Transparent);
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
        public void addTB(TrackBar TB)
        {
            this.Controls.Add(TB);
        }
        public void FillPrePens(Pen[] pens, int size)
        {
            for (int i = 0; i < size; i++)
            {
                pens[i] = new Pen(Color.Black, 1);
            }
            pens[0].StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pens[0].EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pens[0].LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            pens[1].DashStyle = System.Drawing.Drawing2D.DashStyle.Solid; 
            ///
            pens[1].StartCap = System.Drawing.Drawing2D.LineCap.Flat;
            pens[1].EndCap = System.Drawing.Drawing2D.LineCap.Flat;
            pens[1].LineJoin = System.Drawing.Drawing2D.LineJoin.Miter;
            pens[1].DashStyle = System.Drawing.Drawing2D.DashStyle.Dash; 
            ///
            pens[2].StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pens[2].EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pens[2].LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
            pens[2].DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot; 
            ///
            pens[3].StartCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;
            pens[3].EndCap = System.Drawing.Drawing2D.LineCap.Triangle;
            pens[3].LineJoin = System.Drawing.Drawing2D.LineJoin.MiterClipped;
            pens[3].DashStyle = System.Drawing.Drawing2D.DashStyle.Dot; 
            ///
            pens[4].StartCap = System.Drawing.Drawing2D.LineCap.Square;
            pens[4].EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            pens[4].LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            pens[4].DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot; 
        }
        public Form1()
        {
            InitializeComponent();
            presetPens = new Pen[5];
            FillPrePens(presetPens, 5);
            shapes = new List<Shape> { };
            fillPresetBrushes();
            viewport = new ViewPoint(new Point(0, 0), 1);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            picture = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            mainColor = mainColorBut.BackColor;
            offColor = offColorBut.BackColor;
            bonusColor = bonusColorBut.BackColor;
            cur_pen = (Pen)presetPens[0].Clone();
            curBrush = new CurBrush(Color.Transparent, Color.Transparent, 0);
            cur_brush = (Brush)presetBrushes[0].Clone();
            curTool = new Bruh(pictureBox1, this);
        }
        public void refreshBrushImg(ToolStripMenuItem tsmi, Brush brush)
        {
            Graphics g = Graphics.FromImage(tsmi.Image);
                g.FillRectangle(Brushes.White, 1, 1, tsmi.Image.Width - 2, tsmi.Image.Height - 2);
                g.DrawRectangle(Pens.Red, 1, 1, tsmi.Image.Width - 2, tsmi.Image.Height - 2);
                g.DrawLine(Pens.Red, 1, 1, tsmi.Image.Width - 2, tsmi.Image.Height - 2);
                g.DrawLine(Pens.Red, tsmi.Image.Width - 1, 1, 1, tsmi.Image.Height - 2);
                g.FillRectangle(brush, 1, 1, tsmi.Image.Width - 2, tsmi.Image.Height - 2);
                g.DrawRectangle(Pens.Black, 1, 1, tsmi.Image.Width - 2, tsmi.Image.Height - 2);
            
        }
        public void fillPresetBrushes()
        {
            presetBrushes = new Brush[4];
            presetBrushes[0] = (Brush)Brushes.Transparent.Clone();
            presetBrushes[1] = new SolidBrush(offColor);
            presetBrushes[2] = new System.Drawing.Drawing2D.HatchBrush(
                System.Drawing.Drawing2D.HatchStyle.Cross,
                bonusColor, offColor);
            presetBrushes[3] = new System.Drawing.Drawing2D.HatchBrush(
                System.Drawing.Drawing2D.HatchStyle.LargeConfetti,
                bonusColor, offColor);
        }
        public void refreshBrushes()
        {
            curTool.brush = (Brush)cur_brush.Clone();
            fillPresetBrushes();
            refreshBrushImg(toolStripMenuItem6, cur_brush);
            refreshBrushImg(toolStripMenuItem7, presetBrushes[0]);
            refreshBrushImg(toolStripMenuItem8, presetBrushes[1]);
            refreshBrushImg(toolStripMenuItem9, presetBrushes[2]);
            refreshBrushImg(toolStripMenuItem10, presetBrushes[3]);
            menuStrip2.Refresh();
        }        
        public void changeBrush(Brush brush)
        {
            cur_brush = (Brush)brush.Clone();
            curBrush.id = bId;
            curBrush.color1 = offColor;
            curBrush.color2 = bonusColor;
            curTool.brush = (Brush)brush.Clone();
            refreshBrushes();
        }
        public void refreshPens()
        {
            curTool.pen = (Pen)cur_pen.Clone();
            refreshPen(toolStripMenuItem0, cur_pen);
            refreshPen(toolStripMenuItem1, presetPens[0]);
            refreshPen(toolStripMenuItem2, presetPens[1]);
            refreshPen(toolStripMenuItem3, presetPens[2]);
            refreshPen(toolStripMenuItem4, presetPens[3]);
            refreshPen(toolStripMenuItem5, presetPens[4]);
            menuStrip3.Refresh();
        }
        public void refreshPen(ToolStripMenuItem tsmi, Pen pen)
        {
            int tempW = (int)cur_pen.Width;
            pen.Width = Math.Max(2,cur_pen.Width);
            pen.Color = cur_pen.Color;
            Graphics g = Graphics.FromImage(tsmi.Image);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, tsmi.Image.Width, tsmi.Image.Height);
            g.DrawLine(pen, tsmi.Image.Width / 12, tsmi.Image.Height / 2, tsmi.Image.Width * 11 / 12, tsmi.Image.Height / 2);
            pen.Width = tempW;
        }
        public void changePen(Pen pen)
        {
            cur_pen = (Pen)pen.Clone();
            curTool.pen = (Pen)pen.Clone();
            refreshPens();
        }
        public void SaveJson(string fname)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            string json = JsonConvert.SerializeObject(shapes, settings);
            File.WriteAllText(fname, json);
        }
        public void LoadJson(string fname)
        {
            string json = File.ReadAllText(fname);
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            shapes.Clear();
            shapes = JsonConvert.DeserializeObject<List<Shape>>(json, settings);
            viewport.scale = 1;
            viewport.offset = new Point(0, 0);
            Graphics g = Graphics.FromImage(picture);
            g.Clear(Color.White);
            foreach(Shape shape in shapes)
            {
                shape.Draw(pictureBox1);
            }
        }
    }
}
