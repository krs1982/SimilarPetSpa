using UnityEngine;
using System.Collections;

public class FactoryTapeController : MonoBehaviour {
	
	public GameObject firstPart;
	public GameObject secondPart;
	float distance;
	float c = 0;
	public float shiftDistance = 1.67f;
	int counter = 0;
	public bool rightDirection = true;

	void Start(){
	if (rightDirection) {
			distance = firstPart.transform.position.x - secondPart.transform.position.x;
		} else {
			distance = - firstPart.transform.position.x + secondPart.transform.position.x;
		}
	}


	public void PlayAnimation(){
		counter++;
			TweenPosition tween = this.GetComponent<TweenPosition> ();
		tween.from = new Vector3 ((counter-1)*shiftDistance, this.transform.position.y, this.transform.position.z);
		tween.to = new Vector3 (counter*shiftDistance, this.transform.position.y, this.transform.position.z);
		tween.Play (true);
		tween.Reset();
	}

	  void Update()
	{
		if (rightDirection) {
			if (this.transform.position.x >= distance + c) {
				GameObject temp = firstPart;
				firstPart = secondPart;
				secondPart = temp;
				secondPart.transform.position = new Vector3 (secondPart.transform.position.x - 2 * distance, secondPart.transform.position.y, secondPart.transform.position.z);
				c = c + distance;
			}
		} else {
			if (this.transform.position.x <= -(distance + c)) {
				GameObject temp = firstPart;
				firstPart = secondPart;
				secondPart = temp;
				secondPart.transform.position = new Vector3 (secondPart.transform.position.x + 2* distance, secondPart.transform.position.y, secondPart.transform.position.z);
				c = c + distance;
			}
		
		}
	}
}
