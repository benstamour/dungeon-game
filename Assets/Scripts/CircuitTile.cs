using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for the tile that moves counterclockwise in a square
public class CircuitTile : MonoBehaviour
{
	int dir = 0; // 4 possible directions for the tile
	Vector3 startPos = Vector3.zero;
	//float slideProgress = 0f;
	//float slideRate = 0.1f;
	float speed = 2f;
	
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
		// handles movement of the circuit tile
		if(this.dir == 0)
		{
			//this.slideProgress += Time.fixedDeltaTime*this.slideRate;
			this.transform.position = Vector3.MoveTowards(this.transform.position, this.startPos + new Vector3(4,0,0), speed*Time.deltaTime);
			//Vector3.Lerp(this.transform.position, this.startPos + new Vector3(4,0,0), this.slideProgress);
			if((this.transform.position - (this.startPos + new Vector3(4,0,0))).magnitude <= 0.05)
			{
				this.transform.position = this.startPos + new Vector3(4,0,0);
			}
			if(this.transform.position == this.startPos + new Vector3(4,0,0))
			{
				this.dir = 1;
				this.startPos = this.transform.position;
				//this.slideProgress = 0f;
			}
		}
		else if(this.dir == 1)
		{
			//this.slideProgress += Time.fixedDeltaTime*this.slideRate;
			this.transform.position = Vector3.MoveTowards(this.transform.position, this.startPos + new Vector3(0,0,4), speed*Time.deltaTime);
			//this.transform.position = Vector3.Lerp(this.transform.position, this.startPos + new Vector3(0,0,4), this.slideProgress);
			if((this.transform.position - (this.startPos + new Vector3(0,0,4))).magnitude <= 0.05)
			{
				this.transform.position = this.startPos + new Vector3(0,0,4);
			}
			if(this.transform.position == this.startPos + new Vector3(0,0,4))
			{
				this.dir = 2;
				this.startPos = this.transform.position;
				//this.slideProgress = 0f;
			}
		}
		else if(this.dir == 2)
		{
			//this.slideProgress += Time.fixedDeltaTime*this.slideRate;
			this.transform.position = Vector3.MoveTowards(this.transform.position, this.startPos + new Vector3(-4,0,0), speed*Time.deltaTime);
			//this.transform.position = Vector3.Lerp(this.transform.position, this.startPos + new Vector3(-4,0,0), this.slideProgress);
			if((this.transform.position - (this.startPos + new Vector3(-4,0,6))).magnitude <= 0.05)
			{
				this.transform.position = this.startPos + new Vector3(-4,0,0);
			}
			if(this.transform.position == this.startPos + new Vector3(-4,0,0))
			{
				this.dir = 3;
				this.startPos = this.transform.position;
				//this.slideProgress = 0f;
			}
		}
		else
		{
			//this.slideProgress += Time.fixedDeltaTime*this.slideRate;
			this.transform.position = Vector3.MoveTowards(this.transform.position, this.startPos + new Vector3(0,0,-4), speed*Time.deltaTime);
			//this.transform.position = Vector3.Lerp(this.transform.position, this.startPos + new Vector3(0,0,-4), this.slideProgress);
			if((this.transform.position - (this.startPos + new Vector3(0,0,-4))).magnitude <= 0.05)
			{
				this.transform.position = this.startPos + new Vector3(0,0,-4);
			}
			if(this.transform.position == this.startPos + new Vector3(0,0,-4))
			{
				this.dir = 0;
				this.startPos = this.transform.position;
				//this.slideProgress = 0f;
			}
		}
	}
}
