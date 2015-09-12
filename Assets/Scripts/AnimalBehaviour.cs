using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AnimalBehaviour : MonoBehaviour {

	[HideInInspector]
	public Transform myNode;
	[HideInInspector]
	public int myNodeNumber = 0;
	public GameObject Conveyor;
	GameObject[] localNodes;
	public Sprite startingSprite;
	public Sprite progresSprite;
	public Sprite happySprite;
	SpriteRenderer animalSprite;

    public enum TREATMENTS { saw, magnet, tesla, syringe, roll};
    public List<TREATMENTS> neccesaryTreatments;
	TREATMENTS nextTreatment;
	void Start()
	{
		nextTreatment = neccesaryTreatments [0];
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
		else
        {
            if (myNodeNumber == 10)
            {
                if (neccesaryTreatments.Count == 0)
                    GameManager.Instance.AddPoints(50);
                else if (neccesaryTreatments.Count == 1)
                    GameManager.Instance.AddPoints(25);
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
	public void ChangeSprite()
	{
		if (neccesaryTreatments [0] == nextTreatment) {
			if (neccesaryTreatments.Count == 2)
				animalSprite.sprite = progresSprite;
			else if (neccesaryTreatments.Count == 1)
				animalSprite.sprite = happySprite;
		}

    void OnDestroy()
    {
        
    }


	}

}
