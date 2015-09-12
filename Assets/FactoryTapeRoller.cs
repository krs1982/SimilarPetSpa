using UnityEngine;
using System.Collections;

public class FactoryTapeRoller : MonoBehaviour {

	public int rollState = 0;

	public void Roll()
	{

	TweenRotation tween = this.GetComponent<TweenRotation>();
	switch (rollState) {
		case 0 : 
			tween.from = new Vector3 (0, 0, 0);
			tween.to = new Vector3 (0, 0, -120);
			break;
		case 1:
			tween.from = new Vector3 (0, 0, -120);
			tween.to = new Vector3 (0, 0, -240);
			break;
		case 2:
			tween.from = new Vector3 (0, 0, -240);
			tween.to = new Vector3 (0, 0, 0);
			break;
		}

		rollState = (rollState+1) % 3;

		tween.Reset ();
		tween.Play (true);
	}
}
