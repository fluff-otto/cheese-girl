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

   
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // up

            rb.position = new Vector2((float)Math.Round(rb.position.x), rb.position.y+speed * Time.deltaTime);
        }
        
        else if (Input.GetKey(KeyCode.S))
        {
            rb.position = new Vector2((float)Math.Round(rb.position.x), rb.position.y-speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rb.position = new Vector2(rb.position.x+speed * Time.deltaTime, (float)Math.Round(rb.position.y));
        }

        else if (Input.GetKey(KeyCode.A))
        {
            rb.position = new Vector2(rb.position.x-speed * Time.deltaTime, (float)Math.Round(rb.position.y));
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

        }

        if (collision.gameObject.name.StartsWith("Ogre"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
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
    }

}
