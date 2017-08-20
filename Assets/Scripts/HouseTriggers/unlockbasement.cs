using UnityEngine;
using System.Collections;

public class unlockbasement : MonoBehaviour {

	public GameObject gkey,l2,door,doorp1,doorp2,dooropensound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject.name == "GoldenKey") {
			l2.SetActive (true);
			gkey.SetActive (true);
			other.gameObject.SetActive (false);
			door.GetComponent<Animator>().Play("openDoor");
			dooropensound.SetActive (true);
			//other.gameObject.transform.position = new Vector3 (160.13f,4.14f,171.97f);
			//other.gameObject.transform.eulerAngles = new Vector3 (-46.4f, -90f, -92.397f);
			doorp1.GetComponent<MeshCollider>().isTrigger=true;
			doorp2.GetComponent<MeshCollider>().isTrigger=true;
	}
}
}
