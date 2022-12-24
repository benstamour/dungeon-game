using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for levers
public class Lever : MonoBehaviour
{
	//private InputAction leverAction;
	private bool activated = false;
	
	private Animator anim;
	
	// NearView()
    private float distance;
    private float angleView;
    private Vector3 direction;
	
	private GameManager gameManagerScript;

	// Start is called before the first frame update
	void Start()
    {
		anim = GetComponent<Animator>();
		anim.SetBool("LeverUp", true);
		
		this.gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	void Update()
    {
		// if the player presses E while near the lever, activate it
        if (Input.GetKeyDown(KeyCode.E) && NearView())
		{
			activate();
		}
    }
	
	public void activate(){
		if (activated == false)
		{
			anim.SetBool("LeverUp", false); // triggers lever animation
			activated = true;
			
			this.gameManagerScript.PlayLeverClip();
			
			StartCoroutine(CheckAnim()); // waits for lever animation to complete before triggering effects

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
	
	// is the player close enough to the lever to activate it?
	private bool NearView()
    {
		GameObject character = GameObject.FindWithTag("Character");
        distance = Vector3.Distance(transform.position, character.transform.position);
		if(distance <= 3f)
		{
			return true;
		}
        else
		{
			return false;
		}
    }
	
	IEnumerator CheckAnim()
	{
		// wait for lever animation to complete
		yield return new WaitForSeconds(0.5f);
		while(this.anim.GetCurrentAnimatorStateInfo(0).length >
            this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime)
		{
			yield return null;
		}
		
		// if this lever is for the lifting platform, trigger movement of platform
		if(this.gameObject.transform.parent.name == "Platform Lever")
		{
			GameObject liftingPlatform = GameObject.Find("Lifting Platform");
			LiftingPlatform liftingPlatformScript = liftingPlatform.GetComponent<LiftingPlatform>();
			liftingPlatformScript.setLiftActivated(true);
		}
		
		// if this lever is for the sliding door, trigger the door movement and start the movement of the spike row and crusher
		else if(this.gameObject.transform.parent.name == "Wall Lever")
		{
			GameObject slidingDoor = GameObject.Find("Sliding Door");
			SlidingDoor slidingDoorScript = slidingDoor.GetComponent<SlidingDoor>();
			slidingDoorScript.SlideTriggered();
			
			yield return new WaitForSeconds(2f); // wait for sliding door to move into place before activating the other objects, as the door is also one of the crusher walls
			
			GameObject spikeRow = GameObject.Find("Spike Row");
			SpikeRow spikeRowScript = spikeRow.GetComponent<SpikeRow>();
			spikeRowScript.setMoveActivated(true);
			
			GameObject crusher1 = GameObject.Find("Crusher1");
			Crusher crusher1Script = crusher1.GetComponent<Crusher>();
			crusher1Script.setMoveActivated(true);
			
			GameObject crusher2 = GameObject.Find("Crusher2");
			Crusher crusher2Script = crusher2.GetComponent<Crusher>();
			crusher2Script.setMoveActivated(true);
		}
	}
}