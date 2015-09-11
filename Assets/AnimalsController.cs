using UnityEngine;
using System.Collections;

public class AnimalsController : MonoBehaviour {


	public GameObject[] animals;

	public void CreateRandomAnimal()
	{
		Vector3 newPos = new Vector3 (-100, -100, 0);
		int random = Random.Range (0, animals.Length);
		GameObject newAnimal = (GameObject)Instantiate (animals [random], newPos, Quaternion.identity);
		newAnimal.transform.parent = this.transform;
		}
}
