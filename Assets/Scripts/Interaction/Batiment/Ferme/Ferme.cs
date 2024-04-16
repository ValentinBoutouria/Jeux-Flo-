using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ferme : MonoBehaviour
{
    public Compteur _compteur;
    public Ressources _ressources;
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
        if (_compteur.counterAjoutRessources > 10f)
        {
            _compteur.counterAjoutRessources = 0;
            _ressources._nbStone += _beneficeFerme;
        }
    }
    
}
