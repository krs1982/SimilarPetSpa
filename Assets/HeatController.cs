using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeatController : MonoBehaviour {

	public GameObject gameManager;

	Image image;




	float heatLevel = 0f;

	void Start()
	{
		image = this.GetComponent<Image> ();
	}


	void Update()
	{
		heatLevel = gameManager.GetComponent<GameManager> ().heatMeter;

		image.fillAmount = heatLevel / 100;

	}
}
