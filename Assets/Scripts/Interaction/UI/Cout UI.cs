using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class CoutUI : MonoBehaviour
{
    public Selection _selection;
    public TMP_Text textMeshPro;
    private int _cout;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        _cout = _selection.nbGameObjectSelect;
        textMeshPro.text = "Co�t : " + _cout;

        
    }
}
