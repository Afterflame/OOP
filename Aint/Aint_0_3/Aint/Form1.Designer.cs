﻿namespace Aint
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lupa1pBut = new System.Windows.Forms.Button();
            this.lupa2pBut = new System.Windows.Forms.Button();
            this.rectangleButton = new System.Windows.Forms.Button();
            this.elipseButton = new System.Windows.Forms.Button();
            this.bruhButton = new System.Windows.Forms.Button();
            this.eraserButton = new System.Windows.Forms.Button();
            this.offColorBut = new System.Windows.Forms.Button();
            this.mainColorBut = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(894, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox1.Location = new System.Drawing.Point(94, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 600);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.lupa1pBut);
            this.panel1.Controls.Add(this.lupa2pBut);
            this.panel1.Controls.Add(this.rectangleButton);
            this.panel1.Controls.Add(this.elipseButton);
            this.panel1.Controls.Add(this.bruhButton);
            this.panel1.Controls.Add(this.eraserButton);
            this.panel1.Controls.Add(this.offColorBut);
            this.panel1.Controls.Add(this.mainColorBut);
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(88, 600);
            this.panel1.TabIndex = 2;
            // 
            // lupa1pBut
            // 
            this.lupa1pBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lupa1pBut.BackColor = System.Drawing.Color.AliceBlue;
            this.lupa1pBut.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lupa1pBut.BackgroundImage")));
            this.lupa1pBut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.lupa1pBut.Location = new System.Drawing.Point(46, 220);
            this.lupa1pBut.Name = "lupa1pBut";
            this.lupa1pBut.Size = new System.Drawing.Size(39, 39);
            this.lupa1pBut.TabIndex = 8;
            this.lupa1pBut.UseVisualStyleBackColor = false;
            this.lupa1pBut.Click += new System.EventHandler(this.lupa1pBut_Click);
            // 
            // lupa2pBut
            // 
            this.lupa2pBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lupa2pBut.BackColor = System.Drawing.Color.AliceBlue;
            this.lupa2pBut.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lupa2pBut.BackgroundImage")));
            this.lupa2pBut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.lupa2pBut.Location = new System.Drawing.Point(3, 220);
            this.lupa2pBut.Name = "lupa2pBut";
            this.lupa2pBut.Size = new System.Drawing.Size(39, 39);
            this.lupa2pBut.TabIndex = 7;
            this.lupa2pBut.UseVisualStyleBackColor = false;
            this.lupa2pBut.Click += new System.EventHandler(this.lupa2pBut_Click);
            // 
            // rectangleButton
            // 
            this.rectangleButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rectangleButton.BackColor = System.Drawing.Color.AliceBlue;
            this.rectangleButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rectangleButton.BackgroundImage")));
            this.rectangleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.rectangleButton.Location = new System.Drawing.Point(46, 180);
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(39, 39);
            this.rectangleButton.TabIndex = 6;
            this.rectangleButton.UseVisualStyleBackColor = false;
            this.rectangleButton.Click += new System.EventHandler(this.rectangleButton_Click);
            // 
            // elipseButton
            // 
            this.elipseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.elipseButton.BackColor = System.Drawing.Color.AliceBlue;
            this.elipseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("elipseButton.BackgroundImage")));
            this.elipseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.elipseButton.Location = new System.Drawing.Point(3, 180);
            this.elipseButton.Name = "elipseButton";
            this.elipseButton.Size = new System.Drawing.Size(39, 39);
            this.elipseButton.TabIndex = 5;
            this.elipseButton.UseVisualStyleBackColor = false;
            this.elipseButton.Click += new System.EventHandler(this.elipseButton_Click);
            // 
            // bruhButton
            // 
            this.bruhButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bruhButton.BackColor = System.Drawing.Color.AliceBlue;
            this.bruhButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bruhButton.BackgroundImage")));
            this.bruhButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bruhButton.Location = new System.Drawing.Point(46, 140);
            this.bruhButton.Name = "bruhButton";
            this.bruhButton.Size = new System.Drawing.Size(39, 39);
            this.bruhButton.TabIndex = 4;
            this.bruhButton.UseVisualStyleBackColor = false;
            this.bruhButton.Click += new System.EventHandler(this.bruhButton_Click);
            // 
            // eraserButton
            // 
            this.eraserButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.eraserButton.BackColor = System.Drawing.Color.AliceBlue;
            this.eraserButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("eraserButton.BackgroundImage")));
            this.eraserButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.eraserButton.Location = new System.Drawing.Point(3, 140);
            this.eraserButton.Name = "eraserButton";
            this.eraserButton.Size = new System.Drawing.Size(39, 39);
            this.eraserButton.TabIndex = 3;
            this.eraserButton.UseVisualStyleBackColor = false;
            this.eraserButton.Click += new System.EventHandler(this.eraserButton_Click);
            // 
            // offColorBut
            // 
            this.offColorBut.BackColor = System.Drawing.Color.White;
            this.offColorBut.Location = new System.Drawing.Point(46, 100);
            this.offColorBut.Name = "offColorBut";
            this.offColorBut.Size = new System.Drawing.Size(39, 39);
            this.offColorBut.TabIndex = 2;
            this.offColorBut.UseVisualStyleBackColor = false;
            this.offColorBut.Click += new System.EventHandler(this.ColorBut_Click);
            // 
            // mainColorBut
            // 
            this.mainColorBut.BackColor = System.Drawing.Color.Black;
            this.mainColorBut.Location = new System.Drawing.Point(3, 100);
            this.mainColorBut.Name = "mainColorBut";
            this.mainColorBut.Size = new System.Drawing.Size(39, 39);
            this.mainColorBut.TabIndex = 1;
            this.mainColorBut.UseVisualStyleBackColor = false;
            this.mainColorBut.Click += new System.EventHandler(this.ColorBut_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(3, 3);
            this.trackBar1.Maximum = 40;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 91);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickFrequency = 8;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(5, 265);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(67, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Fill Apply";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 624);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Aint v.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button offColorBut;
        private System.Windows.Forms.Button mainColorBut;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button bruhButton;
        private System.Windows.Forms.Button eraserButton;
        private System.Windows.Forms.Button rectangleButton;
        private System.Windows.Forms.Button elipseButton;
        private System.Windows.Forms.Button lupa1pBut;
        private System.Windows.Forms.Button lupa2pBut;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

