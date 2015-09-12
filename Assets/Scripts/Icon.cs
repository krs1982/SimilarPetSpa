using UnityEngine;
using System.Collections;

public class Icon : MonoBehaviour {

    private SpriteRenderer spriteRenderer;

    public Sprite sawIcon, magnetIcon, teslaIcon, syringeIcon, rollerIcon;

    private AnimalBehaviour.TREATMENTS treatment;

    void Awake ()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

	void Start ()
    {
        switch(treatment)
        {
            case AnimalBehaviour.TREATMENTS.saw: spriteRenderer.sprite = sawIcon; break;
            case AnimalBehaviour.TREATMENTS.magnet: spriteRenderer.sprite = magnetIcon; break;
            case AnimalBehaviour.TREATMENTS.tesla: spriteRenderer.sprite = teslaIcon; break;
            case AnimalBehaviour.TREATMENTS.syringe: spriteRenderer.sprite = syringeIcon; break;
            case AnimalBehaviour.TREATMENTS.roll: spriteRenderer.sprite = rollerIcon; break;
        }	    
	}

    public void AssignTreatment(AnimalBehaviour.TREATMENTS treatment)
    {
        this.treatment = treatment;
    }

    public void DestroySelf(float time)
    {
        //ODPAL ANIMACJĘ
        Destroy(gameObject, time);
    }
	
}
