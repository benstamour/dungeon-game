using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    private Vector3 startPos = Vector3.zero;
	private float speed = 2f;
	
	// Start is called before the first frame update
    void Start()
    {
        this.startPos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void SlideTriggered()
	{
		StartCoroutine(Slide());
	}
	
	IEnumerator Slide()
	{
		while(this.transform.position != this.startPos + new Vector3(4,0,0))
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, this.startPos + new Vector3(4,0,0), speed*Time.deltaTime);
			if((this.transform.position - (this.startPos + new Vector3(4,0,0))).magnitude <= 0.05)
			{
				this.transform.position = this.startPos + new Vector3(4,0,0);
			}
			yield return null;
		}
	}
}
