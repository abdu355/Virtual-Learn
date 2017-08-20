using UnityEngine;
using System.Collections;

public class animateDoor : MonoBehaviour {
    public GameObject blackhole,doorpart1,doorpart2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {

			GetComponent<Animator> ().Play ("openDoor");
			doorpart1.GetComponent<MeshCollider> ().isTrigger = true;
			doorpart2.GetComponent<MeshCollider> ().isTrigger = true;
			if(blackhole!=null)
				blackhole.SetActive (true);
		}

	}
}
