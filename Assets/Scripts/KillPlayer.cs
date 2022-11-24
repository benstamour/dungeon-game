using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
	void Respawn()
	{
		SceneManager.LoadScene("Arena");
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "DeathZone")
		{
			Respawn();
		}
    }
}
