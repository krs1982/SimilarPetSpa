using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AnimalBehaviour : MonoBehaviour {

	[HideInInspector]
	public Transform myNode;
	[HideInInspector]
	public int myNodeNumber = 0;
	[HideInInspector]
	public GameObject Conveyor;
	GameObject[] localNodes;
	public Sprite startingSprite;
	public Sprite progresSprite;
	public Sprite happySprite;
	SpriteRenderer animalSprite;
	public int firstTreatment;
	public int secondTreatment;
	bool alreadyTreated = false;
	public Color color;
	int animalStateFlag = 0;

	public float delay = 0;

    public Transform leftIcon, middleIcon, rightIcon;
    private Icon firstTreatmentIcon, secondTreatmentIcon;
    public GameObject IconPrefab;
    private GameObject firstIcon, secondIcon;

    private Lamp lamp;
	
	public void ChangeSprite ()
    {
		StartCoroutine (changeSpriteDelay(delay));
	}
	
	IEnumerator changeSpriteDelay (float time) { 
		yield return new WaitForSeconds (time);
		ChangeSpriteAction ();
	} 

    public enum TREATMENTS { saw, magnet, tesla, syringe, roll};
	public List<TREATMENTS> neccesaryTreatments = new List<TREATMENTS>();

	void Start()
	{
		animalSprite = this.GetComponent<SpriteRenderer> ();
		animalSprite.sprite = startingSprite;
		Conveyor = GameObject.FindGameObjectWithTag ("Conveyor");
		localNodes = Conveyor.GetComponent<ConveyorMoving>().nodes;
		myNode = localNodes [myNodeNumber].transform;
        myNode.gameObject.GetComponent<NodeController>().AssignAnimalToNode(this.gameObject);
		this.GetComponent<TweenPosition> ().duration = Conveyor.GetComponent<ConveyorMoving>().animationTime;
		this.GetComponent<TweenPosition> ().to = myNode.transform.position;
		this.GetComponent<TweenPosition> ().from = new Vector3 (-10.83f, -3.37f, 0);
		this.GetComponent<TweenPosition> ().Play (true);
		this.GetComponent<TweenPosition> ().Reset ();

        firstIcon = (GameObject)Instantiate(IconPrefab, leftIcon.position, Quaternion.identity);
        firstIcon.GetComponent<Icon>().AssignTreatment(neccesaryTreatments[0]);
        firstIcon.transform.parent = leftIcon.transform;

        secondIcon = (GameObject)Instantiate(IconPrefab, rightIcon.position, Quaternion.identity);
        secondIcon.GetComponent<Icon>().AssignTreatment(neccesaryTreatments[1]);
        secondIcon.transform.parent = rightIcon.transform;

        lamp = GameObject.Find("Lamp").GetComponent<Lamp>();
	}

	public void MoveAnimal()
	{
		if (myNodeNumber == 10)
			Destroy (this.gameObject);
		else
        {
            if (myNodeNumber == 9)
            {
                if (animalStateFlag == 2)
                {
                    GameManager.Instance.AddPoints(50);
                    GameManager.Instance.AddSuccessfulTry();
                    lamp.TurnOn();
                    
                }
                else if (animalStateFlag == 1)
                {
                    GameManager.Instance.AddPoints(25);
                    GameManager.Instance.ResetSuccessfulTries();
                }
                else
                {
                    GameManager.Instance.AddPoints(0);
                    GameManager.Instance.ResetSuccessfulTries();
                }

            }

            myNode.gameObject.GetComponent<NodeController>().AssignAnimalToNode(null);
            this.gameObject.GetComponent<TweenPosition> ().from = myNode.position;
			myNodeNumber++;
			myNode = localNodes [myNodeNumber].transform;
            myNode.gameObject.GetComponent<NodeController>().AssignAnimalToNode(this.gameObject);
            this.gameObject.GetComponent<TweenPosition> ().to = myNode.position;
			this.gameObject.GetComponent<TweenPosition> ().Play (true);
			this.gameObject.GetComponent<TweenPosition> ().Reset ();
		}
	}
	void ChangeSpriteAction()
	{
		if (animalStateFlag != -1)
        {
			if (myNodeNumber == firstTreatment)
            {
				animalSprite.sprite = progresSprite;
				alreadyTreated = true;
				animalStateFlag = 1;
                //... usuniecie ikony
                firstIcon.GetComponent<Icon>().DestroySelf(0f);
                //... przesuniecie ikony na srodek
                secondIcon.transform.position = middleIcon.position;
			}
            else if (myNodeNumber == secondTreatment)
            {
				if (alreadyTreated)
                {
					animalSprite.sprite = happySprite;
					animalStateFlag = 2;
                    //... usuniecie drugiej ikony
                    secondIcon.GetComponent<Icon>().DestroySelf(0f);
                }
                else 
					GraySprite ();
			}
            else
				GraySprite ();
		}

	}

	public void GraySprite()
	{
		animalSprite.color = color;
		animalStateFlag = -1;
        
        //... usuniecie ikon
        if(firstIcon != null)
            firstIcon.GetComponent<Icon>().DestroySelf(0);

        if (secondIcon != null)
            secondIcon.GetComponent<Icon>().DestroySelf(0);
    }


}
