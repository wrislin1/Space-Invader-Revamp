using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject missle;
    public int interval,FireRate;
    bool right, left;
    int n,i;
    public ushort health;
    public ushort speed;
    // Start is called before the first frame update
    void Start()
    {
        right = true;
        left = false;
        n = 0;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        move();
        fire();

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="Bullet")
        {health--;}
        if(col.gameObject.tag=="Bullet" &&health<=0)
        {
        Destroy(gameObject);
        }

    }

    void move()
    {
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;
        
        if (n <= interval)
        {


            if (right)
            {
                gameObject.transform.position = new Vector3((x + (.05f*speed)), (y), 0);
                n++;
            }
            else if (left)
            {
                gameObject.transform.position = new Vector3((x - (.05f*speed)), (y), 0);
                n++;
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

    void fire()
    {
        GameObject player;
         i++;
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;
        player=GameObject.FindWithTag("Player");
        if(player!=null)
        {

        if(System.Math.Floor(x)==System.Math.Floor(player.transform.position.x)&&(i>FireRate))
        {
            i=0;
            Instantiate(missle, new Vector3((x),(y-1f), 0f), Quaternion.identity);
                  
        }
        
        }
    }
}

