using UnityEngine;
using System.Collections;

public class BubbleEffect : MonoBehaviour {

	public GameObject[] TeslaObjects;
	public float delay = 0;
	public float interdelay = 0.05f;
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
			StartCoroutine (startEffect(interdelay));
			break;
		case 1:
			TeslaObjects[counter].GetComponent<TweenColor>().Reset();
			TeslaObjects[counter].GetComponent<TweenColor>().Play(true);
			counter++;
			StartCoroutine (startEffect(interdelay));
			break;
		case 2:
			TeslaObjects[counter].GetComponent<TweenColor>().Reset();
			TeslaObjects[counter].GetComponent<TweenColor>().Play(true);
			counter++;
			StartCoroutine (startEffect(interdelay));
			break;
		case 3:
			TeslaObjects[counter].GetComponent<TweenColor>().Reset();
			TeslaObjects[counter].GetComponent<TweenColor>().Play(true);
			counter++;
			StartCoroutine (startEffect(interdelay));
			break;
		case 4:
			TeslaObjects[counter].GetComponent<TweenColor>().Reset();
			TeslaObjects[counter].GetComponent<TweenColor>().Play(true);
			counter++;
			StartCoroutine (startEffect(interdelay));
			break;
		case 5:
			TeslaObjects[counter].GetComponent<TweenColor>().Reset();
			TeslaObjects[counter].GetComponent<TweenColor>().Play(true);
			counter++;
			StartCoroutine (startEffect(interdelay));
			break;
		case 6:
			TeslaObjects[counter].GetComponent<TweenColor>().Reset();
			TeslaObjects[counter].GetComponent<TweenColor>().Play(true);
			counter++;
			StartCoroutine (startEffect(interdelay));
			break;
		case 7:
			TeslaObjects[counter].GetComponent<TweenColor>().Reset();
			TeslaObjects[counter].GetComponent<TweenColor>().Play(true);
			counter++;
			StartCoroutine (startEffect(interdelay));
			break;
		case 8:
			break;
		}
		
	}
}
