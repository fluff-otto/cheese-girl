using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using TMPro;


public class CheeseGirl : MonoBehaviour

{ 
    private Rigidbody2D rb;
    private float speed = 6;
    public TMP_Text text;
    public int score = 0;
    public int targetscore = 12;
    private int direction = 0;
    

   
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            // up

            rb.position = new Vector2((float)Math.Round(rb.position.x), rb.position.y+speed * Time.deltaTime);
            direction = 1;
            SnapToGrid();
        }
        
        else if (Input.GetKey(KeyCode.S))
        {
            // down

            rb.position = new Vector2((float)Math.Round(rb.position.x), rb.position.y-speed * Time.deltaTime);
            direction = 3;
            SnapToGrid();
        }

        else if (Input.GetKey(KeyCode.D))
        {
            // right

            rb.position = new Vector2(rb.position.x+speed * Time.deltaTime, (float)Math.Round(rb.position.y));
            direction = 0;
            SnapToGrid();
        }

        else if (Input.GetKey(KeyCode.A))
        {
            // left

            rb.position = new Vector2(rb.position.x-speed * Time.deltaTime, (float)Math.Round(rb.position.y));
            direction = 2;
            SnapToGrid();
        }

        else if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name.StartsWith("Grass"))
        {
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.name.StartsWith("Crystal"))
        {
            Destroy(collision.gameObject);
            score++;
            text.text = "Score: " + score;

            if (score >= targetscore)
            {
                targetscore = targetscore + 12;
            }

        }

        if (!collision.gameObject.name.StartsWith("Ogre"))
        {
            return;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    private void SnapToGrid()
    {
        if (direction == 0 || direction == 2)
        {
            SnapToGridY();
        }
        else
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.name.StartsWith("Lava"))
        {
            
            int deltaDirection = UnityEngine.Random.Range(1, 3);
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
}
