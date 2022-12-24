using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// script that stores game data so that it is saved if a new scene loads or if the current scene reloads
public class GameManager : MonoBehaviour
{
	private int score = 0;
	private float timeTaken = 0f;
	private int numAttempts = 0;
	private string character = "";
	
	public AudioClip menuSoundtrack;
	public AudioClip arenaSoundtrack;
	
	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
		this.LoadStartScreen();
	}
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void SetCharacter(string character)
	{
		this.character = character;
	}
	
	public void setScore(int score)
	{
		this.score = score;
	}
	
	public int getScore()
	{
		return this.score;
	}
	
	public void setTime(float time)
	{
		this.timeTaken = time;
	}
	
	public float getTime()
	{
		return this.timeTaken;
	}
	
	public void LoadStartScreen()
	{
		SceneManager.LoadScene("StartScreen");
		
		AudioSource audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.clip = menuSoundtrack;
		audioSource.Stop();
		audioSource.loop = true;
		audioSource.Play();
	}
	
	public void StartGame()
	{
		SceneManager.LoadScene("Arena");
		
		AudioSource audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.Stop();
		audioSource.clip = arenaSoundtrack;
		audioSource.loop = true;
		audioSource.Play();
	}
	
	public void EndZone()
	{
		SceneManager.LoadScene("EndScreen");
	}
	
	public void incrementAttempts()
	{
		this.numAttempts += 1;
	}
	
	public int getAttempts()
	{
		return this.numAttempts;
	}
	
	public string getChar()
	{
		return this.character;
	}
}
