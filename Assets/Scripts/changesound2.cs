using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.FirstPerson{
	public class changesound2 : MonoBehaviour {


		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {

		}

		void OnTriggerEnter (Collider other)
		{
			if (other.gameObject.tag == "Player") {

				other.GetComponent<RigidbodyFirstPersonController> ().inforest = false;
				other.GetComponent<RigidbodyFirstPersonController> ().incuberoom = true;
				other.GetComponent<RigidbodyFirstPersonController> ().inhouse = false;
			}

		}
	}
}
