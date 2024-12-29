using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FoeBehavior : MonoBehaviour
{
    public GameObject player;
    public float notticeDistance;
    public float forgetDistance;
    public bool notticed;
    public NavMeshAgent ai;
    public float stunTime = 3;
    private float lastHit;

    void Update()
    {
        lastHit += Time.deltaTime;
        if (lastHit < stunTime)
        {
            ai.destination = transform.position;
            return;
        }
        if (notticed == true)
        {
            if (Vector3.Distance(transform.position, player.transform.position) > forgetDistance)
            {
                notticed = false;
                Debug.Log("Exited enemy view");
            }
            ai.destination = player.transform.position;
        }
        else
        {
            if (Vector3.Distance(transform.position, player.transform.position) < notticeDistance)
            {
                notticed = true;
                Debug.Log("Entered enemy view");
            }
            ai.destination = new Vector3(Mathf.Sin(Time.time * 0.05f) * 50, 0, Mathf.Cos(Time.time * 0.05f) * 50);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            FindObjectOfType<GameManager>().Hit();
        }
        if(col.gameObject.layer == 7)
        {
            lastHit = 0;
        }
    }
}
