using UnityEngine;
using System.Collections;

public class haunt : MonoBehaviour {

	public GameObject door,bulb1,bulb2,doorsound,ambsound,doorlight,admanager;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			StartCoroutine (hauntPlayer ());
		}


	}

	IEnumerator hauntPlayer()
	{
		yield return new WaitForSeconds(4);
		doorsound.SetActive (true);
		door.GetComponent<Animator> ().Play ("closeDoor");
		doorlight.SetActive (false);
		//yield return new WaitForSeconds(2);
		//ambsound.SetActive (true);
		yield return new WaitForSeconds(3);
		bulb1.SetActive (true);
		bulb2.SetActive (true);
		yield return new WaitForSeconds (8);
		admanager.GetComponent<LevelChanger> ().changeLevel ();

	}
}
