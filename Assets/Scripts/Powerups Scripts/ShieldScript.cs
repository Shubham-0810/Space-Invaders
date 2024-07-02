using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    private PowerupsScript Powerups;
    public GameObject ShieldUse;

    private void Start()
    {
        Powerups = GameObject.FindGameObjectWithTag("PowerupsTag").GetComponent<PowerupsScript>();
    }
    private void Update()
    {
        Move();
       Powerups.DestroyPowerup(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerTag")
        {
            ShieldUse.SetActive(true);
            gameObject.SetActive(false);
           
        }
    }

    void Move()
    {
        Powerups.MovePowerup(gameObject);
    }

}
