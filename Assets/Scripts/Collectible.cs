using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
	private Character characterScript;
	
    // Start is called before the first frame update
    void Start()
    {
        characterScript = GameObject.Find("Character").GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name == "Character")
		{
			characterScript.IncrementScore();
			this.gameObject.SetActive(false);
		}
	}
}
