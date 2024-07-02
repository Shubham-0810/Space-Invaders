using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncHealthScript : MonoBehaviour
{
    public GameObject Player;
    public PlayerControllerScript PlayerController;
    private HealthBarScript HealthBar;
    private LogicScript Logic;
    private PowerupsScript Powerups;

    private void Start()
    {
        PlayerController = GameObject.FindGameObjectWithTag("PlayerTag").GetComponent<PlayerControllerScript>();
        HealthBar = GameObject.FindGameObjectWithTag("HealthBarTag").GetComponent<HealthBarScript>();
        Logic = GameObject.FindGameObjectWithTag("LogicObject").GetComponent<LogicScript>();
        Powerups = GameObject.FindGameObjectWithTag("PowerupsTag").GetComponent <PowerupsScript>();
    }

    private void Update()
    {
        Move();
        Powerups.DestroyPowerup(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerTag")
        {
            IncHealth();
            gameObject.SetActive(false);
        }
    }
    void IncHealth() 
    {
        Logic.playerHealth = PlayerController.MaxHealth;
        PlayerController.CurrentHealth = PlayerController.MaxHealth;
        HealthBar.SetHealth(PlayerController.MaxHealth);
    }

    void Move()
    {
        Powerups.MovePowerup(gameObject);
    }

}
