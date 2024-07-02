using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float BulletSpeed = 3f;
    public float max_X = -15f;
    public bool Bullet_Is_Destroyed;

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
        Vector3 temp = transform.position;
        temp.x -= BulletSpeed * Time.deltaTime;
        transform.position = temp;
    }
    void Deactivate_Bullet()
    {
        if (transform.position.x < max_X)
        {
            gameObject.SetActive(false);
        }
        if (Bullet_Is_Destroyed && anim_Bullet.GetCurrentAnimatorStateInfo(0).IsName("EnemyBulletDestroy"))
        {
            gameObject.SetActive(false);
        }
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "PlayerBulletTag")
        {
            Bullet_Is_Destroyed = true;
            anim_Bullet.SetBool("BulletCollide", true);
            collision.gameObject.SetActive(false);
            Debug.Log("Enemy hit");
        }

        

    }
}
