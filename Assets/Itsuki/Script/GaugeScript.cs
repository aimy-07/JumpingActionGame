using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeScript : MonoBehaviour {
    public GameObject Player, Gauge, Area;
    GameObject Enemy;
    ActionScript actionscript;
    EnemyStatus enemystatus;

	// Use this for initialization
	void Start () {
        actionscript = Player.GetComponent<ActionScript>();
    }
	
	// Update is called once per frame
	void Update () {
        Enemy = Player.GetComponent<ActionScript>().Enemy;
        enemystatus = Enemy.GetComponent<EnemyStatus>();
        GaugeSet();
        GaugeMove();
        SetArea();
	}

    private void GaugeSet()
    {
        bool Check = actionscript.JumpCheck;

        if (Check)
        {
            Gauge.SetActive(true);
        }
        else
        {
            Gauge.SetActive(false);
        }
    }

    private void GaugeMove()
    {
        Gauge.GetComponent<Slider>().value = actionscript.pos.y * 10;
    }

    private void SetArea()
    {
        Area.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, enemystatus.S1 * 24, 0);
        Area.GetComponent<RectTransform>().sizeDelta = new Vector2(30, (enemystatus.E1 - enemystatus.S1) * 24);
    }
}
