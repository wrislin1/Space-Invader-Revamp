using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    GameObject player;
    public GameObject missle;
    public GameObject Alien;
    int n;
  
    // Start is called before the first frame update
    void Start()
    {
        n=0;
    }

    // Update is called once per frame
    void Update()
    {
        n++;
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;
        player=GameObject.FindWithTag("Player");
        if(player!=null)
        {
        Debug.Log("N: "+n);
        if(System.Math.Floor(x)==System.Math.Floor(player.transform.position.x)&&(n>15))
        {
            n=0;
            Instantiate(missle, new Vector3((x),(y-1f), 0f), Quaternion.identity);
                  
        }
        
        }
    }
}
