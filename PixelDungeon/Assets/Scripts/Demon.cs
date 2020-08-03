using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : EnemyBehaviour
{
    private Transform targetPlayer;

    // Start is called before the first frame update
    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public override void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
    }

    public override void TakeDamage()
    {
        
    }

}
