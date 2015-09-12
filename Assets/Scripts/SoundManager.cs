using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public GameObject gameMusic;
	public float musicDelay = 0;

	public void StartGameMusic () {
		StartCoroutine (startMusic(musicDelay));
	}

	IEnumerator startMusic (float time) { 
		yield return new WaitForSeconds (time);
		gameMusic.GetComponent<AudioSource> ().Play ();
	} 
}
