using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScripts : MonoBehaviour
{
    public float Y_offset = 3.8f;
    public float Spawn_Rate = 5f;
    private float Spawn_Timer = 6f;
    public GameObject EnemyObject;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if (Spawn_Timer > Spawn_Rate)
        {
            Instantiate(EnemyObject, new Vector3(transform.position.x, Random.Range(transform.position.y - Y_offset, transform.position.y + Y_offset), transform.position.z), Quaternion.identity);
            Spawn_Timer = 0f;
        }
        Spawn_Timer += Time.deltaTime;
    }
}
