using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
            FindObjectOfType<GameManager>().pickupsCollected += 1;
            FindObjectOfType<GameManager>().pickupsLeft -= 1;
        }
    }
}
