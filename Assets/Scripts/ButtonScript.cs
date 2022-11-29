using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
}
