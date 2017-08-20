using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadDino : MonoBehaviour {
	public GameObject Door;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other)
	{
		StartCoroutine (openDoor ());

	}

	IEnumerator openDoor()
	{
		Door.GetComponent<Animator> ().Play ("openDoor");
		yield return new WaitForSeconds (3f);
		SceneManager.LoadSceneAsync ("Demo");
	}
}
