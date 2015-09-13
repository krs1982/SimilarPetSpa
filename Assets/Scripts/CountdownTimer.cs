using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
	public GameObject bar;

	void Update ()
    {
		bar.GetComponent<Image> ().fillAmount = GameManager.Instance.CountdownTimer / 300;
	}
}
