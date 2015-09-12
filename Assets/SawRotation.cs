using UnityEngine;
using System.Collections;

public class SawRotation : MonoBehaviour {

	int rotationMultiplier = 1;
	public bool rightRotation = true;
	TweenRotation tween;
	int rollState = 1;

	void Start () {
		tween = this.GetComponent<TweenRotation> ();
		Roll ();
		if (!rightRotation)
			rotationMultiplier = -1;
	}
	public void Roll()
	{
		switch (rollState) {
		case 0 : 
			tween.from = new Vector3 (0, 0, 0);
			tween.to = new Vector3 (0, 0, -120*rotationMultiplier);
			break;
		case 1:
			tween.from = new Vector3 (0, 0, -120*rotationMultiplier);
			tween.to = new Vector3 (0, 0, -240*rotationMultiplier);
			break;
		case 2:
			tween.from = new Vector3 (0, 0, -240*rotationMultiplier);
			tween.to = new Vector3 (0, 0, 0);
			break;
		}
		
		rollState = (rollState+1) % 3;
		
		tween.Reset ();
		tween.Play (true);
	}
}
