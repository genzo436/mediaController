using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace mediaController.control
{
  public partial class TemplateButton : UserControl
  {
    enum Status { INACTIVE, SELECTED, CLICKED };
    Status status;

    public Bitmap[] statusImages =
    {
      new Bitmap(Properties.Resources.emptyBasic),
      new Bitmap(Properties.Resources.emptySelected),
      new Bitmap(Properties.Resources.emptyClicked),
    };
    public TemplateButton()
    {
      InitializeComponent();
      InitializeInternals();
    }
    private void InitializeInternals()
    {
      status = Status.INACTIVE;
      this.SetStyle(ControlStyles.StandardClick, true);
      this.SetStyle(ControlStyles.StandardDoubleClick, false);
      SetControlRegion();
    }
    internal void SetImages(Bitmap inactive, Bitmap selected, Bitmap clicked)
    {
      statusImages[(int)Status.INACTIVE] = new Bitmap(inactive);
      statusImages[(int)Status.SELECTED] = new Bitmap(selected);
      statusImages[(int)Status.CLICKED] = new Bitmap(clicked);
    }
    private void SetControlRegion()
    {
      // TODO: change code for any shape, might be possible with collor mapping
      GraphicsPath grPath = new GraphicsPath();
      grPath.AddEllipse(0, 0, this.Size.Width, this.Size.Height);
      this.Region = new System.Drawing.Region(grPath);
    }
    private void UserControlMouseHover(object sender, EventArgs e)
    {
      status = Status.SELECTED;
      this.Invalidate();
    }
    private void UserControlMouseDown(object sender, MouseEventArgs e)
    {
      status = Status.CLICKED;
      this.Invalidate();
    }
    private void UserControlMouseLeave(object sender, EventArgs e)
    {
      status = Status.INACTIVE;
      this.Invalidate();
    }
    private void UserControlMouseUp(object sender, MouseEventArgs e)
    {
      status = Status.SELECTED;
      this.Invalidate();
    }
    private void UserControlSizeChanged(object sender, EventArgs e)
    {
      SetControlRegion();
    }
    private void UserControlPaint(object sender, PaintEventArgs e)
    {
      DrawBackground(e, statusImages[(int)status]);
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
