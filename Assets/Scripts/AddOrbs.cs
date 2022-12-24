using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddOrbs : MonoBehaviour
{
	public GameObject orbPrefab;
	
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(orbPrefab, new Vector3(15f, 2.5f, 56f), Quaternion.identity);
		Instantiate(orbPrefab, new Vector3(35f, 10.5f, 89.5f), Quaternion.identity);
		Instantiate(orbPrefab, new Vector3(21.5f, 10.5f, 98.5f), Quaternion.identity);
		Instantiate(orbPrefab, new Vector3(30.5f, 5.5f, 53.5f), Quaternion.identity);
		Instantiate(orbPrefab, new Vector3(-15f, 2.5f, 52.5f), Quaternion.identity);
		Instantiate(orbPrefab, new Vector3(-12f, 4f, 37.5f), Quaternion.identity);
		Instantiate(orbPrefab, new Vector3(-14f, 19f, 94.5f), Quaternion.identity);
		Instantiate(orbPrefab, new Vector3(47f, 12.5f, 67.5f), Quaternion.identity);
		Instantiate(orbPrefab, new Vector3(9f, 9.5f, 102.5f), Quaternion.identity);
		Instantiate(orbPrefab, new Vector3(33f, 10.5f, 76f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
