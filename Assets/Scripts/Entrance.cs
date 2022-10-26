using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entrance : MonoBehaviour
{
    public GameObject entrance;
    public int score = 0;
    bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (entrance.GetComponent<CheeseGirl>().score == 12)
        {
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        isOpen = true;
    }
    public void CloseDoor()
    {
        isOpen = false;
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
