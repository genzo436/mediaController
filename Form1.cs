using mediaController.control;
using NAudio.CoreAudioApi;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace mediaController
{
  public partial class Form1 : Form
  {
    MMDeviceEnumerator _deviceEnumerator = new MMDeviceEnumerator();
    MMDevice _playbackDevice;
    public Form1()
    {
      _playbackDevice = _deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
      InitializeComponent();
      notifyIcon.Visible = false;
      volumeControl1.Value = GetVolume();
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
    private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
    private const int APPCOMMAND_VOLUME_UP = 0xA0000;
    private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
    private const int WM_APPCOMMAND = 0x319;
    private const int APPCOMMAND_MEDIA_PLAY_PAUSE = 0xE0000;
    private const int APPCOMMAND_MEDIA_PREVIOUSTRACK = 0xC0000;

    [DllImport("user32.dll")]
    public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
     IntPtr wParam, IntPtr lParam);
    private void button1_Click(object sender, EventArgs e)
    {
      SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
            (IntPtr)APPCOMMAND_VOLUME_DOWN);
    }
    private void PlayPauseButton1Click(object sender, EventArgs e)
    {
      SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
          (IntPtr)APPCOMMAND_MEDIA_PLAY_PAUSE);
    }

    private void PrevButton1Click(object sender, EventArgs e)
    {

      SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
          (IntPtr)APPCOMMAND_MEDIA_PREVIOUSTRACK);
    }

 

    public int GetVolume()
    {
      return (int)(_playbackDevice.AudioEndpointVolume.MasterVolumeLevelScalar * 100);
    }

    public void SetVolume(int volumeLevel)
    {
      if (volumeLevel < 0)
      {
        volumeLevel = 0;
      }
      else if (volumeLevel > 100)
      {
        volumeLevel = 100;
      }
      _playbackDevice.AudioEndpointVolume.MasterVolumeLevelScalar = volumeLevel / 100.0f;
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
      SetVolume(volumeControl1.Value);
    }
  }
}
