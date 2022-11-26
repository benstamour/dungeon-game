using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlatform : MonoBehaviour
{
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
			if((hit.collider.gameObject.name == "Circuit Tile" || hit.collider.gameObject.name == "Lifting Platform") && hit.distance <= 1.3)
			{
				gameObject.transform.parent = hit.collider.gameObject.transform;
			}
			// move this to script on planks; Rotate()?
			else if((hit.collider.gameObject.tag == "BalancePlank" && hit.distance <= 1.3) || ((hit.collider.gameObject.name == "UnderBridge") && GetComponent<CharacterController>().isGrounded))
			{
				//hit.collider.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(2f*Vector3.down,gameObject.transform.position);
				
				/*gameObject.GetComponent<Rigidbody>().AddForceAtPosition(10f*Vector3.down,gameObject.transform.position+Vector3.down, ForceMode.VelocityChange);*/
				
				/*Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, 1f);
				Debug.Log("C " + colliders.Length.ToString());
				foreach (Collider c in colliders)
				{
					try
					{
						//c.gameObject.GetComponent<Rigidbody>().AddExplosionForce(1000f,gameObject.transform.position, 1f, -10f);
						//c.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(5f*Vector3.down,gameObject.transform.position, ForceMode.Impulse);
						//c.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(5f*Vector3.down,gameObject.transform.position+Vector3.down, ForceMode.Impulse);
					}
					catch
					{
						
					}
				}*/
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
