using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for the sliding spiked walls
public class MovingWall : MonoBehaviour
{
	[SerializeField] int wallNum = 0;
	int dir = 0; // two possible directions
	Vector3 startPos = Vector3.zero;
	float slideProgress = 0f;
	float slideRate = 0.025f;
	
    // Start is called before the first frame update
    void Start()
    {
        if(this.wallNum%2 == 1)
		{
			this.dir = 1;
		}
		this.startPos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void FixedUpdate()
	{
		// handles movement of walls
		if(this.dir == 0)
		{
			this.slideProgress += Time.fixedDeltaTime*this.slideRate;
			this.transform.position = Vector3.Lerp(this.transform.position, this.startPos + new Vector3(0,0,-6), this.slideProgress);
			if((this.transform.position - (this.startPos + new Vector3(0,0,-6))).magnitude <= 0.05)
			{
				this.transform.position = this.startPos + new Vector3(0,0,-6);
			}
			if(this.transform.position == this.startPos + new Vector3(0,0,-6))
			{
				this.dir = 1;
				this.startPos = this.transform.position;
				this.slideProgress = 0f;
			}
		}
		else
		{
			this.slideProgress += Time.fixedDeltaTime*this.slideRate;
			this.transform.position = Vector3.Lerp(this.transform.position, this.startPos + new Vector3(0,0,6), this.slideProgress);
			if((this.transform.position - (this.startPos + new Vector3(0,0,6))).magnitude <= 0.05)
			{
				this.transform.position = this.startPos + new Vector3(0,0,6);
			}
			if(this.transform.position == this.startPos + new Vector3(0,0,6))
			{
				this.dir = 0;
				this.startPos = this.transform.position;
				this.slideProgress = 0f;
			}
		}
	}
}
