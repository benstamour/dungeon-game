using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// displays the total time the player took to escape the dungeon on their last attempt
public class TimeText : MonoBehaviour
{
    private GameManager gameManagerScript;
	private float time = 0f;
	
	public TextMeshProUGUI textComponent;
	
    // Start is called before the first frame update
    void Start()
    {
        this.gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
		this.time = gameManagerScript.getTime();
		UpdateText(this.time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateText(float time)
	{
		int intTime = (int)time;
		int minutes = intTime / 60;
		int seconds = intTime % 60;
        textComponent.text = "Time  Taken:  " + minutes.ToString() + " : " + seconds.ToString("D2");
	}
}
