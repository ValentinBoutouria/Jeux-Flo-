using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaisonBat : MonoBehaviour
{
    public Compteur _compteur;
    public Ressources _ressources;
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
        if (_compteur.counterAjoutRessources > 10f)
        {
            _compteur.counterAjoutRessources = 0;
            _ressources._nbWood += _beneficeMaison;
        }
    }
    
}
