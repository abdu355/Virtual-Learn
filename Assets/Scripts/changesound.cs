using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.FirstPerson{
public class changesound : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") {

				other.GetComponent<RigidbodyFirstPersonController> ().inforest = true;
				other.GetComponent<RigidbodyFirstPersonController> ().incuberoom = false;
				other.GetComponent<RigidbodyFirstPersonController> ().inhouse = false;
		}

	}
}
}
