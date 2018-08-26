using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;

namespace MuteSpeakersScript
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MMDeviceEnumerator MMDE = new NAudio.CoreAudioApi.MMDeviceEnumerator();
                MMDeviceCollection DevCol = MMDE.EnumerateAudioEndPoints(NAudio.CoreAudioApi.DataFlow.All, NAudio.CoreAudioApi.DeviceState.All);
                foreach (NAudio.CoreAudioApi.MMDevice dev in DevCol)
                {
                    try
                    {
                        if (dev.FriendlyName.Contains("Haut-parleurs"))
                        {
                            dev.AudioEndpointVolume.Mute = true;
                        }
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
