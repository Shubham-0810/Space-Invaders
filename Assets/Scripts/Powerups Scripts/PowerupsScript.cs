using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerupsScript : MonoBehaviour
{
    private float MoveSpeed = 4f;
    public bool PowerupIsActive;
    public float Min_x = -15f;

    public void MovePowerup(GameObject gmobj)
    {
        Vector3 temp  = gmobj.transform.position;
        temp.x -= MoveSpeed * Time.deltaTime;
        gmobj.transform.position = temp;
    }

    public void DestroyPowerup(GameObject go)
    {
        if (go.transform.position.x <= Min_x)
        {
            go.SetActive(false);
        }
    }
    
}
