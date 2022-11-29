using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
	private float startTime;
	private GameManager gameManagerScript;
	
	private Vector3 rotation;
	
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
		this.startTime = Time.time;
		this.gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
		this.gameManagerScript.incrementAttempts();
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
		}
	}
	
	void EndZone()
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
}
