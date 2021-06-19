using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public Light flashlight;
    public bool on = false;
    void Start()
    {
        flashlight.enabled = false;
        on = false;
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(on == false)
            {
                flashlight.enabled = true;
                on = true;
            }
            else
            {
                flashlight.enabled = false;
                on = false;
            }
        }
    }
}
