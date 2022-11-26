using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	
	// put row of spikes above this bridge!
	// add walls!
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name == "Character")
		{
			ContactPoint contact = col.GetContact(0);
			Vector3 contactPoint = contact.point;
			gameObject.GetComponent<Rigidbody>().AddForceAtPosition(10f*Vector3.down,contactPoint, ForceMode.Force);
			
			Collider[] colliders = Physics.OverlapSphere(contactPoint, 1f);
			Debug.Log("C " + colliders.Length.ToString());
			foreach (Collider c in colliders)
			{
				try
				{
					//c.gameObject.GetComponent<Rigidbody>().AddExplosionForce(1000f,gameObject.transform.position, 1f, -10f);
					//c.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(5f*Vector3.down,gameObject.transform.position, ForceMode.Impulse);
					c.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(10f*Vector3.down,contactPoint, ForceMode.Force);
				}
				catch
				{
					
				}
			}
		}
	}
}