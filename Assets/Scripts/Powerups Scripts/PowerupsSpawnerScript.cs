using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupsSpawnerScript : MonoBehaviour
{
    
    public GameObject IncHealth;
    public GameObject BulletRate;
    public GameObject Shield;
    private GameObject PowerupToBeSpawned;
    private float HeightOffset = 3.2f;
    public int  choice;
    public  float PowerupSpawnMaxTime = 20f;
    public float timerspeed = 1f;
    public float timer = 0f;
 

    
    void Start()
    {
        //SpawnPowerup();
    }

    
    void Update()
    {
        PowerupSpawnTimer();
    }

    public void PowerupSpawnTimer()
    {
        timer += timerspeed * Time.deltaTime;
        if (timer >= PowerupSpawnMaxTime)
        {
            SpawnPowerup();
            timer = 0f;
        }
    }
    public void SelectPowerup()
    {
        choice =  Random.Range(1,4);
        if (choice == 1 )
        {
            IncHealth.SetActive(true);
            PowerupToBeSpawned = IncHealth;
        }
        else if(choice == 2 )
        {
            BulletRate.SetActive(true);
            PowerupToBeSpawned = BulletRate;
        }
        else if (choice == 3 )
        {
            Shield.SetActive(true);
            PowerupToBeSpawned = Shield;
        }

    }
    public void SpawnPowerup()
    {
        SelectPowerup();
        Instantiate(PowerupToBeSpawned, new Vector3(transform.position.x, Random.Range(transform.position.y - HeightOffset, transform.position.y + HeightOffset), transform.position.z), Quaternion.identity);
    }
}
