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
	}
	
	void Update () 
    {
        timer += Time.deltaTime;
	
        if(timer >= 2f)
        {
            timer = 0;
            animalMover.MoveConveyor();
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
}
