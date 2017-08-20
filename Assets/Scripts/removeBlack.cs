using UnityEngine;
using System.Collections;

public class removeBlack : MonoBehaviour {
	public GameObject doorblackshade,blackhole,ambience1,ambience2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			Destroy (doorblackshade);
			Destroy (blackhole);
			ambience1.SetActive (true);
			ambience2.SetActive (true);
		}
	}
}
