using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AjoutPoint : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public int scoreSelect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AjoutPointfct()
        {
        textMeshPro.text = "Score : " + scoreSelect;
       // scoreSelect = 0;
        }
}
