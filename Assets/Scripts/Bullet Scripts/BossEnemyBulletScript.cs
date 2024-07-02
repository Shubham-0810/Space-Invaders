/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyBulletScript : MonoBehaviour
{
    private float BulletSpeed = 0.2f;
    public float max_X = -15f;
    public bool Bullet_Is_Destroyed;
    public int BulletHealth = 1;
    public Vector2 direction = new Vector2(-1, 0);
    public Vector2 velocity;

    public Animator anim_Bullet;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Deactivate_Bullet();
    }

    void Move()
    {
        velocity = direction * BulletSpeed;
        Vector2 temp = transform.position;
        temp += velocity * Time.deltaTime;
        transform.position = temp;
    }
    void Deactivate_Bullet()
    {
        if (transform.position.x < max_X)
        {
            gameObject.SetActive(false);
        }
        if (Bullet_Is_Destroyed && anim_Bullet.GetCurrentAnimatorStateInfo(0).IsName("BossBulletDestroy"))
        {
            gameObject.SetActive(false);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "PlayerBulletTag" )
        {
            if (BulletHealth <= 0) {
                Bullet_Is_Destroyed = true;
                anim_Bullet.SetBool("BossBulletCollide", true);
                collision.gameObject.SetActive(false);
                Debug.Log("Bullet Collide");
            }
            else {
                BulletHealth--;
                collision.gameObject.SetActive(false);
                Debug.Log("Bullet Collide");
            }
        }



    }
}*/


using UnityEngine;

public class BossEnemyBulletScript : MonoBehaviour
{
    private float BulletSpeed = 15f;
    public bool Bullet_Is_Destroyed;
    public int BulletHealth = 1;
    public Animator anim_Bullet;
    public Vector2 direction;
    public Vector2 velocity;

    
    void Start()
    {
             
    }

    
    void Update()
    {
        Move();
        Deactivate_Bullet();
    }

    void Move()
    {
       
        Vector2 velocity = direction * BulletSpeed;
        Vector2 temp = (Vector2)transform.position + velocity * Time.deltaTime;
        transform.position = temp;
    }

    void Deactivate_Bullet()
    {
        if (transform.position.x < -15f)
        {
            gameObject.SetActive(false);
        }
        if (Bullet_Is_Destroyed && anim_Bullet.GetCurrentAnimatorStateInfo(0).IsName("BossBulletDestroy"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBulletTag")
        {

            if (BulletHealth >= 5)
            {
                Bullet_Is_Destroyed = true;
                anim_Bullet.SetBool("BossBulletCollide", true);
                collision.gameObject.SetActive(false);
                Debug.Log("Bullet Collide");
            }
            else
            {
                BulletHealth--;
                collision.gameObject.SetActive(false);
                Debug.Log("Bullet Collide");
            }
        }

        
    }
}
