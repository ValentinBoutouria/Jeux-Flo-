using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gold : MonoBehaviour
{
    public int _nbGold;
    public TMP_Text tMP_Text; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tMP_Text.text="Gold : "+_nbGold;
        
    }
}
