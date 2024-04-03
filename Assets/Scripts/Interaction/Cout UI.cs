using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;
public class CoutUI : MonoBehaviour
{
    public AjoutPoint _ajoutPoint;
    public TMP_Text textMeshPro;
    private int _cout;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        _cout = _ajoutPoint.scoreSelect;
        textMeshPro.text = "Coût : " + _cout;

        
    }
}
