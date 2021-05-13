using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace mediaController.control
{
  public partial class PlayPauseButton : UserControl
  {
    enum Status {INACTIVE,SELECTED,CLICKED};
    Status status;
    public PlayPauseButton()
    {
      InitializeComponent();
      status = Status.INACTIVE;
      this.SetStyle(ControlStyles.StandardClick, true);
      this.SetStyle(ControlStyles.StandardDoubleClick, false);
      SetRegion();
    }

    private void SetRegion()
    {
      // TODO: change code for any shape, might be possible with collor mapping
      GraphicsPath grPath = new GraphicsPath();
      grPath.AddEllipse(0, 0, this.Size.Width, this.Size.Height);
      this.Region = new System.Drawing.Region(grPath);
    }
    private void UserControl1_MouseHover(object sender, EventArgs e)
    {
      status = Status.SELECTED;
      this.Invalidate();
    }
    private void UserControl1_MouseDown(object sender, MouseEventArgs e)
    {
      status = Status.CLICKED;
      this.Invalidate();
    }
    private void UserControl1_MouseLeave(object sender, EventArgs e)
    {
      status = Status.INACTIVE;
      this.Invalidate();
    }
    private void UserControl1_MouseUp(object sender, MouseEventArgs e)
    {
      status = Status.SELECTED;
      this.Invalidate();
    }
    private void UserControl1_SizeChanged(object sender, EventArgs e)
    {
      SetRegion();
    }

    private void PlayPauseButton_Paint(object sender, PaintEventArgs e)
    {
      switch (status)
      {
        case Status.CLICKED:
          {
            DrawBackground(e, global::mediaController.Properties.Resources.play2Clicked);
          }
          break;
        case Status.SELECTED:
          {
            DrawBackground(e, global::mediaController.Properties.Resources.play2Preselect);
          }
          break;
        default:
          {
            DrawBackground(e, global::mediaController.Properties.Resources.play2Basic);
          }
          break;
      }
    }

    private void DrawBackground(PaintEventArgs e, Bitmap image)
    {
      e.Graphics.DrawImage(
       image,
       new Rectangle(0, 0, this.Size.Width, this.Size.Height),
       new Rectangle(0, 0, image.Width, image.Height),
       GraphicsUnit.Pixel
     );
    }
  }
}
