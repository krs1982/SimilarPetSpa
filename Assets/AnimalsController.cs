using UnityEngine;
using System.Collections;

public class AnimalsController : MonoBehaviour {


	public GameObject[] animals;

	public void CreateRandomAnimal()
	{
		int random = Random.Range (0, animals.Length);
		GameObject newAnimal = (GameObject)Instantiate (animals [random], this.transform.position, Quaternion.identity); 
		newAnimal.transform.parent = this.transform;
	}
}
