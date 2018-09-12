using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    private Vector3 Distance;
    public GameObject Player;

	// Use this for initialization
	void Start () {
        Distance = transform.position - Player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = Player.transform.position + Distance;
	}
}
