using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadeSpr : MonoBehaviour {

	 Renderer renderer;

	// Use this for initialization
	void Start () {

			    if (renderer == null) Debug.Log("Renderer is empty"); 
			GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On; 
			GetComponent<Renderer>().receiveShadows = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
