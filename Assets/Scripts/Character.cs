using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	private CharacterController characterController;
	public float speed = 5f;
	private Vector3 playerVelocity;
	private bool groundedPlayer;
	private float jumpHeight = 1f;
	private float gravityValue = -9.81f;
	private float turnSpeed = 1.5f;
	[SerializeField] private bool isActive = true;
	private int score = 0;
	
	private Vector3 rotation;
	
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
		groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
		
		if(this.isActive)
		{
			this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * turnSpeed*100 * Time.deltaTime, 0);
 
			Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
			move = this.transform.TransformDirection(move);
			characterController.Move(move * speed);
			this.transform.Rotate(this.rotation);
			
			if (Input.GetButton("Jump") && groundedPlayer)
			{
				playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
			}
		
			playerVelocity.y += gravityValue*Time.deltaTime;
			characterController.Move(playerVelocity*Time.deltaTime);
		}
		else
		{
			characterController.Move(Vector3.zero);
		}
    }
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "EndZone")
		{
			this.EndZone();
			Debug.Log("H");
		}
	}
	
	void EndZone()
	{
		this.isActive = false;
	}
	
	public void IncrementScore()
	{
		this.score++;
		Debug.Log(this.score);
	}
}
