using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

    [SerializeField]
    private Joystick _joystick = null;

    public float SPEED;
	
	// Update is called once per frame
	private void Update () {
        Vector3 pos = transform.position;

        pos.x += _joystick.Position.x * SPEED;
        pos.z += _joystick.Position.y * SPEED;

        transform.position = pos;
	}
}
