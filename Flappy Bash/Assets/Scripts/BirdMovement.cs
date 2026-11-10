using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class BirdMovement : MonoBehaviour
{
    float minY;
    Rigidbody2D rb;
    [SerializeField] float jumpPower = 8;
    [SerializeField] float gravity = 2;
    [SerializeField] float speedX = 2;

    Transform graphics;
    // Start is called before the first frame update
    void Start()
    {
        graphics = transform.GetChild(0);
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravity;
        minY = transform.position.y;
    }

    private void OnDisable()
    {
        rb.gravityScale = 0;
        rb.velocity = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < minY) Jump();
        RotateToVelocity();
    }
    
    void Jump()
    {
        float rx = speedX + Random.Range(-0.1f, 0.1f);
        float rj = jumpPower + Random.Range(1f, -1f);

        rb.velocity = new Vector2(rx, rj);
    }

    void RotateToVelocity()
    {
        Vector3 dir = rb.velocity.normalized;
        dir.y = dir.y / 2;
        graphics.right = dir;
    }

}
