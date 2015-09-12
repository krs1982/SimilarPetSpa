﻿using UnityEngine;
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
		Conveyor = GameObject.FindGameObjectWithTag ("Conveyor");
		localNodes = Conveyor.GetComponent<ConveyorMoving>().nodes;
		myNode = localNodes [myNodeNumber].transform;
		this.GetComponent<TweenPosition> ().duration = Conveyor.GetComponent<ConveyorMoving>().animationTime;
		this.GetComponent<TweenPosition> ().to = myNode.transform.position;
		this.GetComponent<TweenPosition> ().from = new Vector3 (-9.7f, -3.71f, 0);
		this.GetComponent<TweenPosition> ().Play (true);
		this.GetComponent<TweenPosition> ().Reset ();
	}

	public void MoveAnimal()
	{
		if (myNodeNumber == 12)
			Destroy (this.gameObject);
		else {
			this.gameObject.GetComponent<TweenPosition> ().from = myNode.position;
			myNodeNumber++;
			myNode = localNodes [myNodeNumber].transform;
			this.gameObject.GetComponent<TweenPosition> ().to = myNode.position;
			this.gameObject.GetComponent<TweenPosition> ().Play (true);
			this.gameObject.GetComponent<TweenPosition> ().Reset ();
		}
	}


}