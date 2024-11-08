using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector2 maxSpeed;
    [SerializeField] Vector2 timeToFullSpeed;
    [SerializeField] Vector2 timeToStop;
    [SerializeField] Vector2 stopClamp;
    Vector2 moveDirection;
    Vector2 moveVelocity;
    Vector2 moveFriction;
    Vector2 stopFriction;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveVelocity = 2 * maxSpeed / timeToFullSpeed;
        moveFriction = -2 * maxSpeed / (timeToFullSpeed * timeToFullSpeed);
        stopFriction = -2 * maxSpeed / (timeToStop * timeToStop);
    }

    public void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        moveDirection = new Vector2(inputX, inputY).normalized;

        if (moveDirection != Vector2.zero)
        {
            Vector2 targetVelocity = moveDirection * maxSpeed;
            rb.velocity = Vector2.ClampMagnitude(rb.velocity + targetVelocity * Time.fixedDeltaTime, maxSpeed.magnitude);
        }
        else
        {
            rb.velocity += GetFriction() * Time.fixedDeltaTime;

            if (Mathf.Abs(rb.velocity.x) < stopClamp.x) rb.velocity = new Vector2(0, rb.velocity.y);
            if (Mathf.Abs(rb.velocity.y) < stopClamp.y) rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }

    Vector2 GetFriction()
    {
        if (rb.velocity != Vector2.zero)
        {
            return -rb.velocity.normalized * (moveDirection != Vector2.zero ? moveFriction.magnitude : stopFriction.magnitude);
        }
        return Vector2.zero;
    }

    public bool IsMoving()
    {
        return rb.velocity != Vector2.zero;
    }

    public void MoveBound()
    {
        
    }
}
