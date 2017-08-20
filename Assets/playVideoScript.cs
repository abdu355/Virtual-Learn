using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playVideoScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
		((MovieTexture)GetComponent<Renderer> ().material.mainTexture).loop = true;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
