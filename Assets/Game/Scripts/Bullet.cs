using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public GameObject blast;
    private float timeToLive = 5;
    void Update()
    {
        rb.velocity = this.transform.forward * speed; 
        timeToLive -= Time.deltaTime;
        if (timeToLive <= 0)
        {
            Instantiate(blast, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        Instantiate(blast, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
