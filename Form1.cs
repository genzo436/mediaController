using mediaController.Classes;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace mediaController
{
  public partial class Form1 : Form
  {

    MediaController playbackDevice;
    public Form1()
    {
      playbackDevice = new MediaController();  
      InitializeComponent();
      ChangeButtonImages();
      notifyIcon.Visible = false;

      volumeControl1.Value = playbackDevice.GetVolume();
      volumeControl1.Muted = playbackDevice.IsMuted();
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

    private void playButton_Click(object sender, EventArgs e)
    {
      playbackDevice.PlayPause();
    }

    private void nextButton_Click(object sender, EventArgs e)
    {
      playbackDevice.NextTrack();
    }
  }
}
