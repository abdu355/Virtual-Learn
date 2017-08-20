using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mixChemical : MonoBehaviour {
	private bool ironAdded;
	private bool alumAdded,sugarAdded,bakingSodaAdded,potNitrateAdded,ignited, soapAdded, hydrogenAdded,yeastAdded;

	public GameObject blacksmoke,fire,yellowsmoke,txt,foam1,foam2,foam3;

	private bool trig1,trig2,trig3,trig4,trig5,trig6,trig7,trig8;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (alumAdded == true && ironAdded == true && ignited==true) { //thermite reaction complete

			txt.GetComponent<TextMesh> ().text = "Thermite Reaction (Heat)";
			blacksmoke.GetComponent<ParticleSystem> ().Play ();
			fire.SetActive (true);
			yellowsmoke.GetComponent<ParticleSystem> ().Stop ();
			alumAdded = false;
			ignited = false;
		}
		if (sugarAdded == true && bakingSodaAdded == true && potNitrateAdded==true && ignited ==true) { //yellow smoke bomb complete

			txt.GetComponent<TextMesh> ().text = "Yellow Smoke Bomb";
			yellowsmoke.GetComponent<ParticleSystem> ().Play ();
			fire.SetActive (false);
			sugarAdded = false;
			ignited = false;
		}
		if (soapAdded == true && hydrogenAdded == true && yeastAdded == true) {

			txt.GetComponent<TextMesh> ().text = "Elephant Toothpaste !";
			foam1.GetComponent<ParticleSystem> ().Play ();
			foam2.GetComponent<ParticleSystem> ().Play ();
			foam3.GetComponent<ParticleSystem> ().Play ();
			soapAdded = false;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject.tag == "ironoxide" && !trig1) {
			other.gameObject.GetComponent<Animator> ().enabled = true;
			other.gameObject.GetComponent<Animator> ().Play ("addiron");
			ironAdded = true;
			trig1 = true;

		}
		if (other.gameObject.tag == "aluminum" &&!trig2) {
			Debug.Log ("Alum Vial triggered");
			other.gameObject.GetComponent<Animator> ().enabled = true;
			other.gameObject.GetComponent<Animator> ().Play ("addalum");
			alumAdded = true;
			trig2 = true;

		}
		if (other.gameObject.tag == "potnitrate" &&!trig3) {
			other.gameObject.GetComponent<Animator> ().enabled = true;
			other.gameObject.GetComponent<Animator> ().Play ("addpot");
			potNitrateAdded = true;
			trig3 = true;

		}
		if (other.gameObject.tag == "bakingsoda" &&!trig4) {
			other.gameObject.GetComponent<Animator> ().enabled = true;
			other.gameObject.GetComponent<Animator> ().Play ("addbaking");
			bakingSodaAdded = true;
			trig4 = true;

		}
		if (other.gameObject.tag == "sugar" &&!trig5) {
			other.gameObject.GetComponent<Animator> ().enabled = true;
			other.gameObject.GetComponent<Animator> ().Play ("addsugar");
			sugarAdded = true;
			trig5 = true;

		}
		if (other.gameObject.tag == "lighter") {

			ignited = true;
		}
		if (other.gameObject.tag == "hydrogenperoxide" &&!trig6) {
			other.gameObject.GetComponent<Animator> ().enabled = true;
			other.gameObject.GetComponent<Animator> ().Play ("addsugar");
			hydrogenAdded = true;
			trig6 = true;
		}
		if (other.gameObject.tag == "yeast" &&!trig7) {
			other.gameObject.GetComponent<Animator> ().enabled = true;
			other.gameObject.GetComponent<Animator> ().Play ("addyeast");
			yeastAdded = true;
			trig7 = true;
		}
		if (other.gameObject.tag == "soap" &&!trig8) {
			other.gameObject.GetComponent<Animator> ().enabled = true;
			other.gameObject.GetComponent<Animator> ().Play ("addsoap");
			soapAdded = true;
			trig8 = true;
		}
	}
}
