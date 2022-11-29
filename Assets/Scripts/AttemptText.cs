using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AttemptText : MonoBehaviour
{
    private GameManager gameManagerScript;
	private int attempts = 0;
	
	public TextMeshProUGUI textComponent;
	
    // Start is called before the first frame update
    void Start()
    {
        this.gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
		this.attempts = gameManagerScript.getAttempts();
		UpdateAttempts(this.attempts);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateAttempts(int attempts)
	{
		textComponent.text = "Number of Attempts: " + attempts.ToString();
	}
}
