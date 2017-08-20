using UnityEngine;
using System.Collections;

public class playnextamb : MonoBehaviour {
	bool trig = false;
	public GameObject amb1, amb2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && !trig) {

			amb1.SetActive (false);
			amb2.SetActive (true);
			trig = true;
		}
	}
}
