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
    public GameObject deathEffect;

    public void ApplyDamage(int damage)
    {
        if(health > damage)
        {
            health = health - damage;
        }
        else
        {
            Destruct();
        }
    }

    public void Destruct()
    {
        if(deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
