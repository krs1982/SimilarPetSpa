using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{

	void Update ()
    {
        this.GetComponent<Text>().text = GameManager.Instance.minutes.ToString() + ":" + GameManager.Instance.seconds.ToString("00");
	}
}
