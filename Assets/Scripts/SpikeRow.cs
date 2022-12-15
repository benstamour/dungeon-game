using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for row of spikes that moves up and down
public class SpikeRow : MonoBehaviour
{
	private int dir = 0; // two possible directions
	private Vector3 startPos = Vector3.zero;
	private float speed = 1f;
	private bool moveActivated = false; // true once lever is pulled
	
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
		// handles movement of spike row
		if(moveActivated)
		{
			if(this.dir == 0)
			{
				this.transform.position = Vector3.MoveTowards(this.transform.position, this.startPos + new Vector3(0,-2,0), speed*Time.deltaTime);
				if((this.transform.position - (this.startPos + new Vector3(0,-2,0))).magnitude <= 0.05)
				{
					this.transform.position = this.startPos + new Vector3(0,-2,0);
				}
				if(this.transform.position == this.startPos + new Vector3(0,-2,0))
				{
					this.dir = 1;
					this.startPos = this.transform.position;
				}
			}
			else
			{
				this.transform.position = Vector3.MoveTowards(this.transform.position, this.startPos + new Vector3(0,2,0), speed*Time.deltaTime);
				if((this.transform.position - (this.startPos + new Vector3(0,2,0))).magnitude <= 0.05)
				{
					this.transform.position = this.startPos + new Vector3(0,2,0);
				}
				if(this.transform.position == this.startPos + new Vector3(0,2,0))
				{
					this.dir = 0;
					this.startPos = this.transform.position;
				}
			}
		}
	}
	
	public void setMoveActivated(bool b)
	{
		this.moveActivated = b;
	}
}
