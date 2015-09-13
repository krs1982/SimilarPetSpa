using UnityEngine;
using System.Collections;

public class TeslaEffect : MonoBehaviour {

	public GameObject[] TeslaObjects;
	public float delay = 0;
	int counter = 0;

	public void StartAnim () {
		counter = 0;
		StartCoroutine (startEffect(delay));
	}
	
	IEnumerator startEffect (float time) { 
		yield return new WaitForSeconds (time);
		FunnyIteration ();
	}

		void FunnyIteration()
		{
		switch (counter) {
		case 0:
			TeslaObjects[counter].GetComponent<TweenColor>().Reset();
			TeslaObjects[counter].GetComponent<TweenColor>().Play(true);
			counter++;
			StartCoroutine (startEffect(0.1f));
			break;
		case 1:
			TeslaObjects[counter].GetComponent<TweenColor>().Reset();
			TeslaObjects[counter].GetComponent<TweenColor>().Play(true);
			counter++;
			StartCoroutine (startEffect(0.1f));
			break;
		case 2:
			TeslaObjects[counter].GetComponent<TweenColor>().Reset();
			TeslaObjects[counter].GetComponent<TweenColor>().Play(true);
			counter++;
			StartCoroutine (startEffect(0.1f));
			break;
		case 3:
			break;
		}

		}
}
