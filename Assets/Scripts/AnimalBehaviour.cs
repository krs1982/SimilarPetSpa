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
	}

	public void MoveAnimal()
	{
		if (myNodeNumber == 11)
			Destroy (this.gameObject);
		else {
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
	public void ChangeSprite()
	{
		if (myNodeNumber == firstTreatment) {
			animalSprite.sprite = progresSprite;
			alreadyTreated = true;
		} else if (myNodeNumber == secondTreatment) {
			if (alreadyTreated) {
				animalSprite.sprite = happySprite;
				animalStateFlag = 1;
			} else 
				GraySprite ();
		} else
			GraySprite ();

	}

	void GraySprite()
	{
		animalSprite.color = color;
		animalStateFlag = -1;
	}


}
