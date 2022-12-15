using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for the large spikeball
public class SpikyBall : MonoBehaviour
{
	private Vector3[] spawnPoints = new Vector3[3];
	//private int stage = 0;
	//private Vector3 startPos = Vector3.zero;
	//private float speed = 2f;
	
    // Start is called before the first frame update
    void Start()
    {
		// 3 possible spawn points for the large spikeball: one in the middle and one each slightly to the left and right
        GameObject[] spawnPointObjects = GameObject.FindGameObjectsWithTag("Spikeball Spawn Points");
		for(int i = 0; i < 3; i++)
		{
			spawnPoints[i] = spawnPointObjects[i].transform.position;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	/*void FixedUpdate()
	{
		if(this.stage == 1)
		{
			Debug.Log("A");
			this.transform.position = Vector3.MoveTowards(this.transform.position, this.startPos + new Vector3(0,-5,0), speed*Time.deltaTime);
			if((this.transform.position - (this.startPos + new Vector3(0,-5,0))).magnitude <= 0.05)
			{
				this.transform.position = this.startPos + new Vector3(0,-5,0);
			}
			if(this.transform.position == this.startPos + new Vector3(0,-5,0))
			{
				this.stage = 0;
				Debug.Log("spikyball respawning...");
				gameObject.transform.position = spawnPoint;
				foreach (Transform child in gameObject.transform)
				{
					Physics.IgnoreCollision(child.GetComponent<Collider>(), GameObject.Find("Spikeball Lava").GetComponent<Collider>(), false);
				}
			}
		}
	}*/
	
	void OnCollisionEnter(Collision col)
    {
		// once the large spikeball reaches the bottom of the lava pit, respawn it at the top of the ramp at a random spawn point
        if(col.gameObject.name == "Spikeball Pit Bottom")
		{
			/*foreach (Transform child in gameObject.transform)
			{
				Physics.IgnoreCollision(child.GetComponent<Collider>(), col.gameObject.GetComponent<Collider>());
			}
			Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), col.gameObject.GetComponent<Collider>());
			this.stage = 1;
			this.startPos = gameObject.transform.position;*/
			int randSpawn = Random.Range(0,3);
			gameObject.transform.position = this.spawnPoints[randSpawn];
		}
    }
}
