using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
   public GameObject Boss;
   GameObject temp;
   bool wave_1;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        temp=GameObject.FindWithTag("Enemy");
        if(temp==null && !wave_1)
        {
            wave_1 = true;
            Instantiate(Boss, new Vector3(-6f,4f, 0f), Quaternion.identity);

        }
    }
}
