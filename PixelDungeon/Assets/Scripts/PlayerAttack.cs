using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float force;

    private void Update()
    {

    }

    //private Vector3 SetDestination()
    //{
    //    //Touch attckTouch = Input.GetTouch(0);
    //    //if (attckTouch.phase == TouchPhase.Stationary)
    //    //{
    //    //    Vector3 touchPos = Camera.main.ScreenToWorldPoint(attckTouch.position);
    //    //    Vector3 destination = touchPos - transform.position;
    //    //    destination.Normalize();
    //    //    return destination;
    //    //}
    //}

    public void SpawnBullet()
    {
        //GameObject bullet = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
        //Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        Touch [] attckTouch = Input.touches;
        for (int touch = 0; touch < Input.touchCount; touch++)
        {
            if (attckTouch[touch].phase == TouchPhase.Stationary)
            {
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(attckTouch[touch].position);
                Vector3 destination = touchPos - transform.position;
                destination.Normalize();

                
                GameObject bullet = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(destination * force, ForceMode2D.Impulse);
            }
        }
        

        //rb.AddForce(() * force, ForceMode2D.Impulse);
    }
}
