using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
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
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;
        gameObject.transform.position = new Vector3((x), (y + .05f), 0);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag!="Bullet" && col.gameObject.tag!="Player")
        Destroy(gameObject);

    }
}
