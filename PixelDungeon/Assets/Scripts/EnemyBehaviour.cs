using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemyBehaviour : MonoBehaviour
{
    public float speed;

    public int damage;
    public int health;

    public abstract void Movement();
   
    public abstract void TakeDamage();
}
