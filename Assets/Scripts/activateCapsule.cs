using UnityEngine;
using System.Collections;

public class activateCapsule : MonoBehaviour {
	public GameObject line1,line2;
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {


	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "diamondkey") {

			line1.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", Color.red);
			line2.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", Color.red);
			if(other.gameObject.GetComponent<Gazepickup> ()!=null)
				other.gameObject.GetComponent<Gazepickup> ().dropObject ();
		}

	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "diamondkey") {

			line1.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", Color.yellow);
			line2.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", Color.yellow);
		}

	}
}
