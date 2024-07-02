using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;
    public float speed = 5f;
    public float min_Y = -4.3f;
    public float max_Y = 4.3f;
    public float max_X = 15f;
    public float Attack_Timer = 0.3f;
    public float Current_Attack_Timer;
    private bool Can_Attack;
    private bool Static_Bullet_Ispresent;
    public GameObject GameOverScreenUI;
    public GameObject GameplayScreenUI;
    public GameObject PauseMenuUI;
    public GameObject staticBullet;
    public HealthBarScript HealthBar;
    private PauseScreenScript PauseScreenScript;
    public bool Player_Is_Destroyed;
    public Animator anim_player;

    public LogicScript logic;

    [SerializeField]
    private GameObject player_Bullet;

    [SerializeField]
    private Transform Attack_Point;

    [SerializeField]
    private GameObject static_Player_Bullet;

    [SerializeField]
    private Transform static_Bullet_Point;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("LogicObject").GetComponent<LogicScript>();
        MaxHealth = logic.playerHealth;
        HealthBar.SetMaxHealth(MaxHealth);
        CurrentHealth = MaxHealth;
        Current_Attack_Timer = Attack_Timer;
        PauseScreenScript = PauseMenuUI.GetComponent<PauseScreenScript>();
        PauseScreenScript.PressResume();
    }



    void Update()
    {
        MovePlayer();
        Attack();
        Static_Bullet();
        PlayerDestroy();
    }

    void MovePlayer()
    {
        if(Input.GetAxisRaw("Vertical") > 0f)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;
            
            if(temp.y > max_Y)
                temp.y = max_Y;

            transform.position = temp;
        }
         else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;

            if (temp.y < min_Y)
                temp.y = min_Y;

            transform.position = temp;
        }
    }//MovePlayer

    void Attack()
    {
        if(Attack_Timer > Current_Attack_Timer)
        {
            Can_Attack = true;
        }
        else 
        { 
            Attack_Timer += Time.deltaTime; 
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Can_Attack)
            {
                Static_Bullet_Ispresent = false;
                static_Player_Bullet.SetActive(false);
                Can_Attack = false;
                Attack_Timer = 0f;
                Instantiate(player_Bullet, Attack_Point.position, Quaternion.identity);
            }
        }
    }//Attack

    void Static_Bullet()
    {
        if (Static_Bullet_Ispresent == false && Attack_Timer > Current_Attack_Timer)
        {
            Static_Bullet_Ispresent = true;
            static_Player_Bullet.SetActive(true);
            
        }
        if(Static_Bullet_Ispresent == true && Attack_Timer > Current_Attack_Timer)
        {
            static_Player_Bullet.transform.position = static_Bullet_Point.position;
        }
    }//Static_Bullet

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "EnemyBulletTag")
        {
            collision.gameObject.SetActive(false);
            logic.Reduce_Health();
            HealthBar.SetHealth(logic.playerHealth);
        }
        if (collision.gameObject.tag == "BossBulletTag")
        {
            collision.gameObject.SetActive(false);
            logic.PlayerHealthChanger = 3;
            logic.Reduce_Health();
            logic.PlayerHealthChanger = 1;
            HealthBar.SetHealth(logic.playerHealth);
        }
        if (collision.gameObject.tag == "EnemyTag")
        {
            logic.PlayerHealthChanger = 2;
            logic.Reduce_Health();
            logic.PlayerHealthChanger = 1;
            HealthBar.SetHealth(logic.playerHealth);
        }
       
            if (logic.playerHealth <= 0)
            {
                staticBullet.SetActive(false);
                speed = 0f;
                Player_Is_Destroyed = true;
            }
            anim_player.SetBool("PlayerIsDestroyed", Player_Is_Destroyed);
        
    }

    void PlayerDestroy()
    {
       
        if (Player_Is_Destroyed && anim_player.GetCurrentAnimatorStateInfo(0).IsName("DestroyPlayer"))
        {
            gameObject.SetActive(false);
            Time.timeScale = 0f;
            PauseMenuUI.SetActive(false);
            GameplayScreenUI.SetActive(false);
            GameOverScreenUI.SetActive(true);
            
            Debug.Log("Player destroyed");
        }
    }

}//class
