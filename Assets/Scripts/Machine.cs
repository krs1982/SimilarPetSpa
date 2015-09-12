using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Machine : MonoBehaviour {

	TweenPosition machineSpriteTween;

    public GameObject Node;

    public AnimalBehaviour.TREATMENTS machineTreatment;

    private bool isWorking = false;

    public bool IsWorking 
    {
        get { return isWorking; }
        set { isWorking = value; }
    }

    private TweenPosition tweenPosition;

    private GameObject currentAnimal;

    void Awake()
    {
        tweenPosition = this.gameObject.GetComponent<TweenPosition>();
		machineSpriteTween = this.transform.GetComponentInChildren<TweenPosition> ();
    }

    public void Work()
    {
        currentAnimal = Node.GetComponent<NodeController>().CurrentAnimal;

        if (currentAnimal != null)
        {
            if (!IsWorking)
            {
                FullMove();
                TreatAnimal();
            }
        }
        if (currentAnimal == null)
        {
            WrongMove();
        }
    }

    IEnumerator MachineFinishedWork(float duration)
    {
        yield return new WaitForSeconds(duration);
        IsWorking = false;
    }

    private void FullMove()
    {
        IsWorking = true;
        this.GetComponent<TweenPosition>().Reset();
        this.GetComponent<TweenPosition>().Play(true);
        StartCoroutine(MachineFinishedWork(tweenPosition.duration));
    }

    private void WrongMove()
    {
        IsWorking = true;
		machineSpriteTween.Reset();
		machineSpriteTween.Play(true);
        StartCoroutine(MachineFinishedWork(tweenPosition.duration));
    }

    private void TreatAnimal()
    {
        foreach(AnimalBehaviour.TREATMENTS treatment in currentAnimal.GetComponent<AnimalBehaviour>().neccesaryTreatments)
        {
            bool animalTreated = false;

            if(treatment == machineTreatment)
            {
                if(!animalTreated)
                {
                    currentAnimal.GetComponent<AnimalBehaviour>().neccesaryTreatments.Remove(treatment);
                    animalTreated = true;
                }
            }
        }
    }




}
