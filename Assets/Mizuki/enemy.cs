using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class enemy : MonoBehaviour {

	public Vector3 enpos = new Vector3();
	public Vector3 plpos = new Vector3();
	public GameObject player;
	public float kyori;
	public float speed;
	public float muki;
	public float ct;

	 
	// Use this for initialization
	void Start () {
		ct=0;
		transform.localEulerAngles = new Vector3();
	}
	
	// Update is called once per frame
	void Update () {
		enpos = transform.position; 
		plpos = player.transform.position;
		kyori = Mathf.Abs(enpos.x-plpos.x)+Mathf.Abs(enpos.y-plpos.y)+Mathf.Abs(enpos.z-plpos.z);
		if(kyori> 15){
			speed =3;
		}
		if(kyori <=15){
			speed =1.5f;
		}
		ct += Time.deltaTime;
		if(ct >= speed){
			rad();
			ct=0;
		}
	}
	public void rad()
    {
        muki = Mathf.Atan2((plpos.x - enpos.x), (plpos.z - enpos.z)) * Mathf.Rad2Deg;
        transform.localEulerAngles = new Vector3(0, muki, 0);
        mov();
		print(muki);
    }

    private void mov()
    {
        transform.position += transform.forward;
    }
	void OnCollisionEnter(Collision other)
	{
		if(other.transform==player){
			SceneManager.LoadScene("");
		}
	}
}
