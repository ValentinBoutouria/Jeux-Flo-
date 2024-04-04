using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoFerme : MonoBehaviour
{
  
    public int benefice = 1;
    public int _niveau=1;
    public int _benefparsec;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ModificationBenefice();
        benefParSec();
        
        
    }
    void ModificationBenefice()
    {
        benefice=_niveau*benefice;
    }
  void benefParSec()
    {
        _benefparsec = benefice / 10;
    }


}
