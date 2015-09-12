using UnityEngine;
using System.Collections;

public class Machine : MonoBehaviour {

    private bool isWorking = false;

    public bool IsWorking 
    {
        get { return isWorking; }
        set { isWorking = value; }
    }

    private TweenPosition tweenPosition;

    void Awake()
    {
        tweenPosition = this.gameObject.GetComponent<TweenPosition>();
    }

    public void FullMove()
    {
        if(!IsWorking)
        {
            IsWorking = true;
            this.GetComponent<TweenPosition>().Reset();
            this.GetComponent<TweenPosition>().Play(true);
            StartCoroutine(MachineFinishedWork(tweenPosition.duration));
        }     
    }

    IEnumerator MachineFinishedWork(float duration)
    {
        yield return new WaitForSeconds(duration);
        IsWorking = false;
    }
}
