using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
	private CharacterController characterController;
	private float speed = 5f;
	private Vector3 playerVelocity;
	private bool groundedPlayer;
	private float jumpHeight = 1f;
	private float gravityValue = -9.81f;
	private float turnSpeed = 1.5f;
	[SerializeField] private bool isActive = true;
	private int score = 0;
	private float startTime;
	private GameManager gameManagerScript;
	private Vector3 rotation;
	
	//public Animation anim;
	public Animator animator;
	private bool isJumping = false;
	private bool isWalkingForward = false;
	private bool isWalkingBackward = false;
	private bool isTurningLeft = false;
	private bool isTurningRight = false;
	
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
		this.startTime = Time.time;
		this.gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
		this.gameManagerScript.incrementAttempts();
		
		/*foreach (AnimationState state in anim)
        {
			Debug.Log("C");
			Debug.Log(state.ToString());
		}*/
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
				
				if(jumpHeight * -3.0f * gravityValue >= 0)
				{
					this.isJumping = true;
					//animator.SetBool("isIdle", false);
				}
				//anim.CrossFade("Jump");
			}
			else if(groundedPlayer)
			{
				this.isJumping = false;
			}
			
			if(Input.GetAxisRaw("Horizontal") * turnSpeed*100 * Time.deltaTime < 0)
			{
				this.isTurningLeft = true;
				this.isTurningRight = false;
			}
			else if(Input.GetAxisRaw("Horizontal") * turnSpeed*100 * Time.deltaTime > 0)
			{
				this.isTurningLeft = false;
				this.isTurningRight = true;
			}
			else
			{
				this.isTurningLeft = false;
				this.isTurningRight = false;
			}
			
			if(Input.GetAxisRaw("Vertical") > 0)
			{
				this.isWalkingForward = true;
				this.isWalkingBackward = false;
			}
			else if(Input.GetAxisRaw("Vertical") < 0)
			{
				this.isWalkingForward = false;
				this.isWalkingBackward = true;
			}
			else
			{
				this.isWalkingForward = false;
				this.isWalkingBackward = false;
			}
			
			animator.SetBool("isJumping", false);
			animator.SetBool("isWalkingForward", false);
			animator.SetBool("isWalkingBackward", false);
			animator.SetBool("isTurningLeft", false);
			animator.SetBool("isTurningRight", false);
			animator.SetBool("isIdle", false);
			if(this.isJumping)
			{
				animator.SetBool("isJumping", true);
			}
			else if(this.isWalkingForward)
			{
				animator.SetBool("isWalkingForward", true);
			}
			else if(this.isWalkingBackward)
			{
				animator.SetBool("isWalkingBackward", true);
			}
			else if(this.isTurningLeft)
			{
				animator.SetBool("isTurningLeft", true);
			}
			else if(this.isTurningRight)
			{
				animator.SetBool("isTurningRight", true);
			}
			else
			{
				animator.SetBool("isIdle", true);
			}
			
			playerVelocity.y += gravityValue*Time.deltaTime;
			if(this.isJumping && playerVelocity.y < 0)
			{
				animator.SetBool("isJumping", false);
				animator.SetBool("isIdle", true);
			}
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
		}
	}
	
	private void EndZone()
	{
		this.isActive = false;
		float totalTime = Time.time - this.startTime;
		
		this.gameManagerScript.setScore(this.score);
		this.gameManagerScript.setTime(totalTime);
		
		//SceneManager.LoadScene("EndScreen");
		this.gameManagerScript.EndZone();
	}
	
	public void IncrementScore()
	{
		this.score++;
	}
	
	private bool AnimPlaying()
	{
		return this.animator.GetCurrentAnimatorStateInfo(0).length > this.animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
	}
	
	private bool AnimPlaying(string stateName)
	{
		return AnimPlaying() && this.animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
	}
}
