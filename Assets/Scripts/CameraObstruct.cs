using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObstruct : MonoBehaviour
{
	private List<GameObject> hiding = new List<GameObject>();
	private List<float> alphas = new List<float>();
	//private int fadeSpeed = 1;
	
    // Start is called before the first frame update
    void Start()
    {
        //this.hiding = GameObejct.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
		if(Physics.Raycast(transform.position, (gameObject.transform.parent.transform.position - transform.position).normalized, out hit, Mathf.Infinity))
		{
			if(hit.collider.gameObject.tag == "Character")
			{
				for(int i = 0; i < hiding.Count; i++)
				{
					StartCoroutine(Unobstruct(hiding[i], alphas[i]));
				}
			}
			else
			{
				GameObject obj = hit.collider.gameObject;
				Debug.Log(obj.name);
				float alpha = hit.collider.gameObject.GetComponent<Renderer>().material.color.a;
				this.hiding.Add(obj);
				this.alphas.Add(alpha);
				StartCoroutine(Obstruct(obj, alpha));
			}
		}
    }
	
	IEnumerator Unobstruct(GameObject obj, float origAlpha)
	{
		var color = obj.GetComponent<Renderer>().material.color;
		while(color.a < origAlpha)
		{
			color = obj.GetComponent<Renderer>().material.color;
			Color newColor = new Color(color.r, color.g, color.b, Mathf.Min(1, color.a + 0.01f));
			obj.GetComponent<Renderer>().material.SetColor("_Color", newColor);
			//color.a = Mathf.Min(1, color.a + this.fadeSpeed*Time.deltaTime);
			yield return null;
		}
		int index = this.hiding.FindIndex(a => a.GetInstanceID() == obj.GetInstanceID());
		this.hiding.RemoveAt(index);
		this.alphas.RemoveAt(index);
	}
	
	IEnumerator Obstruct(GameObject obj, float origAlpha)
	{
		Debug.Log("B");
		var color = obj.GetComponent<Renderer>().material.color;
		Debug.Log(color.a);
		while(color.a > 0.01)
		{
			Debug.Log("C");
			color = obj.GetComponent<Renderer>().material.color;
			Color newColor = new Color(color.r, color.g, color.b, Mathf.Max(0, color.a - 0.01f));
			obj.GetComponent<Renderer>().material.SetColor("_Color", newColor);//this.fadeSpeed*Time.deltaTime);
			Debug.Log(color.a);
			yield return null;
		}
	}
}
