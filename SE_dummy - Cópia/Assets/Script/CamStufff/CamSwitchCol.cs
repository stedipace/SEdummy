﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitchCol : MonoBehaviour {

	public static bool isTouchingCanChange;
	public int myCurrentCam;
	

	// Use this for initialization
	void Start () 
	{

		
	}
	
	// Update is called once per frame
	void Update () 
	{

		
	}



			public void OnTriggerEnter(Collider collider)
	{


		if (collider.tag == "Player")
		{
			isTouchingCanChange=true;
		
			//myCurrentCam+=1;

			//else if(myCurrentCam==1){myCurrentCam-=1;}
			


		}
		
		
		}

		
				public void OnTriggerExit(Collider collider)
	{


		if (collider.tag == "Player")
		{
			isTouchingCanChange=false;
		
			//myCurrentCam+=1;

			//else if(myCurrentCam==1){myCurrentCam-=1;}
			


		}
		
		
		}



}
