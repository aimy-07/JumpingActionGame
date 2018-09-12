using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionScript : MonoBehaviour
{
    public GameObject Enemy, EndMessage,Hit,Gauge;
    GameObject[] Enemies;
    EnemyStatus status;
    private bool Jumping, Click,Top;
    public Vector3 pos;
    private float t;
    public float Speed;
    private float Base = 1;
    public float Max;
    public int Hp;
    public int EnemyNum;

    // Use this for initialization
    void Start()
    {
        Click = false;
        Top = false;
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        ///Debug.Log(Enemies.Length);
    }

    // Update is called once per frame
    void Update()
    {
        GetEnemy();

        if (pos.y > Base)
        {
            Jumping = true;
        }
        else
        {
            Jumping = false;
        }


        if (Click)
        {
            if (pos.y >= Max) Top = true;

            if (Top)
            {
                t += Time.deltaTime;
                if (t < 0.1f)
                {
                    pos.y = Max;
                }
                else
                {
                    Down();
                }
            }
            else
            {
                Up();
            }
            ResetPos();
        }
    }


    private void Up()
    {
        pos.y += Speed;
        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }

    private void Down()
    {
        pos.y -= Speed;
        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }

    private void ResetPos() { 
        if (pos.y <= Base)
        {
            t = 0;
            transform.position = new Vector3(pos.x, Base, pos.z);
            Click = false;
            Top = false;
        }
    }
    

    private void Attack()
    {
        if (pos.y > status.S1 && pos.y < status.E1)
        {
            Debug.Log("Attack!");
            Enemy.tag = "Untagged";
            Destroy(Enemy);
            Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            Hit.SetActive(true);
            Gauge.SetActive(false);
        }
        else
        {
            Debug.Log("Damage!");
            Hp -= 1;
            if(Hp == 0)
            {
                EndMessage.SetActive(true);
            }
        }
        var Y = pos.y;
    }


    public void OnClick()
    {
        Hit.SetActive(false);
        if (Jumping)
        {
            Attack();
        }
        else
        {
            pos = transform.position;
            Click = true;
        }
    }

    public bool JumpCheck
    {
        get { return Jumping; }
    }

    private void GetEnemy()
    {
        float min = Vector3.Distance(Enemies[0].transform.position, transform.position);
        Enemy = Enemies[0];
        EnemyNum = Enemies.Length;

        for(int i = 1; i < EnemyNum; i++)
        {
            if (min > Vector3.Distance(Enemies[i].transform.position, transform.position))
            {
                min = Vector3.Distance(Enemies[i].transform.position, transform.position);
                Enemy = Enemies[i];             
            }

        }
        status = Enemy.GetComponent<EnemyStatus>();
    }
}

