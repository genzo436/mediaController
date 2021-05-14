using mediaController.Classes;
using System;
using System.Collections.Generic;
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
      BorderFinder borderFinder = new BorderFinder();
      List<Point[]> borderPoints = borderFinder.Find(statusImages[(int)Status.INACTIVE]);

      Matrix scaleMatrix = new Matrix();
      scaleMatrix.Scale(
        1.0F * this.Size.Width / statusImages[(int)Status.INACTIVE].Width,
        1.0F * this.Size.Height / statusImages[(int)Status.INACTIVE].Height
      );
      GraphicsPath grPath = new GraphicsPath();
      foreach (Point[] p in borderPoints)
      {
        grPath.AddPolygon(p);
      }
      grPath.Transform(scaleMatrix);
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
