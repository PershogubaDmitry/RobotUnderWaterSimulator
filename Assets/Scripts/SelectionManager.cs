using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public GameObject newPipe, floatingText, victory, lose;
    public Text counter;
    public Text counter2;
    private int i = 1;
    //private int i2 = 0;

    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    private Transform _selection;
    private Canvas cnv;
    private string[] words, words2;
    private int check = 0;
    private int check2 = 0;
    private bool bb = false;
    private void Start()
    {
        floatingText.SetActive(false);
        victory.SetActive(false);
        lose.SetActive(false);
        words = counter.text.Split(new char[]{'/'});
        //Debug.Log(check2);
        check = int.Parse(words[1]);
    }
    void Update()
    {
        words2 = counter2.text.Split(new char[]{' '});
        check2 = int.Parse(words2[1]);
        if(i-1 < check){

        }
        else
        {
            victory.SetActive(true);
            bb = true;
        }

       
        if(check2 <= 0 && bb != true){
            lose.SetActive(true);
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

                    counter.text = "Score: " + i.ToString() + "/" + words[1];
                    i++;
                    
                }
            } 
        }
    }
}
