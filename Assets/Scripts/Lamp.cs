using UnityEngine;
using System.Collections;

public class Lamp : MonoBehaviour {

    public Sprite green, red;

    private SpriteRenderer bulb;

    void Start ()
    {
        bulb = GameObject.Find("Bulb").GetComponent<SpriteRenderer>();
	}

    public void TurnOn()
    {
        bulb.sprite = green;
        StartCoroutine(TurnOff(2f));
    }

    IEnumerator TurnOff(float time)
    {
        yield return new WaitForSeconds(time);
        bulb.sprite = red;
    }

}
