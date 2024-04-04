using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bois : MonoBehaviour
{
    public int _nbBois;
    public TMP_Text tMP_Text; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tMP_Text.text="Wood : "+_nbBois;
        
    }
}
