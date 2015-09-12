using System;
using UnityEngine;
using System.Collections;
using Sanford.Multimedia.Midi;
using Sanford.Threading;
using System.Threading;


public class MidiReceiver : MonoBehaviour {

    public GameObject Machine01;
    private TweenPosition machine01tween;

    private InputDevice midiIn = null;

    //... zmienne do systemu nabijania combosow
    private bool up = true;

    //... zmienne do wyeliminowania zduplikowanych sygnalow
    private bool key01pressed = false,
                 key02pressed = false,
                 key03pressed = false,
                 key04pressed = false,
                 key05pressed = false;

    void Awake()
    {
        machine01tween = Machine01.GetComponent<TweenPosition>();
    }

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

        if (data1 == 1) //... obsluga pokretla do nabijania combosow
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
        else //... obsluga klawiszy odpowiedzialnych za sterowanie maszynami
        {
            if (data1 == 60 && key01pressed == false)
            {
                key01pressed = true;
                GameManager.Instance.AddPressedKey(data1);
            }
            else if (data1 == 60 && key01pressed == true)
            {
                key01pressed = false;
            }

            if (data1 == 62 && key02pressed == false)
            {
                key02pressed = true;
                GameManager.Instance.AddPressedKey(data1);
            }
            else if (data1 == 62 && key02pressed == true)
            {
                key02pressed = false;
            }

            if (data1 == 64 && key03pressed == false)
            {
                key03pressed = true;
                GameManager.Instance.AddPressedKey(data1);
            }
            else if (data1 == 64 && key03pressed == true)
            {
                key03pressed = false;
            }

            if (data1 == 65 && key04pressed == false)
            {
                key04pressed = true;
                GameManager.Instance.AddPressedKey(data1);
            }
            else if (data1 == 65 && key04pressed == true)
            {
                key04pressed = false;
            }

            if (data1 == 67 && key05pressed == false)
            {
                key05pressed = true;
                GameManager.Instance.AddPressedKey(data1);
            }
            else if (data1 == 67 && key05pressed == true)
            {
                key05pressed = false;
            }
        }
    }

    void OnApplicationQuit()
    {
        midiIn.Close();
    }


}
