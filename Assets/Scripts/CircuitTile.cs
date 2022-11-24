using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitTile : MonoBehaviour
{
	int dir = 0;
	Vector3 startPos = Vector3.zero;
	float slideProgress = 0f;
	float slideRate = 0.1f;
	
    // Start is called before the first frame update
    void Start()
    {
        this.startPos = this.gameObject.transform.position;
		Debug.Log(this.startPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void FixedUpdate()
	{
		if(this.dir == 0)
		{
			this.slideProgress += Time.fixedDeltaTime*this.slideRate;
			this.transform.position = Vector3.Lerp(this.transform.position, this.startPos + new Vector3(4,0,0), this.slideProgress);
			if(this.transform.position == this.startPos + new Vector3(4,0,0))
			{
				this.dir = 1;
				this.startPos = this.transform.position;
				this.slideProgress = 0f;
			}
		}
		else if(this.dir == 1)
		{
			this.slideProgress += Time.fixedDeltaTime*this.slideRate;
			this.transform.position = Vector3.Lerp(this.transform.position, this.startPos + new Vector3(0,0,4), this.slideProgress);
			if(this.transform.position == this.startPos + new Vector3(0,0,4))
			{
				this.dir = 2;
				this.startPos = this.transform.position;
				this.slideProgress = 0f;
			}
		}
		else if(this.dir == 2)
		{
			this.slideProgress += Time.fixedDeltaTime*this.slideRate;
			this.transform.position = Vector3.Lerp(this.transform.position, this.startPos + new Vector3(-4,0,0), this.slideProgress);
			if(this.transform.position == this.startPos + new Vector3(-4,0,0))
			{
				this.dir = 3;
				this.startPos = this.transform.position;
				this.slideProgress = 0f;
			}
		}
		else if(this.dir == 3)
		{
			this.slideProgress += Time.fixedDeltaTime*this.slideRate;
			this.transform.position = Vector3.Lerp(this.transform.position, this.startPos + new Vector3(0,0,-4), this.slideProgress);
			if(this.transform.position == this.startPos + new Vector3(0,0,-4))
			{
				this.dir = 0;
				this.startPos = this.transform.position;
				this.slideProgress = 0f;
			}
		}
	}
}
