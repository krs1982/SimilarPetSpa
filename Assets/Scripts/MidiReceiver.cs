using System;
using UnityEngine;
using System.Collections;
using Sanford.Multimedia.Midi;
using Sanford.Threading;
using System.Threading;


public class MidiReceiver : MonoBehaviour{

    private InputDevice midiIn = null;

    //... zmienne do systemu nabijania combosow
    private bool up = true;

    void Start ()
    {
        midiIn = new InputDevice(0);
        midiIn.ChannelMessageReceived += HandleChannelMessageReceived;

        midiIn.StartRecording();
    }

    private void HandleChannelMessageReceived(object sender, ChannelMessageEventArgs e)
    {
        int data1 = e.Message.Data1;
        int data2 = e.Message.Data2;

        //Debug.Log(data1.ToString() + ", " + data2.ToString());

        if(data1 == 1)
        {
            if(up)
            {
                if(data2 > 90)
                {
                    up = false;
                    GameManager.Instance.IncreaseCombo();
                }
            }
            else if(!up)
            {
                if(data2 < 30)
                {
                    up = true;
                    GameManager.Instance.IncreaseCombo();
                }   
            }
        }
        else
        {
            switch (data1)
            {
                case 60: Debug.Log("Maszyna 01"); break;
                case 62: Debug.Log("Maszyna 02"); break;
                case 64: Debug.Log("Maszyna 03"); break;
                case 65: Debug.Log("Maszyna 04"); break;
                case 67: Debug.Log("Maszyna 05"); break;
            }
        }
    }

    void OnApplicationQuit()
    {
        midiIn.Close();
    }


}
