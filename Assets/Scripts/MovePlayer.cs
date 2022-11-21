using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
	private bool moving = true;
	private float moveForce = 1000f;
	private float jumpForce = 20f;
	[SerializeField] private Rigidbody rb;
	private bool jumping = false;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
			Jump();
		}
    }
	
	void FixedUpdate()
	{
		if(moving){
			// direction
			Vector3 dir = Vector3.zero;
			if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
				dir += Vector3.right;
			}
			if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
				dir += Vector3.left;
			}
			if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
				dir += Vector3.forward;
			}
			if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
				dir += Vector3.back;
			}
			
			rb.AddForce(dir*moveForce*Time.fixedDeltaTime);
		}
	}
	
	void Jump()
	{
		if(jumping == false)
		{
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			jumping = true;
		}
	}
}
