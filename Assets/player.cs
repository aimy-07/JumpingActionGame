using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	public GameObject cam;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("up")){
			transform.position+=transform.forward*0.1f;
		}
		if(Input.GetKey("down")){
			transform.position-=transform.forward*0.1f;
		}
		if(Input.GetKey("right")){
			transform.position+=transform.right*0.1f;
		}
		if(Input.GetKey("left")){
			transform.position-=transform.right*0.1f;
		}
		if(Input.GetKey("d")){
			cam.transform.Rotate(new Vector3(0,1,0));
		}
		if(Input.GetKey("a")){
			cam.transform.Rotate(new Vector3(0,-1,0));
		}
	}
}
