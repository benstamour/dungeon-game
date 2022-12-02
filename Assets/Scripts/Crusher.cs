using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{
	private Vector3 startPos = Vector3.zero;
	private float speed = 0.5f;
	private bool moveActivated = false;
	[SerializeField] int dir = 0;
	
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
		if(moveActivated)
		{
			if(this.dir == 0)
			{
				this.transform.position = Vector3.MoveTowards(this.transform.position, this.startPos + new Vector3(0,0,1f), speed*Time.deltaTime);
				if((this.transform.position - (this.startPos + new Vector3(0,0,1f))).magnitude <= 0.05)
				{
					this.transform.position = this.startPos + new Vector3(0,0,1f);
				}
				if(this.transform.position == this.startPos + new Vector3(0,0,1f))
				{
					this.dir = 1;
					this.startPos = this.transform.position;
				}
			}
			else
			{
				this.transform.position = Vector3.MoveTowards(this.transform.position, this.startPos + new Vector3(0,0,-1f), speed*Time.deltaTime);
				if((this.transform.position - (this.startPos + new Vector3(0,0,-1f))).magnitude <= 0.05)
				{
					this.transform.position = this.startPos + new Vector3(0,0,-1f);
				}
				if(this.transform.position == this.startPos + new Vector3(0,0,-1f))
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