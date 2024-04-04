using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stone : MonoBehaviour
{
    public int _nbStone;
    public TMP_Text tMP_Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tMP_Text.text="Stone : "+_nbStone;
    }
}
