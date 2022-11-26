using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
	private Character characterScript;
	private int rotation = 0;
	private float sum = 0f;
	
    // Start is called before the first frame update
    void Start()
    {
        characterScript = GameObject.FindWithTag("Character").GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void FixedUpdate()
	{
		if(rotation == 0)
		{
			this.transform.parent.Rotate(15*Time.fixedDeltaTime,60*Time.fixedDeltaTime,15*Time.fixedDeltaTime, Space.World);
			this.sum += 60*Time.fixedDeltaTime;
			if(this.sum >= 720)
			{
				rotation = 1;
				this.sum = 0;
			}
		}
		else
		{
			this.transform.parent.Rotate(45*Time.fixedDeltaTime,180*Time.fixedDeltaTime,45*Time.fixedDeltaTime, Space.World);
			this.sum += 180*Time.fixedDeltaTime;
			if(this.sum >= 720)
			{
				rotation = 0;
				this.sum = 0;
			}
		}
		
	}
	
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Character")
		{
			characterScript.IncrementScore();
			this.transform.parent.gameObject.SetActive(false);
		}
	}
}
