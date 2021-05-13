
namespace mediaController.control
{
  partial class PlayPauseButton
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.SuspendLayout();
      // 
      // PlayPauseButton
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.BackgroundImage = global::mediaController.Properties.Resources.play2Basic;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.DoubleBuffered = true;
      this.Name = "PlayPauseButton";
      this.Size = new System.Drawing.Size(30, 30);
      this.SizeChanged += new System.EventHandler(this.UserControl1_SizeChanged);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.PlayPauseButton_Paint);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserControl1_MouseDown);
      this.MouseEnter += new System.EventHandler(this.UserControl1_MouseHover);
      this.MouseLeave += new System.EventHandler(this.UserControl1_MouseLeave);
      this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UserControl1_MouseUp);
      this.ResumeLayout(false);

    }

    #endregion
  }
}
