using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject Machine01, Machine02, Machine03, Machine04, Machine05;
    private Machine machine01component, machine02component, machine03component, machine04component, machine05component;

    #region REFERENCES

    private ConveyorMoving animalMover;
    
    #endregion REFERENCES

    //... licznik do przesuwania zwierzat na tasmie
    private float timer = 0;
    
    //... wskaznik naladowania combo sterowany pokretlem klawiatury MIDI
    private int comboMeter = 0;

    //... zmienne zwiazane z przeliczaniem tempa muzyki na tempo gry
    public float BeatsPerMinute = 90f;
    public int Beats = 4;
    private float beatTime, subBeatTime;
    private int barCount = 1, beatCount = 1;
    //... zmienne sluzace do odpalania i wylacania maszyn
    public int StartBar, StartBeat, EndBar, EndBeat;

    //... zmienne zwiazane z maszynami
    private bool machinesActivated = false;
    private int heatMeter = 0;

    //... lista do przechowania kolejki nacisnietych na klawiaturze MIDI klawiszy
    private List<int> pressedKeys = new List<int>();

    void Awake()
    {
        animalMover = GameObject.Find("Conveyor").GetComponent<ConveyorMoving>();

        machine01component = Machine01.GetComponent<Machine>();
        machine02component = Machine02.GetComponent<Machine>();
        machine03component = Machine03.GetComponent<Machine>();
        machine04component = Machine04.GetComponent<Machine>();
        machine05component = Machine05.GetComponent<Machine>();
    }

	void Start () 
    {
        if(Instance == null)
        {
            Instance = this;
        }

        beatTime = 60f / BeatsPerMinute;
        subBeatTime = beatTime / Beats;
	}
	
	void Update () 
    {
        ListenForStandardKeyboard();

        ListenForMidiKeyboard();
        
        timer += Time.deltaTime;

        #region Beats counter
        if(beatCount == 1)
        {
            if(timer >= subBeatTime)
            {
                beatCount = 2;
            }
        }
        else if (beatCount == 2)
        {
            if (timer >= subBeatTime * 2)
            {
                beatCount = 3;
            }
        }
        else if (beatCount == 3)
        {
            if (timer >= subBeatTime * 3)
            {
                beatCount = 4;
            }
        }
        else if (beatCount == 4)
        {
            if (timer >= subBeatTime * 4)
            {
                beatCount = 1;
            }
        }
        #endregion Beats counter

        #region Main timer
        if (timer >= beatTime)
        {
            timer = 0;
            barCount++;
            if (barCount > 4) barCount = 1;

            switch (barCount)
            {
                case 1: MoveAnimals(); break;
                case 3: ActivateMachines(); break;
                case 4: DeactivateMachines(); break;
            }
        }
        #endregion Main timer

        #region Machines activation & deactivation
        if(barCount == StartBar && beatCount == StartBeat)
        {
            ActivateMachines();
        }

        if (barCount == EndBar && beatCount == EndBeat)
        {
            DeactivateMachines();
        }
        #endregion Machines activation & deactivation
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), barCount.ToString() + " : " + beatCount.ToString());
        GUI.Label(new Rect(10, 40, 100, 20), timer.ToString());
    }

    public void AddPressedKey(int keyNumber)
    {
        pressedKeys.Add(keyNumber);
    }

    private void ListenForMidiKeyboard()
    {
        if(pressedKeys.Count > 0)
        {
            //Debug.Log(pressedKeys[0]);
            
            switch(pressedKeys[0])
            {
                case 60: UseMachine01(); pressedKeys.RemoveAt(0); break;
                case 62: UseMachine02(); pressedKeys.RemoveAt(0); break;
                case 64: UseMachine03(); pressedKeys.RemoveAt(0); break;
                case 65: UseMachine04(); pressedKeys.RemoveAt(0); break;
                case 67: UseMachine05(); pressedKeys.RemoveAt(0); break;
            }
        }
    }

    private void ListenForStandardKeyboard()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            pressedKeys.Add(60);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            pressedKeys.Add(62);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            pressedKeys.Add(64);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            pressedKeys.Add(65);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            pressedKeys.Add(67);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            DecreaseHeat(2);
        }
    }

    public void IncreaseCombo()
    {
        comboMeter++;

        Debug.Log("Combo counter: " + comboMeter.ToString());
    }

    private void DecreaseHeat(int amount)
    {
        heatMeter = heatMeter - amount;
        if (heatMeter < 0) heatMeter = 0;

        Debug.Log("Machines heat: " + heatMeter.ToString());
    }

    private void ResetCombo()
    {
        comboMeter = 0;
    }

    private void MoveAnimals()
    {
        animalMover.MoveConveyor();
    }

    private void ActivateMachines()
    {
        machinesActivated = true;
        //Debug.Log("Machines activated");
    }

    private void DeactivateMachines()
    {
        machinesActivated = false;
        //Debug.Log("Machines deactivated");
    }

    #region Machine controls
    public void UseMachine01()
    {
        if (machinesActivated)
        {
            if (machine01component.IsWorking == false)
                machine01component.Work();
        }
        else
        {

        }
    }

    public void UseMachine02()
    {
        if (machinesActivated)
        {
            if(machine02component.IsWorking == false)
                machine02component.Work();
        }
        else
        {

        }
    }

    public void UseMachine03()
    {
        if (machinesActivated)
        {
            if (machine03component.IsWorking == false)
                machine03component.Work();
        }
        else
        {

        }
    }

    public void UseMachine04()
    {
        if (machinesActivated)
        {
            if (machine04component.IsWorking == false)
                machine04component.Work();
        }
        else
        {

        }
    }

    public void UseMachine05()
    {
        if (machinesActivated)
        {
            if (machine05component.IsWorking == false)
                machine05component.Work();
        }
        else
        {

        }
    }
    #endregion Machine controls
}
