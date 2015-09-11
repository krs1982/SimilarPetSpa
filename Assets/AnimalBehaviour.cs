using UnityEngine;
using System.Collections;

public class AnimalBehaviour : MonoBehaviour {

	[HideInInspector]
	public Transform myNode;
	[HideInInspector]
	public int myNodeNumber = 0;

	public GameObject Conveyor;

	GameObject[] localNodes;

	void Start()
	{
		localNodes = Conveyor.GetComponent<ConveyorMoving>().nodes;
		myNode = localNodes [myNodeNumber].transform;
	}

	public void MoveAnimal()
	{
		this.gameObject.GetComponent<TweenPosition> ().from = myNode.position;
		myNodeNumber++;
		myNode = localNodes[myNodeNumber].transform;
		this.gameObject.GetComponent<TweenPosition> ().to = myNode.position;
		this.gameObject.GetComponent<TweenPosition> ().Play (true);
		this.gameObject.GetComponent<TweenPosition> ().Reset();

	}


}
