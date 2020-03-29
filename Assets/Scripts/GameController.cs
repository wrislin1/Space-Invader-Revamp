using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
   public GameObject Boss;
    GameObject temp;
   public GameObject mooks;
   bool wave_1;
    float  m, l;
   
    // Start is called before the first frame update
    void Start()
    {
        m = 0f;
        l = 0f;
        for (int j = 0; j < 24; j++)
        {
            m++;
            if (j % 8 == 0)
            {
                l++;
                m = 1f;
            }
            Instantiate(mooks, new Vector3(-8f + (m * 1.5f), 5f - (l * 1.5f), 0f), Quaternion.identity);
        }

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
