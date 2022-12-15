using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// script for buttons on GUI screens
public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	// these functions load the corresponding scene
	public void LoadArena()
	{
		SceneManager.LoadScene("Arena");
	}
	
	public void LoadControls()
	{
		SceneManager.LoadScene("ControlScreen");
	}
	
	public void LoadStartScreen()
	{
		SceneManager.LoadScene("StartScreen");
	}
	
	public void LoadEndScreen()
	{
		SceneManager.LoadScene("EndScreen");
	}
	
	public void LoadInstructionScreen()
	{
		SceneManager.LoadScene("InstructionScreen");
	}
}
