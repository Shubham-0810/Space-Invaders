using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRateActiveScript : MonoBehaviour
{
    private PlayerControllerScript PlayerController;

    private float BulletRateMaxTime = 7f;
    public float timerspeed = 1f;
    public float timer = 0f;
    private float BulletRateChange = 0.1f;

    private void Start()
    {
        PlayerController = GameObject.FindGameObjectWithTag("PlayerTag").GetComponent<PlayerControllerScript>();        
    }


    public void Update()
    {
        SetBulletRate();
        BulletRateTime();
    }


    public void BulletRateTime()
    {
        timer += timerspeed * Time.deltaTime;
        if (timer >= BulletRateMaxTime)
        {
            ResetBulletRate();
            timer = 0f;
            gameObject.SetActive(false);
        }
    }

    public void SetBulletRate()
    {
        if (timer == 0)
        {
            Debug.Log("BulletRateSet");
            PlayerController.Current_Attack_Timer -= BulletRateChange;
        }
    }

    public void ResetBulletRate()
    {
        Debug.Log("BulletRateReset");
        PlayerController.Current_Attack_Timer += BulletRateChange;
    }
}
