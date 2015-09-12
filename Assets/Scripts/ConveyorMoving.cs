using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ConveyorMoving : MonoBehaviour {

	public GameObject[] nodes;
	public GameObject animalsParent;
	public float animationTime = 0.8f;
	public GameObject conveyorTop;
	public GameObject conveyorBot;
	public GameObject[] conveyorWheels;
	

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

	}
}