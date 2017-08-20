using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startChemistry : MonoBehaviour {
	public GameObject vial1,vial2,p1,p2,p3,smokered,smokeblue,smokewhite;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="Player")
			StartCoroutine (showInfo ());
	}

	IEnumerator showInfo()
	{
		yield return new WaitForSeconds (3f);
		vial1.GetComponent<Animator> ().Play ("vial_pour");
		yield return new WaitForSeconds (0.2f);
		smokeblue.GetComponent<ParticleSystem> ().Play ();
		yield return new WaitForSeconds (3f);
		vial2.GetComponent<Animator> ().Play ("vial_pour2");
		yield return new WaitForSeconds (0.2f);
		smokered.GetComponent<ParticleSystem> ().Play ();
		yield return new WaitForSeconds (3f);
		smokewhite.GetComponent<ParticleSystem> ().Play ();
		p1.GetComponent<ParticleSystem> ().Play ();
		p2.GetComponent<ParticleSystem> ().Play ();
		p3.GetComponent<ParticleSystem> ().Play ();
	}
}
