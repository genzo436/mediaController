using mediaController.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace mediaController.control
{
  public partial class VolumeControl : UserControl, INotifyPropertyChanged
  {
    const int MAX_VALUE = 100;
    const int MIN_VALUE = 0;

    static readonly Bitmap[] imgInactive = {
      new Bitmap(Properties.Resources._0basic),
      new Bitmap(Properties.Resources._1basic),
      new Bitmap(Properties.Resources._2basic),
      new Bitmap(Properties.Resources._3basic),
    };
    static readonly Bitmap[] imgSelected = {
      new Bitmap(Properties.Resources._0preSelected),
      new Bitmap(Properties.Resources._1preSelected),
      new Bitmap(Properties.Resources._2preSelected),
      new Bitmap(Properties.Resources._3preSelected),
    };
    static readonly Bitmap[] imgClicked = {
      new Bitmap(Properties.Resources._0clicked),
      new Bitmap(Properties.Resources._1clicked),
      new Bitmap(Properties.Resources._2clicked),
      new Bitmap(Properties.Resources._3clicked),
    };
    private readonly Bitmap[][] buttonStatus = { imgInactive, imgSelected, imgClicked };

    int value;
    private bool muted;
    enum Status { INACTIVE, SELECTED, CLICKED }
    Status status;

    Pen pen;
    Rectangle rectangle;
    Color valueColor = Color.Green;
    
    bool mouseMoved;
    Point cursorInit;
    bool changingValue;
    int originalValue;

    public int Value { get => value; 
      set {
        if (value < MIN_VALUE) { this.value = MIN_VALUE; }
        else if (value > MAX_VALUE) { this.value = MAX_VALUE; }
        else { this.value = value; }
      } 
    }

    public bool Muted { get => muted; set => muted = value; }

  public VolumeControl()
    {
      InitializeComponent();
      status = Status.INACTIVE;
      this.SetStyle(ControlStyles.StandardClick, true);
      this.SetStyle(ControlStyles.StandardDoubleClick, false);
      InitializeExternalVariables();
    }

    private void InitializeExternalVariables()
    {
      // TODO: change code for any shape, might be possible with collor mapping
      setRegion();
      Muted = false;
      pen = new Pen(valueColor, Math.Max(this.Size.Width,this.Size.Height)*0.08F);
      rectangle = new Rectangle(2, 2, this.Size.Width - 4, this.Size.Height - 4);
    }

    public void setRegion()
    {
      BorderFinder borderFinder = new BorderFinder();
      List<Point[]> borderPoints = borderFinder.Find(buttonStatus[0][0]);

      Matrix scaleMatrix = new Matrix();
      scaleMatrix.Scale(
        1.0F * this.Size.Width / buttonStatus[0][0].Width,
        1.0F * this.Size.Height / buttonStatus[0][0].Height
      );
      GraphicsPath grPath = new GraphicsPath();
      foreach (Point[] p in borderPoints)
      {
        grPath.AddPolygon(p);
      }
      grPath.Transform(scaleMatrix);
      this.Region = new System.Drawing.Region(grPath);
    }
    private void UserControl1_MouseHover(object sender, EventArgs e)
    {
      status = Status.SELECTED;
      this.Invalidate(this.Region);
    }
    private void UserControl1_MouseDown(object sender, MouseEventArgs e)
    {
      mouseMoved = false;
      originalValue = value;
      changingValue = true;
      cursorInit = Cursor.Position;

      status = Status.CLICKED;
      this.Invalidate(this.Region);
    }
    private void UserControl1_MouseLeave(object sender, EventArgs e)
    {

      status = Status.INACTIVE;
      this.Invalidate(this.Region);
    }
    private void UserControl1_MouseUp(object sender, MouseEventArgs e)
    {
      status = Status.SELECTED;
      this.Invalidate(this.Region);
      changingValue = false;
    }
    private void UserControl1_SizeChanged(object sender, EventArgs e)
    {
      InitializeExternalVariables();
    }
    public int SetValue(int volume)
    {
      
      this.Value = volume;
      return this.Value;
    }

    private void UpdateGraphics(Graphics g)
    {
      int statusOptions = buttonStatus[(int)status].Length - 1;
      double volume = muted ? 0 : Math.Ceiling(1.0 * value * statusOptions / MAX_VALUE);
      Bitmap statusImage = buttonStatus[(int)status][(int)volume];
      g.DrawImage(
        statusImage,
        new Rectangle(0, 0, this.Size.Width, this.Size.Height),
        new Rectangle(0, 0, statusImage.Width, statusImage.Height),
        GraphicsUnit.Pixel
      );
      g.DrawArc(pen, rectangle, 0, ScaleVolumeToFullCircle());
    }

    private float ScaleVolumeToFullCircle()
    {
      return -((float)Value / MAX_VALUE * 360);
    }

    private void VolumeControl_Paint(object sender, PaintEventArgs e)
    {
      UpdateGraphics(e.Graphics);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    private void VolumeControl_MouseMove(object sender, MouseEventArgs e)
    {
      if (!changingValue)
      {
        return;
      }
      mouseMoved = true;
      int valueVariation = Cursor.Position.X - cursorInit.X;
      this.Value = originalValue + valueVariation;
      NotifyPropertyChanged("value");
      this.Invalidate(this.Region);
    }

    private void VolumeControl_Click(object sender, EventArgs e)
    {
      if (!mouseMoved)
      {
        muted = !muted;
        NotifyPropertyChanged("muted");
      }
      this.Invalidate(this.Region);
    }
  }
}
