using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikyBall : MonoBehaviour
{
	private Vector3[] spawnPoints = new Vector3[3];
	//private int stage = 0;
	//private Vector3 startPos = Vector3.zero;
	//private float speed = 2f;
	
    // Start is called before the first frame update
    void Start()
    {
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
		//Debug.Log(col.gameObject.name);
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
