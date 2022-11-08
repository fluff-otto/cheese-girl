using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class Ogre : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 4;
    private int direction = 0;
    private int eatenGrass = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (direction == 0)
        {
            rb.MovePosition(new Vector2(speed, 0) * Time.deltaTime + rb.position);
        }

        else if (direction == 1)
        {
            rb.MovePosition(new Vector2(0, speed) * Time.deltaTime + rb.position);
        }

        else if (direction == 2)
        {
            rb.MovePosition(new Vector2(-speed, 0) * Time.deltaTime + rb.position);
        }

        else if (direction == 3)
        {
            rb.MovePosition(new Vector2(0, -speed) * Time.deltaTime + rb.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        int deltaDirection = Random.Range(0, 2);
        deltaDirection *= 2;
        direction += deltaDirection;
        direction = direction % 4;
        //SnapToGrid();

        if (direction == 0 || direction == 2)
        {
            SnapToGridY();
        }
        else
        {
            SnapToGridX();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        direction = Random.Range(0, 4);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name.StartsWith("Lava"))
        {
            
            int deltaDirection = Random.Range(0, 2);
            deltaDirection *= 2;
            direction += deltaDirection;
            direction = direction % 4;
            if (direction == 1 || direction == 3)
            {
                SnapToGridY();
            }
            else
            {
                SnapToGridX();
            }
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Lava"))
        {
            int deltaDirection = Random.Range(0, 2);
            deltaDirection *= 2;
            direction += deltaDirection;
            direction = direction % 4;
            if (direction == 1 || direction == 3)
            {
                SnapToGridY();
            }
            else
            {
                SnapToGridX();
            }
        }
    }


    private void SnapToGrid()
    {
        if(direction == 0 || direction == 2)
        {
            SnapToGridX();
        }

    }
    private void SnapToGridX()
    {
        rb.position = new Vector2((float)System.Math.Round(rb.position.x), rb.position.y);
    }

    private void SnapToGridY()
    {
        rb.position = new Vector2(rb.position.x, (float)System.Math.Round(rb.position.y));

    }

    
   
    /*private void ResetSpeed()
    {
        int x = 0;
        int y = 0;
        if (direction == 0)
        {
            x = 1;
        }
        else if (direction == 1)
        {
            y = 1;
        }
        else if (direction == 2)
        {
            x = -1;
        }
        else if (direction == 3)
        {
            y = -1;
        }
        rb.velocity = new Vector2(x, y)* speed;
    }
    */
}
