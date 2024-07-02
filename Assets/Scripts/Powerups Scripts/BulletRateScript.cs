using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRateScript : MonoBehaviour
{
    
    private PowerupsScript Powerups;
    public GameObject BulletRateActive;

    private void Start()
    {       
        Powerups = GameObject.FindGameObjectWithTag("PowerupsTag").GetComponent<PowerupsScript>();  
    }

    public void Update()
    {
        Powerups.MovePowerup(gameObject);
       Powerups.DestroyPowerup(gameObject);
    }


   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerTag")
        {
            Debug.Log("BulletRateChanged");
            BulletRateActive.SetActive(true);
            gameObject.SetActive(false);
        }
    }



}
