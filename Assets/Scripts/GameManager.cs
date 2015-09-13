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
    [HideInInspector]
	public float heatMeter = 0f;
    public float IncreaseOverTime;
	[HideInInspector]
	public float AdditionalIncrease = 0;
    private bool overheat = false;
    public float DecreaseByCombo;

    //... lista do przechowania kolejki nacisnietych na klawiaturze MIDI klawiszy
    private List<int> pressedKeys = new List<int>();

    //... ogolna punktacja gry
    public int points;

    //... odliczanie
    public float CountdownTimer = 60f;
    public int minutes, seconds;
    public float BonusTime = 10f;

    //... zmienna do zmierzenia ilosci udanych pod rzad prob
    private int successfulTries;

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

        IncreaseHeat(IncreaseOverTime);

        if (heatMeter == 100f) overheat = true;

        if(overheat)
        {
            if (heatMeter < 1f) overheat = false;
        }

        #region Countdown timer
        CountdownTimer -= Time.deltaTime;

        float tempMinutes = CountdownTimer / 60f;
        minutes = (int)Math.Floor(tempMinutes);

        seconds = (int)(CountdownTimer - ((float)minutes * 60f));
        #endregion Countdown timer

        #region Successful tries check
        if(successfulTries == 3)
        {
            successfulTries = 0;
            CountdownTimer += BonusTime;
        }
        #endregion Successful tries check
    }

    void OnGUI()
    {
        //GUI.Label(new Rect(10, 10, 200, 20), barCount.ToString() + " : " + beatCount.ToString());
        //GUI.Label(new Rect(10, 40, 200, 20), timer.ToString());
        //GUI.Label(new Rect(10, 70, 200, 20), "Machines heat: " + heatMeter.ToString());
        //GUI.Label(new Rect(10, 110, 200, 20), "Points: " + points.ToString());
        //GUI.Label(new Rect(10, 10, 200, 20), "Countdown: " + minutes.ToString() + ":" + seconds.ToString());
        //GUI.Label(new Rect(10, 40, 200, 20), timer.ToString());
    }

    public void AddSuccessfulTry()
    {
        successfulTries++;
    }

    public void ResetSuccessfulTries()
    {
        successfulTries = 0;
    }

    public void AddPoints(int number)
    {
        points += number;
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

        DecreaseHeat(DecreaseByCombo);

        //Debug.Log("Combo counter: " + comboMeter.ToString());
    }

    public void IncreaseHeat(float amount)
    {
		heatMeter = heatMeter + amount + AdditionalIncrease;
        if (heatMeter > 100f) heatMeter = 100f;
    }

    private void DecreaseHeat(float amount)
    {
        heatMeter = heatMeter - amount;
        if (heatMeter < 0f) heatMeter = 0f;

        //Debug.Log("Machines heat: " + heatMeter.ToString());
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
        if(!overheat)
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
    }

    public void UseMachine02()
    {
        if (!overheat)
        {
            if (machinesActivated)
            {
                if (machine02component.IsWorking == false)
                    machine02component.Work();
            }
            else
            {

            }
        }       
    }

    public void UseMachine03()
    {
        if(!overheat)
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
    }

    public void UseMachine04()
    {
        if(!overheat)
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
    }

    public void UseMachine05()
    {
        if(!overheat)
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
    }
    #endregion Machine controls
}
