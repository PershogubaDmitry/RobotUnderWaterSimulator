using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MapCreate : MonoBehaviour
{
    public GameObject NP, DP;
    public Text cnt;
    GameObject[] arr = new GameObject[2];
    
    void Start()
    { 
        arr[0] = NP;
        arr[1] = DP;
        var counter = 0;

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                var rnd = Random.Range(0,2);
                if(rnd == 1){counter++;}
                Instantiate(arr[rnd], new Vector3(-50 + 30*i + Random.Range(0,20), 1.95f, -50 + 30*j + Random.Range(0,20)), Quaternion.Euler(0f,Random.Range(0,90),0f));
            }
        }

        
        cnt.text = "Score: " + "0/"+ counter.ToString();
    }
}
