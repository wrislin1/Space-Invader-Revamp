using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed;
    public GameObject bullet;
    public ushort health;
    public Text mytext;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mytext.text="Health: "+ health;
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        body.velocity = new Vector2(h * speed, v * speed);
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, new Vector3((x),(y+1), 0f), Quaternion.identity);

        }

  
    }

        void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="Missle")
        {
        health--;
        }
        if(health==0)
        {
        Destroy(gameObject);
        }

    }
}
