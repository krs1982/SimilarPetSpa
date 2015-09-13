using UnityEngine;
using UnityEngine.UI;

public class PointsIndicator : MonoBehaviour
{
	void Update ()
    {
        this.GetComponent<Text>().text = GameManager.Instance.points.ToString();
    }
}
