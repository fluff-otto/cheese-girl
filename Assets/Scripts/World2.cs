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
    public GameObject crystal;
    public GameObject ogre;
    public GameObject chestRed;

    public int antal = 12;
    private int score = 0;
    private int targetscore = 12;
    public TMP_Text text;

    public bool boolPortal = false;
    List<Vector2> cobbleCoordinates = new List<Vector2>();
    


    // Start is called before the first frame update
    void Start()
    {
        float yMax = Camera.main.orthographicSize;
        float xMax = yMax * Camera.main.aspect;

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
                if (i < 40)
                {
                    Instantiate(lava, new Vector2(x, y), Quaternion.identity);
                }
                
                else
                {
                    Instantiate(cobble, new Vector2(x, y), Quaternion.identity);
                    cobbleCoordinates.Add(new Vector2(x, y));
                    int o = Random.Range(0, 100);
                    if (o < 10)
                    {
                        Instantiate(ogre, new Vector2(x, y), Quaternion.identity);
                    }
                    else if (o > 96)
                    {                       
                        Instantiate(chestRed, new Vector2(x, y), Quaternion.identity);
                    }

                    
                }
            }
         }

         for (int x = -21; x <= 21; x = x + 2)
         {
            for (int y = -8; y <= 8; y = y + 2)
            {
                int i = Random.Range(0, 100);
                if (i < 40)
                {
                    Instantiate(lava, new Vector2(x, y), Quaternion.identity);

                }
                
                else
                {
                    Instantiate(cobble, new Vector2(x, y), Quaternion.identity);
                    cobbleCoordinates.Add(new Vector2(x, y));
                    int c = Random.Range(0, 100);
                    if (c < 10)
                    {
                        GameObject theCrystal = Instantiate(crystal, new Vector2(x, y), Quaternion.identity);
                        theCrystal.GetComponent<BoxCollider2D>().isTrigger = true;
                    }
                }

                if (boolPortal)
                {
                    if (i < 2)
                    {
                        Instantiate(portal, new Vector2(x, y), Quaternion.identity);
                    }
                }
            }
         }

         for (int x = -21; x <= 21; x = x + 2)
        {
            for (int y = -9; y <= 9; y = y + 2)
            {
                Instantiate(cobble, new Vector2(x, y), Quaternion.identity);
                cobbleCoordinates.Add(new Vector2(x, y));
                int c = Random.Range(0, 100);
                if (c < 5)
                {
                    GameObject theCrystal = Instantiate(crystal, new Vector2(x, y), Quaternion.identity);
                    theCrystal.GetComponent<BoxCollider2D>().isTrigger = true;
                }
            }
        }

     
    }

    public Vector2 RandomCobble()
    {
        return cobbleCoordinates[Random.Range(0, cobbleCoordinates.Count)];
    }


    // Update is called once per frame
    void Update()
    {

    }
}
