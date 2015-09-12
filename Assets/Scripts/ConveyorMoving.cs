﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ConveyorMoving : MonoBehaviour {

	public GameObject[] nodes;
	public GameObject animalsParent;
	public float animationTime = 0.8f;
	public GameObject conveyorTop;
	public GameObject conveyorBot;
	public GameObject[] conveyorWheels;
	int spawnerCounter = 0;
	int spawnerHelper = 0;
	

	public void MoveConveyor()
	{
		foreach (Transform child in animalsParent.transform)
		{
			child.gameObject.GetComponent<AnimalBehaviour>().MoveAnimal();
		}
		conveyorTop.GetComponent<FactoryTapeController> ().PlayAnimation();
		conveyorBot.GetComponent<FactoryTapeController> ().PlayAnimation ();

		for (int c = 0; c < conveyorWheels.Length; c++) {
			conveyorWheels[c].GetComponent<FactoryTapeRoller>().Roll ();
		}

		if (spawnerHelper == 0) {

			animalsParent.GetComponent<AnimalsController> ().CreateRandomAnimal ();
			spawnerCounter++;

			if (spawnerCounter == 1)
				spawnerHelper = 8;
			else if (spawnerCounter < 3)
				spawnerHelper = 3;
			else 
				spawnerHelper = Random.Range (2, 4);
		}

		spawnerHelper--;

	}
}