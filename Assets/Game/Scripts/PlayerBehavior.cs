using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public int health = 10;
    public float moveSpeed;
    public float rotateSpeed;

    private Rigidbody _rb;

    public GameObject bullet;
    public float timePerFire = 0.5f;
    [HideInInspector] public float lastFire;

    public bool onGround = false;
    public float jumpForce;
    private bool jumpOnLand;
    private float lastJump;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Move()
    {
        _rb.angularVelocity = new Vector3(0,Input.GetAxis("Horizontal") * rotateSpeed ,0);
        Vector3 move = transform.forward * Input.GetAxis("Vertical") * moveSpeed;
        move.y = _rb.velocity.y;
        _rb.velocity = move;
    }

    private void Fire()
    {
        if(Input.GetAxis("Fire1") > 0.9f)
        {
            if(lastFire > timePerFire)
            {
                GameObject newBullet = Instantiate(bullet, this.transform.position + this.transform.forward, transform.rotation);
            }
            lastFire = 0;
        }
        else
        {
            lastFire += Time.deltaTime;
        }
    }

    private void Hop()
    {
        if (onGround)
        {
            if (jumpOnLand && lastJump < 0.5f)
            {
                lastJump = 0;
                _rb.AddForce(new Vector3(0,jumpForce,0));
            }
            if (Input.GetAxis("Jump") > 0.9 && lastJump > 0.1f)
            {
                lastJump = 0;
                _rb.AddForce(new Vector3(0,jumpForce,0));
            }
            jumpOnLand = false;
        }
        else
        {
            if (Input.GetAxis("Jump") > 0.9 && lastJump > 0.1f)
            {
                lastJump = 0;
                jumpOnLand = true;
            }
        }
        lastJump += Time.deltaTime;
        onGround = false;
    }

    void Update()
    {
        Move();
        Fire();
        Hop();
        if (transform.position.y <= -10)
        {
            health = 0;
        }
    }

    public void OnCollisionStay(Collision col)
    {
        if( col.gameObject.layer == 3)
        {
            if(col.transform.position.y + 0.3f < transform.position.y)
            {
                onGround = true; 
            }
        }
    }
}
