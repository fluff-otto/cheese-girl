using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class World2 : MonoBehaviour
{
    public GameObject darkWall;
    public GameObject entrance;
    public GameObject portal;
    public GameObject cobble;
    public GameObject heart;
    public GameObject lava;

    public int antal = 12;
    private int score = 0;
    private int targetscore = 12;
    public TMP_Text text;


    // Start is called before the first frame update
    void Start()
    {
        targetscore = 12;

        for (int x = -22; x <= 22; x++)
        {
            int y = 10;

            Instantiate(darkWall, new Vector2(x, y), Quaternion.identity);
            Instantiate(darkWall, new Vector2(x, -y), Quaternion.identity);
        }

        for (int y = -10; y <= 10; y++)
        {
            int x = 22;

            Instantiate(darkWall, new Vector2(x, y), Quaternion.identity);
            Instantiate(darkWall, new Vector2(-x, y), Quaternion.identity);
        }

        for (int x = -20; x <= 20; x = x + 2)
        {
            for (int y = -8; y <= 8; y = y + 2)
            {
                Instantiate(lava, new Vector2(x, y), Quaternion.identity);
                // slumpa tal 0 - 100
                // 0 - 25 => lava
                // resten mark

            }
        }


         for (int x = -20; x <= 20; x = x + 2)
         {
            
            for (int y = -9; y <= 9; y = y + 2)
            {
                int i = Random.Range(0, 100);
                if (i < 45)
                {
                    Instantiate(lava, new Vector2(x, y), Quaternion.identity);
                }
                
                else
                {
                    Instantiate(cobble, new Vector2(x, y), Quaternion.identity);
                }
            }
         }

         for (int x = -21; x <= 21; x = x + 2)
         {
            for (int y = -8; y <= 8; y = y + 2)
            {
                int i = Random.Range(0, 100);
                if (i < 45)
                {
                    Instantiate(lava, new Vector2(x, y), Quaternion.identity);
                }
                
                else
                {
                    Instantiate(cobble, new Vector2(x, y), Quaternion.identity);
                }
            }
         }

         for (int x = -21; x <= 21; x = x +2)
        {
            for (int y = -9; y <= 9; y = y + 2)
            {
                Instantiate(cobble, new Vector2(x, y), Quaternion.identity);
            }
        }
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
