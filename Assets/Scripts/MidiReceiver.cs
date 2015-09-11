using System;
using UnityEngine;
using System.Collections;
using Sanford.Multimedia.Midi;
using Sanford.Threading;
using System.Threading;


public class MidiReceiver : MonoBehaviour{

    private InputDevice midiIn = null;

    void Start ()
    {
        midiIn = new InputDevice(0);
        midiIn.ChannelMessageReceived += HandleChannelMessageReceived;

        midiIn.StartRecording();
    }

    private void HandleChannelMessageReceived(object sender, ChannelMessageEventArgs e)
    {
        int message = e.Message.Data1;

        switch(message)
        {
            case 60: Debug.Log("Maszyna 01"); break;
            case 62: Debug.Log("Maszyna 02"); break;
            case 64: Debug.Log("Maszyna 03"); break;
            case 65: Debug.Log("Maszyna 04"); break;
            case 67: Debug.Log("Maszyna 05"); break;
        }

    }


}
