
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace mediaController
{
  partial class Form1
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    /// 

    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.volumeControl1 = new mediaController.control.VolumeControl();
      this.playButton = new mediaController.control.TemplateButton();
      this.prevButton = new mediaController.control.TemplateButton();
      this.nextButton = new mediaController.control.TemplateButton();
      this.minimizeButton = new mediaController.control.TemplateButton();
      this.closeButton = new mediaController.control.TemplateButton();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // notifyIcon
      // 
      this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
      this.notifyIcon.Text = "text to change";
      this.notifyIcon.Visible = true;
      this.notifyIcon.Click += new System.EventHandler(this.NotifyIconClick);
      // 
      // volumeControl1
      // 
      this.volumeControl1.BackColor = System.Drawing.Color.Black;
      this.volumeControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("volumeControl1.BackgroundImage")));
      this.volumeControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.volumeControl1.Location = new System.Drawing.Point(45, 37);
      this.volumeControl1.Muted = false;
      this.volumeControl1.Name = "volumeControl1";
      this.volumeControl1.Size = new System.Drawing.Size(50, 50);
      this.volumeControl1.TabIndex = 6;
      this.volumeControl1.Value = 0;
      this.volumeControl1.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.VolumeControlChanged);
      // 
      // playButton
      // 
      this.playButton.BackColor = System.Drawing.Color.Black;
      this.playButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("playButton.BackgroundImage")));
      this.playButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.playButton.Location = new System.Drawing.Point(145, 49);
      this.playButton.Name = "playButton";
      this.playButton.Size = new System.Drawing.Size(38, 38);
      this.playButton.TabIndex = 7;
      this.playButton.Click += new System.EventHandler(this.PlayButtonClick);
      // 
      // prevButton
      // 
      this.prevButton.BackColor = System.Drawing.Color.Black;
      this.prevButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("prevButton.BackgroundImage")));
      this.prevButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.prevButton.Location = new System.Drawing.Point(101, 49);
      this.prevButton.Name = "prevButton";
      this.prevButton.Size = new System.Drawing.Size(38, 38);
      this.prevButton.TabIndex = 8;
      this.prevButton.Click += new System.EventHandler(this.PrevButtonClick);
      // 
      // nextButton
      // 
      this.nextButton.BackColor = System.Drawing.Color.Black;
      this.nextButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("nextButton.BackgroundImage")));
      this.nextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.nextButton.Location = new System.Drawing.Point(189, 49);
      this.nextButton.Name = "nextButton";
      this.nextButton.Size = new System.Drawing.Size(38, 38);
      this.nextButton.TabIndex = 10;
      this.nextButton.Click += new System.EventHandler(this.NextButtonClick);
      // 
      // minimizeButton
      // 
      this.minimizeButton.BackColor = System.Drawing.Color.Black;
      this.minimizeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("minimizeButton.BackgroundImage")));
      this.minimizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.minimizeButton.Location = new System.Drawing.Point(186, 32);
      this.minimizeButton.Name = "minimizeButton";
      this.minimizeButton.Size = new System.Drawing.Size(15, 15);
      this.minimizeButton.TabIndex = 11;
      this.minimizeButton.Click += new System.EventHandler(this.MinimizeButtonClick);
      // 
      // closeButton
      // 
      this.closeButton.BackColor = System.Drawing.Color.Black;
      this.closeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("closeButton.BackgroundImage")));
      this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.closeButton.Location = new System.Drawing.Point(206, 32);
      this.closeButton.Name = "closeButton";
      this.closeButton.Size = new System.Drawing.Size(15, 15);
      this.closeButton.TabIndex = 12;
      this.closeButton.Click += new System.EventHandler(this.CloseButtonClick);
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackgroundImage = global::mediaController.Properties.Resources.baseSimple;
      this.pictureBox1.Location = new System.Drawing.Point(0, -1);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(285, 106);
      this.pictureBox1.TabIndex = 13;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMouseDown);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Lime;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.ClientSize = new System.Drawing.Size(362, 170);
      this.ControlBox = false;
      this.Controls.Add(this.closeButton);
      this.Controls.Add(this.minimizeButton);
      this.Controls.Add(this.nextButton);
      this.Controls.Add(this.prevButton);
      this.Controls.Add(this.playButton);
      this.Controls.Add(this.volumeControl1);
      this.Controls.Add(this.pictureBox1);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.TopMost = true;
      this.TransparencyKey = System.Drawing.Color.Transparent;
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMouseDown);
      this.Resize += new System.EventHandler(this.Form1Resize);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.NotifyIcon notifyIcon;
    private control.VolumeControl volumeControl1;
    private control.TemplateButton playButton;
    private control.TemplateButton prevButton;
    private control.TemplateButton nextButton;
    private control.TemplateButton minimizeButton;
    private control.TemplateButton closeButton;
    private System.Windows.Forms.PictureBox pictureBox1;
  }
}

