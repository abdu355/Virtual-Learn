using UnityEngine;
using System.Collections;

public class insertkey : MonoBehaviour {
	private bool trig1,trig2,trig3;
	public GameObject l1, l2, l3,dkey,gkey,skey,door,house,doorsound,doortrigger;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "DiamondKey") {
			l1.SetActive (true);
			dkey.SetActive (true);
			other.gameObject.SetActive (false);
			trig1 = true;
			//other.gameObject.transform.position = new Vector3 (160.29f,6.55f,177.32f);
		}
		if (other.gameObject.name == "GoldenKey") {
			l2.SetActive (true);
			gkey.SetActive (true);
			other.gameObject.SetActive (false);
			trig2 = true;
			//other.gameObject.transform.position = new Vector3 (160.13f,4.14f,171.97f);
			//other.gameObject.transform.eulerAngles = new Vector3 (-46.4f, -90f, -92.397f);

		}
		if (other.gameObject.name == "StaffKey") {
			l3.SetActive (true);
			skey.SetActive (true);
			other.gameObject.SetActive (false);
			trig3 = true;
			//other.gameObject.transform.position = new Vector3 (160.13f,4.14f,171.97f);
			//other.gameObject.transform.eulerAngles = new Vector3 (-46.4f, -90f, -92.397f);

		}
		if (trig1 && trig2 && trig3) {
			//keyhole.SetActive (false);
			//gkey.SetActive (false);
			//dkey.SetActive (false);
			door.GetComponent<Animator>().Play("openDoor");
			doorsound.SetActive (true);
			//house.GetComponent<loadbasement> ().enabled = true;
			doortrigger.SetActive(true);
		}

	}
}
