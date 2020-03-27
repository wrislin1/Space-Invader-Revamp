using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Control : MonoBehaviour
{
 public int interval;
    public ushort fireRate;
    public GameObject missle;
    GameObject player;
    bool right, left;
    public ushort health;
    int n,i,k;
    // Start is called before the first frame update
    void Start()
    {
        right = true;
        left = false;
        n = 0;
        i=0;
        k = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

       move();
       target();


    }

    void OnCollisionEnter2D(Collision2D col)
    {

         if(col.gameObject.tag=="Bullet" && health>0 )
        {
        health--;
        }

        if(col.gameObject.tag=="Bullet" && health <=0 )
        {
        Destroy(gameObject);
        }

    }

      void move()
    {
        k++;
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;
        float xp = GameObject.FindWithTag("Player").transform.position.x;
        float yp = GameObject.FindWithTag("Player").transform.position.y;

        if (n <= interval)
        {


            if (right)
            {

                if(x<xp)
                {
                gameObject.transform.position = new Vector3((x + .025f), (y), 0);
                n++;
                }
                else{
                gameObject.transform.position = new Vector3((x - .025f), (y), 0);
                n++;
                }
            }
            else if (left)
            {
                if(n>=50)
                {
                    gameObject.transform.position = new Vector3(xp, yp, 0);
                }
                if(x>xp)
                {
                gameObject.transform.position = new Vector3((x + (.025f)), (y), 0);
                n++;
                }
                else{
                gameObject.transform.position = new Vector3((x - (.025f)), (y), 0);
                n++;
                }
            }

                if(k>=100)
                {
                gameObject.transform.position = new Vector3(xp, gameObject.transform.position.y, 0);
                k =0;
                    
                }
        }

        else
        {
            gameObject.transform.position = new Vector3((x), (y - .1f), 0);
            if (right)
            {
                right = false;
                left = true;

            }

            else if (left)
            {
                left = false;
                right = true;
            }
            n = 0;

        }
    }

    void target()
    {
        i++;
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;
        player=GameObject.FindWithTag("Player");
        if(player!=null)
        {

        if(System.Math.Floor(x)==System.Math.Floor(player.transform.position.x)&&(i>fireRate))
        {
        
            i=0;
            if (gameObject.transform.position.x>0)
            {
                right=false;
                left=true;
            }
            else if(gameObject.transform.position.x<0)
            {
                left=false;
                right=true;
            }

           Instantiate(missle, new Vector3((x),(y-1f), 0f), Quaternion.identity);

                  
        }
        
        }
    }
}
