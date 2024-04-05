using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ferme : MonoBehaviour
{
    public Compteur _compteur;
    public Stone _stone;
    public int _beneficeFerme;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AjoutRessourcesFerme();
        
    }
      public void AjoutRessourcesFerme()
    {
        if (_compteur.counterAjoutFerme < 0f)
        {
            _compteur.counterAjoutFerme = 9;
            _stone._nbStone += _beneficeFerme;
        }
    }
    
}
