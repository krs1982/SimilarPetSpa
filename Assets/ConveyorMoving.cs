using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ConveyorMoving : MonoBehaviour {

	public GameObject[] nodes;
	public GameObject animalsParent;
	

	public void MoveConveyor()
	{
		foreach (Transform child in animalsParent.transform)
		{
			child.gameObject.GetComponent<AnimalBehaviour>().MoveAnimal();
		}

	}
}