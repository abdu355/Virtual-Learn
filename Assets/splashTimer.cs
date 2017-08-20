using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splashTimer : MonoBehaviour {
	public GameObject screenfader;
	// Use this for initialization
	void Start () {
		StartCoroutine (splashscreenTimer ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator splashscreenTimer()
	{
		yield return new WaitForSeconds (4f);
		screenfader.GetComponent<levelchange> ().changeLevel (1);
	}
}
