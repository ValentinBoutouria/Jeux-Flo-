using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiUnit : MonoBehaviour
{
    public GameObject _uiUnit;
    public GameObject _uiBat;
    public Selection _selection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChoixUI();
        
    }
    void ChoixUI()
    {
        if (_selection.listeGameObjectbatimentSelect.Count != 0)//si on selectionne un batiment
        {
            //on selectionne pas de bat donc on peut acheter un bat et pas d'unit
            _uiBat.SetActive(false);
            _uiUnit.SetActive(true);
            
        }
        else
        {
            //on active l'ui des unit et on desactive l'ui des bat
            _uiBat.SetActive(true);
            _uiUnit.SetActive(false);

        }

    }
}
