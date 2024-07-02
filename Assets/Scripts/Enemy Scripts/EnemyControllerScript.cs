using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMoveScript : MonoBehaviour
{
   
    public float MoveSpeed = 2f;
    public float max_X = -15f;
    public float Attack_Timer = 1f;
    private float Current_Attack_Timer;
    private bool Can_Attack;
    private bool Enemy_Is_Destroyed;
    public Animator anim;
    public LogicScript logic;

    [SerializeField]
    private GameObject Enemy_Bullet;

    [SerializeField]
    private Transform Enemy_Attack_Point;

    // Start is called before the first frame update
    void Start()
    {
        Current_Attack_Timer = Attack_Timer;
        Attack_Timer = 0f;
        logic = GameObject.FindGameObjectWithTag("LogicObject").GetComponent<LogicScript>();
        
        EnemyRotate();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
        Attack();
        EnemyDestroy();
       
    }

    void EnemyMove()
    {
        Vector3 temp = transform.position;
        temp.x -= MoveSpeed*Time.deltaTime;
        transform.position = temp;
    }

    void EnemyRotate()
    {
        //z_rotate  = transform.rotation.z;
        //z_rotate += 90;
        transform.Rotate(0f, 0f, 90f);
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
                Instantiate(Enemy_Bullet, Enemy_Attack_Point.position, Quaternion.identity);
            }
        
    }

    void EnemyDestroy()
    {
        if(transform.position.x < max_X)
        {
            gameObject.SetActive(false);
        }
        if(Enemy_Is_Destroyed && anim.GetCurrentAnimatorStateInfo(0).IsName("Destroy"))
        {
            gameObject.SetActive(false);
            logic.AddScore();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "PlayerBulletTag" && !Enemy_Is_Destroyed)
            {
            
            Enemy_Is_Destroyed = true;
            anim.SetBool("EnemyHit", true);
            collision.gameObject.SetActive(false);  
            Debug.Log("Enemy hit");
        }
        if (collision.gameObject.tag == "PlayerTag" && !Enemy_Is_Destroyed)
        {
            Enemy_Is_Destroyed = true;
            anim.SetBool("EnemyHit", true);
            Debug.Log("Enemy player collide");
        }
        if (collision.gameObject.tag == "ShieldUseTag")
        {
           
            Enemy_Is_Destroyed = true;
            anim.SetBool("EnemyHit", true);
            Debug.Log("Enemy Shield collide");
        }
    }

   
}
