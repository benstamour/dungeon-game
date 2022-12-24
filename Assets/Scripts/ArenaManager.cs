using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script to spawn character chosen by player with corresponding spawn point
public class ArenaManager : MonoBehaviour
{
	public GameObject serazPrefab;
	public GameObject aestaPrefab;
	public GameObject gavaanPrefab;
	public GameObject xaleriePrefab;
	private GameManager gameManagerScript;
	private string character;
	
    // Start is called before the first frame update
    void Start()
    {
		// location that character begins at
		Vector3 startLoc = new Vector3(-12f, 0.5f, 33f);
		
        try
		{
			this.gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
			
			// gets chosen character from game manager
			this.character = gameManagerScript.getChar();
		}
		catch
		{
			// this block should only be executed during testing
			var charList = new List<string>{"Gavaan","Xalerie","Seraz","Aesta"};
			int index = Random.Range(0, charList.Count);
			this.character = charList[index];
		}
		
		// instantiates chosen character at starting location
		switch(this.character)
		{
			case "Seraz":
			{
				Instantiate(serazPrefab, startLoc, Quaternion.identity);
				break;
			}
			case "Aesta":
			{
				Instantiate(aestaPrefab, startLoc, Quaternion.identity);
				break;
			}
			case "Gavaan":
			{
				Instantiate(gavaanPrefab, startLoc, Quaternion.identity);
				break;
			}
			case "Xalerie":
			{
				Instantiate(xaleriePrefab, startLoc, Quaternion.identity);
				break;
			}
			default:
			{
				Instantiate(gavaanPrefab, startLoc, Quaternion.identity);
				break;
			}
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
