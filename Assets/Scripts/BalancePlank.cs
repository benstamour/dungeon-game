using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for the unstable planks on the second bridge
public class BalancePlank : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	// when player lands on a plank, add downward force where player is standing
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Character")
		{
			ContactPoint contact = col.GetContact(0);
			Vector3 contactPoint = contact.point;
			gameObject.GetComponent<Rigidbody>().AddForceAtPosition(1f*Vector3.down,contactPoint, ForceMode.Force);
			
			Collider[] colliders = Physics.OverlapSphere(contactPoint, 1f);
			foreach (Collider c in colliders)
			{
				try
				{
					//c.gameObject.GetComponent<Rigidbody>().AddExplosionForce(1000f,gameObject.transform.position, 1f, -10f);
					//c.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(5f*Vector3.down,gameObject.transform.position, ForceMode.Impulse);
					c.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(1f*Vector3.down,contactPoint, ForceMode.Force);
				}
				catch
				{
					
				}
			}
		}
	}
}
