using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Sprite openDoor;
    public Sprite closeDoor;
    public GameObject f;
    private SpriteRenderer sprite;
    public int score = 0;
    public bool isOpen = false;

    
    

  
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (f.GetComponent<CheeseGirl>().score == 12)
        {
            OpenDoor();
        }
        
        
    }

    public void OpenDoor()
    {
        sprite.sprite = openDoor;
        isOpen = true;
    }
    public void CloseDoor()
    {
        isOpen = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Player"))
        {
            if (isOpen)
            {
                SceneManager.LoadScene("Level2");
            }

        }
    }
}
