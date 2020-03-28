using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public int interval;
    public ushort fireRate;
    public GameObject missle;
    GameObject player;
    public GameObject mooks;
    bool right, left, isDamaged,notSummoned;
    public ushort health;
    int n, i, k,h;

    // Start is called before the first frame update
    void Start()
    {
        right = true;
        left = false;
        isDamaged = false;
        notSummoned = true;
        n = 0;
        i = 0;
        k = 0;
        h = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!isDamaged)
        {
            target();
            move();
        }
        checkHealth();


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

        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;
        float xp = GameObject.FindWithTag("Player").transform.position.x;
        float yp = GameObject.FindWithTag("Player").transform.position.y;

        if (System.Math.Floor(x) != System.Math.Floor(player.transform.position.x))
        {
            k++;

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
                if(x>xp)
                {
                gameObject.transform.position = new Vector3((x - .025f), (y), 0);
                n++;
                }
                else{
                gameObject.transform.position = new Vector3((x + .025f), (y), 0);
                n++;
                }
            }

            if (k >= 200)
            {
                gameObject.transform.position = new Vector3(xp, gameObject.transform.position.y, 0);
                k = 0;

            }
        }

        else if(n>interval)
        {
            gameObject.transform.position = new Vector3((x), (y - .1f), 0);
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
                right=true;
                left=false;
            }
            else if(gameObject.transform.position.x<0)
            {
                left=true;
                right=false;
            }

           Instantiate(missle, new Vector3((x),(y-1f), 0f), Quaternion.identity);

                  
        }
        
        }
    }

    void checkHealth()
    {
        if(health<=10)
        {
            isDamaged = true;
        }
        if(isDamaged)
        {
            
            summonMooks();
 
            if(right)
            {
                gameObject.transform.position = new Vector3(-18f, gameObject.transform.position.y, 0);
            }
            else if(left)
            {
                gameObject.transform.position = new Vector3(18f, gameObject.transform.position.y, 0);
            }

            h++;
        }

        if(h>=100)
        {
            h = 0;
            health = 20;
            isDamaged = false;
            float xp = GameObject.FindWithTag("Player").transform.position.x;
            gameObject.transform.position = new Vector3(xp, gameObject.transform.position.y, 0);
        }
    }

    void summonMooks()
    {
        float l = 0f;
        if (notSummoned)
        {
            notSummoned = false;
            for (int j = 0; j < 24; j++)
            {
                if (j % 4 == 0)
                {
                    l++;
                }
                Instantiate(mooks, new Vector3(-8f + (j), 5f - l, 0f), Quaternion.identity);
            }
        }
    }
}
