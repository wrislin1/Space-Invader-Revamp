using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleControl : MonoBehaviour
{
    public Rigidbody2D body;
    //public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float xp = GameObject.FindWithTag("Player").transform.position.x;
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;
        if(x<xp)
        {
        gameObject.transform.position = new Vector3((x+.02f), (y - .05f), 0);
        }
        else if(x>xp)
        {
            gameObject.transform.position = new Vector3((x-.02f), (y - .05f), 0);
        }

        else
        {
            gameObject.transform.position = new Vector3((x), (y - .05f), 0);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="Player"  || col.gameObject.tag=="Bullet")
        {Destroy(gameObject);}

    }
}
