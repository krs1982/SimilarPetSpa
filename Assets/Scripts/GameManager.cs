using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

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

    private enum STATE { animalMove = 1, firstIdle, machineMove, secondIdle };
    private STATE gameState;

    void Awake()
    {
        animalMover = GameObject.Find("Conveyor").GetComponent<ConveyorMoving>();	
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
        if(machinesActivated)
        {

        }
        else
        {

        }
    }

    public void UseMachine02()
    {
        if (machinesActivated)
        {

        }
        else
        {

        }
    }

    public void UseMachine03()
    {
        if (machinesActivated)
        {

        }
        else
        {

        }
    }

    public void UseMachine04()
    {
        if (machinesActivated)
        {

        }
        else
        {

        }
    }

    public void UseMachine05()
    {
        if (machinesActivated)
        {

        }
        else
        {

        }
    }
    #endregion Machine controls
}
