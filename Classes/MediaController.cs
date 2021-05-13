using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace mediaController.Classes
{
  class MediaController
  {
    private const int WM_APPCOMMAND = 0x319;
    private const int APPCOMMAND_VOLUME_UP = 0xA0000;
    private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
    private const int APPCOMMAND_MEDIA_PLAY_PAUSE = 0xE0000;
    private const int APPCOMMAND_MEDIA_PREVIOUSTRACK = 0xC0000;
    private const int APPCOMMAND_MEDIA_NEXTTRACK = 0xB0000;

    MMDeviceEnumerator _deviceEnumerator = new MMDeviceEnumerator();
    MMDevice _playbackDevice;

    public MediaController()
    {
      _deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
      _playbackDevice = _deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia); ;
    }

    internal bool ToogleMute()
    {
      _playbackDevice.AudioEndpointVolume.Mute = !_playbackDevice.AudioEndpointVolume.Mute;
      return _playbackDevice.AudioEndpointVolume.Mute;
    }

    internal void SetVolume(int volumeLevel)
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
    internal int GetVolume()
    {
      return (int)(_playbackDevice.AudioEndpointVolume.MasterVolumeLevelScalar * 100);
    }
    internal bool IsMuted()
    {
      return _playbackDevice.AudioEndpointVolume.Mute;
    }

    [DllImport("user32.dll")]
    public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
     IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    internal void VolumeUp()
    {
      IntPtr lHwnd = FindWindow("Shell_TrayWnd", null);
      SendMessageW(lHwnd, WM_APPCOMMAND, (IntPtr)0,
            (IntPtr)APPCOMMAND_VOLUME_UP);
    }
    internal void VolumeDown()
    {
      IntPtr lHwnd = FindWindow("Shell_TrayWnd", null);
      SendMessageW(lHwnd, WM_APPCOMMAND, (IntPtr)0,
            (IntPtr)APPCOMMAND_VOLUME_DOWN);
    }
    internal void PreviousTrack()
    {
      IntPtr lHwnd = FindWindow("Shell_TrayWnd", null);
      SendMessageW(lHwnd, WM_APPCOMMAND, (IntPtr)0,
            (IntPtr)APPCOMMAND_MEDIA_PREVIOUSTRACK);
    }
    internal void NextTrack()
    {
      IntPtr lHwnd = FindWindow("Shell_TrayWnd", null);
      SendMessageW(lHwnd, WM_APPCOMMAND, (IntPtr)0,
            (IntPtr)APPCOMMAND_MEDIA_NEXTTRACK);
    }
    internal void PlayPause()
    {
      IntPtr lHwnd = FindWindow("Shell_TrayWnd", null);
      SendMessageW(lHwnd, WM_APPCOMMAND, (IntPtr)0,
            (IntPtr)APPCOMMAND_MEDIA_PLAY_PAUSE);
    }
  }
}
