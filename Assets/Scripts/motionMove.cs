using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public class motionMove : MonoBehaviour
	{


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
			
		}
		public void movePlayerForward()
		{
			cc.isLook = true;
			moveForward = true;
		}
		public void stopPlayerMove()
		{
			cc.isLook = false;
			moveForward = false;
		}
	}
		
}
