using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaisonBat : MonoBehaviour
{
    public Compteur _compteur;
    public Bois _bois;
    public int _beneficeMaison;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AjoutRessourcesMaison();
        
    }
      public void AjoutRessourcesMaison()
    {
        if (_compteur.counterAjoutMaison < 0f)
        {
            _compteur.counterAjoutMaison = 9;
            _bois._nbBois += _beneficeMaison;
        }
    }
    
}
