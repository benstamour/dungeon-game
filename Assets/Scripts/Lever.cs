using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
	//private InputAction leverAction;
	private bool activated = false;
	
	private Animator anim;
	
	// NearView()
    private float distance;
    private float angleView;
    private Vector3 direction;

	// Start is called before the first frame update
	void Start()
    {
		anim = GetComponent<Animator>();
		anim.SetBool("LeverUp", true);
    }
	
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && NearView()) // 1.lever and 2.button
		{
			activate();
		}
    }
	
	public void activate(){
		if (activated == false)
		{
			anim.SetBool("LeverUp", false);
			activated = true;
			
			GameObject liftingPlatform = GameObject.Find("Lifting Platform");
			LiftingPlatform liftingPlatformScript = liftingPlatform.GetComponent<LiftingPlatform>();
			liftingPlatformScript.setLiftActivated(true);

			/*if(gameObject.transform.parent.name == "Lever_Prefab")
			{
				Debug.Log("Lever A");
			}*/
		}
		/*else
		{
			anim.SetBool("LeverUp", true);
			activated = false;

			if(gameObject.transform.parent.name == "Lever_Prefab")
			{
				Debug.Log("Lever B");
			}
		}*/
	}
	
	public bool getActivated()
	{
		return activated;
	}
	
	private bool NearView() // it is true if you near interactive object
    {
		GameObject character = GameObject.FindWithTag("Character");
        distance = Vector3.Distance(transform.position, character.transform.position);
		if(distance <= 2f)
		{
			return true;
		}
        else
		{
			return false;
		}
    }
}