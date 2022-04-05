using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private Rigidbody2D rb;

    private float height;

    private float speed = -3f;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        height = boxCollider.size.y;
        rb.velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > -height)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        Vector2 vector = new Vector2(0, height * 2f);
        transform.position = (Vector2)transform.position - vector;
    }
}
