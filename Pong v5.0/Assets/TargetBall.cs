using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBall : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public GameManager ui;
    
    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(40, 0));
        }
        else
        {
            rb2d.AddForce(new Vector2(40, 0));
        }
    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
        GoBall();
        ui = GameObject.FindWithTag("ui").GetComponent<GameManager>();
       
    }
    
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Ball"))
        {
            Destroy(gameObject);
            ui.IncrementScore();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
