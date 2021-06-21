using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergyControll : MonoBehaviour
{

    public Text charge_lvl;
    public GameObject chargeArea;
    private  Collider triger;
    private float energy = 100;
    private bool check = false;
    private Rigidbody body;
    void Start()
    {   
        triger = chargeArea.GetComponent<Collider>();
    }

    private void minusE(float mult)
    {
        energy = Mathf.Max(0, energy - mult*Time.deltaTime);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("ChargingArea"))
        {
            energy = Mathf.Min(100, energy + 10*Time.deltaTime);
            charge_lvl.text = "Charge: "  + (Mathf.RoundToInt(energy)).ToString();
        }
    }
    void Update()
    {
        float chargeOffset = 0.1f;


        if(Input.GetKeyDown(KeyCode.F))
        {
            check = !check;
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            chargeOffset += 2f;
        }
        
        if(Input.GetKey(KeyCode.Space))
        {
            chargeOffset += 1f;
        }

        if(check)
        {
            chargeOffset += 0.25f;
        }

        minusE(chargeOffset);
        
        if(energy == 0)
        {
            body = gameObject.GetComponent<Rigidbody>();
            body.constraints = RigidbodyConstraints.FreezeAll;
        }
            charge_lvl.text = "Charge: "  + (Mathf.RoundToInt(energy)).ToString();

    }
}
