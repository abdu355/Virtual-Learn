using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;

public class UserInput : MonoBehaviour
{


    /*
    
     Good luck folks! If you say to thanks, my LinkedIn profile link below
     
     https://www.linkedin.com/in/malisasmaz
     
     you can +rep my skills thanks!
     
     VR_LIONEYE HAVE 4 MOD; 
          FOR MOD CHANGE PRESS @-A   -Mouse mod ** my codes not work on this mode
                               @-B   -Horizontal bluetooth controller mode
                               @-C   -Vertical bluetooth controller mode
                               @-D   -Inactive mod also don't work nothing
         for activate or changing modes press @ and other button what you need same time until see light
     
    joystick button 3           - A     -X1

    joystick button 0           - B     -X2

    joystick button 2           - C

    joystick button 1           - D

    joystick button 11          - OnOff //only work @C mod 

    */


    public GameObject myGo;
	//public GameObject myOb;
    public Text myText;
	Teleport te;
	public Camera cam;
	public GameObject player;


    float roll, pitch;

    void Update()
    {
        roll = Input.GetAxis("Horizontal");     //joystick horizontal
        pitch = Input.GetAxis("Vertical");      //joystick vertical

		//Camera.main.transform.position += new Vector3(roll * 0.1f, 0, pitch * 0.1f);


        //Bluetooth Controller Joystick
        if (Input.GetAxis("Vertical") > 0)
        {
           // ButtonName("Up Pressed");
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            //ButtonName("Down Pressed");
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
           // ButtonName("Right Pressed");
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
           // ButtonName("Left Pressed");
        }




        // Bluetooth Controller Buttons VR_Lioneye
        if (Input.GetButtonDown("A"))
        {
           //jump
        }
        if (Input.GetButtonDown("B"))
        {
			//showtips
        }
        if (Input.GetButtonDown("X"))
        {
           //carrydrop objects
        }
        if (Input.GetButtonDown("Y"))
        {
           //run
        }
        if (Input.GetButtonDown("OnOff"))
        {
     		//reset game
			ButtonName ("Game Reset...Please Wait");
			SceneManager.LoadScene(0);
			Debug.Log ("game reset");
        }
		if (Input.GetButtonDown("Z1"))
		{
			//ButtonName ("R1 pressed");
		}
		if (Input.GetButtonDown("Z2"))
		{
			//ButtonName ("L1 pressed");
		}

    }

    public void ButtonName(string ButtonName)
    {
        myText.text = ButtonName;
    }
}
