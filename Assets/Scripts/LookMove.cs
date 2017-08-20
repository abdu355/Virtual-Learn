using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public class LookMove : MonoBehaviour
	{

		public Transform vrCamera;
		public Transform player;

		public float toggleangle = 30.0f;

		public float speed = 3.0f;

		public bool moveForward;
		private Vector2 playerinput;

		private RigidbodyFirstPersonController cc;
		// Use this for initialization
		void Start ()
		{
	
			cc = GetComponent<RigidbodyFirstPersonController> ();
			playerinput = new Vector2 (0f, 1f);
		}
	
		// Update is called once per frame
		void Update ()
		{
			//Debug.Log ("lookmove cam angle:  "+ vrCamera.rotation.x);
			if (vrCamera.eulerAngles.x >= toggleangle && vrCamera.eulerAngles.x < 90.0f) {
				
				moveForward = true;
			} else {
				moveForward = false;
			}
			if (moveForward) {

				//Vector3 forward = player.TransformDirection (Vector3.forward);
			
				cc.isLook = true;
			}
			if (!moveForward) {
				cc.isLook = false;
			}
		}
	}
}
