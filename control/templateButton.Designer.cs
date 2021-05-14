
namespace mediaController.control
{
  partial class TemplateButton
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
      // TemplateButton
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Lime;
      this.BackgroundImage = global::mediaController.Properties.Resources.emptyBasic;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.DoubleBuffered = true;
      this.Name = "TemplateButton";
      this.Size = new System.Drawing.Size(30, 30);
      this.SizeChanged += new System.EventHandler(this.UserControlSizeChanged);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserControlPaint);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserControlMouseDown);
      this.MouseEnter += new System.EventHandler(this.UserControlMouseHover);
      this.MouseLeave += new System.EventHandler(this.UserControlMouseLeave);
      this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UserControlMouseUp);
      this.ResumeLayout(false);

    }

    #endregion
  }
}
