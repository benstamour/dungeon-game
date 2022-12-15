using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for mini spikeball trap
public class MiniSpikyBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter(Collision col)
    {
		// once mini spikeballs reach bottom of lava pit, set them to inactive
		if(col.gameObject.name == "Spikeball Pit Bottom")
		{
			gameObject.SetActive(false);
		}
    }
}
