using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace mediaController.control
{
  public partial class VolumeControl : UserControl , INotifyPropertyChanged
  {
    private int value;
    private bool muted;
    enum Status {CLICKED, SELECTED, INACTIVE}
    Status status;

    Pen pen;
    Rectangle rectangle;
    Color valueColor = Color.Green;

    Point cursorInit;
    bool changingValue;
    int originalValue;

    public int Value { get => value; 
      set {
        this.value = value;
        NotifyPropertyChanged();
      } 
    }

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
      GraphicsPath grPath = new GraphicsPath();
      grPath.AddEllipse(0, 0, this.Size.Width, this.Size.Height);
      this.Region = new System.Drawing.Region(grPath);
      muted = false;
      pen = new Pen(valueColor, Math.Max(this.Size.Width,this.Size.Height)*0.08F);
      rectangle = new Rectangle(2, 2, this.Size.Width - 4, this.Size.Height - 4);
    }
    private void UserControl1_MouseHover(object sender, EventArgs e)
    {
      status = Status.SELECTED;
      this.Invalidate(this.Region);
    }
    private void UserControl1_MouseDown(object sender, MouseEventArgs e)
    {
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
      if (volume < 0) { volume = 0; }
      else if (volume > 100) { volume = 100; }
      this.Value = volume;
      return this.Value;
    }

    private void UpdateGraphics(Graphics g)
    {
      Image aux;
      if (value == 0 || muted)
      {
        switch (status)
        {
          case Status.CLICKED:
            {
              aux = global::mediaController.Properties.Resources._0clicked;
            }break;
          case Status.SELECTED:
            {
              aux = global::mediaController.Properties.Resources._0preSelected;
            }
            break;
          default:
            {
              aux = global::mediaController.Properties.Resources._0basic;
            }
            break;
        }
      }
      else if (value <= 33)
      {
        switch (status)
        {
          case Status.CLICKED:
            {
              aux  = global::mediaController.Properties.Resources._1clicked;
            }
            break;
          case Status.SELECTED:
            {
              aux  = global::mediaController.Properties.Resources._1preSelected;
            }
            break;
          default:
            {
              aux = global::mediaController.Properties.Resources._1basic;
            }
            break;
        }
      }
      else if (value <= 67)
      {
        switch (status)
        {
          case Status.CLICKED:
            {
              aux = global::mediaController.Properties.Resources._2clicked;
            }
            break;
          case Status.SELECTED:
            {
              aux = global::mediaController.Properties.Resources._2preSelected;
            }
            break;
          default:
            {
              aux = global::mediaController.Properties.Resources._2basic;
            }
            break;
        }
      }
      else
      {
        switch (status)
        {
          case Status.CLICKED:
            {
              aux = global::mediaController.Properties.Resources._3clicked;
            }
            break;
          case Status.SELECTED:
            {
              aux = global::mediaController.Properties.Resources._3preSelected;
            }
            break;
          default:
            {
              aux = global::mediaController.Properties.Resources._3basic;
            }
            break;
        }
      }
      g.DrawImage(
        aux,
        new Rectangle(0, 0, this.Size.Width, this.Size.Height),
        new Rectangle(0, 0, aux.Width, aux.Height),
        GraphicsUnit.Pixel
      );
      g.DrawArc(pen, rectangle, 0, ProcessVolume());
    }

    private float ProcessVolume()
    {
      return -((float)Value / 100 * 360);
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
      Point actualPosition = Cursor.Position;
      int newValue = originalValue + (actualPosition.X - cursorInit.X);
      if (newValue < 0)
      {
        newValue = 0;
      }
      else if (newValue > 100)
      {
        newValue = 100;
      }
      this.value = newValue;
      NotifyPropertyChanged();
      this.Invalidate(this.Region);
    }
  }
}
