using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    Rigidbody2D rigidBodyPWRUP;
    SpringJoint2D springJoint2D;
    private void Awake()
    {
        rigidBodyPWRUP = GetComponent<Rigidbody2D>();
        springJoint2D = GetComponent<SpringJoint2D>();
    }

    private void OnTriggerEnter2D(Collider2D tag)
    {
        if (tag.CompareTag("Player"))
        {
           Invoke(nameof(EnableSpringJoint), 50f * Time.deltaTime);
           Invoke(nameof(DisableSpringJoint), 150f * Time.deltaTime);
        }   
    }

    private void EnableSpringJoint()
    {
        springJoint2D.enabled = true;
    }
    private void DisableSpringJoint(){
        springJoint2D.enabled = false;
    }
}
