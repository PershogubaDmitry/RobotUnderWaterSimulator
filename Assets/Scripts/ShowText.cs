using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    public GameObject UiObject;
    private Renderer mat;
    void Start()
    {
       UiObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Selectable")
        {
            UiObject.SetActive(true);
            mat = other.GetComponentInChildren<Renderer>();
            mat.material = highlightMaterial;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        UiObject.SetActive(false);
        mat.material = defaultMaterial;        
    }
}
