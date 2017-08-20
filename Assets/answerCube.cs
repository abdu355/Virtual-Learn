using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerCube : MonoBehaviour {
	public GameObject wrongb,ansb,lightwrong,lightcorrect,cross,check,stars;
	public GameObject [] confetti;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.tag == "Mathblockwrong") {
			other.gameObject.SetActive (false);
			wrongb.SetActive (true);
			lightwrong.SetActive (true);
			cross.SetActive (true);
			check.SetActive (false);
		}
		if (other.gameObject.tag == "Mathblockans") {
			other.gameObject.SetActive (false);
			ansb.SetActive (true);
			wrongb.SetActive (false);
			lightwrong.SetActive (false);
			lightcorrect.SetActive (true);
			cross.SetActive (false);
			check.SetActive (true);
			stars.SetActive(true);
			for (int i = 0; i < confetti.Length; i++) {
				confetti [i].SetActive (true);
			}
		}
	}
}
