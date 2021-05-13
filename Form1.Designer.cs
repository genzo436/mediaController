
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
      this.playPauseButton1 = new mediaController.control.PlayPauseButton();
      this.prevButton1 = new mediaController.control.PrevButton();
      this.button1 = new System.Windows.Forms.Button();
      this.volumeControl1 = new mediaController.control.VolumeControl();
      this.SuspendLayout();
      // 
      // notifyIcon
      // 
      this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
      this.notifyIcon.Text = "text to change";
      this.notifyIcon.Visible = true;
      this.notifyIcon.Click += new System.EventHandler(this.NotifyIconClick);
      // 
      // playPauseButton1
      // 
      this.playPauseButton1.BackColor = System.Drawing.SystemColors.Control;
      this.playPauseButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("playPauseButton1.BackgroundImage")));
      this.playPauseButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.playPauseButton1.Location = new System.Drawing.Point(182, 12);
      this.playPauseButton1.Name = "playPauseButton1";
      this.playPauseButton1.Size = new System.Drawing.Size(38, 38);
      this.playPauseButton1.TabIndex = 3;
      this.playPauseButton1.Click += new System.EventHandler(this.PlayPauseButton1Click);
      // 
      // prevButton1
      // 
      this.prevButton1.BackColor = System.Drawing.SystemColors.Control;
      this.prevButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("prevButton1.BackgroundImage")));
      this.prevButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.prevButton1.Location = new System.Drawing.Point(138, 12);
      this.prevButton1.Name = "prevButton1";
      this.prevButton1.Size = new System.Drawing.Size(38, 38);
      this.prevButton1.TabIndex = 4;
      this.prevButton1.Click += new System.EventHandler(this.PrevButton1Click);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(209, 144);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(94, 29);
      this.button1.TabIndex = 5;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // volumeControl1
      // 
      this.volumeControl1.BackColor = System.Drawing.SystemColors.Control;
      this.volumeControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("volumeControl1.BackgroundImage")));
      this.volumeControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.volumeControl1.Location = new System.Drawing.Point(241, 12);
      this.volumeControl1.Name = "volumeControl1";
      this.volumeControl1.Size = new System.Drawing.Size(52, 52);
      this.volumeControl1.TabIndex = 6;
      this.volumeControl1.Value = 0;
      this.volumeControl1.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.button1_Click_1);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(615, 353);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.prevButton1);
      this.Controls.Add(this.playPauseButton1);
      this.Controls.Add(this.volumeControl1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.TransparencyKey = System.Drawing.Color.DimGray;
      this.Resize += new System.EventHandler(this.Form1Resize);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.NotifyIcon notifyIcon;
    private control.PlayPauseButton playPauseButton1;
    private control.PrevButton prevButton1;
    private System.Windows.Forms.Button button1;
    private control.VolumeControl volumeControl1;
  }
}

