using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite openDoor;
    public Sprite closeDoor;
    public GameObject f;
    private SpriteRenderer sprite;
    public int score = 0;
    

  
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
    }
    public void CloseDoor()
    {
        
    }
}
