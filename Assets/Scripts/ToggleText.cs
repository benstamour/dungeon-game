using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// script to change text of sound and save point toggle buttons to match settings
public class ToggleText : MonoBehaviour
{
	private GameManager gameManagerScript;
	public TextMeshProUGUI textComponent;
	
    // Start is called before the first frame update
    void Start()
    {
		// change text to match current settings
        this.gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
		if(gameObject.name == "VolumeButton")
		{
			if(gameManagerScript.getVolume())
			{
				textComponent.text = "SOUND ON";
			}
			else
			{
				textComponent.text = "SOUND OFF";
			}
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}