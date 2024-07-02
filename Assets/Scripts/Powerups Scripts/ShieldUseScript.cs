using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUseScript : MonoBehaviour
{
    public GameObject Player;
    private PlayerControllerScript PlayerController;
    //public int ShieldHealth = 3;
    private float ShieldMaxTime = 8f;
    public float timerspeed = 1f;
    public float timer = 0f;
    public LogicScript logic;
    private void Start()
    {
        
        PlayerController = GameObject.FindGameObjectWithTag("PlayerTag").GetComponent<PlayerControllerScript>();
        logic = GameObject.FindGameObjectWithTag("LogicObject").GetComponent<LogicScript>();
        logic.PlayerHealthChanger = 0;

    }

    private void Update()
    {
        ShielduseMove();
        ShieldTime();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBulletTag" || collision.gameObject.tag == "BossBulletTag")
        {
            collision.gameObject.SetActive(false);
           
        }
       
    }

    public void ShieldTime()
    {
        timer += timerspeed * Time.deltaTime;
        if (timer >= ShieldMaxTime)
        {
            logic.PlayerHealthChanger = 1;
            timer = 0f;
            gameObject.SetActive(false);
        }
    }
    

    public void ShielduseMove()
    {
        Vector3 temp = Player.transform.position;
        transform.position = temp;
    }


}
