using UnityEngine;
using System.Collections;

public class NodeController : MonoBehaviour {

	[HideInInspector]
    public GameObject CurrentAnimal;

    public void AssignAnimalToNode(GameObject animal)
    {
        CurrentAnimal = animal;
    }
}
