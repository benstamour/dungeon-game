using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftingPlatform : MonoBehaviour
{
	private int dir = 0;
	private Vector3 startPos = Vector3.zero;
	private float speed = 2f;
	private bool liftActivated = false;
	
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
