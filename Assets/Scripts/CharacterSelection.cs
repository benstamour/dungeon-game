/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for character selection screen
public class CharacterSelection : MonoBehaviour
{
	private GameManager gameManagerScript;
	
    // Start is called before the first frame update
    void Start()
    {
		this.gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void SelectCharacter(string character)
	{
		this.gameManagerScript.SetCharacter(character);
		this.gameManagerScript.StartGame();
	}
}
*/