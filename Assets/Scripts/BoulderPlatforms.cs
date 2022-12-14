using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for the three moving platforms before the spikeball area
public class BoulderPlatforms : MonoBehaviour
{
	[SerializeField] int platformNum = 0;
	int dir = 0; // two possible directions for platform to move in
	Vector3 startPos = Vector3.zero;
	float speed = 0f; // speed of moving platform
	
    // Start is called before the first frame update
    void Start()
    {
        if(this.platformNum%2 == 0)
		{
			this.dir = 1;
		}
		this.startPos = this.gameObject.transform.position;
		this.speed = 2f*platformNum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void FixedUpdate()
	{
		// handles movement of platforms
		if(this.dir == 0)
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, this.startPos + new Vector3(0,0,8), speed*Time.deltaTime);
			if((this.transform.position - (this.startPos + new Vector3(0,0,8))).magnitude <= 0.05)
			{
				this.transform.position = this.startPos + new Vector3(0,0,8);
			}
			if(this.transform.position == this.startPos + new Vector3(0,0,8))
			{
				this.dir = 1;
				this.startPos = this.transform.position;
			}
		}
		else
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, this.startPos + new Vector3(0,0,-8), speed*Time.deltaTime);
			if((this.transform.position - (this.startPos + new Vector3(0,0,-8))).magnitude <= 0.05)
			{
				this.transform.position = this.startPos + new Vector3(0,0,-8);
			}
			if(this.transform.position == this.startPos + new Vector3(0,0,-8))
			{
				this.dir = 0;
				this.startPos = this.transform.position;
			}
		}
	}
}