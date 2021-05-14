using mediaController.Classes;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace mediaController
{
  public partial class Form1 : Form
  {

    MediaController playbackDevice;
    public Form1()
    {
      InitializeComponent();
      ChangeButtonImages();
      notifyIcon.Visible = false;

      playbackDevice = new MediaController();
      volumeControl1.Value = playbackDevice.GetVolume();
      volumeControl1.Muted = playbackDevice.IsMuted();

      this.TransparencyKey = this.BackColor;
    }


    public void ChangeButtonImages()
    {
      playButton.SetImages(
        Properties.Resources.play2Basic,
        Properties.Resources.play2Preselect,
        Properties.Resources.play2Clicked
      );
      prevButton.SetImages(
        Properties.Resources.prevBasic,
        Properties.Resources.prevPreselect,
        Properties.Resources.prevClicked
      );
      nextButton.SetImages(
        Properties.Resources.nextInactive,
        Properties.Resources.nextSelected,
        Properties.Resources.nextClicked
      );
    }
    private void Form1Resize(object sender, EventArgs e)
    {
      if (this.WindowState == FormWindowState.Minimized)
      {
        this.Hide();
        notifyIcon.Visible = true;
      }
    }

    private void NotifyIconClick(object sender, EventArgs e)
    {
      Show();
      this.WindowState = FormWindowState.Normal;
      notifyIcon.Visible = false;
    }

    private void VolumeControlChanged(object sender, EventArgs e)
    {
      switch (((System.ComponentModel.PropertyChangedEventArgs)e).PropertyName)
      {
        case "muted":
          {
            playbackDevice.ToogleMute();
          }
          break;
        default:
          {
            playbackDevice.SetVolume(volumeControl1.Value);
          }
          break;
      }
    }
    private void PrevButtonClick(object sender, EventArgs e)
    {
      playbackDevice.PreviousTrack();
    }
    private void PlayButtonClick(object sender, EventArgs e)
    {
      playbackDevice.PlayPause();
    }
    private void NextButtonClick(object sender, EventArgs e)
    {
      playbackDevice.NextTrack();
    }
    /*Moving Form Without borders*/
    public const int WM_NCLBUTTONDOWN = 0xA1;
    public const int HT_CAPTION = 0x2;

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern bool ReleaseCapture();
    private void FormMouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        ReleaseCapture();
        SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
      }
    }
    private void MinimizeButtonClick(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Minimized;
      this.Hide();
      notifyIcon.Visible = true;
    }

    private void CloseButtonClick(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
