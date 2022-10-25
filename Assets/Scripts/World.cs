using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class World : MonoBehaviour
{
    public GameObject wall;
    public GameObject grass;
    public GameObject sand;
    public GameObject crystal;
    public GameObject ogre;
    public GameObject door;

    public int antal = 12;
    private int score = 0;
    private Door door1;
    private int targetscore = 12;
    public TMP_Text text;



    // Start is called before the first frame update
    void Start()
    {
        targetscore = 12;
      


        for (int x = -22; x <= 22; x++)
        {
            int y = 10;

            Instantiate(wall, new Vector2(x, y), Quaternion.identity);
            Instantiate(wall, new Vector2(x, -y), Quaternion.identity);

        }

        for (int y = -10; y <= 10; y++)
        {
            int x = -22;

            Instantiate(wall, new Vector2(x, y), Quaternion.identity);
            Instantiate(wall, new Vector2(-x, y), Quaternion.identity);
        }

        for (int x = -21; x <= 21; x++)
        {
            for (int y = -9; y <= 9; y++)
            {                                

                Instantiate(sand, new Vector2(x, y), Quaternion.identity);
                
            }

   
        }
        // lista med koordinater med ogres
        List<Vector3> ogre_position = new List<Vector3>();

        ogre.GetComponent<SpriteRenderer>().sortingOrder = 2;
        for (int i = 0; i < antal; ++i)
        {
            int x = Random.Range(-21, 21);
            int y = Random.Range(-9, 9);

            Instantiate(crystal, new Vector2(x, y), Quaternion.identity);


            Instantiate(ogre, new Vector3(x + 1, y, 0), Quaternion.identity);
            // lägg till koordinat i lista
            ogre_position.Add(new Vector3(x + 1, y, 0));

        }

        for (int x = -21; x <= 21; x++)
        {
            for (int y = -9; y <= 9; y++)
            {
                // om koordinat finns i lista => lägg INTE till
                bool ogreOnPosition = false;
                foreach (Vector3 position in ogre_position)
                {
                    if (position.x == x && position.y == y)
                    {
                        // finns ogre => inget gräs
                        ogreOnPosition = true;
                    }
                }

                if (ogreOnPosition)
                {
                    // inget gräs
                }
                else
                {
                    Instantiate(grass, new Vector2(x, y), Quaternion.identity);
                }
                

            }


        }

        

      
 
    }

   




    // Update is called once per frame
    void Update()
    {
        
    }

   
}
