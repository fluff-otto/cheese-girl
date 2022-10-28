using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private World2 world2Object;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] world = GameObject.FindGameObjectsWithTag("World");
        world2Object = world[0].GetComponent<World2>();
        Debug.Log("world object " + world2Object);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 coordinate = world2Object.RandomCobble();
        collision.gameObject.transform.position = coordinate;
        
    }
}
