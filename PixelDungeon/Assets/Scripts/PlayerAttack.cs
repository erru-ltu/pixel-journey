using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //object to spawn
    public GameObject bulletPrefab;
    //force for bullet
    public float force;

    public void SpawnBullet()
    {
        Touch [] attckTouch = Input.touches;
        for (int touch = 0; touch < Input.touchCount; touch++)
        {
            //if we touch the screen and hold the finger
            if (attckTouch[touch].phase == TouchPhase.Stationary) 
            {
                //set destination for spawn bullet
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(attckTouch[touch].position);
                Vector3 destination = touchPos - transform.position;
                destination.Normalize();

                //spawn bullet and add force
                GameObject bullet = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(destination * force, ForceMode2D.Impulse);
            }
        }
    }
}
