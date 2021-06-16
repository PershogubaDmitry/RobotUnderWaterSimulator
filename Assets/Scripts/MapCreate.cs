using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreate : MonoBehaviour
{
    public GameObject NP, DP;
    GameObject[] arr = new GameObject[2];
    
    void Start()
    { 
        arr[0] = NP;
        arr[1] = DP;

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Instantiate(arr[Random.Range(0,2)], new Vector3(-50 + 30*i + Random.Range(0,20), 1.95f, -50 + 30*j + Random.Range(0,20)), Quaternion.Euler(0f,Random.Range(0,90),0f));
            }
        }
    }
}
