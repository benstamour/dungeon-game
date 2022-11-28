using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlatform : MonoBehaviour
{
	private bool rampTrapTriggered = false;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void FixedUpdate()
	{
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
		{
			if((hit.collider.gameObject.name == "Circuit Tile" || hit.collider.gameObject.name == "Lifting Platform" || hit.collider.gameObject.tag == "BoulderPlatform") && hit.distance <= 1.3)
			{
				gameObject.transform.parent = hit.collider.gameObject.transform;
			}
			else if(this.rampTrapTriggered == false && hit.collider.gameObject.tag == "Spikeball Ramp")
			{
				GameObject miniSpikeballs = GameObject.Find("Mini Spikeballs");
				foreach(Transform child in miniSpikeballs.transform)
				{
					Rigidbody rb = child.GetComponent<Rigidbody>();
					rb.useGravity = true;
					rb.isKinematic = false;
				}
				this.rampTrapTriggered = true;
			}
			else
			{
				gameObject.transform.parent = null;
			}
		}
		else
		{
			gameObject.transform.parent = null;
		}
	}
}
