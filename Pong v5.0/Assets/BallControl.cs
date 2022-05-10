using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(10, -15));
        }
        else
        {
            rb2d.AddForce(new Vector2(-10, -15));
        }
    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
    }
    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 2);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            if (vel.x > 0)
            {
                rb2d.AddForce(new Vector2(10, 1));
                vel.y = (rb2d.velocity.y + 5) + (coll.collider.attachedRigidbody.velocity.y / 3);
                rb2d.velocity = vel;
            }
            else if(vel.x <= 0)
            {
                rb2d.AddForce(new Vector2(-10, 1));
                vel.y = (rb2d.velocity.y + 5) + (coll.collider.attachedRigidbody.velocity.y / 3);
                rb2d.velocity = vel;
            }
            
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
