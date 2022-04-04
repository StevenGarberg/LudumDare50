using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
Rigidbody2D platformRigidBody;

    private void Start()
    {
        platformRigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.tag.Equals("Player"))
        {
            Invoke("PlatformFall", 50f * Time.deltaTime);
            Destroy (gameObject, 150f * Time.deltaTime);
        }
    }

    public void PlatformFall()
    {
        platformRigidBody.isKinematic = false;
    }

}
