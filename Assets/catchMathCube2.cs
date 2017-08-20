using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchMathCube2 : MonoBehaviour {
	public GameObject b2,pointlight;
	private bool trig=false;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.tag == "Mathblock" && !trig) {
			trig = true;
			other.gameObject.SetActive (false);
			b2.SetActive (true);
			pointlight.SetActive (true);

		}

	}
}
