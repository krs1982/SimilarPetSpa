using UnityEngine;
using System.Collections;

public class NodeController : MonoBehaviour {

    public GameObject CurrentAnimal;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AssignAnimalToNode(GameObject animal)
    {
        CurrentAnimal = animal;
    }
}
