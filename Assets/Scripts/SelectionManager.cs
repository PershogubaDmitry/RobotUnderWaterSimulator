using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public GameObject newPipe, floatingText, victory;
    public Text counter;
    private int i = 1;

    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    private Transform _selection;
    private Canvas cnv;
    private string[] words;
    private int check = 0;
    //private bool ceck1 = false;
    private void Start()
    {
        floatingText.SetActive(false);
        victory.SetActive(false);
        words = counter.text.Split(new char[]{'/'});
        words[1] = words[1].Remove(words[1].Length - 1);
        check = int.Parse(words[1]);
    }
    void Update()
    {

        if(i-1 < check){

        }
        else
        {
            victory.SetActive(true);
        }

        if(_selection != null)
        {
            var selectionRenderer = _selection.GetComponentInChildren<Renderer>();
            selectionRenderer.material = defaultMaterial;
            floatingText.SetActive(false);
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
    
        
        if(Physics.Raycast(ray, out hit, 2f))
        {
            var selection = hit.transform;

            if(selection.CompareTag(selectableTag))
            {
                var selectionRender = selection.GetComponentInChildren<Renderer>();
                if(selectionRender != null)
                {
                    selectionRender.material = highlightMaterial;
                    floatingText.SetActive(true);
                }
                _selection = selection;
                
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Instantiate(newPipe, selection.position, selection.rotation);
                    Destroy(hit.collider.gameObject);
                    floatingText.SetActive(false);

                    counter.text = "Score: " + i.ToString() + "/" + words[1] + ".";
                    i++;
                    
                }
            } 
        }
    }
}
