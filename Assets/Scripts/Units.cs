using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units : MonoBehaviour
{
    /** 
        This class contains the basic properties of the interactable objects in the game,
        such as health, death effects;
     */
    public int health = 100;
    public int shield = 100;
    public float ruinSize = 0.3f;

    public GameObject deathEffect;

    public void ApplyDamage(int damage)
    {
        if(health > damage)
        {
            health -= damage;
        }
        else
        {
            health -= damage;
            Destruct();
        }
    }

    public void Destruct()
    {
        if(deathEffect != null)
        {
            Vector3 deathPos = transform.position;
            deathPos.y = 0f;
            Instantiate(deathEffect, deathPos, transform.rotation);
        }
        Destroy(gameObject, 0.1f);
    }
}
