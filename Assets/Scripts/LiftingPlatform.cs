using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for the platform that moves up and down once triggered by the lever
public class LiftingPlatform : MonoBehaviour
{
	private int dir = 0; // two possible directions
	private Vector3 startPos = Vector3.zero;
	private float speed = 2f;
	private bool liftActivated = false; // true once player activates lever
	
    // Start is called before the first frame update
    void Start()
    {
        this.startPos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void FixedUpdate()
	{
		// handles movement of platform
		if(liftActivated)
		{
			if(this.dir == 0)
			{
				this.transform.position = Vector3.MoveTowards(this.transform.position, this.startPos + new Vector3(0,5,0), speed*Time.deltaTime);
				if((this.transform.position - (this.startPos + new Vector3(0,5,0))).magnitude <= 0.05)
				{
					this.transform.position = this.startPos + new Vector3(0,5,0);
				}
				if(this.transform.position == this.startPos + new Vector3(0,5,0))
				{
					this.dir = 1;
					this.startPos = this.transform.position;
				}
			}
			else
			{
				this.transform.position = Vector3.MoveTowards(this.transform.position, this.startPos + new Vector3(0,-5,0), speed*Time.deltaTime);
				if((this.transform.position - (this.startPos + new Vector3(0,-5,0))).magnitude <= 0.05)
				{
					this.transform.position = this.startPos + new Vector3(0,-5,0);
				}
				if(this.transform.position == this.startPos + new Vector3(0,-5,0))
				{
					this.dir = 0;
					this.startPos = this.transform.position;
				}
			}
		}
	}
	
	public void setLiftActivated(bool b)
	{
		this.liftActivated = b;
	}
}
