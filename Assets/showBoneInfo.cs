using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showBoneInfo : MonoBehaviour {
	public GameObject b1,b2,b3,b4,b5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{

		StartCoroutine (showInfo ());
	}

	IEnumerator showInfo()
	{
		b1.SetActive (true);
		yield return new WaitForSeconds (2f);
		b2.SetActive (true);
		yield return new WaitForSeconds (2f);
		b3.SetActive (true);
		yield return new WaitForSeconds (2f);
		b4.SetActive (true);
		yield return new WaitForSeconds (2f);
		b5.SetActive (true);
		yield return new WaitForSeconds (2f);
	}
}
