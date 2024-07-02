using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{
    public float BulletSpeed = 5f;
    public float max_X = 15f;
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
        temp.x += BulletSpeed * Time.deltaTime;
        transform.position = temp;
       
    }
    void Deactivate_Bullet()
    {
        if (transform.position.x > max_X)
        {
            gameObject.SetActive(false);
        }
    }

}
