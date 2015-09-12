using UnityEngine;
using System.Collections;

public class SawEffect : MonoBehaviour {

	public float delay = 0;

	public bool saw = false;
	public bool magnet = false;
	public bool tesla = false;
	public bool syringe = false;
	public bool roll = false;

	public GameObject magnetFragments;

	public GameObject[] teslaFragments;

	public void Effect () {
		StartCoroutine (startEffect(delay));
	}
	
	IEnumerator startEffect (float time) { 
		yield return new WaitForSeconds (time);
		PlayEffect ();
	} 


	void PlayEffect()
	{
		if (saw) {
			this.GetComponent<TweenScale> ().Reset ();
			this.GetComponent<TweenScale> ().Play (true);
			this.GetComponent<TweenColor> ().Reset ();
			this.GetComponent<TweenColor> ().Play (true);
		}

		if (magnet) 
		{
			this.GetComponent<TweenAlpha>().Reset();
			this.GetComponent<TweenAlpha>().Play (true);
			//magnetFragments.GetComponent<MagnetFragments>().Reset();
		}

		if (tesla) {


		}
		if (syringe) {
			this.GetComponent<TweenScale> ().Reset ();
			this.GetComponent<TweenScale> ().Play (true);
			this.GetComponent<TweenColor> ().Reset ();
			this.GetComponent<TweenColor> ().Play (true);
		}

	}
}
