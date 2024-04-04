using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Validation : MonoBehaviour
{
    public GameObject _validationUI;
    public Selection _selection;
    public TMP_Text textMeshPro;    
    // Start is called before the first frame update
    void Start()
    {
        
        textMeshPro.text="Bravo vous venez d'acheter "+_selection.nbGameObjectSelect+" Maison";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CliqueValidation()
    {
        _validationUI.SetActive(false);
    }
}
