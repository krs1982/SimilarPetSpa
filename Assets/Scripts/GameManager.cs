using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

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
    private float beatTime;
    private int barCount = 0;

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
	}
	
	void Update () 
    {
        ListenForMidiKeyboard();
        
        timer += Time.deltaTime;
	
        if(timer >= beatTime)
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
	}

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), barCount.ToString());
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
            Debug.Log(pressedKeys[0]);
            
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

    public void IncreaseCombo()
    {
        comboMeter++;
        Debug.Log(comboMeter.ToString());
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
    }

    private void DeactivateMachines()
    {
        machinesActivated = false;
    }


    #region Machine controls
    public void UseMachine01()
    {
        

        if (machinesActivated)
        {
            machine01component.FullMove();
        }
        else
        {

        }
    }

    public void UseMachine02()
    {
        machine02component.FullMove();

        if (machinesActivated)
        {

        }
        else
        {

        }
    }

    public void UseMachine03()
    {
        machine03component.FullMove();

        if (machinesActivated)
        {

        }
        else
        {

        }
    }

    public void UseMachine04()
    {
        machine04component.FullMove();

        if (machinesActivated)
        {

        }
        else
        {

        }
    }

    public void UseMachine05()
    {
        machine05component.FullMove();

        if (machinesActivated)
        {

        }
        else
        {

        }
    }
    #endregion Machine controls
}
