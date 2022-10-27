using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Chest : MonoBehaviour
{
    public int block = 0;

    private bool chest = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (chest)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                block += Random.Range(1, 6);
                Debug.Log(block);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Player")) 
        {
            chest = true;           
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Player"))
        {
            chest = false;
        }
        
    }
}
