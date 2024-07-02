using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BossEnemyControllerScript : MonoBehaviour
{
    private float Attack_Timer = 3f;
    private float Current_Attack_Timer;
    private bool Can_Attack;
    private bool Enemy_Is_Destroyed;
    Vector2 direction; 
    public float BossMoveSpeed = 1f;
    private float BossPosition_X = 8.5f;
    public float BossRotationSpeed = 10f;
    public GameObject Player;
    private bool BossInPosition;
    public int MaxHealth = 20;
    public int CurrentHealth;
    public BossHealthBarScript HealthBar;
    public GameObject GameOverScreenUI;
    public GameObject GameplayScreenUI;
    public GameObject PauseMenuUI;
    public GameObject BossHealthBar;


    [SerializeField]
    private GameObject Boss_Bullet;

    [SerializeField]
    private Transform Boss_Attack_Point;

    void Start()
    {
        BossHealthBar.SetActive(true);
        Current_Attack_Timer = Attack_Timer;
        Attack_Timer = 0f;
        HealthBar.SetMaxHealth(MaxHealth);
        CurrentHealth = MaxHealth;

    }

    

    void Update()
    { 
        ReachOnPosition();
        if (BossInPosition)
        {
            BossRotation();
            Attack();
        }     
        BossDestroy();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "PlayerBulletTag")
        {
            collision.gameObject.SetActive(false);
            CurrentHealth--;
            HealthBar.SetHealth(CurrentHealth);
        }


        if (CurrentHealth <= 0)
        {
            Enemy_Is_Destroyed = true;
        }
        

    }
    void BossDestroy()
    {

        if (Enemy_Is_Destroyed )
        {
            gameObject.SetActive(false);
            Time.timeScale = 0f;
            PauseMenuUI.SetActive(false);
            GameplayScreenUI.SetActive(false);
            GameOverScreenUI.SetActive(true);

            Debug.Log("Boss destroyed");
        }
    }

    void Attack()
    {
        if (Attack_Timer > Current_Attack_Timer)
        {
            Can_Attack = true;
        }
        else
        {
            Attack_Timer += Time.deltaTime;
        }

        if (Can_Attack && !Enemy_Is_Destroyed)
        {
            Can_Attack = false; 
            Attack_Timer = 0f;

            Vector2 direction = (Player.transform.position - transform.position).normalized;

           
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 180;

            
            GameObject go = Instantiate(Boss_Bullet, Boss_Attack_Point.position, Quaternion.Euler(0, 0, angle));
           BossEnemyBulletScript goBullet = go.GetComponent<BossEnemyBulletScript>();
            goBullet.direction = direction;
        }
    }


    void ReachOnPosition()
    {
        Vector3 temp = transform.position;
        if(temp.x >= BossPosition_X)
        {
            temp.x -= BossMoveSpeed * Time.deltaTime;
        }
        if(temp.x <= BossPosition_X)
            BossInPosition = true;
        transform.position = temp;
    }

    void BossRotation()
    {
        Vector3 temp_player = Player.transform.position;
        Vector3 temp_boss = transform.position;
        Vector3 direction = temp_player - temp_boss;
        float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg - 270;
        
        Quaternion angleAxis = Quaternion.AngleAxis(angle,Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, angleAxis, BossRotationSpeed * Time.deltaTime); 
    }
}

