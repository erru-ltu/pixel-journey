using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum PlayerState
{
    idle,
    walking,
    attacking
}

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    bool shortAttack = true;

    [SerializeField]
    bool longAttack = false;

    [SerializeField]
    public PlayerState currentState;

    private Rigidbody2D rb;
    public VirtualJoystick joystick;
    private Animator anim;

    public float speed;
    public float timeBtwAttack;
    private float startTimeBtwAttack;

    public bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        startTimeBtwAttack = timeBtwAttack;
        //currentState = PlayerState.idle;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(joystick.Horizontal() != 0 || joystick.Vertical() != 0)
        {
            Movement();
            currentState = PlayerState.walking;
            anim.SetBool("walking", true);
        }
        else
        {
            rb.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            anim.SetBool("walking", false);
        }

        SwordAttack();    
    }


    private void Movement()
    {
        //set direction and speed of movement
        rb.velocity = new Vector2(joystick.Horizontal() * speed, joystick.Vertical() * speed);

        if (joystick.Horizontal() > 0)
        {           
            //player spirte set to right
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(joystick.Horizontal() < 0)
        {
            //player sprite set to left
            transform.localScale = new Vector3(-1, 1, 1);
        }

        
    }

    public void SwordAttack()
    {
        if(Input.touchCount > 0 && !IsPointerOverGameObject())
        {
            Touch attackTouch = Input.GetTouch(0);
            if (attackTouch.phase == TouchPhase.Began)
            {
                StartCoroutine(SwordAttackCo());
            }
        }       
    }


    public void SwitchAttackMode()
    {
        if (shortAttack && !longAttack)
        {
            shortAttack = false;
            longAttack = true;
        }
        else if(!shortAttack && longAttack)
        {
            shortAttack = true;
            longAttack = false;
        }

        Debug.Log(shortAttack);
    }

    private IEnumerator SwordAttackCo()
    {
        if (shortAttack && !isAttacking)
        {
            isAttacking = true;
            currentState = PlayerState.attacking;
            anim.SetBool("shortAttack", true);
            yield return new WaitForSeconds(0.5f);
            anim.SetBool("shortAttack", false);
            isAttacking = false;
            currentState = PlayerState.idle;
        }
        else if(longAttack && !isAttacking)
        {
            isAttacking = true;
            currentState = PlayerState.attacking;
            anim.SetBool("longAttack", true);
            yield return new WaitForSeconds(0.5f);
            anim.SetBool("longAttack", false);
            isAttacking = false;
            currentState = PlayerState.idle;
        }
    }

    public static bool IsPointerOverGameObject()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if(EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
            {
                return true;
            }
        }
        return false;
    }

}
