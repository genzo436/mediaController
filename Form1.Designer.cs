
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
      this.volumeControl1.BackColor = System.Drawing.SystemColors.Control;
      this.volumeControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("volumeControl1.BackgroundImage")));
      this.volumeControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.volumeControl1.Location = new System.Drawing.Point(119, 28);
      this.volumeControl1.Muted = false;
      this.volumeControl1.Name = "volumeControl1";
      this.volumeControl1.Size = new System.Drawing.Size(50, 50);
      this.volumeControl1.TabIndex = 6;
      this.volumeControl1.Value = 0;
      this.volumeControl1.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.VolumeControlChanged);
      // 
      // playButton
      // 
      this.playButton.BackColor = System.Drawing.SystemColors.Control;
      this.playButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("playButton.BackgroundImage")));
      this.playButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.playButton.Location = new System.Drawing.Point(219, 40);
      this.playButton.Name = "playButton";
      this.playButton.Size = new System.Drawing.Size(38, 38);
      this.playButton.TabIndex = 7;
      this.playButton.Click += new System.EventHandler(this.playButton_Click);
      // 
      // prevButton
      // 
      this.prevButton.BackColor = System.Drawing.SystemColors.Control;
      this.prevButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("prevButton.BackgroundImage")));
      this.prevButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.prevButton.Location = new System.Drawing.Point(175, 40);
      this.prevButton.Name = "prevButton";
      this.prevButton.Size = new System.Drawing.Size(38, 38);
      this.prevButton.TabIndex = 8;
      this.prevButton.Click += new System.EventHandler(this.PrevButtonClick);
      // 
      // nextButton
      // 
      this.nextButton.BackColor = System.Drawing.SystemColors.Control;
      this.nextButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("nextButton.BackgroundImage")));
      this.nextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.nextButton.Location = new System.Drawing.Point(263, 40);
      this.nextButton.Name = "nextButton";
      this.nextButton.Size = new System.Drawing.Size(38, 38);
      this.nextButton.TabIndex = 10;
      this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(615, 353);
      this.Controls.Add(this.nextButton);
      this.Controls.Add(this.prevButton);
      this.Controls.Add(this.playButton);
      this.Controls.Add(this.volumeControl1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.TransparencyKey = System.Drawing.Color.DimGray;
      this.Resize += new System.EventHandler(this.Form1Resize);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.NotifyIcon notifyIcon;
    private control.VolumeControl volumeControl1;
    private control.TemplateButton playButton;
    private control.TemplateButton prevButton;
    private control.TemplateButton nextButton;
  }
}

